using CustomerDetailsApp.Models;
using CustomerDetailsApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CustomerDetailsApp.DataAccess
{
    public class CustomerRepository(CustomerContext context) : ICustomerRepository
    {
        public async Task<List<Customer>> GetCustomers()
        {
            return await context.Customers.ToListAsync();
        }

        public async Task<bool> CustomerExists(Guid id)
        {
            return await context.Customers.AnyAsync(e => e.Id == id);
        }

        public async Task<Customer> GetCustomer(Guid id)
        {
            return await context.Customers.FindAsync(id);
        }

        public async Task<Guid> AddCustomer(Customer customer)
        {
            await context.Customers.AddAsync(customer);

            await context.SaveChangesAsync();

            return customer.Id;
        }

        public async Task<bool> UpdateCustomer(EditModel model)
        {
            var customer = await GetCustomer(model.Id);

            UpdateCustomerModel(customer, model);

            await context.SaveChangesAsync();

            return true;
        }

        private static void UpdateCustomerModel(Customer customer, EditModel model)
        {
            customer.Name = model.Name;
            customer.Age = model.Age;
            customer.Postcode = model.Postcode;
            customer.Height = model.Height;
        }

        public async Task<bool> RemoveCustomer(Guid id)
        {
            var customer = await GetCustomer(id);

            context.Customers.Remove(customer);

            await context.SaveChangesAsync();

            return true;
        }
    }
}
