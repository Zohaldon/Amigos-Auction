namespace AmigosAuction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegisterFunctionality : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Auctions", "Title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Auctions", "AuctionStartTime", c => c.DateTime());
            AlterColumn("dbo.Auctions", "AuctionEndTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Auctions", "AuctionEndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Auctions", "AuctionStartTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Auctions", "Title", c => c.String());
        }
    }
}
