using ProvaPub.Models.abstracts;

namespace ProvaPub.Models
{
    public class CreditCardPayment : Payment
    {
        private Card _creditCard;

        public CreditCardPayment(Card creditCard, decimal paymentValue, int customerId) : base(paymentValue, customerId)
        {
            _creditCard = creditCard;
        }

        public override Order MakePayment()
        {
            // regra para pagamento via cartao de credito
            return new Order { Value = PaymentValue, OrderDate = DateTime.Now };
        }

    }
}
