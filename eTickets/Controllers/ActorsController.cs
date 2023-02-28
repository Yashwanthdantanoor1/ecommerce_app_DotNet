using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
	public class ActorsController : Controller
	{
		private readonly IActorsService _service;
		public ActorsController(IActorsService service)
		{
			_service = service;
		}
		public async Task<IActionResult> Index()
		{
			var data = await _service.GetAllAsync();
			return View(data);
		}
		// Actors/Create it is aget request
        public async Task<IActionResult> Create()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")]Actor actor)
		{
			await _service.AddAsync(actor);
			return RedirectToAction(nameof(Index));

		}
		public async Task<IActionResult> Details(int id)
		{
			var actorDetails = await _service.GetByIDAsync(id);
			if (actorDetails == null) { return View("NotFound"); }
			return View(actorDetails);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var result = await _service.GetByIDAsync(id);
			if(result == null) { return View("NotFound"); }
			return View(result);

		}
		[HttpPost]
		public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureUrl,Bio")] Actor actor)
		{
			await _service.UpdateAsync(id,actor);
			return RedirectToAction(nameof(Index));

		}

		public async Task<IActionResult> Delete(int id)
		{
			var result = await _service.GetByIDAsync(id);
			if(result == null) { return View("NotFound");
			}
			return View(result);
		}
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> Deletedetails(int id)
		{
			var result = await _service.GetByIDAsync(id);
			await _service.DeleteAsync(id);
			return RedirectToAction(nameof(Index));

		}
	}
}
