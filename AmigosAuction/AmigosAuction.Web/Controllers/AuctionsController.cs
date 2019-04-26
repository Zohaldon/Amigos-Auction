using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AmigosAuction.Data;
using AmigosAuction.Entities;
using AmigosAuction.Services;
using AmigosAuction.Web.ViewModels;

namespace AmigosAuction.Web.Controllers
{
    public class AuctionsController : Controller
    {
        private AmigosAuctionContext db = new AmigosAuctionContext();

        // GET: Auctions
        public ActionResult Index()
        {
            var auctions = db.Auctions.Include(a => a.Category);
            return View(auctions.ToList());
        }


        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AuctionsService auctionService = new AuctionsService();
            SharedService sharedService = new SharedService();
            AuctionDetailsViewModel model = new AuctionDetailsViewModel();
            model.Auction = auctionService.GetAuctionByID(id);
            model.BidsAmount = model.Auction.InitialPrice + model.Auction.Bids.Sum(x => x.BiddingRate);
            var latestbidder = model.Auction.Bids.OrderByDescending(x => x.TimeStamp).FirstOrDefault();
            model.LatestBidder = latestbidder != null ? latestbidder.User : null;
            model.EntityID = (int)EntityEnums.Auction;
            model.Comments = sharedService.GetComments((int)EntityEnums.Auction, model.Auction.ID);
            if (model == null)
            {
                return RedirectToAction("Error","Home");
            }
            try
            {
                Auction auction = new Auction();
                auction = model.Auction;
                auction.InitialPrice = model.Auction.InitialPrice + model.Auction.Bids.Sum(x => x.BiddingRate);
                db.Entry(auction).State = EntityState.Modified;
                db.SaveChanges();

            }
            catch {
            }
            return View(model);
        }

        // GET: Auctions/Details/5
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auction auction = db.Auctions.Find(id);
            if (auction == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(auction);
        }

        // GET: Auctions/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        // POST: Auctions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Description,InitialPrice,AuctionStartTime,AuctionEndTime,CategoryID,AuctionPicture")] Auction auction)
        {
            if (ModelState.IsValid)
            {
                db.Auctions.Add(auction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", auction.CategoryID);
            return View(auction);
        }

        // GET: Auctions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auction auction = db.Auctions.Find(id);
            if (auction == null)
            {
                return RedirectToAction("Error", "Home");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", auction.CategoryID);
            return View(auction);
        }

        // POST: Auctions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description,InitialPrice,AuctionStartTime,AuctionEndTime,CategoryID,AuctionPicture")] Auction auction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", auction.CategoryID);
            return View(auction);
        }

        // GET: Auctions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auction auction = db.Auctions.Find(id);
            if (auction == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(auction);
        }

        // POST: Auctions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auction auction = db.Auctions.Find(id);
            db.Auctions.Remove(auction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
