using System.Collections.Generic;

namespace SnackTrace.Services.Interfaces
{
	public interface IDrinkService : IBaseService<Data.Models.Drink, GraphQL.Entities.Drink, GraphQL.Entities.Where.WhereDrink>
	{
		IEnumerable<GraphQL.Entities.Drink> GetGraph(GraphQL.Entities.Where.WhereDrink where, GraphQL.Entities.Order.OrderDrink order, int first);
	}
}
