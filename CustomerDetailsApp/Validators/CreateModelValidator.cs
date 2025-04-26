using CustomerDetailsApp.ViewModels;
using FluentValidation;

namespace CustomerDetailsApp.Validators
{
    public class CreateModelValidator : AbstractValidator<CreateModel>/* : FieldsModelValidator*/
    {
        public CreateModelValidator()
        {
            Include(new FieldsModelValidator());
        }
    }
}