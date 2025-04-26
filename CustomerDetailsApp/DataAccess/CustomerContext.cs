using Microsoft.EntityFrameworkCore;
using CustomerDetailsApp.Models;

namespace CustomerDetailsApp.DataAccess
{
    public class CustomerContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "CustomerDb");
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
