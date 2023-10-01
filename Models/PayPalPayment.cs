using ProvaPub.Models.abstracts;

namespace ProvaPub.Models
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(decimal paymentValue, int customerId) : base(paymentValue, customerId)
        {
        }

        public override Order MakePayment()
        {
            // regra para pagamento via paypal
            return new Order { Value = PaymentValue, OrderDate = DateTime.Now };
        }
    }
}
