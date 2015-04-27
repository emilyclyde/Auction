using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Auction.Models
{
  public class MultipleBidderItem
  {
    //[DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ID { get; set; }
   // [StringLength(50)]
    public string Title { get; set; }
   
  }
}