using GraphQL.Types;
using SnackTrace.GraphQL.Arguments;
using SnackTrace.GraphQL.Resolvers;
using SnackTrace.GraphQL.Types;
using SnackTrace.Services.Interfaces;

namespace SnackTrace.GraphQL
{
	public sealed class Query : ObjectGraphType
	{
		public Query(ISnackService snackService, IDrinkService drinkService, IMenuService menuService)
		{
			Field<ListGraphType<SnackType>>("snacks",
				description: "All snack entities",
				arguments: SnackArguments.GetQueryArguments(),
				resolve: SnackResolvers.GetQueryResolver(snackService));

			Field<ListGraphType<DrinkType>>("drinks",
				description: "All srink entities",
				arguments: DrinkArguments.GetQueryArguments(),
				resolve: DrinkResolvers.GetQueryResolver(drinkService));

			Field<ListGraphType<MenuType>>("menus",
				description: "All menu entities",
				arguments: MenuArguments.GetQueryArguments(),
				resolve: MenuResolvers.GetQueryResolver(menuService));
		}
	}
}
