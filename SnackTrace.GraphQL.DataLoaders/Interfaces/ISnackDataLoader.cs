using GraphQL.DataLoader;
using SnackTrace.GraphQL.Entities;
using System;
using System.Collections.Generic;

namespace SnackTrace.GraphQL.DataLoaders.Interfaces
{
	public interface ISnackDataLoader
	{
		IDataLoaderResult<Snack> Load(Guid id);

		IDataLoaderResult<IEnumerable<Snack>> LoadMany(Guid id);
	}
}
