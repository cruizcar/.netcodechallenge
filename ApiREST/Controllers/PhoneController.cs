using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ApiREST;
using System.Web.Http; 

namespace ApiREST
{
	[Route("api/[controller]")]
	[ApiController]
	public class PhoneController : ControllerBase
	{
		private List<Phone> listaDispositivos;

		public PhoneController()
		{
			listaDispositivos = new List<Phone>();
			for (int i = 0; i < 9; i++){
				Phone phone = new Phone() { Id = i, Name = "Phone " + i, Description = "Description of the phone " + i, Price = new decimal(200.49) + i, ImageUrl = "http://localhost:8080/smartphone" + i };
				listaDispositivos.Add(phone);
			}
		}

		[HttpGet]
		public ActionResult<List<Phone>> Get()
		{
			return listaDispositivos;
		}

		[HttpGet("{id}", Name = "GetPhone")]
		public ActionResult<Phone> GetById(int id)
		{
			if (id >= listaDispositivos.Count())
				return NotFound();
			
			Phone phone = listaDispositivos[id];
			if (phone == null)
			{
				return NotFound();
			}
			return phone;
		}
	}
}
