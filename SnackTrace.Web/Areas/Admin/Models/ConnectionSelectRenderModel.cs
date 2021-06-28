using SnackTrace.Utility.Convert.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace SnackTrace.Web.Areas.Admin.Models
{
	public class ConnectionSelectRenderModel : ConnectionSelectRenderModel<Guid>
	{ }

	public class ConnectionSelectRenderModel<T>
	{
		[ConvertKey("Id")]
		public T Id { get; set; }

		[Display(Name = "Name")]
		[ConvertKey("Name")]
		public string Name { get; set; }
	}
}
