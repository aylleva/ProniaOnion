

using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Domain.Entities
{
    public class Color:BaseNamebleEntity
    {
        public ICollection<ProductColors> ProductColors { get; set; }
    }
}
