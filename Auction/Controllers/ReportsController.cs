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



      foreach (var li in db.Items)
        if (li.WinningBidder == IBVM.BidderNumber && li.AuctionType == 1)
        {
          IBVM.LiveItems.Add(li);
          IBVM.LiveTotal += (decimal)li.BidAmount;
        }

      foreach (var si in db.Items)
        if (si.WinningBidder == IBVM.BidderNumber && si.AuctionType == 2)
        {
          IBVM.LiveItems.Add(si);
          IBVM.SilentTotal += (decimal)si.BidAmount;
        }

      foreach (var mi in db.IndividualMultiBidderItems)
        if (mi.Bidder_ID == bidder.BidderNumber)
        {
          IBVM.MultiItems.Add(mi);
          IBVM.MultiTotal += (decimal)mi.BidAmount;
        }

      IBVM.ALLTotal = IBVM.LiveTotal + IBVM.SilentTotal + IBVM.MultiTotal;

      return View(IBVM);
    }




    //All Donors *************************************************************************************




    //Individual Donors ******************************************************************************









  }
}