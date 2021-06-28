using System;
using System.Linq;

namespace SnackTrace.Repositories.Interfaces
{
	public interface IBaseRepository<Tentity, Twhere>
	{
		public abstract IQueryable<Tentity> GetAll();

		public abstract Tentity Get(Guid id);

		public abstract void Add(Tentity entity);

		public abstract void Remove(Guid id);

		public abstract IQueryable<Tentity> GetQuery(Twhere where);
	}
}
