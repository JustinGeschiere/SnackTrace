using System;
using System.Linq;

namespace SnackTrace.Repositories.Interfaces
{
	public interface IBaseRepository<Tentity>
	{
		IQueryable<Tentity> GetAll();

		Tentity Get(Guid id);

		void Add(Tentity entity);

		void Remove(Guid id);
	}
}
