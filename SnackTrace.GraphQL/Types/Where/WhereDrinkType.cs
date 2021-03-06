using GraphQL.Types;
using SnackTrace.GraphQL.Entities.Where;

namespace SnackTrace.GraphQL.Types.Where
{
	internal class WhereDrinkType : InputObjectGraphType<WhereDrink>
	{
		public WhereDrinkType()
		{
			Name = "WhereDrink";
			Field(i => i.Id, type: typeof(GuidGraphType)).Description("Identifier to find an entity");
			Field(i => i.Search, type: typeof(StringGraphType)).Description("Search string to find an entity");
			Field(i => i.CreatedAfter, type: typeof(DateTimeGraphType)).Description("Creation date to find entities that have been created after");
		}
	}
}
