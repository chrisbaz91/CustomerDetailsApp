using CustomerDetailsApp.Validators;
using CustomerDetailsApp.ViewModels;
using FluentValidation.TestHelper;

namespace CustomerDetailsAppUnitTests
{
    public class FieldsModelValidatorTests
    {
        private readonly FieldsModelValidator validator;
        private readonly CreateModel testCustomer;

        public FieldsModelValidatorTests()
        {
            validator = new();
            testCustomer = new()
            {
                Name = "TestCustomer",
                Age = 20,
                Postcode = "BS1 1AA",
                Height = 2
            };
        }

        [Fact]
        public async Task Validate_ValidData_NoValidationErrors()
        {
            var results = await validator.TestValidateAsync(testCustomer);

            Assert.NotNull(results);
            Assert.True(results.IsValid);
            results.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public async Task Validate_NameIsEmpty_ValidationErrorForName()
        {
            testCustomer.Name = "";

            var results = await validator.TestValidateAsync(testCustomer);

            Assert.NotNull(results);
            Assert.False(results.IsValid);
            results.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public async Task Validate_NameTooLong_ValidationErrorForName()
        {
            testCustomer.Name = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            var results = await validator.TestValidateAsync(testCustomer);

            Assert.NotNull(results);
            Assert.False(results.IsValid);
            results.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public async Task Validate_AgeTooLow_ValidationErrorForAge()
        {
            testCustomer.Age = -1;

            var results = await validator.TestValidateAsync(testCustomer);

            Assert.NotNull(results);
            Assert.False(results.IsValid);
            results.ShouldHaveValidationErrorFor(x => x.Age);
        }

        [Fact]
        public async Task Validate_AgeTooHigh_ValidationErrorForAge()
        {
            testCustomer.Age = 120;

            var results = await validator.TestValidateAsync(testCustomer);

            Assert.NotNull(results);
            Assert.False(results.IsValid);
            results.ShouldHaveValidationErrorFor(x => x.Age);
        }

        [Fact]
        public async Task Validate_HeightTooLow_ValidationErrorForHeight()
        {
            testCustomer.Height = -1;

            var results = await validator.TestValidateAsync(testCustomer);

            Assert.NotNull(results);
            Assert.False(results.IsValid);
            results.ShouldHaveValidationErrorFor(x => x.Height);
        }

        [Fact]
        public async Task Validate_HeightTooHigh_ValidationErrorForHeight()
        {
            testCustomer.Height = 2.51;

            var results = await validator.TestValidateAsync(testCustomer);

            Assert.NotNull(results);
            Assert.False(results.IsValid);
            results.ShouldHaveValidationErrorFor(x => x.Height);
        }

        [Fact]
        public async Task Validate_HeightTooManyDecimalPlaces_ValidationErrorForHeight()
        {
            testCustomer.Height = 1.11111111111111111111;

            var results = await validator.TestValidateAsync(testCustomer);

            Assert.NotNull(results);
            Assert.False(results.IsValid);
            results.ShouldHaveValidationErrorFor(x => x.Height.ToString());
        }

        [Fact]
        public async Task Validate_PostcodeIsEmpty_ValidationErrorForPostcode()
        {
            testCustomer.Postcode = "";

            var results = await validator.TestValidateAsync(testCustomer);

            Assert.NotNull(results);
            Assert.False(results.IsValid);
            results.ShouldHaveValidationErrorFor(x => x.Postcode);
        }

        [Fact]
        public async Task Validate_PostcodeIncorrectFormat_ValidationErrorForPostcode()
        {
            testCustomer.Postcode = "111AAA";

            var results = await validator.TestValidateAsync(testCustomer);

            Assert.NotNull(results);
            Assert.False(results.IsValid);
            results.ShouldHaveValidationErrorFor(x => x.Postcode);
        }
    }
}
