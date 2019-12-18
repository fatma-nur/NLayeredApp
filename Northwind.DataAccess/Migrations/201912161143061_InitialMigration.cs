namespace Northwind.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        CategoryId = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuantityPerUnit = c.String(),
                        UnitsInStock = c.Short(nullable: false),
                        Stock_StockId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Stocks", t => t.Stock_StockId)
                .Index(t => t.Stock_StockId);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        StockId = c.Int(nullable: false, identity: true),
                        StockName = c.String(),
                        StockAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StockId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Stock_StockId", "dbo.Stocks");
            DropIndex("dbo.Products", new[] { "Stock_StockId" });
            DropTable("dbo.Stocks");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
