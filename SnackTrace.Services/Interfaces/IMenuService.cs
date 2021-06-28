using System.Collections.Generic;

namespace SnackTrace.Services.Interfaces
{
	public interface IMenuService : IBaseService<Data.Models.Menu>, IGraphService<GraphQL.Entities.Menu, GraphQL.Entities.Where.WhereMenu, GraphQL.Entities.Order.OrderMenu>
	{ }
}
