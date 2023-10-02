using Microsoft.EntityFrameworkCore;
using NuGet.Frameworks;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;
using Xunit;

namespace ProvaPub.Tests
{
    public class CustomerServiceTests
    {
        private readonly TestDbContext _context;

        public CustomerServiceTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TestDbContext>();
            optionsBuilder.UseInMemoryDatabase("Teste");
            _context = new TestDbContext(optionsBuilder.Options);
        }

        [Fact]
        public async Task InvalidCustomerId_CanPurchaseIsCalled_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            int customerId = 0;
            decimal puchaseValue = 0.00M;

            var customerService = new CustomerService(_context);

            // Act + Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => customerService.CanPurchase(customerId, puchaseValue));
        }

        [Fact]
        public async Task CustomerNull_CanPurchaseIsCalled_ThrowInvalidOperationException()
        {
            // Arrange
            int customerId = 31;
            decimal puchaseValue = 3.00M;

            var customerService = new CustomerService(_context);

            // Act + Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                                        customerService.CanPurchase(customerId, puchaseValue));

            Assert.Equal($"Customer Id {customerId} does not exists", exception.Message);

        }

        [Fact]
        public async Task ValidPurchasePerMonth_CanPurchaseCalled_Boolean()
        {
            // Arrange
            var customerService = new CustomerService(_context);


            // criando um customer com order com data atual para teste
            // devendo retornar falso ao chamar o metodo CanPurchase
            var customer = new Customer
            {
                Id = 21,
                Name = "João Da silva",
                Orders = new List<Order>()
                {
                    new Order
                    {
                        Id = 33,
                        Value = 33.00M,
                        CustomerId = 21,
                        OrderDate = DateTime.Now
                    }

                }
            };
            customerService.Create(customer);

            // Act + Assert
            var result = await customerService.CanPurchase(customer.Id, 35.00M);
            Assert.False(result);
        }

        [Fact]
        public async Task ValidFirstPurchase_CanPurchaseCalled_Boolean()
        {
            // Arrange
            var customerService = new CustomerService(_context);

            // criando um customer sem order
            customerService.Create(new Customer { Id = 23, Name = "João Oliveira"});

            // Act + Assert
            var result = await customerService.CanPurchase(23, 100.01M);
            Assert.False(result);

            result = await customerService.CanPurchase(23, 100.00M);
            Assert.True(result);
        }
    }
}
