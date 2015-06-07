using System;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Auction.DAL;

namespace Auction.Models
{
  public class Bidder
  {
    AuctionContext db = new AuctionContext();

    public int ID { get; set; }

    [Display(Name = "Bidder Name")]
    public string BidderName { get; set; }

    //[Display(Name = "Bidder Number")]
    // public string BidderNumber { get; set; }

    [Display(Name = "Bidder Number")]
    public int BidderNumber{ get; set; }
    
    [Display(Name = "Bidder Contact 1")]
    public string BidderContact1 { get; set; }

    [Display(Name = "Bidder Contact 2")]
    public string BidderContact2 { get; set; }

    [Display(Name = "Bidder Contact 3")]
    public string BidderContact3 { get; set; }

    //public List<IndividualMultiBidderItem> MultiItems { get; set; }
  }
}