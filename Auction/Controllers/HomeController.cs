using Auction.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auction.Controllers
{
    public class HomeController : Controller
    {
        //private AuctionContext db = new AuctionContext();

        public ActionResult Index()
        {
            HomeVM contents = new HomeVM();

            contents.Theme = "Polynesian Paradise";
            contents.Date = "May 23, 2015";
            contents.LocationName = "Emanuel Baptist Church";
            contents.LocationAddress="3050 Game Farm Rd Springfield, OR";
            contents.Time1 = "Doors open at 5:30";
            contents.Time2 = "Buffet Dinner at 6:30";
            contents.Time2 = "Live Auction at 7:00";
            contents.DoorCost = "$20.00";
            contents.EarlyCost = "$15.00";
            contents.EarlyTicketDate = "May 15";
            contents.Name = "Debra Norland";
            contents.Email = "logosacademymusic@gmail.com";
            contents.PhoneNumber = "(541)747-0702";

            return View(contents);
        }

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