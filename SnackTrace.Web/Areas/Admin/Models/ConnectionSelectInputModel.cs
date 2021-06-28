using SnackTrace.Utility.Convert.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace SnackTrace.Web.Areas.Admin.Models
{
	public class ConnectionSelectInputModel : ConnectionSelectInputModel<Guid>
	{ }

	public class ConnectionSelectInputModel<T>
	{
		[Required]
		[ConvertKey("Id")]
		public T Id { get; set; }
	}
}
