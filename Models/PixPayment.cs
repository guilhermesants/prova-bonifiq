using ProvaPub.Models.abstracts;

namespace ProvaPub.Models
{
    public class PixPayment : Payment
    {
        public PixPayment(decimal paymentValue, int customerId) : base(paymentValue, customerId)
        {}

        public override Order MakePayment()
        {
            // regra para pagamento via pix
            return new Order { Value = PaymentValue, OrderDate = DateTime.Now };
        }
    }
}
