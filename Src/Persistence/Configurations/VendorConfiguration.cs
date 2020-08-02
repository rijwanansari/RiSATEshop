using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RiSAT.Eshop.Domain.Vendor;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiSAT.Eshop.Persistence.Configurations
{
    public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.ToTable(nameof(Vendor));
            builder.HasKey(vendor => vendor.Id);
            builder.Property(vendor => vendor.Name).HasMaxLength(400).IsRequired();
            builder.Property(vendor => vendor.Email).HasMaxLength(200);
            builder.Property(vendor => vendor.MetaKeywords).HasMaxLength(400);
            builder.Property(vendor => vendor.MetaTitle).HasMaxLength(400);
            builder.Property(vendor => vendor.PageSizeOptions).HasMaxLength(200);
        }
    }
}
