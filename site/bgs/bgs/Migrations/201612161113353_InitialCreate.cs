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
                "dbo.Game",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        GameName = c.String(),
                        GameCode = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.GameId)
                .Index(t => t.GameCode, unique: true, name: "GameIndex");
            
            CreateTable(
                "dbo.ProductFitGame",
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
                        ProductCode = c.String(maxLength: 15),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryId = c.Int(nullable: false),
                        ProductSizeId = c.Int(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Barcode = c.String(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.ProductSize", t => t.ProductSizeId, cascadeDelete: true)
                .Index(t => t.ProductCode, unique: true, name: "ProductIndex")
                .Index(t => t.CategoryId)
                .Index(t => t.ProductSizeId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryText = c.String(),
                        CategoryCode = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.CategoryId)
                .Index(t => t.CategoryCode, unique: true, name: "CategoryIndex");
            
            CreateTable(
                "dbo.ProductSize",
                c => new
                    {
                        ProductSizeId = c.Int(nullable: false, identity: true),
                        ProductSizeText = c.String(),
                        ProductSizeColorCode_Cyan = c.Int(nullable: false),
                        ProductSizeColorCode_Magenta = c.Int(nullable: false),
                        ProductSizeColorCode_Yellow = c.Int(nullable: false),
                        ProductSizeColorCode_KeyColor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductSizeId);
            
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
            
            CreateTable(
                "dbo.SleeveSize",
                c => new
                    {
                        ProductSizeId = c.Int(nullable: false),
                        DisplayDim_Width = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DisplayDim_Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DisplayDim_Length = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DisplayDim_Depth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FitCardDim_Width = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FitCardDim_Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FitCardDim_Length = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FitCardDim_Depth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NGBoxDim_Width = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NGBoxDim_Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NGBoxDim_Length = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NGBoxDim_Depth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NGSleeveDim_Width = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NGSleeveDim_Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NGSleeveDim_Length = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NGSleeveDim_Depth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OuterCartonDim_Width = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OuterCartonDim_Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OuterCartonDim_Length = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OuterCartonDim_Depth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StandardSleeveDim_Width = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StandardSleeveDim_Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StandardSleeveDim_Length = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StandardSleeveDim_Depth = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductSizeId)
                .ForeignKey("dbo.ProductSize", t => t.ProductSizeId)
                .Index(t => t.ProductSizeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SleeveSize", "ProductSizeId", "dbo.ProductSize");
            DropForeignKey("dbo.OrderItem", "Order_OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "Customer_PersonId", "dbo.Person");
            DropForeignKey("dbo.Person", "Credential_CredentialsId", "dbo.Credential");
            DropForeignKey("dbo.OrderItem", "Product_ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "ProductSizeId", "dbo.ProductSize");
            DropForeignKey("dbo.ProductFitGame", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.ProductFitGame", "GameId", "dbo.Game");
            DropIndex("dbo.SleeveSize", new[] { "ProductSizeId" });
            DropIndex("dbo.Person", new[] { "Credential_CredentialsId" });
            DropIndex("dbo.Order", new[] { "Customer_PersonId" });
            DropIndex("dbo.OrderItem", new[] { "Order_OrderId" });
            DropIndex("dbo.OrderItem", new[] { "Product_ProductId" });
            DropIndex("dbo.Category", "CategoryIndex");
            DropIndex("dbo.Product", new[] { "ProductSizeId" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropIndex("dbo.Product", "ProductIndex");
            DropIndex("dbo.ProductFitGame", new[] { "GameId" });
            DropIndex("dbo.ProductFitGame", new[] { "ProductId" });
            DropIndex("dbo.Game", "GameIndex");
            DropTable("dbo.SleeveSize");
            DropTable("dbo.Person");
            DropTable("dbo.Order");
            DropTable("dbo.OrderItem");
            DropTable("dbo.ProductSize");
            DropTable("dbo.Category");
            DropTable("dbo.Product");
            DropTable("dbo.ProductFitGame");
            DropTable("dbo.Game");
            DropTable("dbo.Credential");
        }
    }
}
