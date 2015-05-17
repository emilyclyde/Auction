using Auction.DAL;
using Auction.Models;
using Auction.ViewModels;
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


        //Individual Bidder Selection List **************************************************************
        public ActionResult IndividualBidderSelectList()
        {
            return View(db.Bidders.ToList());
        }



        //Individual Bidder *****************************************************************************
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
            IndividualBidderVM IBVM = new IndividualBidderVM();

            IBVM.BidderName = bidder.BidderName;
            IBVM.BidderNumber = bidder.BidderNumber;
            IBVM.BidderContact1 = bidder.BidderContact1;
            IBVM.BidderContact2 = bidder.BidderContact2;
            IBVM.BidderContact3 = bidder.BidderContact3;

            IBVM.LiveItems = null;           //clears the list
            IBVM.LiveTotal = 0;
            IBVM.SilentTotal = 0;
            IBVM.MultiTotal = 0;

            //Live Item List
            List<Item> liveItemList = new List<Item>();
            foreach (var li in db.Items)
                if (li.WinningBidder == IBVM.BidderNumber && li.AuctionType == 1)
                {
                    liveItemList.Add(li);
                    IBVM.LiveTotal += (decimal)li.BidAmount;
                }
            IBVM.LiveItems = liveItemList;


            //Silent Item List
            List<Item> silentItemList = new List<Item>();
            foreach (var li in db.Items)
                if (li.WinningBidder == IBVM.BidderNumber && li.AuctionType == 2)
                {
                    silentItemList.Add(li);
                    IBVM.SilentTotal += (decimal)li.BidAmount;
                }
            IBVM.SilentItems = silentItemList;


            //Multi-Bidder Items List
            List<IndividualMultiBidderItem> multiItemList = new List<IndividualMultiBidderItem>();
            foreach (var mi in db.IndividualMultiBidderItems)
                if (mi.Bidder_ID == IBVM.BidderNumber)
                {
                    multiItemList.Add(mi);
                    IBVM.MultiTotal += (decimal)mi.BidAmount;
                }
            IBVM.MultiItems = multiItemList;

           
            IBVM.ALLTotal = IBVM.LiveTotal + IBVM.SilentTotal + IBVM.MultiTotal;

            return View(IBVM);
        }




        //All Donors *************************************************************************************
        public ActionResult AllDonors()
        {
            return View(db.Donors.ToList());
        }



        //All Silent Items ******************************************************************************
        public ActionResult AllSilentItems()
        {
            return View(db.Items.ToList());
        }


        //All Live Items ********************************************************************************
        public ActionResult AllLiveItems()
        {
            return View(db.Items.ToList());
        }









        //*******************************************************************************************************************************************************************
        //*******************************************************************************************************************************************************************
        // GET: Bidder
        //public ActionResult Index()
        //{
        //    return View(db.Bidders.ToList());
        //}

        //Details ************************************************************************************************************
        // GET: Bidder/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Bidder bidder = db.Bidders.Find(id);
        //    if (bidder == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(bidder);
        //}





    }
}