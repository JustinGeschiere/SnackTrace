using GraphQL.DataLoader;
using GraphQL.Types;
using SnackTrace.GraphQL.Arguments;
using SnackTrace.GraphQL.DataLoaders.Interfaces;
using SnackTrace.GraphQL.Resolvers;
using SnackTrace.Services.Interfaces;

namespace SnackTrace.GraphQL.Types
{
	internal class MenuType : ObjectGraphType<Entities.Menu>
	{
		public MenuType(IMenuDataLoader loader, ISnackService snackService, IDrinkService drinkService)
		{
			Name = "Menu";

			Field(i => i.Id, type: typeof(IdGraphType)).Description("Identifier of entity");

			Field<DecimalGraphType>("Price", "Price of entity",
				resolve: (ctx) => loader.Load(ctx.Source.Id).Then(i => i.Price));

			Field<StringGraphType>("Name", "Name of entity",
				resolve: (ctx) => loader.Load(ctx.Source.Id).Then(i => i.Name));

			Field<DateTimeGraphType>("Created", "Creation data of entity",
				resolve: ctx => loader.Load(ctx.Source.Id).Then(i => i.Created.GetValueOrDefault()));

			Field<DateTimeGraphType>("Modified", "Modified data of entity",
				resolve: ctx => loader.Load(ctx.Source.Id).Then(i => i.Modified.GetValueOrDefault()));

			Field<ListGraphType<SnackType>>("Snacks", "All related snack entities",
				arguments: SnackArguments.GetQueryArguments(),
				resolve: SnackResolvers.GetMenuConnectionResolver(snackService));

			Field<ListGraphType<DrinkType>>("Drinks", "All related drink entities",
				arguments: DrinkArguments.GetQueryArguments(),
				resolve: DrinkResolvers.GetMenuConnectionResolver(drinkService));
		}
	}
}
