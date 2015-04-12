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

      var bidders = new List<Bidder>
        {
          new Bidder{ID=1,BidderNumber="001", BidderName = "Rob and Karina Callahan", BidderContact="(541)736-0300"},
          new Bidder{ID=2,BidderNumber="002", BidderName = "Erica Dundee", BidderContact="EricaD@gmail.com"},
          new Bidder{ID=3,BidderNumber="003", BidderName = "Keith and Laurita Blunk", BidderContact="(541)726-6915"},
          new Bidder{ID=4,BidderNumber="004", BidderName = "Arthur King", BidderContact="Arthur@Camilot.com"},
          new Bidder{ID=5,BidderNumber="005", BidderName = "Rhoda Byke", BidderContact="(206)733-8805"},
        };

      bidders.ForEach(b => context.Bidders.Add(b));
      context.SaveChanges();


      var donors = new List<Donor>
        {
          new Donor{ID=1, Name="Phil Night", Address="2800 Highview Dr.",  City="Beaverton", State="OR", Zip="97443", Email="MrPhil@Nike.com", Items="Autographed Duck BasketBall", Value=150 },
          new Donor{ID=2, Name="Adam Tubbs", Address="19034 West B st.",  City="Springfield", State="OR", Zip="97478", Email="ATubbs54@yahoo,com", Items="Rafting trip", Value=400 },
          new Donor{ID=2, Name="Albertsons Bakery", Address="5820 Main St.",  City="Springfield", State="OR", Zip="97478", Email= "None", Items="German Chocolate Cake", Value=12.00m },
          new Donor{ID=2, Name="Flashback Grill", Address="4210 Main St.",  City="Springfield", State="OR", Zip="97478", Email= "FlashbackGrill@Yahoo.com", Items="Gift certificate", Value=30.00m },
        
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
