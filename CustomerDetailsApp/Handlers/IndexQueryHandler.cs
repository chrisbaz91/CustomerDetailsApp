using CustomerDetailsApp.DataAccess;
using CustomerDetailsApp.ViewModels;

namespace CustomerDetailsApp.Handlers
{
    public class IndexQueryHandler(ICustomerRepository repo)
    {
        public async Task<IndexModel> Handle()
        {
            return new IndexModel()
            {
                List = [.. (await repo.GetCustomers())
                .Select(x => new ListItemModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Postcode = x.Postcode,
                    DateRegistered = x.DateRegistered.ToShortDateString()
                })]
            };
        }
    }
}
