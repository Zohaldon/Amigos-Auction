namespace AmigosAuction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bidFunctionalityAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bids",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AuctionId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        BiddingRate = c.Double(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Auctions", t => t.AuctionId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.AuctionId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bids", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bids", "AuctionId", "dbo.Auctions");
            DropIndex("dbo.Bids", new[] { "UserId" });
            DropIndex("dbo.Bids", new[] { "AuctionId" });
            DropTable("dbo.Bids");
        }
    }
}
