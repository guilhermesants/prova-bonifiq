using ProvaPub.Models;
using ProvaPub.Models.abstracts;

namespace ProvaPub.Services
{
	public class OrderService
	{
		public async Task<Order> PayOrder(Payment payment)
		{
			return await Task.FromResult(payment.MakePayment());
		}
	}
}
