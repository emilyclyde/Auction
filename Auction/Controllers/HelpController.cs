using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auction.Controllers
{
  //[Authorize(Users = "admin@test.com, admin1@auction.com, admin2@auction.com, admin3@auction.com")] //user: "" password: Pass_1234
    public class HelpController : Controller
    {
        // GET: Help
        public ActionResult Index()
        {
            return View();
        }
    }
}