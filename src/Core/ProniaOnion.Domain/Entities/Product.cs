

using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Domain.Entities
{
   public class Product:BaseNamebleEntity
    {
        public decimal Price {  get; set; }
        public string SKU {  get; set; }
        public string Description { get; set; }

        public int CategoryId {  get; set; }
        public Category Category { get; set; }

        public ICollection<ProductColors> ProductColors { get; set; }
    }
}
