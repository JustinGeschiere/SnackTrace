using GraphQL;
using SnackTrace.GraphQL.Entities;
using SnackTrace.GraphQL.Entities.Order;
using SnackTrace.GraphQL.Entities.Where;
using SnackTrace.GraphQL.Resolvers.Contexts;
using SnackTrace.Services.Interfaces;
using System;

namespace SnackTrace.GraphQL.Resolvers
{
	internal class SnackResolvers : BaseResolvers<Snack, WhereSnack, OrderSnack>
	{
		public static Func<IResolveFieldContext<Menu>, object> GetMenuConnectionResolver(ISnackService service)
		{
			MenuContext.CustomWhere<WhereSnack> setMenuConnection = (context, where) =>
			{
				if (where == null)
				{
					where = new WhereSnack();
				}

				where.ContainsMenu = context.Source.Id;

				return where;
			};

			return GetQueryResolver(service, setMenuConnection);
		}
	}
}
