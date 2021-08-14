using GraphQL.DataLoader;
using GraphQL.Types;
using SnackTrace.GraphQL.Arguments;
using SnackTrace.GraphQL.DataLoaders.Interfaces;
using SnackTrace.GraphQL.Resolvers;
using SnackTrace.Services.Interfaces;

namespace SnackTrace.GraphQL.Types
{
	internal class SnackType : ObjectGraphType<Entities.Snack>
	{
		public SnackType(ISnackDataLoader loader, IMenuService menuService)
		{
			Name = nameof(Entities.Snack);

			Field(i => i.Id, type: typeof(IdGraphType)).Description("Identifier of entity");

			Field<DecimalGraphType>("Price", "Price of entity", 
				resolve: (ctx) => loader.Load(ctx.Source.Id).Then(i => i.Price));

			Field<StringGraphType>("Name", "Name of entity", 
				resolve: (ctx) => loader.Load(ctx.Source.Id).Then(i => i.Name));

			Field<DateTimeGraphType>("Created", "Creation date of entity", 
				resolve: ctx => loader.Load(ctx.Source.Id).Then(i => i.Created.GetValueOrDefault()));

			Field<DateTimeGraphType>("Modified", "Modified date of entity", 
				resolve: ctx => loader.Load(ctx.Source.Id).Then(i => i.Modified.GetValueOrDefault()));

			Field<ListGraphType<MenuType>>("Menus", "All related menu entities",
				arguments: MenuArguments.GetQueryArguments(),
				resolve: MenuResolvers.GetSnackConnectionResolver(menuService));
		}
	}
}
