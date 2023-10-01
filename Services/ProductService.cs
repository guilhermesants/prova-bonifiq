using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services
{
	public class ProductService : IProductService
	{
		TestDbContext _ctx;

		public ProductService(TestDbContext ctx)
		{
			_ctx = ctx;
		}

        public ProductList ListProducts(int? page)
		{
			var productList = page.HasValue ? _ctx.Products.ToList().Skip((page.Value - 1) * 10).Take(10).ToList() : _ctx.Products.ToList();
            return new ProductList(productList);
        }

        public IList<Product> GetAll() => _ctx.Products.ToList();
    }
}
