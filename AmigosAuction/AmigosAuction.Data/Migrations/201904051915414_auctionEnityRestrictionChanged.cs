namespace AmigosAuction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class auctionEnityRestrictionChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Auctions", "Title", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Auctions", "Title", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
