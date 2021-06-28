using SnackTrace.Utility.Convert.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace SnackTrace.Web.Areas.Admin.Models.Menus
{
	public class ConnectionItemRenderModel
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
	}
}
