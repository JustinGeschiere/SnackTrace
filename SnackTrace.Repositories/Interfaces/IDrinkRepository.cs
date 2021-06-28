using SnackTrace.Data.Models;
using SnackTrace.GraphQL.Entities.Order;
using SnackTrace.GraphQL.Entities.Where;

namespace SnackTrace.Repositories.Interfaces
{
	public interface IDrinkRepository : IBaseRepository<Drink>, IGraphRepository<Drink, WhereDrink, OrderDrink>
	{ }
}
