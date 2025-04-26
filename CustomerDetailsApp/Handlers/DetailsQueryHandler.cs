using CustomerDetailsApp.DataAccess;
using CustomerDetailsApp.ViewModels;

namespace CustomerDetailsApp.Handlers
{
    public class DetailsQueryHandler(ICustomerRepository repo)
    {
        public async Task<DetailsModel> Handle(DetailsQuery query)
        {
            var customer = await repo.GetCustomer(query.Id);

            return new DetailsModel()
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
