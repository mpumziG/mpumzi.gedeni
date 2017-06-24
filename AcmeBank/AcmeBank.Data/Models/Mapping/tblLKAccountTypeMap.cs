using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AcmeBank.Data.Models.Mapping
{
    public class tblLKAccountTypeMap : EntityTypeConfiguration<tblLKAccountType>
    {
        public tblLKAccountTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("tblLKAccountType");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
