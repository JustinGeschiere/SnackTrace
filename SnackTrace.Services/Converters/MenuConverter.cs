using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackTrace.Services.Converters
{
	internal static class MenuConverter
	{
		public static GraphQL.Entities.Menu ToGraphEntity(this Data.Models.Menu model)
		{
			return new GraphQL.Entities.Menu()
			{
				Id = model.Id,
				Name = model.Name,
				Price = model.Price,
				Created = model.Created,
				Modified = model.Modified
			};
		}

		public static IEnumerable<GraphQL.Entities.Menu> ToGraphEntities(this IEnumerable<Data.Models.Menu> models)
		{
			foreach (var model in models)
			{
				yield return model.ToGraphEntity();
			}
		}

		public static async Task<IEnumerable<GraphQL.Entities.Menu>> ToGraphEntitiesAsync(this IEnumerable<Data.Models.Menu> models)
		{
			var conversionTasks = models.Select(i => Task.Run(() => i.ToGraphEntity()));

			await Task.WhenAll(conversionTasks);

			return conversionTasks.Select(i => i.Result);
		}

		/*
		public static Data.Models.Menu ToDataEntity(this GraphQL.Entities.Menu model)
		{
			return new Data.Models.Menu()
			{
				Id = model.Id,
				Name = model.Name,
				Price = model.Price,
				Created = model.Created,
				Modified = model.Modified,
				Snacks = new List<Data.Models.Snack>(),
				Drinks = new List<Data.Models.Drink>()
			};
		}

		public static IEnumerable<Data.Models.Menu> ToDataEntities(this IEnumerable<GraphQL.Entities.Menu> models)
		{
			foreach (var model in models)
			{
				yield return model.ToDataEntity();
			}
		}
		*/
	}
}
