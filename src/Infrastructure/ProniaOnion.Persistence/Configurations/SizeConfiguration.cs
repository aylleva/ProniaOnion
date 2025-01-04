using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProniaOnion.Domain.Entities;


namespace ProniaOnion.Persistence.Configurations
{
    internal class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.Property(t => t.Name).IsRequired().HasMaxLength(50);
            builder.HasIndex(t => t.Name).IsUnique();
        }
    }
}
