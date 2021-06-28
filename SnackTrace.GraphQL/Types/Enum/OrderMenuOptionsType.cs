using GraphQL.Types;
using SnackTrace.GraphQL.Entities.Order;

namespace SnackTrace.GraphQL.Types.Enum
{
	internal class OrderMenuOptionsType : EnumerationGraphType<OrderMenu.Options>
	{
		public OrderMenuOptionsType()
		{
			Name = "OrderMenuOptions";
		}
	}
}
