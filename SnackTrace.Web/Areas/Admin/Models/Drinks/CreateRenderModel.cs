using SnackTrace.Utility.Convert.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SnackTrace.Web.Areas.Admin.Models.Drinks
{
	public class CreateRenderModel
	{
		[Display(Name = "Name")]
		[ConvertKey("Name")]
		public string Name { get; set; }

		[Display(Name = "Price")]
		[ConvertKey("Price")]
		public decimal Price { get; set; }
	}
}
