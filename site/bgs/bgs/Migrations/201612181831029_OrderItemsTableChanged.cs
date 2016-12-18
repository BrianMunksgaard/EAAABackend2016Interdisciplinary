namespace bgs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderItemsTableChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItem", "Product_ProductId", "dbo.Product");
            DropIndex("dbo.OrderItem", new[] { "Product_ProductId" });
            DropColumn("dbo.OrderItem", "Product_ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderItem", "Product_ProductId", c => c.Int());
            CreateIndex("dbo.OrderItem", "Product_ProductId");
            AddForeignKey("dbo.OrderItem", "Product_ProductId", "dbo.Product", "ProductId");
        }
    }
}
