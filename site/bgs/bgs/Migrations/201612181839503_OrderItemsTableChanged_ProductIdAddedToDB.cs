namespace bgs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderItemsTableChanged_ProductIdAddedToDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItem", "ProductId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderItem", "ProductId");
        }
    }
}
