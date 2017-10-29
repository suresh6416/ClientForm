using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClientRequest.Entities.Models.Mapping
{
    public class RequestStatuMap : EntityTypeConfiguration<RequestStatu>
    {
        public RequestStatuMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Number)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.FromHours)
                .HasMaxLength(255);

            this.Property(t => t.ToHours)
                .HasMaxLength(255);

            this.Property(t => t.ToMinutes)
                .HasMaxLength(255);

            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("RequestStatus");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Number).HasColumnName("Number");
            this.Property(t => t.RequestID).HasColumnName("RequestID");
            this.Property(t => t.StatusID).HasColumnName("StatusID");
            this.Property(t => t.WorkLocationID).HasColumnName("WorkLocationID");
            this.Property(t => t.Narration).HasColumnName("Narration");
            this.Property(t => t.Note).HasColumnName("Note");
            this.Property(t => t.FromHours).HasColumnName("FromHours");
            this.Property(t => t.ToHours).HasColumnName("ToHours");
            this.Property(t => t.ToMinutes).HasColumnName("ToMinutes");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            this.HasOptional(t => t.Request)
                .WithMany(t => t.RequestStatus)
                .HasForeignKey(d => d.RequestID);
            this.HasOptional(t => t.StatusLookup)
                .WithMany(t => t.RequestStatus)
                .HasForeignKey(d => d.StatusID);
            this.HasOptional(t => t.WorkLocationLookup)
                .WithMany(t => t.RequestStatus)
                .HasForeignKey(d => d.WorkLocationID);

        }
    }
}
