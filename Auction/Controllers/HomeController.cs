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

    /* public ActionResult List()
     {
         //temporary hardcoded Data used untill the DB context is created
         ListVM list = new ListVM();
         DateTime date = new DateTime();
         List<string> items = new List<string>(); 
 
         date = DateTime.Now;

         list.Name = "Debra Norland";
         list.Email = "logosacademymusic@gmail.com";
         list.PhoneNumber = "(541)747-0702";
         list.CurrentDate = date.ToString("d");

         items.Add("Sun River 5 Night Getaway");
         items.Add("Mckenzie River Rafting Adventure");
         items.Add("NewPort Deep Sea Fishing Excursion");
         items.Add("Hoodoo Ski Weekend");
         items.Add("24 Karat Diamond Necklace");
         items.Add("Cedar Patio Furniture Set");

         list.ItemList = items;

         return View(list);

     }*/
    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }


  }
}