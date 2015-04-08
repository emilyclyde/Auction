using System;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Auction.Models
{
  public class Bidder
  {
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ID { get; set; }
    public string Name { get; set; }
    public string BidderName { get; set; }
  }
}