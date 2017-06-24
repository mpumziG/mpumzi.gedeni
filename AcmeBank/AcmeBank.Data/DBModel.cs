namespace AcmeBank.Data
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class DBModel : DbContext
	{
		public DBModel()
			: base("name=DBModel")
		{
		}

		public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
		public virtual DbSet<tblAccount> tblAccounts { get; set; }
		public virtual DbSet<tblCustomer> tblCustomers { get; set; }
		public virtual DbSet<tblLKAccountType> tblLKAccountTypes { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblCustomer>()
				.Property(e => e.Fullname)
				.IsUnicode(false);

			modelBuilder.Entity<tblCustomer>()
				.HasMany(e => e.tblAccounts)
				.WithRequired(e => e.tblCustomer)
				.HasForeignKey(e => e.fkCustomerId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<tblLKAccountType>()
				.Property(e => e.Description)
				.IsUnicode(false);

			modelBuilder.Entity<tblLKAccountType>()
				.HasMany(e => e.tblAccounts)
				.WithRequired(e => e.tblLKAccountType)
				.HasForeignKey(e => e.fkLKAccountType)
				.WillCascadeOnDelete(false);
		}
	}
}
