using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction.Models
{
    public class Tickets
    {
        public int NumEarlyTickets { get; set; }

        public int NumDoorTickets { get; set; }

        public decimal CostEarlyTickets { get; set; }

        public decimal CostDoorTickets { get; set; }
    }
}