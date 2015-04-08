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
        new AuctionDetail{ID=1, Theme="Polynesian Paradise", Date="May 23, 2015", LocationName = "Emanuel Baptist Church", LocationAddress = "3050 Game Farm Rd Springfield, OR",
        Time1 = "Doors open at 5:30", Time2 = "Buffet Dinner at 6:30", Time3 = "Live Auction at 7:00",DoorCost = "$20.00", EarlyCost = "$15.00", EarlyTicketDate = "May 15, 2015"}, 
                
      };

      auctiondetails.ForEach(d => context.AuctionDetails.Add(d));
      context.SaveChanges();

      var contacts = new List<Contact>
      {
        new Contact{ID= 1,Name = "Debra Norland", Email = "logosacademymusic@gmail.com", PhoneNumber = "(541)747-0702"},
                
      };

      contacts.ForEach(c => context.Contacts.Add(c));
      context.SaveChanges();


      //  var auctiontypes = new List<AuctionType>
      //  {
      //    new AuctionType{},
      //    new AuctionType{},
      //  };

      //  auctiontypes.ForEach(t => context.AuctionTypes.Add(t));
      //  context.SaveChanges();

      //  var bidders = new List<Bidder>
      //  {
      //    new Bidder{},
      //    new Bidder{},
      //  };

      //  bidders.ForEach(b => context.Bidders.Add(b));
      //  context.SaveChanges();


      //  var donors = new List<Donor>
      //  {
      //    new Donor{},
      //    new Donor{},
      //  };

      //  donors.ForEach(o => context.Donors.Add(o));
      //  context.SaveChanges();

      //  var items = new List<Item>
      //  {
      //    new Item{},
      //    new Item{},
      //  };

      //  items.ForEach(i => context.Items.Add(i));
      //  context.SaveChanges();

      //  var multiplebidderitems = new List<MultipleBidderItem>
      //  {
      //    new MultipleBidderItem{},
      //    new MultipleBidderItem{},
      //  };

      //  multiplebidderitems.ForEach(m => context.MultipleBidderItems.Add(m));
      //  context.SaveChanges();
      //}
    }
  }
}
