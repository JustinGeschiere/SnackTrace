using GraphQL;
using GraphQL.Types;
using SnackTrace.GraphQL.Entities.Where;
using SnackTrace.GraphQL.Types.Where;
using SnackTrace.Repositories.Interfaces;
using SnackTrace.Services.Converters;
using System.Collections.Generic;

namespace SnackTrace.GraphQL.Types
{
	internal class MenuType : ObjectGraphType<Entities.Menu>
	{
		public MenuType(ISnackRepository snackRepository, IDrinkRepository drinkRepository)
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
				description: "Collection of related menu entities",
				arguments: new QueryArguments(new List<QueryArgument>()
				{
					new QueryArgument<WhereSnackType>()
					{
						Name = "where"
					}
				}),
				resolve: context =>
				{
					var where = context.GetArgument<WhereSnack>("where");

					if (where == null)
					{
						where = new WhereSnack();
					}

					// Always search from current entity scope
					where.ContainsMenu = context.Source.Id;

					return snackRepository.GetQuery(where).ToGraphEntities();
				});

			Field(typeof(ListGraphType<DrinkType>), "Drinks",
				description: "Collection of related menu entities",
				arguments: new QueryArguments(new List<QueryArgument>()
				{
					new QueryArgument<WhereDrinkType>()
					{
						Name = "where"
					}
				}),
				resolve: context =>
				{
					var where = context.GetArgument<WhereDrink>("where");

					if (where == null)
					{
						where = new WhereDrink();
					}

					// Always search from current entity scope
					where.ContainsMenu = context.Source.Id;

					return drinkRepository.GetQuery(where).ToGraphEntities();
				});
		}
	}
}
