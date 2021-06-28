using GraphQL;
using GraphQL.Types;
using SnackTrace.GraphQL.Entities.Where;
using SnackTrace.GraphQL.Types.Where;
using SnackTrace.Repositories.Interfaces;
using SnackTrace.Services.Converters;
using System.Collections.Generic;

namespace SnackTrace.GraphQL.Types
{
	internal class SnackType : ObjectGraphType<Entities.Snack>
	{
		public SnackType(IMenuRepository menuRepository)
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
				description: "Collection of related menu entities",
				arguments: new QueryArguments(new List<QueryArgument>()
				{
					new QueryArgument<WhereMenuType>()
					{
						Name = "where"
					}
				}),
				resolve: context => 
				{
					var where = context.GetArgument<WhereMenu>("where");

					if (where == null)
					{
						where = new WhereMenu();
					}

					// Always search from current entity scope
					where.ContainsSnack = context.Source.Id;

					return menuRepository.GetQuery(where).ToGraphEntities();
				});
		}
	}
}
