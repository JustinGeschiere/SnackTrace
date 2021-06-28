using GraphQL.Types;
using SnackTrace.GraphQL.Entities.Order;
using SnackTrace.GraphQL.Types.Enum;

namespace SnackTrace.GraphQL.Types.Order
{
	internal class OrderDrinkType : InputObjectGraphType<OrderDrink>
	{
		public OrderDrinkType()
		{
			Name = "OrderDrink";
			Field(i => i.Option, type: typeof(OrderDrinkOptionsType)).Description("Option of ordering");
			Field(i => i.Direction, type: typeof(OrderDirectionType)).Description("Direction of ordering");
		}
	}
}
