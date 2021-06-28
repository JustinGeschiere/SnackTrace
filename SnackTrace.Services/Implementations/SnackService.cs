using SnackTrace.Repositories.Interfaces;
using SnackTrace.Services.Converters;
using SnackTrace.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace SnackTrace.Services.Implementations
{
	internal class SnackService : BaseService<ISnackRepository>, ISnackService
	{
		public SnackService(ISnackRepository snackRepository) : base(snackRepository)
		{ }

		public IEnumerable<Data.Models.Snack> GetAll()
		{
			return _repository.GetAll();
		}

		public Data.Models.Snack Get(Guid id)
		{
			return _repository.Get(id);
		}

		public void Add(Data.Models.Snack entity)
		{
			_repository.Add(entity);
		}

		public void Remove(Guid id)
		{
			_repository.Remove(id);
		}

		public IEnumerable<GraphQL.Entities.Snack> GetGraphEntities(GraphQL.Entities.Where.WhereSnack where, GraphQL.Entities.Order.OrderSnack order, int skip, int take)
		{
			return _repository.GetQuery(where, order, skip, take).ToGraphEntities();
		}
	}
}
