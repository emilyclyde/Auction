using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Models;
using Auction.DAL;

namespace Auction.ViewModels
{
    public class AddWinningBidsVM
    {
        public List<Item> SilentItems  { get; set; }
        public List<Item> LiveItems  { get; set; }




    }
}
