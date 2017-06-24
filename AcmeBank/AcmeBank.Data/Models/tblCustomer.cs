using System;
using System.Collections.Generic;

namespace AcmeBank.Data.Models
{
    public partial class tblCustomer
    {
        public tblCustomer()
        {
            this.tblAccounts = new List<tblAccount>();
        }

        public long Id { get; set; }
        public string Fullname { get; set; }
        public virtual ICollection<tblAccount> tblAccounts { get; set; }
    }
}
