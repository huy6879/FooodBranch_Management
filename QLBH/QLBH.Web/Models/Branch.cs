using System;
using System.Collections.Generic;

namespace QLBH.Web.Models
{
    public partial class Branch
    {
        public Branch()
        {
            Accounts = new HashSet<Account>();
            Orders = new HashSet<Order>();
        }

        public int BranchId { get; set; }
        public string BranchName { get; set; } = null!;
        public string BranchCity { get; set; } = null!;
        public string BranchDistrict { get; set; } = null!;
        public string BranchAddress { get; set; } = null!;

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
