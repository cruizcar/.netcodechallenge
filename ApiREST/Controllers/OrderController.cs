using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ApiREST;
using System.Web.Http;
using System.Net.Http;
using System.Net;

namespace ApiREST
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : Controller
	{
		public OrderController()
		{
		}

		[HttpGet]
		public ActionResult<Order> Get()
		{
			return new Order();
		}

		[HttpPost ("{order}", Name = "AddOrder")]
		public IActionResult AddOrder([FromBody]Order order)
		{
			if (order == null)
				return StatusCode(452, "Order is null");

			switch(order.Validate()){
				case (-1):
					return StatusCode(453, "Error in Order Date field");
				case -2:
					return StatusCode(454, "Error in Customer data");
				case -3:
					return StatusCode(455, "Error in OrderLines data");
				default:
					break;
			}
			
			order.CalculateTotal();

			order.ToString();

			return StatusCode(200, "Order received. Total order: " + order.TotalPrice + "€");
		}
	}
}
