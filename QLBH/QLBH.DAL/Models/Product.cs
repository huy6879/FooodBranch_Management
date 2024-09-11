using System;
using System.Collections.Generic;

namespace QLBH.DAL.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public int CateId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public decimal? Discount { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public int Status { get; set; }
        public int Quantity { get; set; }
        public int? UnitInStock { get; set; }

        public virtual Category Cate { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
