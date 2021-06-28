using GraphQL.Types;
using SnackTrace.GraphQL.Entities.Order;

namespace SnackTrace.GraphQL.Types.Enum
{
	internal class OrderDirectionType : EnumerationGraphType<OrderDirection>
	{
		public OrderDirectionType()
		{
			Name = "OrderDirection";
		}
	}
}
