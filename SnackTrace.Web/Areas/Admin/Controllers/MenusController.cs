using Microsoft.AspNetCore.Mvc;
using SnackTrace.Data.Models;
using SnackTrace.Services.Interfaces;
using SnackTrace.Utility.Attributes;
using SnackTrace.Utility.Convert;
using SnackTrace.Web.Areas.Admin.Models;
using SnackTrace.Web.Areas.Admin.Models.Menus;
using System;
using System.Linq;

namespace SnackTrace.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class MenusController : Controller
	{
		private readonly IMenuService _menuService;
		private readonly ISnackService _snackService;
		private readonly IDrinkService _drinkService;

		public MenusController(IMenuService menuService, ISnackService snackService, IDrinkService drinkService)
		{
			_menuService = menuService;
			_snackService = snackService;
			_drinkService = drinkService;
		}

		public ActionResult Index()
		{
			var entities = _menuService.GetAll();
			var itemModels = entities.ConvertEachTo<Menu, IndexItemModel>((input, output) =>
			{
				output.SnackCount = input.Snacks?.Count() ?? 0;
				output.DrinkCount = input.Drinks?.Count() ?? 0;
			});

			var model = new IndexRenderModel(itemModels);

			return View(model);
		}

		[HttpGet]
		public ActionResult Details(Guid id)
		{
			var entity = _menuService.Get(id);

			if (entity == null)
			{
				return NotFound();
			}

			var model = entity.ConvertTo<Menu, DetailsRenderModel>((input, output) =>
			{
				output.Snacks = input.Snacks.ConvertEachTo<Models.Snacks.ConnectionItemRenderModel>();
				output.Drinks = input.Drinks.ConvertEachTo<Models.Drinks.ConnectionItemRenderModel>();
			});

			return View(model);
		}

		[HttpGet]
		[RestoreModelErrors]
		public ActionResult Create(CreateRenderModel model)
		{
			var snackEntities = _snackService.GetAll();
			var drinkEntities = _drinkService.GetAll();

			model.Snacks = snackEntities.ConvertEachTo<ConnectionSelectRenderModel>();
			model.Drinks = drinkEntities.ConvertEachTo<ConnectionSelectRenderModel>();

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
				var entity = model.ConvertTo<CreateInputModel,Menu>((input, output) =>
				{
					output.Snacks = input.Snacks.Select(i => _snackService.Get(i)).ToArray();
					output.Drinks = input.Drinks.Select(i => _drinkService.Get(i)).ToArray();

					output.Created = DateTime.UtcNow;
					output.Modified = DateTime.UtcNow;
				});

				_menuService.Add(entity);

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
				_menuService.Remove(id);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return BadRequest();
			}
		}
	}
}
