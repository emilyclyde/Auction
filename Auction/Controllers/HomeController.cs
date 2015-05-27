using Auction.DAL;
using Auction.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auction.Models;


namespace Auction.Controllers
{
  public class HomeController : Controller
  {
    private AuctionContext db = new AuctionContext();


    //**Index Home page********************************************************************************

    public ActionResult Index()
    {

      HomeVM contents = new HomeVM();

      foreach (var d in db.AuctionDetails)
      {
        contents.Theme = d.Theme;
        contents.Date = d.Date;
        contents.LocationName = d.LocationName;
        contents.LocationAddress = d.LocationAddress;
        contents.Time1 = d.Time1;
        contents.Time2 = d.Time2;
        contents.Time3 = d.Time3;
        contents.DoorCost = d.DoorCost;
        contents.EarlyCost = d.EarlyCost;
        contents.EarlyTicketDate = d.EarlyTicketDate;
      }

      foreach (var c in db.Contacts)
      {
        contents.Name = c.Name;
        contents.Email = c.Email;
        contents.PhoneNumber = c.PhoneNumber;

      }
      return View(contents);
    }


    //**List Page************************************************************************************

    public ActionResult List()
    {
      //temporary hardcoded Data used untill the DB context is created
      ListVM list = new ListVM();
      DateTime date = new DateTime();
      List<Item> items = new List<Item>();

      date = DateTime.Now;

      foreach (var c in db.Contacts)             // gets and sets contact info
      {
        list.Name = c.Name;
        list.Email = c.Email;
        list.PhoneNumber = c.PhoneNumber;
      }

      list.CurrentDate = String.Format("{0:D}", date);    //sets the current date


      foreach (var i in db.Items)                //gets all Items that are Auction type 1(Live)
      {
        if (i.AuctionType == 1)
          items.Add(i);
      }

      list.ItemList = items;

      return View(list);
    }
    //**Detail Page********************************************************************************
    public ActionResult Detail(int? id)
    {
      if (id == null)     // if no id was passed
      {
        return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
      }
      Item item = db.Items.Find(id);
      if (item == null)
      {
        return HttpNotFound();
      }

      ItemDetailVM thisItem = new ItemDetailVM();

      foreach (var c in db.Contacts)             // gets and sets contact info
      {
        thisItem.Name = c.Name;
        thisItem.Email = c.Email;
        thisItem.PhoneNumber = c.PhoneNumber;
      }

      thisItem.Title = item.Title;
      thisItem.Description = item.Description;
      thisItem.ImageURL = item.ImageURL;

      return View(thisItem);
    }



    //**About Page********************************************************************************
    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }


    //**Contact Page********************************************************************************
    public ActionResult Contact()
    {
      //Commenting out for now since and I want it to run, VM is not created yet correct?! 
      //Go ahead and uncomment Rob when you get back here! :) Emily
         ContactVM cvm = new ContactVM();
      foreach(var c in db.Contacts)
      {
         cvm.Name = c.Name;
         cvm.Email = c.Email;
         cvm.PhoneNumber=c.PhoneNumber;
      }

       return View(cvm);

      
    }


  }
}