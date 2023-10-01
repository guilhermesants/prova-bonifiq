using ProvaPub.Models.abstracts;

namespace ProvaPub.Models
{
    public class PixPayment : Payment
    {
        public PixPayment(decimal paymentValue, int customerId) : base(paymentValue, customerId)
        {}
    }
}
