using GraphQL.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SnackTrace.GraphQL;
using SnackTrace.Web.Models;
using System;
using System.Diagnostics;

namespace SnackTrace.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IServiceProvider _provider;

		public HomeController(ILogger<HomeController> logger, IServiceProvider provider)
		{
			_logger = logger;
			_provider = provider;
		}

		public IActionResult Index()
		{
			// Redirect to admin overview
			return Redirect("/Admin");
		}

		public IActionResult Playground()
		{
			// Redirect to playground
			return Redirect("/ui/playground");
		}

		public IActionResult Print()
		{
			// Render GraphQL schema as content result
			var printer = new SchemaPrinter(new Schema(_provider));
			var print = printer.Print();

			// Log schema
			_logger.LogInformation(print);

			return Content(print);
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
