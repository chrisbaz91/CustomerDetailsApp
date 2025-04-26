using CustomerDetailsApp.DataAccess;
using CustomerDetailsApp.Models;
using CustomerDetailsApp.ViewModels;

namespace CustomerDetailsApp.Handlers
{
    public class CreateModelHandler(ICustomerRepository repo)
    {
        public async Task<Guid> Handle(CreateModel model)
        {
            var customer = CreateCustomer(model);

            return await repo.AddCustomer(customer);
        }

        private static Customer CreateCustomer(CreateModel model)
        {
            return new Customer(
                model.Name,
                model.Age,
                model.Postcode,
                model.Height,
                DateTime.Now
                );
        }
    }
}
