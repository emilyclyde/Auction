﻿using System;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Auction.Models
{
  public class Bidder
  {
   // [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ID { get; set; }

    [Display(Name = "Bidder Name")]
    public string BidderName { get; set; }

    [Display(Name = "Bidder Number")]
    public int BidderNumber { get; set; }

    [Display(Name = "Bidder Contact")]
    public string BidderContact { get; set; }
  }
}