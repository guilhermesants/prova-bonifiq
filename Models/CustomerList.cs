using ProvaPub.Models.abstracts;

namespace ProvaPub.Models
{
    public class CustomerList : ModelList<Customer>
    {
        public CustomerList(IList<Customer> list) : base(list)
        {}
    }
}
