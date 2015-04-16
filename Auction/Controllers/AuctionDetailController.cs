using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Auction.DAL;
using Auction.Models;

namespace Auction.Controllers
{
    public class AuctionDetailController : Controller
    {
        private AuctionContext db = new AuctionContext();

        // GET: AuctionDetail
        public ActionResult Index()
        {
            return View(db.AuctionDetails.ToList());
        }

        // GET: AuctionDetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuctionDetail auctionDetail = db.AuctionDetails.Find(id);
            if (auctionDetail == null)
            {
                return HttpNotFound();
            }
            return View(auctionDetail);
        }

        // GET: AuctionDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuctionDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Theme,Date,LocationName,LocationAddress,Time1,Time2,Time3,DoorCost,EarlyCost,EarlyTicketDate")] AuctionDetail auctionDetail)
        {
            if (ModelState.IsValid)
            {
                db.AuctionDetails.Add(auctionDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(auctionDetail);
        }

        // GET: AuctionDetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuctionDetail auctionDetail = db.AuctionDetails.Find(id);
            if (auctionDetail == null)
            {
                return HttpNotFound();
            }
            return View(auctionDetail);
        }

        // POST: AuctionDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Theme,Date,LocationName,LocationAddress,Time1,Time2,Time3,DoorCost,EarlyCost,EarlyTicketDate")] AuctionDetail auctionDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auctionDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(auctionDetail);
        }

        // GET: AuctionDetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuctionDetail auctionDetail = db.AuctionDetails.Find(id);
            if (auctionDetail == null)
            {
                return HttpNotFound();
            }
            return View(auctionDetail);
        }

        // POST: AuctionDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AuctionDetail auctionDetail = db.AuctionDetails.Find(id);
            db.AuctionDetails.Remove(auctionDetail);
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
