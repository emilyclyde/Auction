using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Auction.Models;

namespace Auction.ViewModels
{
    public class IndividualBidderVM
    {
        
        public string BidderName { get; set; }

        public int BidderNumber {get;set;}

        public List<Item> LiveItems {get; set;}

        public List<Item> SilentItems {get; set;}

        public List<IndividualMultiBidderItem> MultiItems { get; set; }

        public string BidderContact1 { get; set; }

        public string BidderContact2 { get; set; }

        public string BidderContact3 { get; set; }

        public decimal SilentTotal { get; set; }

        public decimal LiveTotal { get; set; }

        public decimal MultiTotal { get; set; }

        public decimal ALLTotal { get; set; }
    }

}