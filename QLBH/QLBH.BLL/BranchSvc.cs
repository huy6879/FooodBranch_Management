using QLBH.Common.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;
using QLBH.DAL;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.BLL
{

    public class BranchSvc : GenericSvc<BranchRep, Branch>
    {
        private BranchRep BranchRep;
        public BranchSvc()
        {
            BranchRep = new BranchRep();
        }
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }
        public override SingleRsp Update(Branch m)
        {
            var res = new SingleRsp();

            var m1 = m.BranchId > 0 ? _rep.Read(m.BranchId) : _rep.Read(m.BranchName);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }

            return res;
        }


        HeThongDatDoAnContext da = new HeThongDatDoAnContext();
        public SingleRsp GetList(int page = 1)
        {
            var res = new SingleRsp();

            int totalBranches = da.Branches.Count();
            int totalPages = (int)Math.Ceiling((double)totalBranches / 10);

            var pagedBranches = da.Branches.Skip((page - 1) * 10).Take(10).ToList();

            // Tạo đối tượng phản hồi
            var p = new
            {
                Data = pagedBranches,
                Page = page,
                TotalPages = totalPages
            };
            res.Data = p; return res;
        }

        public SingleRsp SearchBranch(string kw)
        {
            BranchRep branchRep = new BranchRep();
            var res = new SingleRsp();
            var branches = BranchRep.SearchBranch(kw);
            
            res.Data = branches;
            return res;
        }

        public SingleRsp CreateBranch(BranchReq branchReq)
        {
            var res = new SingleRsp();
            Branch branch = new Branch();
            branch.BranchId = branchReq.BranchID;
            branch.BranchName = branchReq.BranchName;
            branch.BranchCity = branchReq.BranchCity;
            branch.BranchDistrict = branchReq.BranchDistrict;
            branch.BranchAddress = branchReq.BranchAddress;
            res = BranchRep.CreateBranch(branch);
            return res;
        }

        public SingleRsp UpdateBranch(BranchReq branchReq)
        {
            var res = new SingleRsp();
            Branch branch = new Branch();
            branch.BranchId = branchReq.BranchID;
            branch.BranchName = branchReq.BranchName;
            branch.BranchCity = branchReq.BranchCity;
            branch.BranchDistrict = branchReq.BranchDistrict;
            branch.BranchAddress = branchReq.BranchAddress;
            res = BranchRep.UpdateBranch(branch);
            return res;
        }


        public SingleRsp Delete(int id)
        {

            var res = new SingleRsp();
            try
            {
                var branchToDel = BranchRep.Read(id);
                if (branchToDel == null)
                {
                    res.SetError("Chi nhánh không tồn tại");
                    return res;
                }
                res = BranchRep.DeleteBranch(branchToDel);
                // Kiểm tra kết quả sau khi xóa
                if (res.Success)
                {
                    res.SetError("Xóa thành công");
                }
            }
            catch (Exception ex)
            {
                res.SetMessage(ex.Message);
            }
            return res;
        }
    }
}

