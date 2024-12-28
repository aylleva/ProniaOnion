using ProniaOnion.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.DTOs
{
    public record GetCategoryDto(int Id,string Name,ICollection<ProductItemDto> Products);
    
}
