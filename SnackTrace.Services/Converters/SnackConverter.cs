using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackTrace.Services.Converters
{
	internal static class SnackConverter
	{
		public static GraphQL.Entities.Snack ToGraphEntity(this Data.Models.Snack model)
		{
			return new GraphQL.Entities.Snack() 
			{ 
				Id = model.Id,
				Name = model.Name,
				Price = model.Price,
				Created = model.Created,
				Modified = model.Modified
			};
		}

		public static IEnumerable<GraphQL.Entities.Snack> ToGraphEntities(this IEnumerable<Data.Models.Snack> models)
		{
			foreach (var model in models)
			{
				yield return model.ToGraphEntity();
			}
		}

		public static async Task<IEnumerable<GraphQL.Entities.Snack>> ToGraphEntitiesAsync(this IEnumerable<Data.Models.Snack> models)
		{
			var conversionTasks = models.Select(i => Task.Run(() => i.ToGraphEntity()));

			await Task.WhenAll(conversionTasks);

			return conversionTasks.Select(i => i.Result);
		}

		/*
		public static Data.Models.Snack ToDataEntity(this GraphQL.Entities.Snack model)
		{
			return new Data.Models.Snack()
			{
				Id = model.Id,
				Name = model.Name,
				Price = model.Price,
				Created = model.Created,
				Modified = model.Modified,
				Menus = new List<Data.Models.Menu>()
			};
		}

		public static IEnumerable<Data.Models.Snack> ToDataEntities(this IEnumerable<GraphQL.Entities.Snack> models)
		{
			foreach (var model in models)
			{
				yield return model.ToDataEntity();
			}
		}
		*/
	}
}
