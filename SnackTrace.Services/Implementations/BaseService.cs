namespace SnackTrace.Services.Implementations
{
	internal abstract class BaseService<Trepository>
	{
		private protected readonly Trepository _repository;

		public BaseService(Trepository repository)
		{
			_repository = repository;
		}
	}
}
