using Auction.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auction.Models;
using Auction.ViewModels;

namespace Auction.Controllers
{
  //[Authorize(Users = "logosauction@outlook.com")] 
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

            foreach (var i in db.Items)
            {
                if (i.AuctionType == 2)
                    SilentItems.Add(i);
            }

            return View(SilentItems);
        }

        //POST *********************************************************************************************************
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddWinningBidsSilent([Bind(Include = "ID, ItemNumber, AuctionType,Title,Description,WinningBidder,BidAmount")]Item item)
        {
            if (ModelState.IsValid)
            {
                if (item.BidAmount == 0)
                    item.BidAmount = null;
                if (item.WinningBidder < 100)
                    item.WinningBidder = null;

                if (IsValidBidder(item)|| item.WinningBidder==null)
                {
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddWinningBidsLive([Bind(Include = "ID, ItemNumber, AuctionType,Title,Description,WinningBidder,BidAmount")]Item item)
        {
            if (ModelState.IsValid)
            {
                if (IsValidBidder(item))
                {
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("AddWinningBidsLive", "Forms");
            }

            return View(item);
        }



        //Add Multiple Bidder Item Bids List *******************************************************************************************

        public ActionResult AddMultiItemsList()
        {
            return View(db.MultipleBidderItems.ToList());
        }


        //Add Multiple Bidder Item Bids *************************************************************************************************
        //GET************************************************************************
        public ActionResult AddMultiItemBids(String Title)
        {
           List<IndividualMultiBidderItem> IMBIList = new List<IndividualMultiBidderItem>();
            foreach (var i in db.IndividualMultiBidderItems)
                    if (i.Title == Title)
                        IMBIList.Add(i);
            var MyList = new MultiBidderItemVM();
            MyList.Title = Title;
            MyList.IMBIList = IMBIList;
            return View(MyList);
        }
        //POST ***************************************************************************************************************************
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMultiItemBids([Bind(Include = "ID,Title,Bidder_ID,BidAmount")]IndividualMultiBidderItem item)
        {
            if (ModelState.IsValid)
            {
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("AddMultiItemBids", "Forms", new { item.Title });
            }

            return View(item.Title);
        }









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
                if (item.BidAmount == 0 || item.BidAmount == null || !IsValidBidder(item))
                {
                    item.BidAmount = null;
                    item.WinningBidder = null;
                }


                if (IsValidBidder(item) || item.WinningBidder == null)
                {
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("AddWinningBidsSilent", "Forms");
            }

            return View(item);
        }
        // Edit Live Auction Items **************************************************************************************************
        // GET ****************************************************************************************************
        public ActionResult EditLiveItem(int? id)
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
        public ActionResult EditLiveItem([Bind(Include = "ID,Title,Description,ImageURL,AuctionType,WinningBidder,BidAmount")] Item item)
        {
            if (ModelState.IsValid)
            {
                if (item.BidAmount == 0 || item.BidAmount == null ||!IsValidBidder(item))
                {
                    item.BidAmount = null;
                    item.WinningBidder = null;
                }
                

                if (IsValidBidder(item)|| item.WinningBidder==null)
                {
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("AddWinningBidsLive", "Forms");
            }

            return View(item);
        }

        // Edit Individual Multiple Bidder Items **************************************************************************************************
        // GET ****************************************************************************************************
        public ActionResult EditIndividualMultiBidderItem(int? id)
        {
            string sess = (string)System.Web.HttpContext.Current.Session["blah"];
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            IndividualMultiBidderItem item = db.IndividualMultiBidderItems.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST ****************************************************************************************************

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditIndividualMultiBidderItem([Bind(Include = "ID,Title,Bidder_ID,BidAmount")] IndividualMultiBidderItem item)
        {
            if (ModelState.IsValid)
            {
                if (item.BidAmount == 0)
                    item.BidAmount = null;

                if (IsValidBidder(item))
                {
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("AddMultiItemBids", "Forms", new { item.Title });
            }

            return View(item);
        }



        //Check for a valid bidder Number w/Item**********************************************************************************

        public bool IsValidBidder(Item item)
        {
            foreach (var b in db.Bidders)
                if (b.BidderNumber == item.WinningBidder)
                    return true;

            return false;
        }
        //Check for a valid abidder Number w/IndividualMultipleBidderItem**********************************************************************************
        public bool IsValidBidder(IndividualMultiBidderItem item)
        {
            foreach (var b in db.Bidders)
                if (b.BidderNumber == item.Bidder_ID)
                    return true;

            return false;
        }



    }//end class
}//end Namespace