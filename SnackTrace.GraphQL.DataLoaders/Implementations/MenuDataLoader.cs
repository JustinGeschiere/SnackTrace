using GraphQL.DataLoader;
using SnackTrace.GraphQL.DataLoaders.Interfaces;
using SnackTrace.GraphQL.Entities;
using SnackTrace.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnackTrace.GraphQL.DataLoaders.Implementations
{
	internal class MenuDataLoader : BaseDataLoader<Menu>, IMenuDataLoader
	{
		private readonly IMenuService _menuService;

		public MenuDataLoader(IDataLoaderContextAccessor dataLoaderContextAccessor, IMenuService menuService)
			: base(dataLoaderContextAccessor)
		{
			_menuService = menuService;
		}

		public IDataLoaderResult<Menu> Load(Guid id)
		{
			// TODO: async
			var loader = _dataLoaderContextAccessor.Context.GetOrAddBatchLoader<Guid, Menu>(GetLoaderKey(nameof(Load)), async (ids, cancellationToken) =>
			{
				var entities = _menuService.LoadGraphEntities(ids);
				return entities.ToDictionary(i => i.Key, i => i.First());
			});

			return loader.LoadAsync(id);
		}

		public IDataLoaderResult<IEnumerable<Menu>> LoadMany(Guid id)
		{
			// TODO: async
			var loader = _dataLoaderContextAccessor.Context.GetOrAddCollectionBatchLoader<Guid, Menu>(GetLoaderKey(nameof(LoadMany)), async (ids, cancellationToken) =>
			{
				var entities = _menuService.LoadGraphEntities(ids);
				return entities;
			});

			return loader.LoadAsync(id);
		}
	}
}
