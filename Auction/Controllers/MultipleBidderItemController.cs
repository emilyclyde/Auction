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

    // Index *****************************************************************************************************************
    public ActionResult Index()
    {
      return View(db.MultipleBidderItems.ToList());
    }


    // Details ****************************************************************************************************************
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




    // Create ******************************************************************************************************************
    // GET *************************************************************************************************************
    public ActionResult Create()
    {
      return View();
    }

    // POST ***********************************************************************************************************
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "ID,Title")] MultipleBidderItem multipleBidderItem)
    {
      if (ModelState.IsValid)
      {
        if (multipleBidderItem.Title == "" || multipleBidderItem.Title == null || multipleBidderItem.Title == " ")
          return RedirectToAction("Index");





        // in work please do not delete
        //Add the new Multi Bidder Item to each Bidder already in the database

        foreach (var b in db.Bidders)
        {
          var IMBI = new IndividualMultiBidderItem();
          IMBI.Title = multipleBidderItem.Title;
          IMBI.Bidder_ID = b.BidderNumber;
          //b.MultiItems.Add(IMBI);
          db.IndividualMultiBidderItems.Add(IMBI);

        }

        db.MultipleBidderItems.Add(multipleBidderItem);
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(multipleBidderItem);
    }









    // Edit ******************************************************************************************************************
    // GET ***********************************************************************************************************
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

    // POST ***********************************************************************************************************
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "ID,Title")] MultipleBidderItem multipleBidderItem)
    {
      if (ModelState.IsValid)
      {
        if (multipleBidderItem.Title == "" || multipleBidderItem.Title == null || multipleBidderItem.Title == " ")
          return RedirectToAction("Index");

        db.Entry(multipleBidderItem).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(multipleBidderItem);
    }



    // Delete ******************************************************************************************************************
    // GET**************************************************************************************************************
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

    // POST*************************************************************************************************************
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      MultipleBidderItem multipleBidderItem = db.MultipleBidderItems.Find(id);
      db.MultipleBidderItems.Remove(multipleBidderItem);
      db.SaveChanges();
      return RedirectToAction("Index");
    }



    // Dispose *****************************************************************************************************************
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
