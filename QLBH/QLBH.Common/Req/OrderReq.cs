using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Common.Req
{
    public class OrderReq 
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? PhoneNumber { get; set; }
        public int PaymentId { get; set; }
        public int BranchId { get; set; }
        public string ShipAddress { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public int StatusId { get; set; }


    }
}
