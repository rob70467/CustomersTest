namespace DataAccessLayer
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    /// <summary>
    /// In memory context with data seeding
    /// </summary>
    public class CustomerDBContext : DbContext
    {
        public DbSet<CustomerEntity?> Customers { get; set; }

        public CustomerDBContext(DbContextOptions<CustomerDBContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data
            modelBuilder.Entity<CustomerEntity>().HasData(
                new CustomerEntity { Id = 1, Name = "CustomerName 1", Reference = "Ref 1" },
                new CustomerEntity { Id = 2, Name = "CustomerName 2", Reference = "Ref 2" },
                new CustomerEntity { Id = 3, Name = "CustomerName 3", Reference = "Ref 3" },
                new CustomerEntity { Id = 4, Name = "CustomerName 4", Reference = "Ref 4" },
                new CustomerEntity { Id = 5, Name = "CustomerName 5", Reference = "Ref 5" }
            );
        }
    }
}
