using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClientRequest.Entities.Models.Mapping
{
    public class StatusLookupMap : EntityTypeConfiguration<StatusLookup>
    {
        public StatusLookupMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("StatusLookup");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
        }
    }
}
