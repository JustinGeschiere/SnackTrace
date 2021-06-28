using GraphQL.Types;
using SnackTrace.GraphQL.Entities.Order;

namespace SnackTrace.GraphQL.Types.Enum
{
	internal class OrderSnackOptionsType : EnumerationGraphType<OrderSnack.Options>
	{
		public OrderSnackOptionsType()
		{
			Name = "OrderSnackOptions";
		}
	}
}
