using System;
using System.Collections.Generic;

namespace QLBH.DAL.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Orders = new HashSet<Order>();
        }

        public int PaymentId { get; set; }
        public string PaymentName { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
