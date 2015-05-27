using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Auction.Models;
using Auction.DAL;

namespace Auction.Controllers
{
  [Authorize(Users = "admin@test.com, admin1@auction.com, admin2@auction.com, admin3@auction.com")] //user: "" password: Pass_1234
    public class ItemController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        //using LocalDB connection string and initializer for now
        private AuctionContext db = new AuctionContext();


//Index **********************************************************************************************************
        public ActionResult Index()
        {
            return View(db.Items.ToList());
        }

//Details ********************************************************************************************************
        // GET: Item/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }


//Create *********************************************************************************************************
        // GET****************************************************************************************************
        public ActionResult Create()
        {
            return View();
        }

        // POST:**************************************************************************************************
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "ID,Title,Description,ImageURL,AuctionType,WinningBidder,BidAmount")] Item item,
            string image,
        HttpPostedFileBase photo)
        {
            string path = HttpContext.Server.MapPath("~/Images/Items/" + image);
           
            path = path.Replace(" ", "");
            path.Trim();

            if (photo != null)
                photo.SaveAs(path);

            // orriginal code
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(item);
        }


//EDIT ************************************************************************************************************
        // GET ****************************************************************************************************
        public ActionResult Edit(int? id)
        {
            string sess = (string)System.Web.HttpContext.Current.Session["blah"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST ****************************************************************************************************
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description,ImageURL,AuctionType,WinningBidder,BidAmount")] Item item
            , string image,
        HttpPostedFileBase photo)
        {
            bool bidderIsError = true;    //Flag to check for a valid bidder

            string path = HttpContext.Server.MapPath("~/Images/Items/" + image);
            
            if (photo != null)
                photo.SaveAs(path);
            // orriginal code
            if (ModelState.IsValid)
            {
                foreach (var b in db.Bidders)
                    if (b.BidderNumber == item.WinningBidder)
                       bidderIsError = false;

                if (bidderIsError)
                    item.WinningBidder = -1;

                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(item);
        }


//Delete *****************************************************************************************************************************
        // GET ***********************************************************************************************************************
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST ************************************************************************************************************************
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string photoFileName)
        {
            Item item = db.Items.Find(id);




            var photoName = "";
            photoName = item.ImageURL;
            string fullPath = Request.MapPath("~/Images/Items/"
            + photoName);

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);

            }



            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }






        //Image upload and delete code
        //Do not delete
        //
        //
        //
        [HttpPost]
        public ActionResult DeletePhoto(string photoFileName)
        {
            var photoName = "";
            photoName = photoFileName;
            string fullPath = Request.MapPath("~/Images/Items/"
            + photoName);

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);

            } return RedirectToAction("Index");
        }
        //
        //
        //
        //Do not delete
        //Image upload and delete code



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}