using ProvaPub.Models.abstracts;

namespace ProvaPub.Models
{
    public class ProductList : ModelList<Product>
    {
        public ProductList(IList<Product> list) : base(list)
        {}
    }
}
