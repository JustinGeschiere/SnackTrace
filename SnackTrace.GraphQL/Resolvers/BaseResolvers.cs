using GraphQL;
using SnackTrace.GraphQL.Resolvers.Contexts;
using SnackTrace.Services.Interfaces;
using System;

namespace SnackTrace.GraphQL.Resolvers
{
	internal abstract class BaseResolvers<Tentity,Twhere,Torder>
	{
		public static Func<IResolveFieldContext<object>, object> GetQueryResolver(IGraphService<Tentity,Twhere,Torder> service)
		{
			return context =>
			{
				var where = context.GetArgument<Twhere>("where");
				var order = context.GetArgument<Torder>("order");
				var skip = context.GetArgument<int>("skip");
				var take = context.GetArgument<int>("take");

				return service.GetGraphEntities(where, order, skip, take);
			};
		}

		public static Func<IResolveFieldContext<Tsource>, object> GetQueryResolver<Tsource>(IGraphService<Tentity, Twhere, Torder> service, BaseContext<Tsource>.CustomWhere<Twhere> customWhere)
		{
			return context =>
			{
				var where = context.GetArgument<Twhere>("where");
				var order = context.GetArgument<Torder>("order");
				var skip = context.GetArgument<int>("skip");
				var take = context.GetArgument<int>("take");

				where = customWhere(context, where);

				return service.GetGraphEntities(where, order, skip, take);
			};
		}
	}
}
