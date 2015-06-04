using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Auction.Models;
using Auction.DAL;

namespace Auction.Controllers
{
    public class BidderController : Controller
    {
      // private ApplicationDbContext db = new ApplicationDbContext();
      
      //using LocalDB connection string and initializer for now
       private AuctionContext db = new AuctionContext();



//Index *************************************************************************************************************
        // GET: Bidder
        public ActionResult Index()
        {
            return View(db.Bidders.ToList());
        }

//Details ************************************************************************************************************
        // GET: Bidder/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bidder bidder = db.Bidders.Find(id);
            if (bidder == null)
            {
                return HttpNotFound();
            }
            return View(bidder);
        }

//Create *************************************************************************************************************
        // GET *******************************************************************************************************
        public ActionResult Create()
        {
            return View();
        }

        // POST ******************************************************************************************************
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BidderName,BidderNumber,BidderContact1,BidderContact2,BidderContact3 ")] Bidder bidder)
        {
           
            //int newID = 0;
            int HighestNum = 99;
            bidder.BidderNumber = 99;
            if (ModelState.IsValid)
            {
                //foreach(var b in db.Bidders )   //determines what the next auto generated Id is going to be
                //    if (b.ID > newID)
                //        newID = b.ID;

            foreach(var b in db.Bidders )
            {
                if (b.BidderNumber > HighestNum)
                    HighestNum = b.BidderNumber;
            }
                bidder.BidderNumber = HighestNum + 1;


                foreach (var mi in db.MultipleBidderItems)
                {
                    var IMBI = new IndividualMultiBidderItem();
                    IMBI.Title = mi.Title;
                    IMBI.Bidder_ID = bidder.BidderNumber;
                    db.IndividualMultiBidderItems.Add(IMBI);
                }
                db.Bidders.Add(bidder);
                db.SaveChanges();

                return RedirectToAction("NewBidder", bidder);
            }
            //return RedirectToAction("Index");
          return View(bidder);
        }
//Edit ****************************************************************************************************************
        // GET*********************************************************************************************************
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bidder bidder = db.Bidders.Find(id);
            if (bidder == null)
            {
                return HttpNotFound();
            }
            return View(bidder);
        }

        // POST********************************************************************************************************
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BidderName,BidderNumber,BidderContact")] Bidder bidder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bidder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bidder);
        }


//Delete ***************************************************************************************************************
        // GET *********************************************************************************************************
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bidder bidder = db.Bidders.Find(id);
            if (bidder == null)
            {
                return HttpNotFound();
            }
            return View(bidder);
        }

        // POST *******************************************************************************************************
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            foreach (var i in db.IndividualMultiBidderItems)            //remove the all individualMultiBidderItems associated with this bidder ID  for ref integrety 
            {
                if (i.Bidder_ID == id)
                {
                    db.IndividualMultiBidderItems.Remove(i);
                }
            }

            Bidder bidder = db.Bidders.Find(id);
            db.Bidders.Remove(bidder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
//NewBidder *************************************************************************************************************
        public ActionResult NewBidder( Bidder bidder)
        {

            if (bidder.ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            if (bidder == null)
            {
                return HttpNotFound();
            }
            return View(bidder);
        }


// Dispose **************************************************************************************************************
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
