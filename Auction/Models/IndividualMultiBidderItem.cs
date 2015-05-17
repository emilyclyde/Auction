using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction.Models
{
    public class IndividualMultiBidderItem
    {
        public int ID { get; set; }

        public String Title { get; set; }
    
        public decimal BidAmount { get; set; }

        public int Bidder_ID { get; set; }
    }

   
}