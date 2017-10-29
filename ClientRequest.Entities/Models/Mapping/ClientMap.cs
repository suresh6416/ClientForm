using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClientRequest.Entities.Models.Mapping
{
    public class ClientMap : EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Number)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Phone)
                .HasMaxLength(255);

            this.Property(t => t.Email)
                .HasMaxLength(255);

            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Clients");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Number).HasColumnName("Number");
            this.Property(t => t.ModuleID).HasColumnName("ModuleID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            this.HasOptional(t => t.Module)
                .WithMany(t => t.Clients)
                .HasForeignKey(d => d.ModuleID);

        }
    }
}
