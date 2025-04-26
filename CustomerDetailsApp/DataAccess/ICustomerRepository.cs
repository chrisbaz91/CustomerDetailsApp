using CustomerDetailsApp.Models;
using CustomerDetailsApp.ViewModels;

namespace CustomerDetailsApp.DataAccess
{
    public interface ICustomerRepository
    {
        public Task<List<Customer>> GetCustomers();

        public Task<bool> CustomerExists(Guid id);

        public Task<Customer> GetCustomer(Guid id);

        public Task<Guid> AddCustomer(Customer customer);

        public Task<bool> UpdateCustomer(EditModel model);

        public Task<bool> RemoveCustomer(Guid id);
    }
}
