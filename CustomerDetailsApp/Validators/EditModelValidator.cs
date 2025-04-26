using CustomerDetailsApp.ViewModels;
using FluentValidation;

namespace CustomerDetailsApp.Validators
{
    public class EditModelValidator : AbstractValidator<EditModel>
    {
        public EditModelValidator()
        {
            Include(new FieldsModelValidator());
        }
    }
}