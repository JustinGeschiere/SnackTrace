using Microsoft.AspNetCore.Mvc;

namespace SnackTrace.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class OverviewController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
