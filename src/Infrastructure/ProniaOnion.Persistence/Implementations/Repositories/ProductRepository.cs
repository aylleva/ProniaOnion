using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Domain.Entities;
using ProniaOnion.Persistence.Contexts;
using ProniaOnion.Persistence.Implementations.Repositories.Generic;


namespace ProniaOnion.Persistence.Implementations.Repositories
{
    internal class ProductRepository:Repository<Product>,IProductRepository
    {
        public ProductRepository(AppDBContext context) : base(context) { }
       
        public async Task<IEnumerable<T>> CheckIds<T>(ICollection<int> ids) where T : BaseEntity
        {
             return await  _context.Set<T>().Where(s=>ids.Contains(s.Id)).ToListAsync();
        } 
    }
}
