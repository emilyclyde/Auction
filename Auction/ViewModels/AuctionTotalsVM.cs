using Auction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.ViewModels
{
    public class AuctionTotalsVM
    {
        public decimal LiveTotal { get; set; }

        public decimal SilentTotal { get; set; }

        public List<IndividualMultiBidderItem> MultiTotals { get; set; }

        public decimal EarlyTicketsTotal { get; set; }

        public decimal DoorTicketsTotal { get; set; }
        
        public string Theme { get; set; }

        public string Date { get; set; }

        public decimal TicketsTotal { get; set; }

    }
}
