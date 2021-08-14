using SnackTrace.Repositories.Interfaces;
using SnackTrace.Services.Converters;
using SnackTrace.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
			var query = _repository.GetGraphQuery(where, order, skip, take);
			return query.ToGraphEntities();
		}

		public async Task<IEnumerable<GraphQL.Entities.Snack>> GetGraphEntitiesAsync(GraphQL.Entities.Where.WhereSnack where, GraphQL.Entities.Order.OrderSnack order, int skip, int take)
		{
			var query = _repository.GetGraphQuery(where, order, skip, take);
			return await query.ToGraphEntitiesAsync();
		}

		public ILookup<Guid, GraphQL.Entities.Snack> LoadGraphEntities(IEnumerable<Guid> ids)
		{
			var query = _repository.GetLoadQuery(ids);
			return query.ToGraphEntities().ToLookup(i => i.Id);
		}

		public async Task<ILookup<Guid, GraphQL.Entities.Snack>> LoadGraphEntitiesAsync(IEnumerable<Guid> ids)
		{
			var query = _repository.GetLoadQuery(ids);
			var result = await query.ToGraphEntitiesAsync();
			return result.ToLookup(i => i.Id);
		}

		// TODO: Remove this
		public ILookup<Guid, GraphQL.Entities.Snack> LoadMenuConnectionGraphEntities(IEnumerable<Guid> ids)
		{
			var result = _repository.GetMenuConnectionLoadQuery(ids).AsEnumerable();

			var pairedResult = result.SelectMany(i =>
			{
				var entity = i.ToGraphEntity();
				var entries = new List<KeyValuePair<Guid, GraphQL.Entities.Snack>>();

				foreach(var id in i.Menus.Select(j => j.Id))
				{
					entries.Add(new KeyValuePair<Guid, GraphQL.Entities.Snack>(id, entity));
				}

				return entries;
			});

			return pairedResult.ToLookup(i => i.Key, i => i.Value);
		}
	}
}
