using AmigosAuction.Data;
using AmigosAuction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigosAuction.Services
{
    public class BidsServices
    {
        public bool AddBid(Bid bid)
        {
            AmigosAuctionContext context = new AmigosAuctionContext();
            context.Bids.Add(bid);
            return context.SaveChanges() > 0;
        }
    }
}
