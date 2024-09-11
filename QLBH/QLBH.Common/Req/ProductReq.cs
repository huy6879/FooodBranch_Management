using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Common.Req
{
    public class ProductReq 
    {
        [Key]
        public int ProductId { get; set; }
        public int CateId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public string? Description { get; set; }
        public int Status { get; set; }
        public int Quantity { get; set; }
        public int? UnitInStock { get; set; }
    }
}
