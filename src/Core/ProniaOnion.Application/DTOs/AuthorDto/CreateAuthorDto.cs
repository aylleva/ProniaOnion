using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.DTOs.AuthorDto
{
    public record CreateAuthorDto(string Name, string Surname, string ProfileImage);
    
}
