using AmigosAuction.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigosAuction.Data
{
    public class AmigosAuctionContext : IdentityDbContext<AmigosAuctionUser>
    {
        public AmigosAuctionContext( ) : base("name=AmigosAuctionConnectionString")
        {

        }

        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public static AmigosAuctionContext Create()
        {
            return new AmigosAuctionContext();
        }
    }
}
