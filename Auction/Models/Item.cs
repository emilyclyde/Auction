using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Auction.Models
{
  public class Item
  {
    public int ID { get; set; }

    [Required]
    [StringLength(50)]
    public string Title { get; set; }
    //[StringLength(50, ErrorMessage = "Title cannot be longer than 50 characters.")]
    [Required]
    [DataType(DataType.MultilineText)]
    public string Description { get; set; }
    //[StringLength(50, ErrorMessage = "Description cannot be longer than 50 characters.")]

    // Img saveing and naming 
    //do not change
    [Display(Name = "Image")]
    public string ImageURL
    {
      get { return Title.Replace(" ", string.Empty) + ".jpg"; }
    }
    //do not change
    // Img saveing and naming 

    [Display(Name = "Auction Type")]
    public int AuctionType { get; set; }

    [Display(Name = "Winning Bidder")]
    public int? WinningBidder { get; set; }
    [Display(Name = "Bid Amount")]
    public decimal? BidAmount { get; set; }



  }
}

