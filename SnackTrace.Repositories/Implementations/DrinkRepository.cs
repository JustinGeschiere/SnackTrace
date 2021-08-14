using Microsoft.EntityFrameworkCore;
using SnackTrace.Data;
using SnackTrace.Data.Models;
using SnackTrace.GraphQL.Entities.Order;
using SnackTrace.GraphQL.Entities.Where;
using SnackTrace.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnackTrace.Repositories.Implementations
{
	internal class DrinkRepository : BaseRepository, IDrinkRepository
	{
		public DrinkRepository(DataContext dataContext) : base(dataContext)
		{ }

		public IQueryable<Drink> GetAll()
		{
			return _dataContext.Drinks
				.Include(i => i.Menus);
		}

		public Drink Get(Guid id)
		{
			return GetAll().FirstOrDefault(i => i.Id.Equals(id));
		}

		public void Add(Drink entity)
		{
			_dataContext.Add(entity);
			_dataContext.SaveChanges();
		}

		public void Remove(Guid id)
		{
			var entity = Get(id);

			if (entity == null)
			{
				return;
			}

			_dataContext.Remove(entity);
			_dataContext.SaveChanges();
		}

		public IQueryable<Drink> GetGraphQuery(WhereDrink where, OrderDrink order, int skip, int take)
		{
			var query = GetBaseQuery(where);

			HandleWhere(ref query, where);

			HandleOrder(ref query, order);

			if (skip != default)
			{
				query = query.Skip(skip);
			}

			if (take != default)
			{
				query = query.Take(take);
			}

			return query;
		}

		public IQueryable<Drink> GetLoadQuery(IEnumerable<Guid> ids)
		{
			return _dataContext.Drinks
				.Where(i => ids.Contains(i.Id));
		}

		private IQueryable<Drink> GetBaseQuery(WhereDrink where)
		{
			var query = _dataContext.Drinks;

			if (where != null)
			{
				if (where.ContainsMenu != default)
				{
					query.Include(i => i.Menus);
				}
			}

			return query;
		}

		private void HandleWhere(ref IQueryable<Drink> query, WhereDrink where)
		{
			if (where != null)
			{
				if (where.Id != default)
				{
					query = query.Where(i => i.Id.Equals(where.Id));
				}

				if (where.Search != default)
				{
					query = query.Where(i => i.Name.Contains(where.Search));
				}

				if (where.ContainsMenu != default)
				{
					query = query.Where(i => i.Menus.Any(i => i.Id.Equals(where.ContainsMenu)));
				}

				if (where.CreatedAfter != default)
				{
					query = query.Where(i => i.Created.GetValueOrDefault() >= where.CreatedAfter);
				}
			}
		}

		private void HandleOrder(ref IQueryable<Drink> query, OrderDrink order)
		{
			if (order != null)
			{
				bool isAscending = order.Direction.Equals(OrderDirection.Ascending);

				Func<IQueryable<Drink>, IOrderedQueryable<Drink>> operation = order.Option switch
				{
					OrderDrink.Options.Name => (i) => isAscending ? i.OrderBy(i => i.Name) : i.OrderByDescending(i => i.Name),
					OrderDrink.Options.Price => (i) => isAscending ? i.OrderBy(i => i.Price) : i.OrderByDescending(i => i.Price),
					OrderDrink.Options.Created => (i) => isAscending ? i.OrderBy(i => i.Created) : i.OrderByDescending(i => i.Created),
					OrderDrink.Options.Modified => (i) => isAscending ? i.OrderBy(i => i.Modified) : i.OrderByDescending(i => i.Modified),
					_ => throw new InvalidOperationException("Invalid enum type")
				};

				query = operation(query);
			}
		}
	}
}
