using bgs.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace bgs.DAL
{
    public class BgsContext : DbContext
    {

        public BgsContext() : base("BgsContext")
        {
        }


        public virtual DbSet<Game> Games { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Dimension> Dimensions { get; set; }

        public virtual DbSet<Category> ProductCategories { get; set; }

        public virtual DbSet<Sleeve> Sleeves { get; set; }

        public virtual DbSet<ProductFitGame> ProductGames { get; set; }

        public virtual DbSet<Person> Persons { get; set; }

        public virtual DbSet<Credential> Credentials { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }

}