using SnackTrace.Utility.Convert.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SnackTrace.Web.Areas.Admin.Models.Snacks
{
	public class CreateRenderModel
	{
		[Display(Name = "Name")]
		[ConvertKey("Name")]
		public string Name { get; set; }

		[Display(Name = "Price")]
		[DataType(DataType.Currency)]
		[ConvertKey("Price")]
		public decimal Price { get; set; }
	}
}
