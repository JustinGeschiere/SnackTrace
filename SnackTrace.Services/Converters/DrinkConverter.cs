using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
				Price = model.Price,
				Created = model.Created,
				Modified = model.Modified
			};
		}

		public static IEnumerable<GraphQL.Entities.Drink> ToGraphEntities(this IEnumerable<Data.Models.Drink> models)
		{
			foreach (var model in models)
			{
				yield return model.ToGraphEntity();
			}
		}

		public static async Task<IEnumerable<GraphQL.Entities.Drink>> ToGraphEntitiesAsync(this IEnumerable<Data.Models.Drink> models)
		{
			var conversionTasks = models.Select(i => Task.Run(() => i.ToGraphEntity()));

			await Task.WhenAll(conversionTasks);

			return conversionTasks.Select(i => i.Result);
		}

		/*
		public static Data.Models.Drink ToDataEntity(this GraphQL.Entities.Drink model)
		{
			return new Data.Models.Drink()
			{
				Id = model.Id,
				Name = model.Name,
				Price = model.Price,
				Created = model.Created,
				Modified = model.Modified,
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
		*/
	}
}
