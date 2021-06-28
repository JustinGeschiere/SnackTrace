using Microsoft.Extensions.DependencyInjection;
using System;
using GraphQLSchema = GraphQL.Types.Schema;

namespace SnackTrace.GraphQL
{
	public sealed class Schema : GraphQLSchema
	{
		public Schema(IServiceProvider provider) : base(provider)
		{
			Query = provider.GetRequiredService<Query>();
		}
	}
}
