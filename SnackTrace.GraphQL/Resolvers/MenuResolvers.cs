using GraphQL;
using SnackTrace.GraphQL.Entities;
using SnackTrace.GraphQL.Entities.Order;
using SnackTrace.GraphQL.Entities.Where;
using SnackTrace.GraphQL.Resolvers.Contexts;
using SnackTrace.Services.Interfaces;
using System;

namespace SnackTrace.GraphQL.Resolvers
{
	internal class MenuResolvers : BaseResolvers<Menu, WhereMenu, OrderMenu>
	{ 
		public static Func<IResolveFieldContext<Drink>, object> GetDrinkConnectionResolver(IMenuService service)
		{
			DrinkContext.CustomWhere<WhereMenu> setDrinkConnection = (context, where) =>
			{
				if (where == null)
				{
					where = new WhereMenu();
				}

				where.ContainsDrink = context.Source.Id;

				return where;
			};

			return GetQueryResolver(service, setDrinkConnection);
		}

		public static Func<IResolveFieldContext<Snack>, object> GetSnackConnectionResolver(IMenuService service)
		{
			SnackContext.CustomWhere<WhereMenu> setSnackConnection = (context, where) =>
			{
				if (where == null)
				{
					where = new WhereMenu();
				}

				where.ContainsSnack = context.Source.Id;

				return where;
			};

			return GetQueryResolver(service, setSnackConnection);
		}
	}
}
