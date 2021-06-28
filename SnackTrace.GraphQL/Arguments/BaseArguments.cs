using GraphQL.Types;
using System.Collections.Generic;

namespace SnackTrace.GraphQL.Arguments
{
	internal abstract class BaseArguments<Twhere,Torder>
		where Twhere : IGraphType
		where Torder : IGraphType
	{
		public static QueryArguments GetQueryArguments()
		{
			return new QueryArguments(new List<QueryArgument>()
			{
				new QueryArgument<Twhere>()
				{
					Name = "where"
				},
				new QueryArgument<Torder>()
				{
					Name = "order"
				},
				new QueryArgument<IntGraphType>()
				{
					Name = "skip"
				},
				new QueryArgument<IntGraphType>()
				{
					Name = "take"
				}
			});
		}
	}
}
