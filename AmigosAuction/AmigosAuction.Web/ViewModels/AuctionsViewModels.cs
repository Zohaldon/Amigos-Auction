using AmigosAuction.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AmigosAuction.Web.ViewModels
{
    public class AuctionsViewModel 
    {
        public List<Auction> AllAuctions { get; set; }
        public List<Auction> FeaturedAuctions { get; set; }
        public string Title { get; set; }
        public List<Category> Categories { get; set; }
    }

    public class CreateAuctionViewModel 
    {
        [Required]
        [MinLength(5, ErrorMessage = "Minimum length should be atleast 15 characters.")]
        [MaxLength(50)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(10, 100000, ErrorMessage = "Please enter value between $100 - $100,000.")]
        public decimal InitialPrice { get; set; }

        public DateTime? AuctionStartTime { get; set; }
        public DateTime? AuctionEndTime { get; set; }
        public string AuctionPictures { get; set; }
        public List<Category> Categories { get; set; }
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string AuctionPicture { get; set; }
    }

    public class AuctionDetailsViewModel
    {
        public Auction Auction { get; set; }
        public decimal BidsAmount { get; set; }
        public AmigosAuctionUser LatestBidder { get; set; }
        public List<Comment> Comments { get; set; }
        public int EntityID { get; set; }
    }

}