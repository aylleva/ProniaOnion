using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.DTOs.ProductDto
{
     public record CreateProductDto(int Id, string Name, decimal Price,string SKU,string Description
         ,int CategoryId,ICollection<int> ColorIds,ICollection<int> TagIds,ICollection<int> SizeIds);
   
}
