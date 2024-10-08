﻿using QLBH.Common.DAL;
using QLBH.Common.Rsp;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DAL
{
    public class ProductRep:GenericRep<HeThongDatDoAnContext, Product>
    {
            #region -- Overrides --


            public override Product Read(int id)
            {
                var res = All.FirstOrDefault(p => p.ProductId == id);
                return res;
            }


            public int Remove(int id)
            {
                var m = base.All.First(i => i.ProductId == id);
                m = base.Delete(m);
                return m.ProductId;
            }

        #endregion

        #region -- Methods --

        public SingleRsp CreateProduct(Product product)
        {
            var res = new SingleRsp();
            using (var context = new HeThongDatDoAnContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Products.Add(product);
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
        public SingleRsp UpdateProduct(Product product)
        {
            var res = new SingleRsp();
            using (var context = new HeThongDatDoAnContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Products.Update(product);
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

        public SingleRsp DeleteProduct(Product product)
        {
            var res = new SingleRsp();
            using (var context = new HeThongDatDoAnContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Products.Remove(product);
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
        #endregion


        public List<Product> SearchProduct(string keyWord)
        {
                return All.Where(x=>x.ProductName.Contains(keyWord)).ToList();
        }

    }
}
