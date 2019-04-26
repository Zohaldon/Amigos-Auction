namespace AmigosAuction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BidEntity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bids", "BiddingRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bids", "BiddingRate", c => c.Double(nullable: false));
        }
    }
}
