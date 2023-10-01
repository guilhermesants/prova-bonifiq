using ProvaPub.Models;

namespace ProvaPub.Services.Interfaces
{
    public interface ICustomerService : IService<Customer>
    {
        CustomerList ListCustomers(int? page);
    }
}
