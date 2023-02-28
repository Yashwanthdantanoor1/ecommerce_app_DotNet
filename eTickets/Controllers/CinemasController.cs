using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
	public class CinemasController : Controller
	{
		private readonly IActorsService _service;

		public CinemasController(IActorsService service)
		{
			_service = service;
		}

		public async Task<IActionResult> Index()
		{
			var cinemadata = await _service.GetAllAsync();
			return View(cinemadata);
		}
	}
}
