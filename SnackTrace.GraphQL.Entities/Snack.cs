using System;

namespace SnackTrace.GraphQL.Entities
{
	public class Snack
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public DateTime? Created { get; set; }
		public DateTime? Modified { get; set; }
	}
}
