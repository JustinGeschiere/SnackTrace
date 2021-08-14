using GraphQL.DataLoader;
using SnackTrace.GraphQL.Entities;
using System;
using System.Collections.Generic;

namespace SnackTrace.GraphQL.DataLoaders.Interfaces
{
	public interface IMenuDataLoader
	{
		IDataLoaderResult<Menu> Load(Guid id);

		IDataLoaderResult<IEnumerable<Menu>> LoadMany(Guid id);
	}
}
