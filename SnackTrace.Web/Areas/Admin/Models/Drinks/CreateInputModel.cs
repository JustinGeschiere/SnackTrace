using SnackTrace.Utility.Convert.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace SnackTrace.Web.Areas.Admin.Models.Drinks
{
	public class CreateInputModel
	{
		[Required]
		[MaxLength(50)]
		[Display(Name = "Name")]
		[ConvertKey("Name")]
		public string Name { get; set; }

		[Required]
		[Range(0, (double)decimal.MaxValue)]
		[Display(Name = "Price")]
		[ConvertKey("Price")]
		public decimal Price { get; set; }
	}
}
