using System;
using System.Collections.Generic;

namespace SnackTrace.Data.Models
{
	public class Drink
	{
		// Entity properties
		public Guid Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public DateTime? Created { get; set; }
		public DateTime? Modified { get; set; }

		// Relation properties
		public ICollection<Menu> Menus { get; set; }
	}
}
