namespace bgs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderIdAddedToOrderItemsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItem", "Order_OrderId", "dbo.Order");
            DropIndex("dbo.OrderItem", new[] { "Order_OrderId" });
            RenameColumn(table: "dbo.OrderItem", name: "Order_OrderId", newName: "OrderId");
            AlterColumn("dbo.OrderItem", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderItem", "OrderId", name: "OrderItemIndex");
            AddForeignKey("dbo.OrderItem", "OrderId", "dbo.Order", "OrderId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItem", "OrderId", "dbo.Order");
            DropIndex("dbo.OrderItem", "OrderItemIndex");
            AlterColumn("dbo.OrderItem", "OrderId", c => c.Int());
            RenameColumn(table: "dbo.OrderItem", name: "OrderId", newName: "Order_OrderId");
            CreateIndex("dbo.OrderItem", "Order_OrderId");
            AddForeignKey("dbo.OrderItem", "Order_OrderId", "dbo.Order", "OrderId");
        }
    }
}
