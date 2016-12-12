using bgs.Models;
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

        public virtual DbSet<CategoryProperties> CategoryProperties { get; set; }

        public virtual DbSet<ProductGame> ProductGames { get; set; }


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
            context.Games.Add(new Game { GameCode = "G-001", GameName = "Acquire" });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}