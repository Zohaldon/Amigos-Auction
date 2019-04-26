namespace AmigosAuction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BidsAdded : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Comments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Test = c.String(),
                        UserID = c.String(),
                        TimeStamp = c.DateTime(nullable: false),
                        AuctionID = c.Int(nullable: false),
                        BlogID = c.Int(nullable: false),
                        EntityID = c.Int(nullable: false),
                        RecordID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
