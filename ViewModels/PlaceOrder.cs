using ProvaPub.Models;

namespace ProvaPub.ViewModels
{
    public class PlaceOrder
    {
        public decimal PaymentValue { get; set; }
        public int CustomerId { get; set; }
    }

    public class CreditCardPlaceOrder : PlaceOrder
    {
        public Card Card { get; set; }
    }
}
