using CustomerDetailsApp.Models;

namespace CustomerDetailsApp.DataAccess
{
    public class SeedData
    {
        public static async Task SetInitialData()
        {
            var chrisBarrett = new Customer("Chris Barrett", 33, "BS30 7ED", 1.7, DateTime.Now.AddDays(-7));
            var peterParker = new Customer("Peter Parker", 25, "NY1 1AA", 1.5, DateTime.Now.AddDays(-3));
            var tonyStark = new Customer("Tony Stark", 37, "NY2 2BB", 1.8, DateTime.Now);
            var jessicaJones = new Customer("Jessica Jones", 32, "NY3 3CC", 1.2, DateTime.Now);

            using var context = new CustomerContext();

            await context.Customers.AddRangeAsync(chrisBarrett, peterParker, tonyStark, jessicaJones);

            await context.SaveChangesAsync();
        }
    }
}
