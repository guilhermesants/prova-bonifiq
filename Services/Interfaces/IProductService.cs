using ProvaPub.Models;

namespace ProvaPub.Services.Interfaces
{
    public interface IProductService : IService<Product>
    {
        ProductList ListProducts(int? page);
    }
}
