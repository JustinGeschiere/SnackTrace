using SnackTrace.Data.Models;
using SnackTrace.GraphQL.Entities.Order;
using SnackTrace.GraphQL.Entities.Where;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnackTrace.Repositories.Interfaces
{
	public interface ISnackRepository : IBaseRepository<Snack>, IGraphRepository<Snack, WhereSnack, OrderSnack>
	{
		// TODO: Remove this
		IQueryable<Snack> GetMenuConnectionLoadQuery(IEnumerable<Guid> ids);
	}
}
