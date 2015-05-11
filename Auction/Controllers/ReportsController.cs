using Auction.DAL;
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
        public ActionResult IndividualBidder()
        {
            return View();
        }



//All Donors *************************************************************************************




//Individual Donors ******************************************************************************









    }
}