using System.Collections.Generic;

namespace SnackTrace.Services.Converters
{
	internal static class DrinkConverter
	{
		public static GraphQL.Entities.Drink ToGraphEntity(this Data.Models.Drink model)
		{
			return new GraphQL.Entities.Drink()
			{
				Id = model.Id,
				Name = model.Name,
				Price = model.Price
			};
		}

		public static IEnumerable<GraphQL.Entities.Drink> ToGraphEntities(this IEnumerable<Data.Models.Drink> models)
		{
			foreach (var model in models)
			{
				yield return model.ToGraphEntity();
			}
		}

		public static Data.Models.Drink ToDataEntity(this GraphQL.Entities.Drink model)
		{
			return new Data.Models.Drink()
			{
				Id = model.Id,
				Name = model.Name,
				Price = model.Price,
				Menus = new List<Data.Models.Menu>()
			};
		}

		public static IEnumerable<Data.Models.Drink> ToDataEntities(this IEnumerable<GraphQL.Entities.Drink> models)
		{
			foreach (var model in models)
			{
				yield return model.ToDataEntity();
			}
		}
	}
}
