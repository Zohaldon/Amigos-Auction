using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigosAuction.Entities
{
    public class Bid :BaseEntity
    {
        public int AuctionId { get; set; }
        public virtual Auction Auction { get; set; }

        public string UserId { get; set; }
        public virtual AmigosAuctionUser User { get; set; }

        public decimal BiddingRate { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
