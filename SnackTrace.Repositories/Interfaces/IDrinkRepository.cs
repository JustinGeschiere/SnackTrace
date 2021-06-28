using SnackTrace.Data.Models;
using SnackTrace.GraphQL.Entities.Order;
using SnackTrace.GraphQL.Entities.Where;
using System.Linq;

namespace SnackTrace.Repositories.Interfaces
{
	public interface IDrinkRepository : IBaseRepository<Drink, WhereDrink>
	{
		IQueryable<Drink> GetQuery(WhereDrink where, OrderDrink order, int first);
	}
}
