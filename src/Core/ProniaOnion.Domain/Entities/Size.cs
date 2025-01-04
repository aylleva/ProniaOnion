using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Domain.Entities
{
    public class Size:BaseNamebleEntity
    {
        public ICollection<ProductSizes> ProductSizes { get; set; }
    }
}
