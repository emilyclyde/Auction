using Auction.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auction.Models;

namespace Auction.Controllers
{
    

    public class FormsController : Controller
    {
        private AuctionContext db = new AuctionContext();

//index **************************************************************************************************
        public ActionResult Index()
        {
            return View();
        }


// Add Winning Silent Auction Bids *************************************************************************************
       //GET ***********************************************************************************************************
        public ActionResult AddWinningBidsSilent()
        {
            var SilentItems = new List<Item>();
 
            foreach(var i in db.Items)
            {
                if(i.AuctionType==2)
                    SilentItems.Add(i);
            }

            return View(SilentItems);
        }
        
        //POST *********************************************************************************************************




// Add Winning Live Auction Bids *************************************************************************************
        public ActionResult AddWinningBidsLive()
        {
            var LiveItems = new List<Item>();

            foreach (var i in db.Items)
            {
                if (i.AuctionType == 1)
                    LiveItems.Add(i);
            }

            return View(LiveItems);
        }




    }//end class
}//end Namespace