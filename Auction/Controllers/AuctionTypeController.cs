using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Auction.Models;

namespace Auction.Controllers
{
    public class AuctionTypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AuctionType
        public ActionResult Index()
        {
            return View(db.AuctionTypes.ToList());
        }

        // GET: AuctionType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuctionType auctionType = db.AuctionTypes.Find(id);
            if (auctionType == null)
            {
                return HttpNotFound();
            }
            return View(auctionType);
        }

        // GET: AuctionType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuctionType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] AuctionType auctionType)
        {
            if (ModelState.IsValid)
            {
                db.AuctionTypes.Add(auctionType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(auctionType);
        }

        // GET: AuctionType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuctionType auctionType = db.AuctionTypes.Find(id);
            if (auctionType == null)
            {
                return HttpNotFound();
            }
            return View(auctionType);
        }

        // POST: AuctionType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] AuctionType auctionType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auctionType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(auctionType);
        }

        // GET: AuctionType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuctionType auctionType = db.AuctionTypes.Find(id);
            if (auctionType == null)
            {
                return HttpNotFound();
            }
            return View(auctionType);
        }

        // POST: AuctionType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AuctionType auctionType = db.AuctionTypes.Find(id);
            db.AuctionTypes.Remove(auctionType);
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
