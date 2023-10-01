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

        public bool CardIsValid() => _creditCard.Number.Length == 16 && !String.IsNullOrEmpty(_creditCard.Number);
    }
}
