using SnackTrace.Utility.Convert.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SnackTrace.Web.Areas.Admin.Models.Menus
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

		[Display(Name = "Snacks")]
		[ConvertIgnore]
		public IEnumerable<Snacks.ConnectionItemRenderModel> Snacks { get; set; }

		[Display(Name = "Drinks")]
		[ConvertIgnore]
		public IEnumerable<Drinks.ConnectionItemRenderModel> Drinks { get; set; }
	}
}
