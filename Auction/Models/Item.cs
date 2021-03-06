﻿using System;
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
    [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "Special characters are not permitted")]
    public string Title { get; set; }

    [Required]
    [DataType(DataType.MultilineText)]
    public string Description { get; set; }

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

    public int  ItemNumber { get; set; }

    //[Display(Name = "Value")]
    //public decimal? Value { get; set; }

  }
}

