
namespace ProniaOnion.Domain.Entities
{
    public class Genre:BaseNamebleEntity
    {
        public ICollection<Blog> Blogs { get; set; }
    }
}
