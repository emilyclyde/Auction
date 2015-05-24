using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Auction.DAL;

namespace Auction.Models
{
    public class Tickets
    {
        public int ID { get; set; }

        public int NumEarlyTickets { get; set; }

        public int NumDoorTickets { get; set; }

        public decimal CostEarlyTickets { get; set; }

        public decimal CostDoorTickets { get; set; }
    }
}