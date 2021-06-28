using System.Collections.Generic;

namespace SnackTrace.Services.Converters
{
	public static class SnackConverter
	{
		public static GraphQL.Entities.Snack ToGraphEntity(this Data.Models.Snack model)
		{
			return new GraphQL.Entities.Snack() 
			{ 
				Id = model.Id,
				Name = model.Name,
				Price = model.Price
			};
		}

		public static IEnumerable<GraphQL.Entities.Snack> ToGraphEntities(this IEnumerable<Data.Models.Snack> models)
		{
			foreach (var model in models)
			{
				yield return model.ToGraphEntity();
			}
		}

		public static Data.Models.Snack ToDataEntity(this GraphQL.Entities.Snack model)
		{
			return new Data.Models.Snack()
			{
				Id = model.Id,
				Name = model.Name,
				Price = model.Price,
				Menus = new List<Data.Models.Menu>()
			};
		}

		public static IEnumerable<Data.Models.Snack> ToDayaEntities(this IEnumerable<GraphQL.Entities.Snack> models)
		{
			foreach (var model in models)
			{
				yield return model.ToDataEntity();
			}
		}
	}
}
