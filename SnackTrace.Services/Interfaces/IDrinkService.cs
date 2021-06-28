namespace SnackTrace.Services.Interfaces
{
	public interface IDrinkService : IBaseService<Data.Models.Drink>, IGraphService<GraphQL.Entities.Drink, GraphQL.Entities.Where.WhereDrink, GraphQL.Entities.Order.OrderDrink>
	{ }
}
