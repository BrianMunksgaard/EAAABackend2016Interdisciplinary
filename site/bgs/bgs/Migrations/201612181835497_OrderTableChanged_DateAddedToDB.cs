namespace bgs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderTableChanged_DateAddedToDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "OrderDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "OrderDate");
        }
    }
}
