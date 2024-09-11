using QLBH.Common.DAL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DAL
{
    public class BranchRep :GenericRep<HeThongDatDoAnContext, Branch>
    {
       

        public override Branch Read(int id)
        {
            var res = All.FirstOrDefault(p => p.BranchId == id);
            return res;
        }


        public int Remove(int id)
        {
            var m = base.All.First(i => i.BranchId == id);
            m = base.Delete(m);
            return m.BranchId;
        }


        public SingleRsp CreateBranch(Branch branch)
        {
            var res = new SingleRsp();
            using (var context = new HeThongDatDoAnContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Branches.Add(branch);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
        public SingleRsp UpdateBranch(Branch branch)
        {
            var res = new SingleRsp();
            using (var context = new HeThongDatDoAnContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Branches.Update(branch);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }

        public SingleRsp DeleteBranch(Branch branch)
        {
            var res = new SingleRsp();
            using (var context = new HeThongDatDoAnContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Branches.Remove(branch);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }


        public List<Branch> SearchBranch(string keyWord)
        {
            return All.Where(x => x.BranchAddress.Contains(keyWord)).ToList();
        }
    }
}
