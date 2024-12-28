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
    public class ProductColorsConfiguration : IEntityTypeConfiguration<ProductColors>
    {
        public void Configure(EntityTypeBuilder<ProductColors> builder)
        {
            builder.HasKey(x => new{ x.ProductId, x.ColorId });
            
            
        }
    }
}
