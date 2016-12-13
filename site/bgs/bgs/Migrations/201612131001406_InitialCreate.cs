namespace bgs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Credential",
                c => new
                    {
                        CredentialsId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        UserPass = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CredentialsId);
            
            CreateTable(
                "dbo.Dimensions",
                c => new
                    {
                        DimensionId = c.Int(nullable: false, identity: true),
                        Width = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        Length = c.Int(nullable: false),
                        Units = c.Int(nullable: false),
                        GapWidth = c.Int(nullable: false),
                        GapHeight = c.Int(nullable: false),
                        GapLength = c.Int(nullable: false),
                        Holds_DimensionId = c.Int(),
                    })
                .PrimaryKey(t => t.DimensionId)
                .ForeignKey("dbo.Dimensions", t => t.Holds_DimensionId)
                .Index(t => t.Holds_DimensionId);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        GameName = c.String(),
                        GameCode = c.String(),
                    })
                .PrimaryKey(t => t.GameId);
            
            CreateTable(
                "dbo.ProductGame",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => new { t.ProductId, t.GameId })
                .ForeignKey("dbo.Game", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductCode = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryId = c.Int(nullable: false),
                        CategoryPropertiesId = c.Int(),
                        Size = c.Int(),
                        CMYK = c.String(),
                        RGB = c.String(),
                        Weight = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        DisplayDim_DimensionId = c.Int(),
                        FitCardDim_DimensionId = c.Int(),
                        NGBoxDim_DimensionId = c.Int(),
                        NGSleeveDim_DimensionId = c.Int(),
                        OuterCartonDim_DimensionId = c.Int(),
                        StandardSleeveDim_DimensionId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Dimensions", t => t.DisplayDim_DimensionId)
                .ForeignKey("dbo.Dimensions", t => t.FitCardDim_DimensionId)
                .ForeignKey("dbo.Dimensions", t => t.NGBoxDim_DimensionId)
                .ForeignKey("dbo.Dimensions", t => t.NGSleeveDim_DimensionId)
                .ForeignKey("dbo.Dimensions", t => t.OuterCartonDim_DimensionId)
                .ForeignKey("dbo.Dimensions", t => t.StandardSleeveDim_DimensionId)
                .Index(t => t.CategoryId)
                .Index(t => t.DisplayDim_DimensionId)
                .Index(t => t.FitCardDim_DimensionId)
                .Index(t => t.NGBoxDim_DimensionId)
                .Index(t => t.NGSleeveDim_DimensionId)
                .Index(t => t.OuterCartonDim_DimensionId)
                .Index(t => t.StandardSleeveDim_DimensionId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryText = c.String(),
                        CategoryCode = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.OrderItem",
                c => new
                    {
                        OrderItemId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Product_ProductId = c.Int(),
                        Order_OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderItemId)
                .ForeignKey("dbo.Product", t => t.Product_ProductId)
                .ForeignKey("dbo.Order", t => t.Order_OrderId)
                .Index(t => t.Product_ProductId)
                .Index(t => t.Order_OrderId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Customer_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Person", t => t.Customer_PersonId)
                .Index(t => t.Customer_PersonId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        Zip = c.String(),
                        City = c.String(),
                        BirthDay = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Credential_CredentialsId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Credential", t => t.Credential_CredentialsId)
                .Index(t => t.Credential_CredentialsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItem", "Order_OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "Customer_PersonId", "dbo.Person");
            DropForeignKey("dbo.Person", "Credential_CredentialsId", "dbo.Credential");
            DropForeignKey("dbo.OrderItem", "Product_ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "StandardSleeveDim_DimensionId", "dbo.Dimensions");
            DropForeignKey("dbo.Product", "OuterCartonDim_DimensionId", "dbo.Dimensions");
            DropForeignKey("dbo.Product", "NGSleeveDim_DimensionId", "dbo.Dimensions");
            DropForeignKey("dbo.Product", "NGBoxDim_DimensionId", "dbo.Dimensions");
            DropForeignKey("dbo.Product", "FitCardDim_DimensionId", "dbo.Dimensions");
            DropForeignKey("dbo.Product", "DisplayDim_DimensionId", "dbo.Dimensions");
            DropForeignKey("dbo.ProductGame", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.ProductGame", "GameId", "dbo.Game");
            DropForeignKey("dbo.Dimensions", "Holds_DimensionId", "dbo.Dimensions");
            DropIndex("dbo.Person", new[] { "Credential_CredentialsId" });
            DropIndex("dbo.Order", new[] { "Customer_PersonId" });
            DropIndex("dbo.OrderItem", new[] { "Order_OrderId" });
            DropIndex("dbo.OrderItem", new[] { "Product_ProductId" });
            DropIndex("dbo.Product", new[] { "StandardSleeveDim_DimensionId" });
            DropIndex("dbo.Product", new[] { "OuterCartonDim_DimensionId" });
            DropIndex("dbo.Product", new[] { "NGSleeveDim_DimensionId" });
            DropIndex("dbo.Product", new[] { "NGBoxDim_DimensionId" });
            DropIndex("dbo.Product", new[] { "FitCardDim_DimensionId" });
            DropIndex("dbo.Product", new[] { "DisplayDim_DimensionId" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropIndex("dbo.ProductGame", new[] { "GameId" });
            DropIndex("dbo.ProductGame", new[] { "ProductId" });
            DropIndex("dbo.Dimensions", new[] { "Holds_DimensionId" });
            DropTable("dbo.Person");
            DropTable("dbo.Order");
            DropTable("dbo.OrderItem");
            DropTable("dbo.Category");
            DropTable("dbo.Product");
            DropTable("dbo.ProductGame");
            DropTable("dbo.Game");
            DropTable("dbo.Dimensions");
            DropTable("dbo.Credential");
        }
    }
}
