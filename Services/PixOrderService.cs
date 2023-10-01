using ProvaPub.Models;
using ProvaPub.Models.abstracts;

namespace ProvaPub.Services
{
    public class PixOrderService : OrderService<PixPayment>
    {
        public override async Task<Order> PayOrder(PixPayment payment)
        {
            // regra para pagamento via pix
            return await Task.FromResult(new Order { Value = payment.PaymentValue, OrderDate = DateTime.Now});
        }
    }
}
