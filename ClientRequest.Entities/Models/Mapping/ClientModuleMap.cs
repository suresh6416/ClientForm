using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClientRequest.Entities.Models.Mapping
{
    public class ClientModuleMap : EntityTypeConfiguration<ClientModule>
    {
        public ClientModuleMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("ClientModules");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ClientId).HasColumnName("ClientId");
            this.Property(t => t.ModuleID).HasColumnName("ModuleID");

            // Relationships
            this.HasOptional(t => t.Client)
                .WithMany(t => t.ClientModules)
                .HasForeignKey(d => d.ClientId);
            this.HasOptional(t => t.Module)
                .WithMany(t => t.ClientModules)
                .HasForeignKey(d => d.ModuleID);

        }
    }
}
