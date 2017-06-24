using System;
using System.Collections.Generic;

namespace AcmeBank.Data.Models
{
    public partial class tblLKAccountType
    {
        public tblLKAccountType()
        {
            this.tblAccounts = new List<tblAccount>();
        }

        public long Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<tblAccount> tblAccounts { get; set; }
    }
}
