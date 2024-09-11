using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Common.Req
{
    public class BranchReq
    {
        public int BranchID { get; set; }     
        public string BranchName { get; set; } = null!;
        public string BranchCity { get; set; } = null!;
        public string BranchDistrict { get; set; } = null!;
        public string BranchAddress { get; set; } = null!;
    }
}
