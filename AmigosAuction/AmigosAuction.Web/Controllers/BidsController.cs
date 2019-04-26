using AmigosAuction.Entities;
using AmigosAuction.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmigosAuction.Web.Controllers
{
    [Authorize]
    public class BidsController : Controller
    {
        BidsServices services = new BidsServices();

        [HttpPost]
        public JsonResult Bid(int ID)
        {
            JsonResult result = new JsonResult();
            if (User.Identity.IsAuthenticated)
            {

                Bid bid = new Bid();

                bid.AuctionId = ID;
                bid.UserId = User.Identity.GetUserId();
                bid.TimeStamp = DateTime.Now;
                bid.BiddingRate = 10;

                var bidresult = services.AddBid(bid);
                if (bidresult)
                {
                    result.Data = new
                    {
                        Success = true
                    };
                }
                else
                {
                    result.Data = new
                    {
                        Success = false,
                        Message = "Unable to bid for given Auction :("
                    };
                }
            }
            else
            {
                result.Data = new { Success = false, Message = "User needs to login in order to bid" };
            }
            return result;
        }
    }
}