using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigosAuction.Entities
{
    public class Auction : BaseEntity
    {
        [Required]
        [MinLength(3,ErrorMessage ="Minimum length should be atleast 15 characters.")]
        [MaxLength(150)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(10,1000000,ErrorMessage ="Please enter value between $100 - $100,000.")]
        public decimal InitialPrice { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? AuctionStartTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? AuctionEndTime { get; set; }
        
        public virtual Category Category { get; set; }
        public int CategoryID { get; set; }

        public string AuctionPicture { get; set; }
        public virtual List<Bid> Bids { get; set; }

    }
}
