using SnackTrace.Data;

namespace SnackTrace.Repositories.Implementations
{
	internal abstract class BaseRepository
	{
		private protected readonly DataContext _dataContext;

		public BaseRepository(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
	}
}
