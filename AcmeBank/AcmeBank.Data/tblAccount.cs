namespace AcmeBank.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblAccount
    {
        public long Id { get; set; }

        public long fkLKAccountType { get; set; }

        public long fkCustomerId { get; set; }

        public int Balance { get; set; }

        public virtual tblCustomer tblCustomer { get; set; }

        public virtual tblLKAccountType tblLKAccountType { get; set; }
    }
}
