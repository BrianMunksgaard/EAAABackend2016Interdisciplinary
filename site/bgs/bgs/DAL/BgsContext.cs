using bgs.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace bgs.DAL
{
    /// <summary>
    /// This is the context class that the Entity Framework 
    /// will use for its integration and handling of access 
    /// to the database.
    /// </summary>
    public class BgsContext : DbContext
    {

        public BgsContext() : base("BgsContext")
        {
        }


        public virtual DbSet<Game> Games { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Category> ProductCategories { get; set; }

        public virtual DbSet<SleeveSize> SleeveSizes { get; set; }

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