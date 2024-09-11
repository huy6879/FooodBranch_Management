using System;
using System.Collections.Generic;

namespace QLBH.Web.Models
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            Orders = new HashSet<Order>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
