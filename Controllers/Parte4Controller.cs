﻿using Microsoft.AspNetCore.Mvc;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Controllers
{
	
	/// <summary>
	/// O Código abaixo faz uma chmada para a regra de negócio que valida se um consumidor pode fazer uma compra.
	/// Crie o teste unitário para esse Service. Se necessário, faça as alterações no código para que seja possível realizar os testes.
	/// Tente criar a maior cobertura possível nos testes.
	/// 
	/// Utilize o framework de testes que desejar. 
	/// Crie o teste na pasta "Tests" da solution
	/// </summary>
	[ApiController]
	[Route("[controller]")]
	public class Parte4Controller :  ControllerBase
	{
		private readonly ICustomerService _customerService;
        public Parte4Controller(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("CanPurchase")]
		public async Task<IActionResult> CanPurchase(int customerId, decimal purchaseValue)
		{
			try
			{
				var result = await _customerService.CanPurchase(customerId, purchaseValue);
				return Ok(result);
			} catch (ArgumentOutOfRangeException ex)
			{
				return BadRequest(ex.Message);
			} catch (InvalidOperationException ex)
			{
                return BadRequest(ex.Message);
            }
        }
	}
}
