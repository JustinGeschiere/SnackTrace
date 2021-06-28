using SnackTrace.Utility.Convert.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SnackTrace.Web.Areas.Admin.Models.Snacks
{
	public class DetailsRenderModel
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

		[Display(Name = "Menus")]
		[ConvertIgnore]
		public IEnumerable<Menus.ConnectionItemRenderModel> Menus { get; set; }
	}
}
