using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Persistence.Configurations
{
    internal class BlogTagsConfiguration : IEntityTypeConfiguration<BlogTags>
    {
        public void Configure(EntityTypeBuilder<BlogTags> builder)
        {
            builder.HasKey(bt => new { bt.BlogId, bt.TagId });
        }
    }
}
