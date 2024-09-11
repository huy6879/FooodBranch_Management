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
    public class CategorySvc : GenericSvc<CategoryRep,Category>
    {
        private CategoryRep CategoryRep;
        public CategorySvc() 
        { 
            CategoryRep = new CategoryRep();
        }

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }

        public SingleRsp CreateCate(CategoryReq cateReq)
        {
            var res = new SingleRsp();
            Category Cate = new Category();
            Cate.CateId = cateReq.CateID;
            Cate.CategoryName = cateReq.CategoryName;
            Cate.Description = cateReq.Description;
            Cate.Status = cateReq.Status;
            res = CategoryRep.CreateCate(Cate);
            return res;
        }

        public SingleRsp UpdateCate(CategoryReq cate)
        {
            var res = new SingleRsp();
            Category category = new Category();
            category.CateId = cate.CateID;
            category.CategoryName = cate.CategoryName;
            category.Description = cate.Description;
            category.Status = cate.Status;
            res = CategoryRep.UpdateCategory(category);
            return res;
        }

        public SingleRsp DeleteCate(int id)
        {
            var res = new SingleRsp();
            try
            {
                var CateToDel = CategoryRep.Read(id);
                if (CateToDel == null)
                {
                    res.SetError("Sản phẩm không tồn tại");
                    return res;
                }
                res = CategoryRep.DeleteCategory(CateToDel);
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
