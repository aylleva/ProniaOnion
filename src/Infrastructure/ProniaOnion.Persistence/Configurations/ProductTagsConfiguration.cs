using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using ProniaOnion.Domain.Entities;


namespace ProniaOnion.Persistence.Configurations
{
    internal class ProductTagsConfiguration : IEntityTypeConfiguration<ProductTags>
    {
        public void Configure(EntityTypeBuilder<ProductTags> builder)
        {
            builder.HasKey(pt => new { pt.ProductId,pt.TagId});
        }
    }
}
