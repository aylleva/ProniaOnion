using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.DTOs.ProductDto
{
   public record GetProductDto(int Id, string Name, decimal Price,CategoryItemDto Category,
       string SKU,string Decription,
       IEnumerable<ColorItemDto> Colors,
    IEnumerable<TagItemDto> Tags,
    IEnumerable<SizeItemDto> Sizes);


}
