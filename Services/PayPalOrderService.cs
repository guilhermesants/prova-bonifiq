using ProvaPub.Models.abstracts;
using ProvaPub.Models;

namespace ProvaPub.Services
{
    public class PayPalOrderService : OrderService<PayPalPayment>
    {
        public override async Task<Order> PayOrder(PayPalPayment payment)
        {
            // regra para pagamento via paypal
            return await Task.FromResult(new Order { Value = payment.PaymentValue, OrderDate = DateTime.Now });
        }
    }
}
