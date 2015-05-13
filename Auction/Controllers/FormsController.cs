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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddWinningBidsSilent([Bind(Include = "ID,AuctionType,Title,Description,WinningBidder,BidAmount")]Item item)
        {
            if (ModelState.IsValid)
            {
                // check for a valid bidder Number

                //foreach (var b in db.Bidders)


                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AddWinningBidsSilent", "Forms");
            }

            return View(item);
        }


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
    
        //POST *********************************************************************************************************
        

// Edit Silent Auction Items **************************************************************************************************
        // GET ****************************************************************************************************
        public ActionResult EditSilentItem(int? id)
        {
            string sess = (string)System.Web.HttpContext.Current.Session["blah"];
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST ****************************************************************************************************
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSilentItem([Bind(Include = "ID,Title,Description,ImageURL,AuctionType,WinningBidder,BidAmount")] Item item)
        {
            if (ModelState.IsValid)
           { 
                // check for a valid bidder Number
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AddWinningBidsSilent", "Forms");
            }

            return View(item);
        }

    }//end class
}//end Namespace