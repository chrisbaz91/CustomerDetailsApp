using CustomerDetailsApp.ViewModels;
using FluentValidation;

namespace CustomerDetailsApp.Validators
{
    public class CreateModelValidator : AbstractValidator<CreateModel>
    {
        public CreateModelValidator()
        {
            Include(new FieldsModelValidator());
        }
    }
}