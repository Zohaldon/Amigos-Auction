using AmigosAuction.Data;
using AmigosAuction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigosAuction.Services
{
    public class AuctionsService
    {
        AmigosAuctionContext context;

        public List<Auction> GetFeaturedAuctions()
        {
            context = new AmigosAuctionContext();
            return context.Auctions.Take(4).ToList();
        }

        public List<Auction> GetAuctions()
        {
            context = new AmigosAuctionContext();
            return context.Auctions.ToList();
        }

        public Auction GetAuctionByID(int? ID)
        {
            context = new AmigosAuctionContext();
            return context.Auctions.Find(ID);
        }

        public void SaveAuction(Auction auction)
        {
            try
            {
                context = new AmigosAuctionContext();
                //Need to add EnityFramework from NuggetPackageManager
                context.Auctions.Add(auction);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }

        public void UpdateAuction(Auction auction)
        {
            context = new AmigosAuctionContext();
            context.Entry(auction).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteAuction(Auction auction)
        {
            context = new AmigosAuctionContext();
            context.Entry(auction).State = System.Data.Entity.EntityState.Deleted;
            //context.Auctions.Remove(auction);
            context.SaveChanges();
        }
    }
}
