using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using AcmeBank.Data.Models.Mapping;

namespace AcmeBank.Data.Models
{
    public partial class AcmeBankContext : DbContext
    {
        static AcmeBankContext()
        {
            Database.SetInitializer<AcmeBankContext>(null);
        }

        public AcmeBankContext()
            : base("Name=AcmeBankContext")
        {
        }

        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<tblAccount> tblAccounts { get; set; }
        public DbSet<tblCustomer> tblCustomers { get; set; }
        public DbSet<tblLKAccountType> tblLKAccountTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new tblAccountMap());
            modelBuilder.Configurations.Add(new tblCustomerMap());
            modelBuilder.Configurations.Add(new tblLKAccountTypeMap());
        }
    }
}
