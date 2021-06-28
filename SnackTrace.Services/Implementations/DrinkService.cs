using SnackTrace.Repositories.Interfaces;
using SnackTrace.Services.Converters;
using SnackTrace.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace SnackTrace.Services.Implementations
{
	public class DrinkService : BaseService<IDrinkRepository>, IDrinkService
	{
		public DrinkService(IDrinkRepository drinkRepository) : base(drinkRepository)
		{ }

		public IEnumerable<Data.Models.Drink> GetAll()
		{
			return _repository.GetAll();
		}

		public Data.Models.Drink Get(Guid id)
		{
			return _repository.Get(id);
		}

		public void Add(Data.Models.Drink entity)
		{
			_repository.Add(entity);
		}

		public void Remove(Guid id)
		{
			_repository.Remove(id);
		}

		public IEnumerable<GraphQL.Entities.Drink> GetGraph(GraphQL.Entities.Where.WhereDrink where)
		{
			return _repository.GetQuery(where).ToGraphEntities();
		}

		public IEnumerable<GraphQL.Entities.Drink> GetGraph(GraphQL.Entities.Where.WhereDrink where, GraphQL.Entities.Order.OrderDrink order, int first)
		{
			return _repository.GetQuery(where, order, first).ToGraphEntities();
		}
	}
}
