using System;
using System.Collections.Generic;
using System.Linq;

namespace SnackTrace.Services.Interfaces
{
	public interface ISnackService : IBaseService<Data.Models.Snack>, IGraphService<GraphQL.Entities.Snack, GraphQL.Entities.Where.WhereSnack, GraphQL.Entities.Order.OrderSnack>
	{
		// TODO: Remove this
		ILookup<Guid, GraphQL.Entities.Snack> LoadMenuConnectionGraphEntities(IEnumerable<Guid> ids);
	}
}
