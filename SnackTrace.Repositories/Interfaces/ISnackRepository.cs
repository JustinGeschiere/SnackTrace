using SnackTrace.Data.Models;
using SnackTrace.GraphQL.Entities.Order;
using SnackTrace.GraphQL.Entities.Where;
using System.Linq;

namespace SnackTrace.Repositories.Interfaces
{
	public interface ISnackRepository : IBaseRepository<Snack, WhereSnack>
	{
		IQueryable<Snack> GetQuery(WhereSnack where, OrderSnack order, int first);
	}
}
