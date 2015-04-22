﻿using System;
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
        public ActionResult Create([Bind(Include = "ID,BidderName,BidderNumber, BidderContact")] Bidder bidder)
        {
            if (ModelState.IsValid)
            {
                db.Bidders.Add(bidder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
        public ActionResult Edit([Bind(Include = "ID,BidderName,BidderNumber")] Bidder bidder)
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
            Bidder bidder = db.Bidders.Find(id);
            db.Bidders.Remove(bidder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
