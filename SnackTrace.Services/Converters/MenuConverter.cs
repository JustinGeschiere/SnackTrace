using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnackTrace.Services.Converters
{
	public static class MenuConverter
	{
		public static GraphQL.Entities.Menu ToGraphEntity(this Data.Models.Menu model)
		{
			return new GraphQL.Entities.Menu()
			{
				Id = model.Id,
				Name = model.Name,
				Price = model.Price
			};
		}

		public static IEnumerable<GraphQL.Entities.Menu> ToGraphEntities(this IEnumerable<Data.Models.Menu> models)
		{
			foreach (var model in models)
			{
				yield return model.ToGraphEntity();
			}
		}

		public static Data.Models.Menu ToDataEntity(this GraphQL.Entities.Menu model)
		{
			return new Data.Models.Menu()
			{
				Id = model.Id,
				Name = model.Name,
				Price = model.Price,
				Snacks = new List<Data.Models.Snack>(),
				Drinks = new List<Data.Models.Drink>()
			};
		}

		public static IEnumerable<Data.Models.Menu> ToDayaEntities(this IEnumerable<GraphQL.Entities.Menu> models)
		{
			foreach (var model in models)
			{
				yield return model.ToDataEntity();
			}
		}
	}
}
