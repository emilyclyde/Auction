using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Auction.Models
{
    public class Item
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageURL
        {
            get { return Title.Replace(" ", string.Empty) + ".jpg"; }
        }
       
        public int AuctionType { get; set; }

        public int WinningBidder { get; set; }

        public decimal BidAmount { get; set; }
    }
}
