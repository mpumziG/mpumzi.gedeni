namespace AcmeBank.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblLKAccountType")]
    public partial class tblLKAccountType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblLKAccountType()
        {
            tblAccounts = new HashSet<tblAccount>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAccount> tblAccounts { get; set; }
    }
}
