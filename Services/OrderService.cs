using ProvaPub.Models;
using ProvaPub.Models.abstracts;

namespace ProvaPub.Services
{
	public abstract class OrderService<T> where T : class
	{
		public abstract Task<Order> PayOrder(T payment);
	}
}
