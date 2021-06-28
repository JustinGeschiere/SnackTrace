using GraphQL.Types;
using SnackTrace.GraphQL.Entities.Order;

namespace SnackTrace.GraphQL.Types.Enum
{
	internal class OrderDrinkOptionsType : EnumerationGraphType<OrderDrink.Options>
	{
		public OrderDrinkOptionsType()
		{
			Name = "OrderDrinkOptions";
		}
	}
}
