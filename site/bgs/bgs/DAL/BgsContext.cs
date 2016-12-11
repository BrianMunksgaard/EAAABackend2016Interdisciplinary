using bgs.Models;
using System.Data.Entity;

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

        public virtual DbSet<ProductCategory> ProductCategories { get; set; }

        public virtual DbSet<CategoryProperties> CategoryProperties { get; set; }

        public virtual DbSet<ProductGame> ProductGames { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }

    public class BgsContextInitializer : DropCreateDatabaseIfModelChanges<BgsContext>
    {
        protected override void Seed(BgsContext context)
        {


            base.Seed(context);
        }
    }
}