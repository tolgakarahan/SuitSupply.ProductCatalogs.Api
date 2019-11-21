using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Constants;

namespace Persistence.Configurations
{
    public class ProductCatalogConfiguration : IEntityTypeConfiguration<ProductCatalog>
    {
        public void Configure(EntityTypeBuilder<ProductCatalog> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Code).HasName(ProductCatalogConstants.ProductCatalogCodeIndexName).IsUnique();

            builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastUpdate).IsRequired(false).HasColumnType("datetime");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Photo).IsRequired(false);
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,8)");
            
            builder.ToTable("ProductCatalogs");

        }
    }
}
