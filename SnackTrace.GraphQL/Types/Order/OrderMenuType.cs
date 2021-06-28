using GraphQL.Types;
using SnackTrace.GraphQL.Entities.Order;
using SnackTrace.GraphQL.Types.Enum;

namespace SnackTrace.GraphQL.Types.Order
{
	internal class OrderMenuType : InputObjectGraphType<OrderMenu>
	{
		public OrderMenuType()
		{
			Name = "OrderMenu";
			Field(i => i.Option, type: typeof(OrderSnackOptionsType)).Description("Option of ordering");
			Field(i => i.Direction, type: typeof(OrderDirectionType)).Description("Direction of ordering");
		}
	}
}
