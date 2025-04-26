using CustomerDetailsApp.DataAccess;
using CustomerDetailsApp.ViewModels;

namespace CustomerDetailsApp.Handlers
{
    public class EditModelHandler(ICustomerRepository repo)
    {
        public async Task<bool> Handle(EditModel model)
        {
            try
            {
                repo.UpdateCustomer(model);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
