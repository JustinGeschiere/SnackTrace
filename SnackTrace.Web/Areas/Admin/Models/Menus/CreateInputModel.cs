using SnackTrace.Utility.Convert.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SnackTrace.Web.Areas.Admin.Models.Menus
{
	public class CreateInputModel
	{
		[Required]
		[MaxLength(50)]
		[ConvertKey("Name")]
		public string Name { get; set; }

		[Required]
		[Range(0, (double)decimal.MaxValue)]
		[ConvertKey("Price")]
		public decimal Price { get; set; }

		[ConvertIgnore]
		public IEnumerable<Guid> Snacks { get; set; }

		[ConvertIgnore]
		public IEnumerable<Guid> Drinks { get; set; }
	}
}
