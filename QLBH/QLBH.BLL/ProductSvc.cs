using Microsoft.IdentityModel.Tokens;
using QLBH.Common.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;
using QLBH.DAL;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.BLL
{
    public class ProductSvc:GenericSvc<ProductRep,Product>
    {

        #region -- Overrides --



        public override SingleRsp Update(Product m)
        {
            var res = new SingleRsp();

            var m1 = m.ProductId > 0 ? _rep.Read(m.ProductId) : _rep.Read(m.ProductName);
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
        #endregion

        #region -- Methods --

        //public SingleRsp searchById(int id)
        //{
        //    ProductRep productRep = new ProductRep();

        //    var res = new SingleRsp();
        //    try
        //    {
        //        var productToDel = productRep.Read(id);
        //        if (productToDel == null)
        //        {
        //            res.SetError("Sản phẩm không tồn tại");
        //            return res;
        //        }
        //        else
        //        {
        //            res.SetMessage("Tìm thành công");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        res.SetMessage(ex.Message);
        //    }
        //    return res;
        //}
        HeThongDatDoAnContext da = new HeThongDatDoAnContext();
        public SingleRsp GetList(int page = 1)
        {
            var res = new SingleRsp();

            // Tính số lượng sản phẩm và tổng số trang
            int totalProducts = da.Products.Count();
            int totalPages = (int)Math.Ceiling((double)totalProducts / 10);

            // Kiểm tra xem trang yêu cầu có hợp lệ không
            //if (page < 1 || page > totalPages)
            //{
            //    return res.SetError("Trang không hợp lệ");
            //}

            // Lấy sản phẩm cho trang hiện tại
            var pagedProducts = da.Products.Skip((page - 1) * 10).Take(10).ToList();

            // Tạo đối tượng phản hồi
            var p = new
            {
                Data = pagedProducts,
                Page = page,
                TotalPages = totalPages
            };
            res.Data = p;
            return res;
        }

        public SingleRsp SearchProduct(string kw)
        {
            ProductRep productRep = new ProductRep();
            var res = new SingleRsp();
            var products = productRep.SearchProduct(kw);
            //Xử lý phân trang
            //int pCount, totalPages, offset;
            //offset = s.Size * (s.Page - 1);
            //pCount = products.Count;
            //totalPages = (pCount%2)==0? pCount / 2: 1 + (pCount /2);
            //var p = new
            //{
            //    Data = products.Skip(offset).Take(2).ToArray(),
            //    Page = s.Page,
            //    Size = s.Size,
            //};
            res.Data = products;
            return res;
        }

        public SingleRsp CreateProduct(ProductReq productReq)
        {
            ProductRep productRep = new ProductRep();
            var res = new SingleRsp();
            Product product = new Product();
            product.ProductId = productReq.ProductId;
            product.CateId = productReq.CateId;
            product.ProductName = productReq.ProductName;
            product.UnitPrice = productReq.UnitPrice;
            product.Quantity = productReq.Quantity;
            product.Description = productReq.Description;
            //product.Picture = productReq.Picture;
            product.Status = productReq.Status;
            product.UnitInStock = productReq.UnitInStock;
            res = productRep.CreateProduct(product);
            return res; 
        }

        public SingleRsp UpdateProduct(ProductReq productReq)
        {
            ProductRep productRep = new ProductRep();
            var res = new SingleRsp();
            Product product = new Product();
            product.ProductId = productReq.ProductId;
            product.CateId = productReq.CateId;
            product.ProductName = productReq.ProductName;
            product.UnitPrice = productReq.UnitPrice;
            product.Description = productReq.Description;
            product.Quantity = productReq.Quantity;
            //product.Picture = productReq.Picture;
            product.Status = productReq.Status;
            product.UnitInStock = productReq.UnitInStock;
            res = productRep.UpdateProduct(product);
            return res;
        }


        public SingleRsp DeleteProduct(int id)
        {
            ProductRep productRep = new ProductRep();

            var res = new SingleRsp();
            try
            {
                var productToDel = productRep.Read(id);
                if (productToDel == null)
                {
                    res.SetError("Sản phẩm không tồn tại");
                    return res;
                }
                res = productRep.DeleteProduct(productToDel);
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
        #endregion
    }
}