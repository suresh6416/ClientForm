using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClientRequest.Entities.Models.Mapping
{
    public class RequestMap : EntityTypeConfiguration<Request>
    {
        public RequestMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Number)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Assessment)
                .HasMaxLength(510);

            this.Property(t => t.RequestedBy)
                .HasMaxLength(255);

            this.Property(t => t.AssignedTo)
                .HasMaxLength(255);

            this.Property(t => t.CRW)
                .HasMaxLength(255);

            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Requests");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Number).HasColumnName("Number");
            this.Property(t => t.ModuleID).HasColumnName("ModuleID");
            this.Property(t => t.JobNatureID).HasColumnName("JobNatureID");
            this.Property(t => t.ClientID).HasColumnName("ClientID");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Assessment).HasColumnName("Assessment");
            this.Property(t => t.RequestedBy).HasColumnName("RequestedBy");
            this.Property(t => t.RequestedOn).HasColumnName("RequestedOn");
            this.Property(t => t.AssignedTo).HasColumnName("AssignedTo");
            this.Property(t => t.CRW).HasColumnName("CRW");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            this.HasOptional(t => t.Client)
                .WithMany(t => t.Requests)
                .HasForeignKey(d => d.ClientID);
            this.HasOptional(t => t.JobNature)
                .WithMany(t => t.Requests)
                .HasForeignKey(d => d.JobNatureID);
            this.HasOptional(t => t.Module)
                .WithMany(t => t.Requests)
                .HasForeignKey(d => d.ModuleID);

        }
    }
}
