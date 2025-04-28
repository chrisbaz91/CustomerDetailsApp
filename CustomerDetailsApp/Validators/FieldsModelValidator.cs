using CustomerDetailsApp.ViewModels;
using FluentValidation;

namespace CustomerDetailsApp.Validators
{
    public class FieldsModelValidator : AbstractValidator<FieldsModel>
    {
        public FieldsModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Please enter your name.")
                .MaximumLength(50)
                .WithMessage("Please enter a name less than 50 characters.");
            RuleFor(x => x.Age)
                .NotNull()
                .WithMessage("Please enter your age.")
                .InclusiveBetween(0, 110)
                .WithMessage("Please enter an age between 0 and 110.");
            RuleFor(x => x.Height)
                .NotNull()
                .WithMessage("Please enter your height.")
                .InclusiveBetween(0, 2.50)
                .WithMessage("Please enter a height between 0 and 2.50 metres.");
            RuleFor(x => x.Height.ToString())
                .Matches("^[0-2](\\.\\d{0,2})?$")
                .WithMessage("Please enter a height with no more than two decimal places.");
            RuleFor(x => x.Postcode)
                .NotEmpty()
                .WithMessage("Please enter a postcode.")
                .Matches("([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9][A-Za-z]?))))\\s?[0-9][A-Za-z]{2})")
                .WithMessage("Please enter a valid postcode.");
        }
    }
}