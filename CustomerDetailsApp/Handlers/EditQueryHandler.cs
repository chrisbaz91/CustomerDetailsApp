using CustomerDetailsApp.DataAccess;
using CustomerDetailsApp.Models;
using CustomerDetailsApp.ViewModels;

namespace CustomerDetailsApp.Handlers
{
    public class EditQueryHandler(ICustomerRepository repo)
    {
        public async Task<EditModel> Handle(EditQuery query)
        {
            Customer customer = await repo.GetCustomer(query.Id);

            return new EditModel()
            {
                Id = customer.Id,
                Name = customer.Name,
                Age = customer.Age,
                Postcode = customer.Postcode,
                Height = customer.Height
            };
        }
    }
}
