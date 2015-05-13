using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;



namespace Auction.Models
{
  public class Contact
  {
    //[DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ID { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }
     //[Column("Phone Number")]
    public string PhoneNumber { get; set; }

   
  }
}