using Microsoft.AspNetCore.Mvc;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;
using ProvaPub.ViewModels;

namespace ProvaPub.Controllers
{
	
	/// <summary>
	/// Esse teste simula um pagamento de uma compra.
	/// O método PayOrder aceita diversas formas de pagamento. Dentro desse método é feita uma estrutura de diversos "if" para cada um deles.
	/// Sabemos, no entanto, que esse formato não é adequado, em especial para futuras inclusões de formas de pagamento.
	/// Como você reestruturaria o método PayOrder para que ele ficasse mais aderente com as boas práticas de arquitetura de sistemas?
	/// </summary>
	[ApiController]
	[Route("[controller]")]
	public class Parte3Controller :  ControllerBase
	{
		[HttpGet("orders/pix")]
		public async Task<Order> PixPlaceOrder([FromBody] PlaceOrder placeOrder)
		{ 
			return await new PixOrderService().PayOrder(
					new PixPayment(placeOrder.PaymentValue, placeOrder.CustomerId)
				);
		}

        [HttpGet("orders/paypal")]
        public async Task<Order> PaypalPlaceOrder([FromBody] PlaceOrder placeOrder)
        {
            return await new PayPalOrderService().PayOrder(
                    new PayPalPayment(placeOrder.PaymentValue, placeOrder.CustomerId)
                );
        }

        [HttpGet("orders/creditcard")]
        public async Task<IActionResult> CreditcardPlaceOrder([FromBody] CreditCardPlaceOrder placeOrder)
        {
            var resultOrder = await new CreditCardOrderService().PayOrder(
                    new CreditCardPayment(placeOrder.Card, placeOrder.PaymentValue, placeOrder.CustomerId)
                );

			if (resultOrder is null) return BadRequest("Erro ao processar pedido");

			return Ok(resultOrder);
        }

    }
}
