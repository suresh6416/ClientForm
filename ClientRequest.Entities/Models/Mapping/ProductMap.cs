using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClientRequest.Entities.Models.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Primary Key
            this.HasKey(t => t.slNO);

            // Properties
            this.Property(t => t.ProductName)
                .HasMaxLength(50);

            this.Property(t => t.ImageUrl)
                .HasMaxLength(450);

            // Table & Column Mappings
            this.ToTable("Products");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.slNO).HasColumnName("slNO");
            this.Property(t => t.productId).HasColumnName("productId");
            this.Property(t => t.ImageUrl).HasColumnName("ImageUrl");
        }
    }
}
