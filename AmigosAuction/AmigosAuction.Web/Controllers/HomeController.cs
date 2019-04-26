using AmigosAuction.Entities;
using AmigosAuction.Services;
using AmigosAuction.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AmigosAuction.Web.Controllers
{
    public class HomeController : Controller
    {
        AuctionsService service = new AuctionsService();
        CategoriesService categoriesService = new CategoriesService();

        public ActionResult Index()
        {
            AuctionsViewModel model = new AuctionsViewModel();
            //var allAuctions = service.GetAuctions();
            model.AllAuctions = service.GetAuctions();
            model.FeaturedAuctions = service.GetFeaturedAuctions();
            model.Categories = categoriesService.GetCategories();
            model.Title = "Home";
            return View(model);
        }

        public ActionResult Error()
        {
            return PartialView();
        }

        public ActionResult SortedAuctions(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category cat = categoriesService.GetCategoryByID(id);
            AuctionsViewModel model = new AuctionsViewModel();
            if (cat == null)
            {
                return RedirectToAction("Error");
            }
            model.AllAuctions = cat.Auctions;
            model.Title = cat.Name;
            return View(model);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}