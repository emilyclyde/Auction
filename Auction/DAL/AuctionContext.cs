using System;
using System.Linq;
using System.Web;
using Auction.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Auction.DAL
{
  public class AuctionContext : DbContext
  {

    public AuctionContext()
      : base("AuctionContext")
    {
    }

    public DbSet<AuctionDetail> AuctionDetails { get; set; }
    public DbSet<AuctionType> AuctionTypes { get; set; }
    public DbSet<Bidder> Bidders { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Donor> Donors { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<MultipleBidderItem> MultipleBidderItems { get; set; }
   


    protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
    {
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    }
  }
}
