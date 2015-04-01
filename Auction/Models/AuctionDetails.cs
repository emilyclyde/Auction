using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction.Models
{
    public class AuctionDetails
    {
        public int ID { get; set; }

        public string Theme { get; set; }

        public string Date { get; set; }

        public string Location { get; set; }

        public string Time1 { get; set; }

        public string Time2 { get; set; }

        public string Time3 { get; set; }

        public string DoorCost { get; set; }

        public string EarlyCost { get; set; }
    }
}