namespace AmigosAuction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class auctionEnityAltered : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Auctions", "AuctionImage_ID", "dbo.Pictures");
            DropIndex("dbo.Auctions", new[] { "AuctionImage_ID" });
            AddColumn("dbo.Auctions", "AuctionPicture", c => c.String());
            DropColumn("dbo.Auctions", "AuctionImage_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Auctions", "AuctionImage_ID", c => c.Int());
            DropColumn("dbo.Auctions", "AuctionPicture");
            CreateIndex("dbo.Auctions", "AuctionImage_ID");
            AddForeignKey("dbo.Auctions", "AuctionImage_ID", "dbo.Pictures", "ID");
        }
    }
}
