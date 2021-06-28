using Microsoft.AspNetCore.Mvc;
using SnackTrace.Data.Models;
using SnackTrace.Services.Interfaces;
using SnackTrace.Utility.Attributes;
using SnackTrace.Utility.Convert;
using SnackTrace.Web.Areas.Admin.Models.Snacks;
using System;
using System.Linq;

namespace SnackTrace.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SnacksController : Controller
	{
		private readonly ISnackService _snackService;

		public SnacksController(ISnackService snackService)
		{
			_snackService = snackService;
		}

		public ActionResult Index()
		{
			var entities = _snackService.GetAll();
			var itemModels = entities.ConvertEachTo<Snack,IndexItemModel>((input, output) => 
			{
				output.MenuCount = input.Menus?.Count() ?? 0;
			});

			var model = new IndexRenderModel(itemModels);

			return View(model);
		}

		[HttpGet]
		public ActionResult Details(Guid id)
		{
			var entity = _snackService.Get(id);

			if (entity == null)
			{
				return NotFound();
			}

			var model = entity.ConvertTo<Snack,DetailsRenderModel>((input, output) =>
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
				var entity = model.ConvertTo<Snack>();
				_snackService.Add(entity);

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
				_snackService.Remove(id);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return BadRequest();
			}
		}
	}
}
