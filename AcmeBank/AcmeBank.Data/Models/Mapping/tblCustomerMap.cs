using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AcmeBank.Data.Models.Mapping
{
    public class tblCustomerMap : EntityTypeConfiguration<tblCustomer>
    {
        public tblCustomerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Fullname)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("tblCustomer");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Fullname).HasColumnName("Fullname");
        }
    }
}
