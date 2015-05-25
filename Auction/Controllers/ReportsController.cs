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


        // Auction Totals *******************************************************************************
        public ActionResult AuctionTotals()
        {
            AuctionTotalsVM totals = new AuctionTotalsVM();
            decimal? lTotal =0;
            decimal? sTotal =0;
            int lCount = 0;
            int sCount = 0;
            List<Bidder> bidderList = db.Bidders.ToList();
            MultiBidderItemTotal mbit;
            List<IndividualMultiBidderItem> imbiList = db.IndividualMultiBidderItems.ToList();
            List<MultiBidderItemTotal> mbitList = new List<MultiBidderItemTotal>();

            // Count Bidders
            totals.BidderCount = bidderList.Count;


            //determine live auction items Total 
            foreach (var i in db.Items)
                if (i.AuctionType == 1 && i.BidAmount != null)
                {
                    lTotal += i.BidAmount;
                    lCount++;
                }
            totals.LiveTotal = (decimal)lTotal;
            totals.LiveCount = lCount;


            // determine Silent auction Item Total
            foreach (var i in db.Items)
                if (i.AuctionType == 2 && i.BidAmount != null)
                {
                    sTotal += i.BidAmount;
                    sCount++;
                }
            totals.SilentTotal = (decimal)sTotal;
            totals.SilentCount = sCount;


            // determine each multi bidder item total
            foreach (var mbi in db.MultipleBidderItems)                     //Loop through each type of multi bidder item
            {
                mbit = new MultiBidderItemTotal();                          //create a new object for the view model list
                mbit.Title = mbi.Title;
                foreach (var imbi in imbiList)                              //loop through all Individual Multibidder items
                {
                    if (mbi.Title == imbi.Title)                            //check for a matching type of multi bidder item
                        mbit.Total += imbi.BidAmount;                       // increment the total
                }
                mbitList.Add(mbit);                                         //add the total object to the mbit List
            }

            totals.MultiTotals = mbitList ;                                 // add the mbit List to the VM



            // determine total for early tickets sales
            foreach (var t in db.Tickets)
            {
                totals.EarlyTicketsTotal = t.NumEarlyTickets * t.CostEarlyTickets;
                totals.EarlyTicketCount = t.NumEarlyTickets;
            }

            // determine total for tickets sales at the door
            foreach (var t in db.Tickets)
            {
                totals.DoorTicketsTotal = t.NumDoorTickets * t.CostDoorTickets;
                totals.DoorTicketCount = t.NumDoorTickets;
            }

            //Auction Total
            totals.AuctionTotal = totals.EarlyTicketsTotal +
                                   totals.DoorTicketsTotal +
                                   totals.LiveTotal +
                                   totals.SilentTotal;
                foreach (var i in totals.MultiTotals)    // get totals from Multi bidder items
                    totals.AuctionTotal += i.Total;
                
            
            //get Date and Theme
                foreach (var d in db.AuctionDetails)
                {
                    totals.Date = d.Date;
                    totals.Theme = d.Theme;
                }

            return View(totals);
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