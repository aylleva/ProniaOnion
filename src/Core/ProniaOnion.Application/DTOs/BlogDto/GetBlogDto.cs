using ProniaOnion.Application.DTOs.AuthorDto;
using ProniaOnion.Application.DTOs.GenreDto;


namespace ProniaOnion.Application.DTOs.BlogDto
{
   public record GetBlogDto(int Id, string Article, string Title, string Image,GetAuthorDto Author,GetGenreDto Genre);
}
