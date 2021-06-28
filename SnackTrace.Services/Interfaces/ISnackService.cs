using System.Collections.Generic;

namespace SnackTrace.Services.Interfaces
{
	public interface ISnackService : IBaseService<Data.Models.Snack, GraphQL.Entities.Snack, GraphQL.Entities.Where.WhereSnack>
	{
		IEnumerable<GraphQL.Entities.Snack> GetGraph(GraphQL.Entities.Where.WhereSnack where, GraphQL.Entities.Order.OrderSnack order, int first);
	}
}
