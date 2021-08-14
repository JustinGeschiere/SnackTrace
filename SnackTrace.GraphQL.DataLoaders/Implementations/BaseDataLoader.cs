using GraphQL.DataLoader;

namespace SnackTrace.GraphQL.DataLoaders.Implementations
{
	internal abstract class BaseDataLoader<T>
	{
		protected readonly IDataLoaderContextAccessor _dataLoaderContextAccessor;

		protected string GetLoaderKey(string method) => $"{GetType()}_{method}";

		public BaseDataLoader(IDataLoaderContextAccessor dataLoaderContextAccessor)
		{
			_dataLoaderContextAccessor = dataLoaderContextAccessor;
		}
	}
}
