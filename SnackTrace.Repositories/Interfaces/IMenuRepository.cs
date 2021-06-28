using SnackTrace.Data.Models;
using SnackTrace.GraphQL.Entities.Order;
using SnackTrace.GraphQL.Entities.Where;
using System.Linq;

namespace SnackTrace.Repositories.Interfaces
{
	public interface IMenuRepository : IBaseRepository<Menu, WhereMenu>
	{
		IQueryable<Menu> GetQuery(WhereMenu where, OrderMenu order, int first);
	}
}
