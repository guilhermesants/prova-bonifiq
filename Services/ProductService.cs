using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services
{
	public class ProductService : Service<Product>, IProductService
	{
        public ProductService(TestDbContext ctx) : base(ctx)
        {}

        public bool Create(Product model)
        {
            throw new NotImplementedException();
        }

        public ProductList ListProducts(int? page) => new ProductList(GetElements(page));
        

    }
}
