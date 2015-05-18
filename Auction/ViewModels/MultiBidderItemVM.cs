using Auction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction.ViewModels
{
    public class MultiBidderItemVM
    {
        public String Title { get; set; }

        public List<IndividualMultiBidderItem> IMBIList { get; set; }
    }
}