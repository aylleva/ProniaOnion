﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Persistence.Configurations
{
    internal class ProductSizesConfiguration : IEntityTypeConfiguration<ProductSizes>
    {
        public void Configure(EntityTypeBuilder<ProductSizes> builder)
        {
            builder.HasKey(pt => new { pt.ProductId, pt.SizeId });
        }
    }
}
