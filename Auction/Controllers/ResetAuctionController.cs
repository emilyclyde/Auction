using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auction.Models;

namespace Auction.Controllers
{
  //[Authorize(Users = "logosauction@outlook.com")]
  public class ResetAuctionController : Controller
  {
    private Auction.DAL.AuctionContext db = new Auction.DAL.AuctionContext();


    //***************************************************************************************************************
    public ActionResult Index()
    {
      return View();
    }
    //DELETE*********************************************************************************************************

    // GET *********************************************************************************************************
    public ActionResult Delete()
    {
      return View();
    }

    // POST *******************************************************************************************************
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed()
    {
      // auction detail
      foreach (var d in db.AuctionDetails)
      {
        d.Theme = "Theme here";
        d.Date = "Auction Date here";
        d.LocationName = "Location here";
        d.LocationAddress = "Location Address here";
        d.Time1 = "time 1 here";
        d.Time2 = "time 2 here";
        d.Time3 = "time 2 here";
        d.DoorCost = "regular price here";
        d.EarlyCost = "discount price here";
        d.EarlyTicketDate = "discount deadline here";
      }

      //Bidders
      foreach (var b in db.Bidders)
        db.Bidders.Remove(b);

      //Contact 
      foreach (var c in db.Contacts)
      {
        c.Name = "Contact's name here";
        c.Email = "Contact's email here";
        c.PhoneNumber = "Contact's phone number here";
      }

      //Donor
      foreach (var d in db.Donors)
        db.Donors.Remove(d);

      //IndividualMultiBidderItems
      foreach (var i in db.IndividualMultiBidderItems)
        db.IndividualMultiBidderItems.Remove(i);

      //Auction Items
      foreach (var i in db.Items)
      {

        //*** we need to  remove images from the folder
        var photoName = "";
        photoName = i.ImageURL;
        string fullPath = Request.MapPath("~/Images/Items/"
        + photoName);

        if (System.IO.File.Exists(fullPath))
          System.IO.File.Delete(fullPath);
        
        db.Items.Remove(i);
      }

      //MultiBidderItems
      foreach (var m in db.MultipleBidderItems)
        db.MultipleBidderItems.Remove(m);

      //Individual Multiple Bidder Item
      foreach (var m in db.IndividualMultiBidderItems)
        db.IndividualMultiBidderItems.Remove(m);

      //Tickets
      foreach (var t in db.Tickets)
        db.Tickets.Remove(t);


      db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }
  }
}