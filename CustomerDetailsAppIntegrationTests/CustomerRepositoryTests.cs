using CustomerDetailsApp.DataAccess;
using CustomerDetailsApp.Models;
using CustomerDetailsApp.ViewModels;

namespace CustomerDetailsAppIntegrationTests
{
    public class CustomerRepositoryTests : IntegrationTest
    {
        private readonly CustomerRepository repo;
        private readonly Customer testCustomer1;
        private readonly Customer testCustomer2;

        public CustomerRepositoryTests()
        {
            repo = new(context);
            testCustomer1 = new("TestCustomer1", 20, "BS1 1AA", 2, DateTime.Now);
            testCustomer2 = new("TestCustomer2", 25, "BS2 2BB", 1.5, DateTime.Now);
        }

        [Fact]
        public async Task GetCustomers_NoCustomers_ReturnsEmptyList()
        {
            var results = await repo.GetCustomers();

            Assert.NotNull(results);
            Assert.Empty(results);
        }

        [Fact]
        public async Task GetCustomers_CustomersExist_ReturnsAllCustomers()
        {
            var customers = new List<Customer>()
            {
                testCustomer1,
                testCustomer2
            };
            await InsertRangeAsync(customers);

            var results = await repo.GetCustomers();

            Assert.NotNull(results);
            Assert.Equal(customers.Count, results.Count);
        }

        [Fact]
        public async Task GetCustomer_SearchedCustomerDoesNotExist_ReturnsNull()
        {
            var customers = new List<Customer>()
            {
                testCustomer1,
                testCustomer2
            };
            await InsertRangeAsync(customers);

            var result = await repo.GetCustomer(new Guid());

            Assert.Null(result);
        }

        [Fact]
        public async Task GetCustomer_CustomersExist_ReturnsCorrectCustomer()
        {
            var customers = new List<Customer>()
            {
                testCustomer1,
                testCustomer2
            };
            await InsertRangeAsync(customers);

            var result = await repo.GetCustomer(customers.First().Id);

            Assert.NotNull(result);
            Assert.Equal(customers.First().Id, result.Id);
            Assert.Equal(customers.First().Name, result.Name);
            Assert.Equal(customers.First().Age, result.Age);
            Assert.Equal(customers.First().Postcode, result.Postcode);
            Assert.Equal(customers.First().Height, result.Height);
            Assert.Equal(customers.First().DateRegistered, result.DateRegistered);
        }

        [Fact]
        public async Task CustomerExists_SearchedCustomerDoesNotExist_ReturnsFalse()
        {
            var customers = new List<Customer>()
            {
                testCustomer1,
                testCustomer2
            };
            await InsertRangeAsync(customers);

            var result = await repo.CustomerExists(new Guid());

            Assert.False(result);
        }

        [Fact]
        public async Task CustomerExists_CustomersExist_ReturnsTrue()
        {
            var customers = new List<Customer>()
            {
                testCustomer1,
                testCustomer2
            };
            await InsertRangeAsync(customers);

            var result = await repo.CustomerExists(customers.First().Id);

            Assert.True(result);
        }

        [Fact]
        public async Task AddCustomer_NewValidCustomer_SuccessfullyAddsNewCustomer()
        {
            await InsertAsync(testCustomer1);

            var result = await repo.AddCustomer(testCustomer2);

            var customer = await FindAsync<Customer>(result);

            Assert.Equal(testCustomer2.Id, result);
            Assert.Equal(testCustomer2.Id, customer.Id);
            Assert.Equal(testCustomer2.Name, customer.Name);
            Assert.Equal(testCustomer2.Age, customer.Age);
            Assert.Equal(testCustomer2.Postcode, customer.Postcode);
            Assert.Equal(testCustomer2.Height, customer.Height);
            Assert.Equal(testCustomer2.DateRegistered, customer.DateRegistered);
        }

        [Fact]
        public async Task UpdateCustomer_ValidCustomerChanges_SuccessfullyUpdatesCustomer()
        {
            await InsertAsync(testCustomer1);

            var model = new EditModel()
            {
                Id = testCustomer1.Id,
                Name = "UpdatedName",
                Age = testCustomer1.Age + 1,
                Postcode = "BS9 9AA"
            };

            var result = await repo.UpdateCustomer(model);

            var customer = await FindAsync<Customer>(model.Id);

            Assert.True(result);
            Assert.Equal(model.Id, customer.Id);
            Assert.Equal(model.Name, customer.Name);
            Assert.Equal(model.Age, customer.Age);
            Assert.Equal(model.Postcode, customer.Postcode);
            Assert.Equal(model.Height, customer.Height);
        }

        [Fact]
        public async Task RemoveCustomer_ValidCustomer_SuccessfullyRemovesCustomer()
        {
            var customers = new List<Customer>()
            {
                testCustomer1,
                testCustomer2
            };
            await InsertRangeAsync(customers);

            var result = await repo.RemoveCustomer(testCustomer1.Id);

            var removedCustomer = await FindAsync<Customer>(testCustomer1.Id);
            var currentCustomers = await repo.GetCustomers();

            Assert.True(result);
            Assert.Null(removedCustomer);
            Assert.Equal(customers.Count - 1, currentCustomers.Count);
        }
    }
}
