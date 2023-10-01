using ProvaPub.Models.abstracts;

namespace ProvaPub.Models
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(decimal paymentValue, int customerId) : base(paymentValue, customerId)
        {
        }

    }
}
