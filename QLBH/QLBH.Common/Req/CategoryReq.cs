using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Common.Req
{
    public class CategoryReq
    {
        public int CateID { get; set; }     
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
        public int? Status { get; set; }
    }
}
