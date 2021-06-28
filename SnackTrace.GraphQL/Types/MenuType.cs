using GraphQL.Types;
using SnackTrace.GraphQL.Arguments;
using SnackTrace.GraphQL.Resolvers;
using SnackTrace.Services.Interfaces;

namespace SnackTrace.GraphQL.Types
{
	internal class MenuType : ObjectGraphType<Entities.Menu>
	{
		public MenuType(ISnackService snackService, IDrinkService drinkService)
		{
			Name = "Menu";
			Field(i => i.Id, type: typeof(IdGraphType)).Description("Identifier of entity");
			Field(i => i.Price).Description("Price of entity");
			Field(i => i.Name).Description("Name of entity");

			Field(typeof(DateTimeGraphType), "Created",
				description: "Creation date of entity",
				resolve: context => context.Source.Created.GetValueOrDefault());

			Field(typeof(DateTimeGraphType), "Modified",
				description: "Modified date of entity",
				resolve: context => context.Source.Modified.GetValueOrDefault());

			Field(typeof(ListGraphType<SnackType>), "Snacks",
				description: "All related snack entities",
				arguments: SnackArguments.GetQueryArguments(),
				resolve: SnackResolvers.GetMenuConnectionResolver(snackService));

			Field(typeof(ListGraphType<DrinkType>), "Drinks",
				description: "All related drink entities",
				arguments: DrinkArguments.GetQueryArguments(),
				resolve: DrinkResolvers.GetMenuConnectionResolver(drinkService));
		}
	}
}
