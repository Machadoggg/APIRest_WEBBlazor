using APIRest_WEBBlazor.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIRest_WEBBlazor.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Creacion de index
            modelBuilder.Entity<Customer>().HasIndex(x => x.Document).IsUnique();
        }
    }
}
