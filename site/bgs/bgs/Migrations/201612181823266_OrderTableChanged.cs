namespace bgs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderTableChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order", "Customer_PersonId", "dbo.Person");
            DropForeignKey("dbo.OrderItem", "OrderId", "dbo.Order");
            DropIndex("dbo.Order", new[] { "Customer_PersonId" });
            AddColumn("dbo.Order", "PersonId", c => c.Int(nullable: false));
            DropColumn("dbo.Order", "CustomerId");
            DropColumn("dbo.Order", "Customer_PersonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "Customer_PersonId", c => c.Int());
            AddColumn("dbo.Order", "CustomerId", c => c.Int(nullable: false));
            DropColumn("dbo.Order", "PersonId");
            CreateIndex("dbo.Order", "Customer_PersonId");
            AddForeignKey("dbo.OrderItem", "OrderId", "dbo.Order", "OrderId", cascadeDelete: true);
            AddForeignKey("dbo.Order", "Customer_PersonId", "dbo.Person", "PersonId");
        }
    }
}
