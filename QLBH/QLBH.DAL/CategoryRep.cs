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
    public class CategoryRep : GenericRep<HeThongDatDoAnContext,Category>
    {
        public CategoryRep ()
        {

        }
        public override Category Read(int id)
        {
            var res = All.FirstOrDefault(c=>c.CateId == id);
            return res;
        }
        public int Remove(int id)
        {
            var m = base.All.First(i => i.CateId == id);
            m = base.Delete(m);
            return m.CateId;
        }

        public SingleRsp CreateCate(Category category)
        {
            var res = new SingleRsp();
            using (var context = new HeThongDatDoAnContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Categories.Add(category);
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

        public SingleRsp UpdateCategory(Category category)
        {
            var res = new SingleRsp();
            using (var context = new HeThongDatDoAnContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Categories.Update(category);
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

        public SingleRsp DeleteCategory(Category cate)
        {
            var res = new SingleRsp();
            using (var context = new HeThongDatDoAnContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Categories.Remove(cate);
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
    }
}
