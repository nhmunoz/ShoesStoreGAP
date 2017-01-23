using ShoesStore.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ShoesStore.DAL
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("StoreConnectionString")
        {
        }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}