﻿

using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Domain.Entities;
using ProniaOnion.Persistence.Contexts;
using System.Linq.Expressions;

namespace ProniaOnion.Persistence.Implementations.Repositories.Generic
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        protected readonly AppDBContext _context;
        private readonly DbSet<T> _table;
        public Repository(AppDBContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>>? expression = null,
             Expression<Func<T, object>>? sort = null,
            bool IsDescending = false,
            bool IsTracking = false,
            bool ignoreFilter=false,
            int skip = 0,
            int take = 0,
            params string[]? includes)

        {
            IQueryable<T> query = _table;

            if (expression is not null) query = query.Where(expression);

            if (includes is not null)
            {
                query = getincludes(query, includes);
            }

            if (sort is not null) query = IsDescending ? query.OrderByDescending(sort) : query.OrderBy(sort);

            query = query.Skip(skip);

            if (take != 0) query = query.Take(take);

            if(ignoreFilter) query=query.IgnoreQueryFilters();

            return IsTracking ? query : query.AsNoTracking();

        }

        public async Task<T> GetbyIdAsync(int? id, params string[]? includes)
        {
            IQueryable<T> query = _table;

            if (includes is not null)
            {
                query=getincludes(query, includes);
            }

            return await query.FirstOrDefaultAsync(c => c.Id == id);
        }


        public async Task AddAsync(T entity)
        {
            await _table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
        }


        public void Update(T entity)
        {
            _table.Update(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }


        private IQueryable<T> getincludes(IQueryable<T> query, params string[]? includes)
        {
            for (int i = 0; i < includes.Length; i++)
            {
                query = query.Include(includes[i]);
            }
            return query;
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>>? expression)
        {
            return _table.AnyAsync(expression);
        }
    }
}
