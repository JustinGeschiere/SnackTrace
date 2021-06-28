using Microsoft.EntityFrameworkCore;
using SnackTrace.Data;
using SnackTrace.Data.Models;
using SnackTrace.GraphQL.Entities.Order;
using SnackTrace.GraphQL.Entities.Where;
using SnackTrace.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SnackTrace.Repositories.Implementations
{
	public class SnackRepository : BaseRepository, ISnackRepository
	{
		public SnackRepository(DataContext dataContext) : base(dataContext)
		{ }

		public IQueryable<Snack> GetAll()
		{
			return _dataContext.Snacks
				.Include(i => i.Menus);
		}

		public Snack Get(Guid id)
		{
			return GetAll().FirstOrDefault(i => i.Id.Equals(id));
		}

		public void Add(Snack entity)
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

		public IQueryable<Snack> GetQuery(WhereSnack where)
		{
			var query = GetBaseQuery(where);

			HandleWhere(ref query, where);

			return query;
		}

		public IQueryable<Snack> GetQuery(WhereSnack where, OrderSnack order, int first)
		{
			var query = GetBaseQuery(where);

			HandleWhere(ref query, where);

			HandleOrder(ref query, order);

			if (first != default)
			{
				query = query.Take(first);
			}

			return query;
		}

		private IQueryable<Snack> GetBaseQuery(WhereSnack where)
		{
			var query = _dataContext.Snacks;

			if (where != null)
			{
				if (where.ContainsMenu != default)
				{
					query.Include(i => i.Menus);
				}
			}

			return query;
		}

		private void HandleWhere(ref IQueryable<Snack> query, WhereSnack where)
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

					query = query.OrderBy<Snack, string>(i => i.Name);
				}
			}
		}

		private void HandleOrder(ref IQueryable<Snack> query, OrderSnack order)
		{
			if (order != null)
			{
				bool isAscending = order.Direction.Equals(OrderDirection.Ascending);

				Func<IQueryable<Snack>, IOrderedQueryable<Snack>> operation = order.Option switch
				{
					OrderSnack.Options.Name => (i) => isAscending ? i.OrderBy(i => i.Name) : i.OrderByDescending(i => i.Name),
					OrderSnack.Options.Price => (i) => isAscending ? i.OrderBy(i => i.Price) : i.OrderByDescending(i => i.Price),
					OrderSnack.Options.Created => (i) => isAscending ? i.OrderBy(i => i.Created) : i.OrderByDescending(i => i.Created),
					OrderSnack.Options.Modified => (i) => isAscending ? i.OrderBy(i => i.Modified) : i.OrderByDescending(i => i.Modified),
					_ => throw new InvalidOperationException("Invalid enum type")
				};

				query = operation(query);
			}
		}
	}
}
