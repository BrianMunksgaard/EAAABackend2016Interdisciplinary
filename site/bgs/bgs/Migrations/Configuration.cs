namespace bgs.Migrations
{
    using DAL;
    using Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Drawing;

    internal sealed class Configuration : DbMigrationsConfiguration<BgsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BgsContext context)
        {
            //  This method will be called after migrating to the latest version.

            Person admin = new Person { PersonId = 1, FirstName = "Adrian", LastName = "Leon", Address = "Gåsevænget 13", Zip = "4812", City = "Stubbekøbning", BirthDay = new System.DateTime(1932, 6, 9) };
            admin.Credential = new Credential { UserName = "admin", UserPass = "admin" };
            admin.Roles.Add(Role.Administrator);
            context.Persons.AddOrUpdate(admin);
            Person customer = new Person { PersonId = 2, FirstName = "Robert", LastName = "Englund", Address = "Elm Street 669", Zip = "48312", City = "Springwood", BirthDay = new System.DateTime(1932, 6, 9) };
            customer.Roles.Add(Role.Customer);
            context.Persons.AddOrUpdate(customer);
            context.SaveChanges();


            Category Sleeves = new Category { CategoryId = 1, CategoryCode = "CA-01", CategoryText = "Sleeves" };
            context.ProductCategories.AddOrUpdate(Sleeves);
            context.SaveChanges();

                        
            /*
             * Sleeve sizes.
             */
            int productSizeId = 0;
            SleeveSize sizeOversize = new SleeveSize
            {
                ProductSizeId = ++productSizeId, ProductSizeText = "Oversize",
                DisplayDim = new Dimension
                {
                    Length = 225, Width = 115, Height = 135
                },
                FitCardDim = new Dimension
                {
                    Width = 79, Height = 120 
                },
                StandardSleeveDim = new Dimension
                {
                    Width = 82, Height = 124
                },
                NGSleeveDim = new Dimension
                {
                    Width = 82, Height = 124
                },
                NGBoxDim = new Dimension
                {
                    Width = 85, Height = 126, Depth = 27
                },
                OuterCartonDim = new Dimension
                {
                    Length = 347, Width = 227, Height = 272

                },
                ProductSizeColorCode = new CMYK
                {
                    Cyan = 36, Magenta = 57, Yellow =84, KeyColor = 23
                }
            };
            context.SleeveSizes.AddOrUpdate(sizeOversize);

            SleeveSize sizeExtraLarge = new SleeveSize
            {
                ProductSizeId = ++productSizeId, ProductSizeText = "Extra Large",
                DisplayDim = new Dimension
                {

                },
                FitCardDim = new Dimension
                {

                },
                StandardSleeveDim = new Dimension
                {

                },
                NGSleeveDim = new Dimension
                {

                },
                NGBoxDim = new Dimension
                {

                },
                OuterCartonDim = new Dimension
                {

                },
                ProductSizeColorCode = new CMYK
                {
                    Cyan = 69, Magenta = 90, Yellow = 0, KeyColor = 0
                }
            };
            context.SleeveSizes.AddOrUpdate(sizeExtraLarge);

            SleeveSize bgsLarge = new SleeveSize { ProductId = 10402, ProductCode = "AT-10402", ProductName = "Board Game Sleeves - Large", Price = 18M, CategoryId = Sleeves.CategoryId, SleeveSize = Size.Large };
            context.Products.AddOrUpdate(bgsLarge);
            SleeveSize bgsStandard = new SleeveSize { ProductId = 10406, ProductCode = "AT-10406", ProductName = "Board Game Sleeves - Standard", Price = 16M, CategoryId = Sleeves.CategoryId, SleeveSize = Size.Standard };
            context.Products.AddOrUpdate(bgsStandard);
            SleeveSize bgsMedium = new SleeveSize { ProductId = 10403, ProductCode = "AT-10403", ProductName = "Board Game Sleeves - Medium", Price = 14M, CategoryId = Sleeves.CategoryId, SleeveSize = Size.Medium };
            context.Products.AddOrUpdate(bgsMedium);
            SleeveSize bgsSmall = new SleeveSize { ProductId = 10404, ProductCode = "AT-10404", ProductName = "Board Game Sleeves - Small", Price = 12M, CategoryId = Sleeves.CategoryId, SleeveSize = Size.Small };
            context.Products.AddOrUpdate(bgsSmall);
            SleeveSize bgsMini = new SleeveSize { ProductId = 10405, ProductCode = "AT-10405", ProductName = "Board Game Sleeves - Mini", Price = 10M, CategoryId = Sleeves.CategoryId, SleeveSize = Size.Mini };
            context.Products.AddOrUpdate(bgsMini);
            SleeveSize bgsSquare = new SleeveSize { ProductId = 10409, ProductCode = "AT-10409", ProductName = "Board Game Sleeves - Square", Price = 10M, CategoryId = Sleeves.CategoryId, SleeveSize = Size.Square };
            context.Products.AddOrUpdate(bgsSquare);
            SleeveSize bgsTarot = new SleeveSize { ProductId = 10410, ProductCode = "AT-10410", ProductName = "Board Game Sleeves - Tarot", Price = 22M, CategoryId = Sleeves.CategoryId, SleeveSize = Size.Tarot };
            context.Products.AddOrUpdate(bgsTarot);
            context.SaveChanges();

            /*
             * Products. 
             */
            productSizeId = 0;

            Product prdOversize = new Product
            {
                ProductId = 10408,
                ProductCode = "AT-10408",
                ProductName = "Board Game Sleeves - Oversize",
                Price = 20M,
                CategoryId = Sleeves.CategoryId,
                Weight = 0,
                ProductSizeId = ++productSizeId
            };
            context.Products.AddOrUpdate(prdOversize);

            Product prdExtraLarge = new Product
            {
                ProductId = 10407,
                ProductCode = "AT-10407",
                ProductName = "Board Game Sleeves - Extra Large",
                Price = 20M,
                CategoryId = Sleeves.CategoryId,
                ProductSizeId = ++productSizeId
            };
            context.Products.AddOrUpdate(prdExtraLarge);

            Product prdLarge = new Product
            {
                ProductId = 10402,
                ProductCode = "AT-10402",
                ProductName = "Board Game Sleeves - Large",
                Price = 18M,
                CategoryId = Sleeves.CategoryId,
                ProductSizeId = ++productSizeId
            };
            context.Products.AddOrUpdate(prdLarge);

            Product prdStandard = new Product
            {
                ProductId = 10406,
                ProductCode = "AT-10406",
                ProductName = "Board Game Sleeves - Standard",
                Price = 16M,
                CategoryId = Sleeves.CategoryId,
                ProductSizeId = ++productSizeId
            };
            context.Products.AddOrUpdate(prdStandard);

            Product prdMedium = new Product
            {
                ProductId = 10403,
                ProductCode = "AT-10403",
                ProductName = "Board Game Sleeves - Medium",
                Price = 14M,
                CategoryId = Sleeves.CategoryId,
                ProductSizeId = ++productSizeId
            };
            context.Products.AddOrUpdate(prdMedium);

            Product prdSmall = new Product
            {
                ProductId = 10404,
                ProductCode = "AT-10404",
                ProductName = "Board Game Sleeves - Small",
                Price = 12M,
                CategoryId = Sleeves.CategoryId,
                ProductSizeId = ++productSizeId
            };
            context.Products.AddOrUpdate(prdSmall);

            Product prdMini = new Product
            {
                ProductId = 10405,
                ProductCode = "AT-10405",
                ProductName = "Board Game Sleeves - Mini",
                Price = 10M,
                CategoryId = Sleeves.CategoryId,
                ProductSizeId = ++productSizeId
            };
            context.Products.AddOrUpdate(prdMini);

            Product prdSquare = new Product
            {
                ProductId = 10409,
                ProductCode = "AT-10409",
                ProductName = "Board Game Sleeves - Square",
                Price = 10M,
                CategoryId = Sleeves.CategoryId,
                ProductSizeId = ++productSizeId
            };
            context.Products.AddOrUpdate(prdSquare);

            Product prdTarot = new Product
            {
                ProductId = 10410,
                ProductCode = "AT-10410",
                ProductName = "Board Game Sleeves - Tarot",
                Price = 22M,
                CategoryId = Sleeves.CategoryId,
                ProductSizeId = ++productSizeId
            };
            context.Products.AddOrUpdate(prdTarot);
            context.SaveChanges();


            /*
             * Games.
             */
            Game acquire = new Game
            {
                GameId = 1,
                GameCode = "G-001",
                GameName = "Acquire"
            };
            context.Games.AddOrUpdate(acquire);

            Game arkhamHorror = new Game
            {
                GameId = 2,
                GameCode = "G-002",
                GameName = "Arkham Horror"
            };
            context.Games.AddOrUpdate(arkhamHorror);
            context.SaveChanges();

            /*
             * Products and Game fit.
             */
            ProductFitGame acquireSleeve = new ProductFitGame { GameId = acquire.GameId, ProductId = prdMedium.ProductId, Comment = "" };
            context.ProductGames.AddOrUpdate(acquireSleeve);
            acquire.ProductsFit.Add(acquireSleeve);
            prdMedium.FitsGames.Add(acquireSleeve);
            ProductFitGame arkhamHorrorSleeve = new ProductFitGame { GameId = arkhamHorror.GameId, ProductId = prdMedium.ProductId, Comment = "Big cards" };
            context.ProductGames.AddOrUpdate(arkhamHorrorSleeve);
            arkhamHorror.ProductsFit.Add(arkhamHorrorSleeve);
            prdMedium.FitsGames.Add(arkhamHorrorSleeve);
            context.SaveChanges();


            OrderItem firstOrderItem = new OrderItem(bgsTarot, 1);


            Order firstOrder = new Order(DateTime.Now);
            firstOrder.CustomerId = customer.PersonId;
            firstOrder.AddItem(bgsTarot, 1);
            //firstOrder.OrderItems.Add(firstOrderItem);
            context.Orders.AddOrUpdate(firstOrder);


            /**
             * Cart
             */

        }
    }
}
