using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auction.Controllers
{
    public class FormsController : Controller
    {
        // GET: Forms
        public ActionResult Index()
        {
            return View();
        }


// Add Winning Bids *************************************************************************************
        public ActionResult AddWinningBids()
        {
            return View();
        }
    }
}