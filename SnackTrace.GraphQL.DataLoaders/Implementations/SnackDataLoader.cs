using GraphQL.DataLoader;
using SnackTrace.GraphQL.DataLoaders.Interfaces;
using SnackTrace.GraphQL.Entities;
using SnackTrace.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnackTrace.GraphQL.DataLoaders.Implementations
{
	internal class SnackDataLoader : BaseDataLoader<Snack>, ISnackDataLoader
	{
		private readonly ISnackService _snackService;
		private readonly IMenuService _menuService;

		public SnackDataLoader(IDataLoaderContextAccessor dataLoaderContextAccessor, ISnackService snackService, IMenuService menuService) 
			: base(dataLoaderContextAccessor)
		{
			_snackService = snackService;
			_menuService = menuService;
		}

		public IDataLoaderResult<Snack> Load(Guid id)
		{
			var loader = _dataLoaderContextAccessor.Context.GetOrAddBatchLoader<Guid, Snack>(GetLoaderKey(nameof(Load)), async (ids, cancellationToken) =>
			{
				var entities = await _snackService.LoadGraphEntitiesAsync(ids);
				return entities.ToDictionary(i => i.Key, i => i.First());
			});

			return loader.LoadAsync(id);
		}

		public IDataLoaderResult<IEnumerable<Snack>> LoadMany(Guid id)
		{
			var loader = _dataLoaderContextAccessor.Context.GetOrAddCollectionBatchLoader<Guid, Snack>(GetLoaderKey(nameof(LoadMany)), async (ids, cancellationToken) =>
			{
				var entities = await _snackService.LoadGraphEntitiesAsync(ids);
				return entities;
			});

			return loader.LoadAsync(id);
		}

		// TODO: Remove this
		public IDataLoaderResult<IEnumerable<Snack>> LoadManyByMenuId(Guid id)
		{
			// TODO: async
			var loader = _dataLoaderContextAccessor.Context.GetOrAddCollectionBatchLoader<Guid, Snack>(GetLoaderKey(nameof(LoadManyByMenuId)), async (ids, cancellationToken) =>
			{
				var entities = _snackService.LoadMenuConnectionGraphEntities(ids);
				return entities;
			});

			return loader.LoadAsync(id);
		}
	}
}
