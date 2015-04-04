using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.ViewModels
{
    public class ListVM
    {
        public List<String> ItemList { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string CurrentDate { get; set; }
    }
}
