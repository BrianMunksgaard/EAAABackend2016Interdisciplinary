namespace bgs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageUrlProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "ImageUrl");
        }
    }
}
