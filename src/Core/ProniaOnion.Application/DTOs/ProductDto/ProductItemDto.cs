using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.DTOs
{
   public record ProductItemDto(int Id,string Name,string SKU,string Description,decimal Price);
   
}
