using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction.Models
{
    public class Donor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Items { get; set; }
        public decimal Value { get; set; }
    }
}