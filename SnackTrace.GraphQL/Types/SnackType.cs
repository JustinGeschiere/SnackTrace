using GraphQL.Types;
using SnackTrace.GraphQL.Arguments;
using SnackTrace.GraphQL.Resolvers;
using SnackTrace.Services.Interfaces;

namespace SnackTrace.GraphQL.Types
{
	internal class SnackType : ObjectGraphType<Entities.Snack>
	{
		public SnackType(IMenuService menuService)
		{
			Name = "Snack";
			Field(i => i.Id, type: typeof(IdGraphType)).Description("Identifier of entity");
			Field(i => i.Price).Description("Price of entity");
			Field(i => i.Name).Description("Name of entity");

			Field(typeof(DateTimeGraphType), "Created",
				description: "Creation date of entity",
				resolve: context => context.Source.Created.GetValueOrDefault());

			Field(typeof(DateTimeGraphType), "Modified",
				description: "Modified date of entity",
				resolve: context => context.Source.Modified.GetValueOrDefault());

			Field(typeof(ListGraphType<MenuType>), "Menus",
				description: "All related menu entities",
				arguments: MenuArguments.GetQueryArguments(),
				resolve: MenuResolvers.GetSnackConnectionResolver(menuService));
		}
	}
}
