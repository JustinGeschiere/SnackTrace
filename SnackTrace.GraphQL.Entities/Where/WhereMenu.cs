using System;

namespace SnackTrace.GraphQL.Entities.Where
{
	public class WhereMenu
	{
		public Guid Id { get; set; }
		public string Search { get; set; }
		public DateTime CreatedAfter { get; set; }

		// Hidden properties
		public Guid ContainsSnack { get; set; }
		public Guid ContainsDrink { get; set; }
	}
}
