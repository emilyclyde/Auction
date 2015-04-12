using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Auction.Models
{
  public class AuctionDetail
  {
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ID { get; set; }

    public string Theme { get; set; }

    public string Date { get; set; }

    public string LocationName { get; set; }

    public string LocationAddress { get; set; }

    public string Time1 { get; set; }

    public string Time2 { get; set; }

    public string Time3 { get; set; }

    public string DoorCost { get; set; }

    public string EarlyCost { get; set; }

    public string EarlyTicketDate { get; set; }


  }
}