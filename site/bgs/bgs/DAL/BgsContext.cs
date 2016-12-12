﻿using bgs.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace bgs.DAL
{
    public class BgsContext : DbContext
    {

        public BgsContext() : base("BgsContext")
        {
            Database.SetInitializer(new BgsContextInitializer());
        }


        public virtual DbSet<Game> Games { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Dimensions> Dimensions { get; set; }

        public virtual DbSet<Category> ProductCategories { get; set; }

        public virtual DbSet<Sleeve> CategoryProperties { get; set; }

        public virtual DbSet<ProductGame> ProductGames { get; set; }

        public virtual DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //base.OnModelCreating(modelBuilder);
        }

    }

    public class BgsContextInitializer : DropCreateDatabaseAlways<BgsContext>
    {
        protected override void Seed(BgsContext context)
        {
            // TODO: Missing information about the Role
            Person admin = new Person { PersonId = 1, FirstName = "Adrian", LastName = "Leon", Address = "Gåsevænget 13", Zip = "4812", City = "Stubbekøbning", BirthDay = new System.DateTime(1932, 6, 9) };
            context.Persons.Add(admin);
            context.SaveChanges();


            Category Sleeves = new Category { CategoryId = 1, CategoryCode = "CA-01", CategoryText = "Sleeves" };
            context.ProductCategories.Add(Sleeves);
            context.SaveChanges();


            // TODO: Products are missing category reference and property reference
            Sleeve bgsOversize = new Sleeve { ProductId = 10408, ProductCode = "AT-10408", ProductName = "Board Game Sleeves - Oversize", Price = 20M };
            context.Products.Add(bgsOversize);
            Sleeve bgsExtraLarge = new Sleeve { ProductId = 10407, ProductCode = "AT-10407", ProductName = "Board Game Sleeves - Extra Large", Price = 20M };
            context.Products.Add(bgsExtraLarge);
            Sleeve bgsLarge = new Sleeve { ProductId = 10402, ProductCode = "AT-10402", ProductName = "Board Game Sleeves - Large", Price = 18M };
            context.Products.Add(bgsLarge);
            Sleeve bgsStandard = new Sleeve { ProductId = 10406, ProductCode = "AT-10406", ProductName = "Board Game Sleeves - Standard", Price = 16M };
            context.Products.Add(bgsStandard);
            Sleeve bgsMedium = new Sleeve { ProductId = 10403, ProductCode = "AT-10403", ProductName = "Board Game Sleeves - Medium", Price = 14M };
            context.Products.Add(bgsMedium);
            Sleeve bgsSmall = new Sleeve { ProductId = 10404, ProductCode = "AT-10404", ProductName = "Board Game Sleeves - Small", Price = 12M };
            context.Products.Add(bgsSmall);
            Sleeve bgsMini = new Sleeve { ProductId = 10405, ProductCode = "AT-10405", ProductName = "Board Game Sleeves - Mini", Price = 10M };
            context.Products.Add(bgsMini);
            Sleeve bgsSquare = new Sleeve { ProductId = 10409, ProductCode = "AT-10409", ProductName = "Board Game Sleeves - Square", Price = 10M };
            context.Products.Add(bgsSquare);
            Sleeve bgsTarot = new Sleeve { ProductId = 10410, ProductCode = "AT-10410", ProductName = "Board Game Sleeves - Tarot", Price = 22M };
            context.Products.Add(bgsTarot);
            context.SaveChanges();


            Game acquire = new Game { GameId = 1, GameCode = "G-001", GameName = "Acquire" };
            context.Games.Add(acquire);
            Game arkhamHorror = new Game { GameId = 2, GameCode = "G-002", GameName = "Arkham Horror" };
            context.Games.Add(arkhamHorror);
            context.SaveChanges();


            ProductGame acquireSleeve = new ProductGame { GameId = acquire.GameId, ProductId = bgsMedium.ProductId, Comment = "" };
            context.ProductGames.Add(acquireSleeve);
            acquire.ProductsFit.Add(acquireSleeve);
            bgsMedium.FitsGames.Add(acquireSleeve);
            ProductGame arkhamHorrorSleeve = new ProductGame { GameId = arkhamHorror.GameId, ProductId = bgsMedium.ProductId, Comment = "Big cards" };
            context.ProductGames.Add(arkhamHorrorSleeve);
            arkhamHorror.ProductsFit.Add(arkhamHorrorSleeve);
            bgsMedium.FitsGames.Add(arkhamHorrorSleeve);
            context.SaveChanges();



            /**
             * Dimension
             * CategoryProperties
             * 
             * Cart
             * Order
             * OrderItem
             */


            base.Seed(context);
        }
    }
}