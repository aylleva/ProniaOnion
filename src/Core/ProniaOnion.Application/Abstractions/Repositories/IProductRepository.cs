using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.Abstractions.Repositories
{
    public interface IProductRepository:IRepository<Product>
    {
        Task<IEnumerable<T>> CheckIds<T>(ICollection<int> ids) where T : BaseEntity;
    }
}
