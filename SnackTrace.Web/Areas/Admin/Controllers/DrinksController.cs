using Microsoft.AspNetCore.Mvc;
using SnackTrace.Data.Models;
using SnackTrace.Services.Interfaces;
using SnackTrace.Utility.Attributes;
using SnackTrace.Utility.Convert;
using SnackTrace.Web.Areas.Admin.Models.Drinks;
using System;
using System.Linq;

namespace SnackTrace.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class DrinksController : Controller
	{
		private readonly IDrinkService _drinkService;

		public DrinksController(IDrinkService drinkService)
		{
			_drinkService = drinkService;
		}

		[HttpGet]
		public ActionResult Index()
		{
			var entities = _drinkService.GetAll();
			var itemModels = entities.ConvertEachTo<Drink, IndexItemModel>((input, output) =>
			{
				output.MenuCount = input.Menus?.Count() ?? 0;
			});

			var model = new IndexRenderModel(itemModels);

			return View(model);
		}

		[HttpGet]
		public ActionResult Details(Guid id)
		{
			var entity = _drinkService.Get(id);

			if (entity == null)
			{
				return NotFound();
			}

			var model = entity.ConvertTo<Drink,DetailsRenderModel>((input, output) =>
			{
				output.Menus = input.Menus.ConvertEachTo<Models.Menus.ConnectionItemRenderModel>();
			});

			return View(model);
		}

		[HttpGet]
		[RestoreModelErrors]
		public ActionResult Create(CreateRenderModel model)
		{
			return View(model);
		}

		[HttpPost]
		[PreserveModelErrors]
		[ValidateAntiForgeryToken]
		public ActionResult CreateConfirm([FromForm] CreateInputModel model)
		{
			if (!ModelState.IsValid)
			{
				var renderModel = model.ConvertTo<CreateRenderModel>();
				return RedirectToAction(nameof(Create), renderModel);
			}

			try
			{
				var entity = model.ConvertTo<CreateInputModel,Drink>((input, output) => 
				{
					output.Created = DateTime.UtcNow;
					output.Modified = DateTime.UtcNow;
				});

				_drinkService.Add(entity);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				ModelState.AddModelError("model", "Something went wrong");
				var renderModel = model.ConvertTo<CreateRenderModel>();
				return RedirectToAction(nameof(Create), new { model = renderModel });
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirm(Guid id)
		{
			try
			{
				_drinkService.Remove(id);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return BadRequest();
			}
		}
	}
}
