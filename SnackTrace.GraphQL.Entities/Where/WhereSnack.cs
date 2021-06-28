using System;

namespace SnackTrace.GraphQL.Entities.Where
{
	public class WhereSnack
	{
		public Guid Id { get; set; }
		public string Search { get; set; }
		public DateTime CreatedAfter { get; set; }

		// Hidden properties
		public Guid ContainsMenu { get; set; }
	}
}
