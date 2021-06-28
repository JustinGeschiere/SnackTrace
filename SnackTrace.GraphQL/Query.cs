using GraphQL;
using GraphQL.Types;
using SnackTrace.GraphQL.Entities.Order;
using SnackTrace.GraphQL.Entities.Where;
using SnackTrace.GraphQL.Types;
using SnackTrace.GraphQL.Types.Order;
using SnackTrace.GraphQL.Types.Where;
using SnackTrace.Services.Interfaces;
using System.Collections.Generic;

namespace SnackTrace.GraphQL
{
	public sealed class Query : ObjectGraphType
	{
		public Query(ISnackService snackService, IDrinkService drinkService, IMenuService menuService)
		{
			Field<ListGraphType<SnackType>>("snacks",
				arguments: new QueryArguments(new List<QueryArgument>()
				{
					new QueryArgument<WhereSnackType>()
					{
						Name = "where"
					},
					new QueryArgument<OrderSnackType>()
					{
						Name = "order"
					},
					new QueryArgument<IntGraphType>()
					{
						Name = "first"
					}
				}),
				resolve: context =>
				{
					var where = context.GetArgument<WhereSnack>("where");
					var order = context.GetArgument<OrderSnack>("order");
					var first = context.GetArgument<int>("first");

					return snackService.GetGraph(where, order, first);
				}
			);

			Field<ListGraphType<DrinkType>>("drinks",
				arguments: new QueryArguments(new List<QueryArgument>()
				{
					new QueryArgument<WhereDrinkType>()
					{
						Name = "where"
					},
					new QueryArgument<OrderDrinkType>()
					{
						Name = "order"
					},
					new QueryArgument<IntGraphType>()
					{
						Name = "first"
					}
				}),
				resolve: context =>
				{
					var where = context.GetArgument<WhereDrink>("where");
					var order = context.GetArgument<OrderDrink>("order");
					var first = context.GetArgument<int>("first");

					return drinkService.GetGraph(where, order, first);
				}
			);

			Field<ListGraphType<MenuType>>("menus",
				arguments: new QueryArguments(new List<QueryArgument>()
				{
					new QueryArgument<WhereMenuType>()
					{
						Name = "where"
					},
					new QueryArgument<OrderMenuType>()
					{
						Name = "order"
					},
					new QueryArgument<IntGraphType>()
					{
						Name = "first"
					}
				}),
				resolve: context =>
				{
					var where = context.GetArgument<WhereMenu>("where");
					var order = context.GetArgument<OrderMenu>("order");
					var first = context.GetArgument<int>("first");

					return menuService.GetGraph(where, order, first);
				}
			);
		}
	}
}
