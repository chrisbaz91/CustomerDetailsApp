using CustomerDetailsApp.DataAccess;
using CustomerDetailsApp.ViewModels;

namespace CustomerDetailsApp.Handlers
{
    public class DeleteQueryHandler(ICustomerRepository repo)
    {
        public async Task<bool> Handle(DeleteQuery query)
        {
            try
            {
                await repo.RemoveCustomer(query.Id);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
