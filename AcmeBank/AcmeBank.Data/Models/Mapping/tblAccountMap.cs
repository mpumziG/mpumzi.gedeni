using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AcmeBank.Data.Models.Mapping
{
    public class tblAccountMap : EntityTypeConfiguration<tblAccount>
    {
        public tblAccountMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("tblAccounts");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.fkLKAccountType).HasColumnName("fkLKAccountType");
            this.Property(t => t.fkCustomerId).HasColumnName("fkCustomerId");
            this.Property(t => t.Balance).HasColumnName("Balance");

            // Relationships
            this.HasRequired(t => t.tblCustomer)
                .WithMany(t => t.tblAccounts)
                .HasForeignKey(d => d.fkCustomerId);
            this.HasRequired(t => t.tblLKAccountType)
                .WithMany(t => t.tblAccounts)
                .HasForeignKey(d => d.fkLKAccountType);

        }
    }
}
