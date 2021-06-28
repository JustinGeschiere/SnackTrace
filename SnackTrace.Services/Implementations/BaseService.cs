namespace SnackTrace.Services.Implementations
{
	public abstract class BaseService<Trepository>
	{
		private protected readonly Trepository _repository;

		public BaseService(Trepository repository)
		{
			_repository = repository;
		}
	}
}
