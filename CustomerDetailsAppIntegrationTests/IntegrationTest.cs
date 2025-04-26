using CustomerDetailsApp.DataAccess;
using CustomerDetailsApp.Models;

namespace CustomerDetailsAppIntegrationTests
{
    public class IntegrationTest : IDisposable
    {
        protected readonly CustomerContext context;

        public IntegrationTest()
        {
            context = new();
        }

        public async void Dispose()
        {
            context.RemoveRange(context.Customers);
            await context.SaveChangesAsync();
        }

        protected async Task<T> FindAsync<T>(Guid id) where T : Entity
        {
            return await context.Set<T>().FindAsync(id);
        }

        protected async Task InsertAsync<T>(T entity) where T : Entity
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        protected async Task InsertRangeAsync<T>(List<T> entities) where T : Entity
        {
            await context.AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }
    }
}