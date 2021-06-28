using SnackTrace.Utility.Convert.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace SnackTrace.Web.Areas.Admin.Models.Menus
{
	public class IndexItemModel
	{
		[Display(Name = "Identifier")]
		[ConvertKey("Id")]
		public Guid Id { get; set; }

		[Display(Name = "Name")]
		[ConvertKey("Name")]
		public string Name { get; set; }

		[Display(Name = "Price")]
		[ConvertKey("Price")]
		public decimal Price { get; set; }

		[Display(Name = "Snack count")]
		[ConvertIgnore]
		public int SnackCount { get; set; }

		[Display(Name = "Drink count")]
		[ConvertIgnore]
		public int DrinkCount { get; set; }
	}
}
