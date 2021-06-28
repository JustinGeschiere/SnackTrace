using SnackTrace.Utility.Convert.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace SnackTrace.Web.Areas.Admin.Models.Drinks
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

		[Display(Name = "Menu count")]
		[ConvertIgnore]
		public int MenuCount { get; set; }

	}
}
