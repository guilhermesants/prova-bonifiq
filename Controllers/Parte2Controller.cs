using Microsoft.AspNetCore.Mvc;
using ProvaPub.Models;
using ProvaPub.Models.Enums;
using ProvaPub.Services.Interfaces;


namespace ProvaPub.Controllers
{
	
	[ApiController]
	[Produces("application/json")]
	[Route("[controller]")]
	public class Parte2Controller :  ControllerBase
	{
		/// <summary>
		/// Precisamos fazer algumas alterações:
		/// 1 - Não importa qual page é informada, sempre são retornados os mesmos resultados. Faça a correção.
		/// 2 - Altere os códigos abaixo para evitar o uso de "new", como em "new ProductService()". Utilize a Injeção de Dependência para resolver esse problema
		/// 3 - Dê uma olhada nos arquivos /Models/CustomerList e /Models/ProductList. Veja que há uma estrutura que se repete. 
		/// Como você faria pra criar uma estrutura melhor, com menos repetição de código? E quanto ao CustomerService/ProductService. Você acha que seria possível evitar a repetição de código?
		/// 
		/// </summary>
		
		private readonly IProductService _productService;
		private readonly ICustomerService _customerService;

		public Parte2Controller(IProductService productService, ICustomerService customerService)
		{
			_productService = productService;
			_customerService = customerService;
		}
	
		[HttpGet("products/{page?}")]
		public ActionResult<ProductList> ListProducts(int? page)
		{
            try {
				return Ok(_productService.ListProducts(page));
			} catch (Exception)
			{
				return StatusCode(500, $"Ocorreu um erro com o código: {ErrorMessage.ErroInterno}");
			}
        }

		[HttpGet("customers/{page?}")]
		public ActionResult<CustomerList> ListCustomers(int? page)
		{
			try
			{
				return Ok(_customerService.ListCustomers(page));
			} catch (Exception)
			{
                return StatusCode(500, $"Ocorreu um erro com o código: {ErrorMessage.ErroInterno}");
            }
		}
	}
}
