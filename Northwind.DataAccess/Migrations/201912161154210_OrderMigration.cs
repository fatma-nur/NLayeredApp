namespace Northwind.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderName = c.String(),
                        OrderAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            AddColumn("dbo.Products", "Order_OrderId", c => c.Int());
            CreateIndex("dbo.Products", "Order_OrderId");
            AddForeignKey("dbo.Products", "Order_OrderId", "dbo.Orders", "OrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.Products", new[] { "Order_OrderId" });
            DropColumn("dbo.Products", "Order_OrderId");
            DropTable("dbo.Orders");
        }
    }
}
