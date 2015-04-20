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
    public class MultipleBidderItemController : Controller
    {
        private AuctionContext db = new AuctionContext();

        // GET: MultipleBidderItem
        public ActionResult Index()
        {
            return View(db.MultipleBidderItems.ToList());
        }

        // GET: MultipleBidderItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultipleBidderItem multipleBidderItem = db.MultipleBidderItems.Find(id);
            if (multipleBidderItem == null)
            {
                return HttpNotFound();
            }
            return View(multipleBidderItem);
        }

        // GET: MultipleBidderItem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MultipleBidderItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title")] MultipleBidderItem multipleBidderItem)
        {
            if (ModelState.IsValid)
            {
                db.MultipleBidderItems.Add(multipleBidderItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(multipleBidderItem);
        }

        // GET: MultipleBidderItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultipleBidderItem multipleBidderItem = db.MultipleBidderItems.Find(id);
            if (multipleBidderItem == null)
            {
                return HttpNotFound();
            }
            return View(multipleBidderItem);
        }

        // POST: MultipleBidderItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title")] MultipleBidderItem multipleBidderItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(multipleBidderItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(multipleBidderItem);
        }

        // GET: MultipleBidderItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultipleBidderItem multipleBidderItem = db.MultipleBidderItems.Find(id);
            if (multipleBidderItem == null)
            {
                return HttpNotFound();
            }
            return View(multipleBidderItem);
        }

        // POST: MultipleBidderItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MultipleBidderItem multipleBidderItem = db.MultipleBidderItems.Find(id);
            db.MultipleBidderItems.Remove(multipleBidderItem);
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
