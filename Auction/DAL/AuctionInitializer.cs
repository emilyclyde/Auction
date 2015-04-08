using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Auction.Models;

namespace Auction.DAL
{
  public class AuctionInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AuctionContext>
  {
    protected override void Seed(AuctionContext context)
    {
      var auctiondetails = new List<AuctionDetail> 
      {
        new AuctionDetail{},
        new AuctionDetail{},
      };

      auctiondetails.ForEach(d => context.AuctionDetails.Add(d));
      context.SaveChanges();

      var auctiontypes = new List<AuctionType>
      {
        new AuctionType{},
        new AuctionType{},
      };

      auctiontypes.ForEach(t => context.AuctionTypes.Add(t));
      context.SaveChanges();

      var bidders = new List<Bidder>
      {
        new Bidder{},
        new Bidder{},
      };

      bidders.ForEach(b => context.Bidders.Add(b));
      context.SaveChanges();

      var contacts = new List<Contact>
      {
        new Contact{},
        new Contact{},
      };

      contacts.ForEach(c => context.Contacts.Add(c));
      context.SaveChanges();

      var donors = new List<Donor>
      {
        new Donor{},
        new Donor{},
      };

      donors.ForEach(o => context.Donors.Add(o));
      context.SaveChanges();

      var items = new List<Item>
      {
        new Item{},
        new Item{},
      };

      items.ForEach(i => context.Items.Add(i));
      context.SaveChanges();

      var multiplebidderitems = new List<MultipleBidderItem>
      {
        new MultipleBidderItem{},
        new MultipleBidderItem{},
      };

      multiplebidderitems.ForEach(m => context.MultipleBidderItems.Add(m));
      context.SaveChanges();
    }
  }
}
