using System.Collections.Generic;

namespace SnackTrace.Services.Interfaces
{
	public interface IMenuService : IBaseService<Data.Models.Menu, GraphQL.Entities.Menu, GraphQL.Entities.Where.WhereMenu>
	{
		IEnumerable<GraphQL.Entities.Menu> GetGraph(GraphQL.Entities.Where.WhereMenu where, GraphQL.Entities.Order.OrderMenu order, int first);
	}
}
