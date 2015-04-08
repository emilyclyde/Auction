using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auction.Models
{
  public class MultipleBidderItem
  {
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ID { get; set; }
    public string Title { get; set; }
    public virtual Item item { get; set; }

  }
}