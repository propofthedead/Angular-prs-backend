namespace prsAngularattempt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmorecontrollers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseRequestLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseRequestId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PurchaseRequests", t => t.PurchaseRequestId, cascadeDelete: true)
                .Index(t => t.PurchaseRequestId);
            
            CreateTable(
                "dbo.PurchaseRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Justification = c.String(),
                        RejectReason = c.String(),
                        DeliviryMode = c.String(),
                        Status = c.String(),
                        Price = c.Double(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseRequestLines", "PurchaseRequestId", "dbo.PurchaseRequests");
            DropForeignKey("dbo.PurchaseRequests", "UserId", "dbo.Users");
            DropIndex("dbo.PurchaseRequests", new[] { "UserId" });
            DropIndex("dbo.PurchaseRequestLines", new[] { "PurchaseRequestId" });
            DropTable("dbo.PurchaseRequests");
            DropTable("dbo.PurchaseRequestLines");
        }
    }
}
