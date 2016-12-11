using System.Data.Entity;

namespace bgs.DAL
{
    public class BgsContext : DbContext
    {

        public BgsContext() : base("BgsContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}