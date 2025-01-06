

using Microsoft.EntityFrameworkCore;
using ProniaOnion.Domain.Entities;
using System.Runtime.CompilerServices;

namespace ProniaOnion.Persistence.Common
{
    internal static class QlobalQueryFilters
    {

        public static void ApplyFilter<T>(this ModelBuilder modelBuilder)where T : BaseEntity, new()
        {
            modelBuilder.Entity<T>().HasQueryFilter(q=>q.IsDeleted==false);
        }

        public static void ApplyQueryFilters(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyFilter<Category>();
            modelBuilder.ApplyFilter<Color>();
            modelBuilder.ApplyFilter<Size>();
            modelBuilder.ApplyFilter<Tag>();
            modelBuilder.ApplyFilter<Author>();
            modelBuilder.ApplyFilter<Blog>();
            modelBuilder.ApplyFilter<Genre>();
        }
    }
}
