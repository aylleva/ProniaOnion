

using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Domain.Entities
{
    public class Category:BaseNamebleEntity
    {
        public ICollection<Product>? Products { get; set; }
    }
}
