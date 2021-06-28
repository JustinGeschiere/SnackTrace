using GraphQL;
using SnackTrace.GraphQL.Entities;
using SnackTrace.GraphQL.Entities.Order;
using SnackTrace.GraphQL.Entities.Where;
using SnackTrace.Services.Interfaces;
using System;

namespace SnackTrace.GraphQL.Resolvers
{
	internal class DrinkResolvers : BaseResolvers<Drink, WhereDrink, OrderDrink>
	{
		public static Func<IResolveFieldContext<Menu>, object> GetMenuConnectionResolver(IDrinkService service)
		{
			Func<IResolveFieldContext<Menu>, WhereDrink, WhereDrink> setMenuConnection = (context, where) =>
			{
				if (where == null)
				{
					where = new WhereDrink();
				}

				where.ContainsMenu = context.Source.Id;

				return where;
			};

			return GetQueryResolver(service, setMenuConnection);
		}
	}
}
