using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Auction.Models;

namespace Auction.ViewModels
{
    public class IndividualBidderVM
    {
        public int ID { get; set; }

        public string BidderName { get; set; }

        public int BidderNumber {get;set;}

        public List<Item> LiveItems {get; set;}

        public List<Item> SilentItems {get; set;}

        public List<IndividualMultiBidderItem> MultiItems { get; set; }

        public string BidderContact1 { get; set; }

        public string BidderContact2 { get; set; }

        public string BidderContact3 { get; set; }

        public int SilentTotal { get; set; }

        public int LiveTotal { get; set; }

        public int MultiTotal { get; set; }

        public int ALLTotal { get; set; }
    }

}