using Auction.DAL;
using Auction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auction.Controllers
{
    public class ReportsController : Controller
    {
        private AuctionContext db = new AuctionContext();

// Index *****************************************************************************************
        public ActionResult Index()
        {
            return View();
        }


// AllBidders  ***********************************************************************************
        public ActionResult AllBidders()
        {
            return View(db.Bidders.ToList());
        }



//Individual Bidders *****************************************************************************
        public ActionResult IndividualBidder(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Bidder bidder = db.Bidders.Find(id);
            if (bidder == null)
            {
                return HttpNotFound();
            }
            return View(bidder);
        }
       



//All Donors *************************************************************************************




//Individual Donors ******************************************************************************









    }
}