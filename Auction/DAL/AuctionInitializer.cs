using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Auction.Models;

namespace Auction.DAL
{
  //public class AuctionInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AuctionContext>
  public class AuctionInitializer : System.Data.Entity.DropCreateDatabaseAlways<AuctionContext>
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


      var auctiontypes = new List<AuctionType>
        {
          new AuctionType{ID=1, Name="Live"},
          new AuctionType{ID=2, Name="Silent"},
          new AuctionType{ID=3, Name="Multi-Bidder"},
        };

      auctiontypes.ForEach(t => context.AuctionTypes.Add(t));
      context.SaveChanges();

      var bidders = new List<Bidder>
        {
          new Bidder{ID=1, BidderName = "Rob and Karina Callahan", BidderContact1="(541)736-0300", BidderContact2="(541)285-5792", BidderContact3="CaddisflyRob@yahoo.com"},
          new Bidder{ID=2, BidderName = "Erica Dundee", BidderContact1="EricaD@gmail.com", BidderContact2="(541)344-0377",BidderContact3="EDundee@yahoo.com"},
          new Bidder{ID=3, BidderName = "Keith and Laurita Blunk", BidderContact1="(541)726-6915", BidderContact2="(541)275-3387",BidderContact3="KeithB62@comcast.net"},
          new Bidder{ID=4, BidderName = "Arthur King", BidderContact1="Arthur@Camilot.com", BidderContact2="(206)597-1492", BidderContact3="(237)772-4086"},
          new Bidder{ID=5, BidderName = "Rhoda Byke", BidderContact1="(206)733-8805", BidderContact2="Sprocket42@yahoo,com",BidderContact3="1-800-Flatire"},
        };

      bidders.ForEach(b => context.Bidders.Add(b));
      context.SaveChanges();


      var donors = new List<Donor>
        {
          new Donor{ID=1, Name="Phil Night", Address="2800 Highview Dr.",  City="Beaverton", State="OR", Zip="97443", Email="MrPhil@Nike.com", Items="Autographed Duck BasketBall", Value=150 },
          new Donor{ID=2, Name="Adam Tubbs", Address="19034 West B st.",  City="Springfield", State="OR", Zip="97478", Email="ATubbs54@yahoo,com", Items="Rafting trip", Value=400 },
          new Donor{ID=3, Name="Albertsons Bakery", Address="5820 Main St.",  City="Springfield", State="OR", Zip="97478", Email= "None", Items="German Chocolate Cake", Value=12.00m },
          new Donor{ID=4, Name="Flashback Grill", Address="4210 Main St.",  City="Springfield", State="OR", Zip="97478", Email= "FlashbackGrill@Yahoo.com", Items="Gift certificate", Value=30.00m },
        
        };

      donors.ForEach(o => context.Donors.Add(o));
      context.SaveChanges();

      var items = new List<Item>
        {
          new Item{ID=1, AuctionType=2, Title="SkateWorld", Description="Addmission for two to Skate World", WinningBidder=101, BidAmount = 10},
          new Item{ID=2, AuctionType=2, Title="Movie Night Basket", Description="5 Family DVDs, Popcorn, Cookie Mix and Disney Blanket", WinningBidder=101, BidAmount = 40 },
          new Item{ID=3, AuctionType=1, Title="Cedar Creek Weekend Getaway", Description="Two night stay at Oregon’s famous Cedar Creek Bed & Breakfast. This premiere country resort is the perfect place to relax and enjoy Cedar Creek and the beautiful Umpqua River from. Offering theme decorated rooms & kitchen suites, decks with barbecues and a parlor-library in the Lodge. Easy access to the river, swimming hole, gazebo and picnic area. This weekend stay at any one our five luxurious cabins will be perfect for a whole family adventure or a romantic get-a-way for just the parents. Package includes a complete country breakfast and full access to our hot springs heated pool and spa.  Cabins will sleep up six people in two queen-sized, and two twin beds.  Local fishing guide service is also available through the fly shop in the Lodge.", WinningBidder=101, BidAmount = 600},
          new Item{ID=4, AuctionType=1, Title="Flowers for a Year", Description="Humbolt Florists will supply a colorful bouquet of seasonal flowers each month. Great for you home or office.", WinningBidder=101, BidAmount = 150},
          new Item{ID=5, AuctionType=1, Title="Oregon Coast Salmon fishing", Description="Bill Reynolds Salmon Carters, Florence OR, will take you and 3 guests out for a full day of Pacific salmon fishing. ", WinningBidder=102, BidAmount = 375},
          new Item{ID=6, AuctionType=1, Title="Hoodo Ski Trip", Description="Lift tickets and ski rental for two people at Hoodo ski resort ", WinningBidder=102, BidAmount = 100},
          new Item{ID=7, AuctionType=2, Title="Jerry's Gift Card", Description="$25 Gift card to Jerry's Home Inprovement Center", WinningBidder=12, BidAmount=25},
          new Item{ID=8, AuctionType=2, Title="Shari's Gift Certificate", Description="Gift certificate for one of Shari's Signature Pies", WinningBidder=101, BidAmount = 10},
          new Item{ID=9, AuctionType=2, Title="Manacure", Description="One Manacure at Nail's-R-Us", WinningBidder=103, BidAmount = 20},
          new Item{ID=10, AuctionType=2, Title="Papa Murphy's Pizzas", Description="2 Family size pizzas from either Springfield Papa Murphy's", WinningBidder=101, BidAmount = 30},
          new Item{ID=11, AuctionType=2, Title="Oregon Ducks Picture", Description="Framed, Autographed picture of the Duck Women's basketball team ", WinningBidder=103, BidAmount = 40},
          new Item{ID=12, AuctionType=2, Title="Art Caddy", Description="250 piece Art Caddy with sketch book ", WinningBidder=102, BidAmount = 18},
          new Item{ID=13, AuctionType=2, Title="Galaxy Lanes Bowling", Description="3 Games of Bowling at Galaxy Lanes. Includes shoe rental.", WinningBidder=101, BidAmount = 20},
          new Item{ID=14, AuctionType=2, Title="Ice Cream Cake", Description="One half-round ice cream cake from Springfield Baskin Robins", WinningBidder=102, BidAmount = 10},
          new Item{ID=15, AuctionType=2, Title="Dozen Roses", Description="One dozen roses from Patrica's Flower Pot", WinningBidder=103, BidAmount = 10},
          new Item{ID=16, AuctionType=2, Title="Quickie Lube", Description="One standard Oil, Lube and filter change at Quickie Lube"},
          new Item{ID=17, AuctionType=2, Title="Euphoria Chocolate", Description="3 lbs of chocolate from the Euphoria Chocolate Company"},
          new Item{ID=18, AuctionType=1, Title="Rockin' R Ranch", Description="3 day weekend trip to the Rockin'R dude Ranch. 4 guests can enjoy all the excitment of the Old West including a real cattle drive on horseback and the best country cooking this side of the Mississippi."},
          new Item{ID=19, AuctionType=2, Title="Winco Groceries", Description="$25.00 Winco gift card"},
        };
 
      items.ForEach(i => context.Items.Add(i));
      context.SaveChanges();


      var multiplebidderitems = new List<MultipleBidderItem>
        {
          new MultipleBidderItem{ID=1, Title="Raise the Paddle"},
          new MultipleBidderItem{ID=2, Title="Dessert Dash"},
          new MultipleBidderItem{ID=3, Title="TV Raffle"},
        };
      multiplebidderitems.ForEach(m => context.MultipleBidderItems.Add(m));
      context.SaveChanges();

      var IMBI = new List<IndividualMultiBidderItem>
            {
                new IndividualMultiBidderItem {ID=1, Bidder_ID=101, Title="Raise the Paddle", BidAmount = 100},
                new IndividualMultiBidderItem {ID=2, Bidder_ID=101, Title="Dessert Dash", BidAmount = 20},
                new IndividualMultiBidderItem {ID=3, Bidder_ID=101, Title="TV Raffle", BidAmount = 20},
                new IndividualMultiBidderItem {ID=4, Bidder_ID=102, Title="Raise the Paddle", BidAmount = 1000},
                new IndividualMultiBidderItem {ID=5, Bidder_ID=102, Title="Dessert Dash", BidAmount = 30},
                new IndividualMultiBidderItem {ID=6, Bidder_ID=102, Title="TV Raffle", BidAmount = 10},
                new IndividualMultiBidderItem {ID=7, Bidder_ID=103, Title="Raise the Paddle", BidAmount = 50},
                new IndividualMultiBidderItem {ID=8, Bidder_ID=103, Title="Dessert Dash", BidAmount = 60},
                new IndividualMultiBidderItem {ID=9, Bidder_ID=103, Title="TV Raffle", BidAmount = 30},
                new IndividualMultiBidderItem {ID=10, Bidder_ID=104, Title="Raise the Paddle", BidAmount = 0},
                new IndividualMultiBidderItem {ID=11, Bidder_ID=104, Title="Dessert Dash", BidAmount = 10},
                new IndividualMultiBidderItem {ID=12, Bidder_ID=104, Title="TV Raffle", BidAmount = 0},
                new IndividualMultiBidderItem {ID=13, Bidder_ID=105, Title="Raise the Paddle", BidAmount = 0},
                new IndividualMultiBidderItem {ID=14, Bidder_ID=105, Title="Dessert Dash", BidAmount = 0},
                new IndividualMultiBidderItem {ID=15, Bidder_ID=105, Title="TV Raffle", BidAmount =0},
            };

      IMBI.ForEach(i => context.IndividualMultiBidderItems.Add(i));
      context.SaveChanges();


    }


  }
}


