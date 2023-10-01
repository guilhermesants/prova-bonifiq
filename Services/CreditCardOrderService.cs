using ProvaPub.Models.abstracts;
using ProvaPub.Models;

namespace ProvaPub.Services
{
    public class CreditCardOrderService : OrderService<CreditCardPayment>
    {
        public override async Task<Order> PayOrder(CreditCardPayment payment)
        {
            // regra para pagamento via credito
            if (!payment.CardIsValid()) return null;

            return await Task.FromResult(new Order { Value = payment.PaymentValue, OrderDate = DateTime.Now });
        }
    }
}
