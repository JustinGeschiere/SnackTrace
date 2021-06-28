using GraphQL.Types;
using SnackTrace.GraphQL.Entities.Order;
using SnackTrace.GraphQL.Types.Enum;

namespace SnackTrace.GraphQL.Types.Order
{
	internal class OrderSnackType : InputObjectGraphType<OrderSnack>
	{
		public OrderSnackType()
		{
			Name = "OrderSnack";
			Field(i => i.Option, type: typeof(OrderSnackOptionsType)).Description("Option of ordering");
			Field(i => i.Direction, type: typeof(OrderDirectionType)).Description("Direction of ordering");
		}
	}
}
