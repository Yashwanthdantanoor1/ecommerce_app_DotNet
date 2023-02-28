using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace eTickets.Controllers
{
	public class ProducersController : Controller
	{
		private IActorsService _service;

		public ProducersController(IActorsService service)
		{
            _service = service;
		}
		public async Task<IActionResult> Index()
		{
			var allproducers = await _service.GetAllAsync();
			return View(allproducers);
		}
	}
}
