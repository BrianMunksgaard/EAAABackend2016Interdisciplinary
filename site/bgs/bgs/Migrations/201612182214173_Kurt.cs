namespace bgs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Kurt : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Product", "ProductIndex");
            AlterColumn("dbo.Product", "ProductName", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "ProductCode", c => c.String(nullable: false, maxLength: 15));
            CreateIndex("dbo.Product", "ProductCode", unique: true, name: "ProductIndex");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Product", "ProductIndex");
            AlterColumn("dbo.Product", "ProductCode", c => c.String(maxLength: 15));
            AlterColumn("dbo.Product", "ProductName", c => c.String());
            CreateIndex("dbo.Product", "ProductCode", unique: true, name: "ProductIndex");
        }
    }
}
