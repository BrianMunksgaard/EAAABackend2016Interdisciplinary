namespace bgs.Migrations
{
    using DAL;
    using Models;
    using System;
    using System.Data.Entity.Migrations;

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


            Sleeve bgsOversize = new Sleeve { ProductId = 10408, ProductCode = "AT-10408", ProductName = "Board Game Sleeves - Oversize", Price = 20M, CategoryId = Sleeves.CategoryId, SleeveSize = Size.Oversize };
            context.Products.AddOrUpdate(bgsOversize);
            Sleeve bgsExtraLarge = new Sleeve { ProductId = 10407, ProductCode = "AT-10407", ProductName = "Board Game Sleeves - Extra Large", Price = 20M, CategoryId = Sleeves.CategoryId, SleeveSize = Size.ExtraLarge };
            context.Products.AddOrUpdate(bgsExtraLarge);
            Sleeve bgsLarge = new Sleeve { ProductId = 10402, ProductCode = "AT-10402", ProductName = "Board Game Sleeves - Large", Price = 18M, CategoryId = Sleeves.CategoryId, SleeveSize = Size.Large };
            context.Products.AddOrUpdate(bgsLarge);
            Sleeve bgsStandard = new Sleeve { ProductId = 10406, ProductCode = "AT-10406", ProductName = "Board Game Sleeves - Standard", Price = 16M, CategoryId = Sleeves.CategoryId, SleeveSize = Size.Standard };
            context.Products.AddOrUpdate(bgsStandard);
            Sleeve bgsMedium = new Sleeve { ProductId = 10403, ProductCode = "AT-10403", ProductName = "Board Game Sleeves - Medium", Price = 14M, CategoryId = Sleeves.CategoryId, SleeveSize = Size.Medium };
            context.Products.AddOrUpdate(bgsMedium);
            Sleeve bgsSmall = new Sleeve { ProductId = 10404, ProductCode = "AT-10404", ProductName = "Board Game Sleeves - Small", Price = 12M, CategoryId = Sleeves.CategoryId, SleeveSize = Size.Small };
            context.Products.AddOrUpdate(bgsSmall);
            Sleeve bgsMini = new Sleeve { ProductId = 10405, ProductCode = "AT-10405", ProductName = "Board Game Sleeves - Mini", Price = 10M, CategoryId = Sleeves.CategoryId, SleeveSize = Size.Mini };
            context.Products.AddOrUpdate(bgsMini);
            Sleeve bgsSquare = new Sleeve { ProductId = 10409, ProductCode = "AT-10409", ProductName = "Board Game Sleeves - Square", Price = 10M, CategoryId = Sleeves.CategoryId, SleeveSize = Size.Square };
            context.Products.AddOrUpdate(bgsSquare);
            Sleeve bgsTarot = new Sleeve { ProductId = 10410, ProductCode = "AT-10410", ProductName = "Board Game Sleeves - Tarot", Price = 22M, CategoryId = Sleeves.CategoryId, SleeveSize = Size.Tarot };
            context.Products.AddOrUpdate(bgsTarot);
            context.SaveChanges();


            //Dimensions 


            Game acquire = new Game { GameId = 1, GameCode = "G-001", GameName = "Acquire" };
            context.Games.AddOrUpdate(acquire);
            Game arkhamHorror = new Game { GameId = 2, GameCode = "G-002", GameName = "Arkham Horror" };
            context.Games.AddOrUpdate(arkhamHorror);
            context.SaveChanges();


            ProductFitGame acquireSleeve = new ProductFitGame { GameId = acquire.GameId, ProductId = bgsMedium.ProductId, Comment = "" };
            context.ProductGames.AddOrUpdate(acquireSleeve);
            acquire.ProductsFit.Add(acquireSleeve);
            bgsMedium.FitsGames.Add(acquireSleeve);
            ProductFitGame arkhamHorrorSleeve = new ProductFitGame { GameId = arkhamHorror.GameId, ProductId = bgsMedium.ProductId, Comment = "Big cards" };
            context.ProductGames.AddOrUpdate(arkhamHorrorSleeve);
            arkhamHorror.ProductsFit.Add(arkhamHorrorSleeve);
            bgsMedium.FitsGames.Add(arkhamHorrorSleeve);
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
