using SnackTrace.Utility.Convert.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SnackTrace.Web.Areas.Admin.Models.Menus
{
	public class CreateRenderModel
	{
		[Display(Name = "Name")]
		[ConvertKey("Name")]
		public string Name { get; set; }

		[Display(Name = "Price")]
		[ConvertKey("Price")]
		public decimal Price { get; set; }

		[Display(Name = "Available snacks")]
		[ConvertIgnore]
		public IEnumerable<ConnectionSelectRenderModel> Snacks { get; set; }

		[Display(Name = "Available drinks")]
		[ConvertIgnore]
		public IEnumerable<ConnectionSelectRenderModel> Drinks { get; set; }
	}
}
