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

        // Img saveing and naming 
        //do not change
        public string ImageURL
        {
            get { return Title.Replace(" ", string.Empty) + ".jpg"; }
        }
        //do not change
        // Img saveing and naming 
       
        public int AuctionType { get; set; }

        public int WinningBidder { get; set; }

        public decimal BidAmount { get; set; }
    }
}
