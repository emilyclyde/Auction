using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Auction.Models
{
  public class AuctionType
  {
   // [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ID { get; set; }
    public string Name { get; set; }
  }
}