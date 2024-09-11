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
    public class OrderSvc : GenericSvc<OrderRep, Order>
    {
        private OrderRep OrderRep;
        public OrderSvc()
        {
            OrderRep = new OrderRep();
        }

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }


        public override SingleRsp Update(Order m)
        {
            var res = new SingleRsp();

            var m1 = m.OrderId > 0 ? _rep.Read(m.OrderId) : _rep.Read(m.CustomerName);
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

            int totalOrders = da.Orders.Count();
            int totalPages = (int)Math.Ceiling((double)totalOrders / 10);

            var pagedOrders = da.Orders.Skip((page - 1) * 10).Take(10).ToList();

            // Tạo đối tượng phản hồi
            var p = new
            {
                Data = pagedOrders,
                Page = page,
                TotalPages = totalPages
            };
            res.Data = p; return res;
        }


        public SingleRsp CreateOrder(OrderReq orderReq)
        {
            var res = new SingleRsp();
            Order order = new Order();
            order.CustomerId = orderReq.CustomerId;
            order.CustomerName = orderReq.CustomerName;
            order.PhoneNumber = orderReq.PhoneNumber;
            order.PaymentId = orderReq.PaymentId;
            order.BranchId = orderReq.BranchId;
            order.ShipAddress = orderReq.ShipAddress;
            order.OrderDate = orderReq.OrderDate;
            order.ShipDate = orderReq.ShipDate;
            order.StatusId = orderReq.StatusId;
            res = OrderRep.CreateOrder(order);
            return res;
        }

        public SingleRsp UpdateOrder(OrderReq orderReq)
        {
            var res = new SingleRsp();
            Order order = new Order();
            order.OrderId = orderReq.OrderId;
            order.CustomerId = orderReq.CustomerId;
            order.CustomerName = orderReq.CustomerName;
            order.PhoneNumber = orderReq.PhoneNumber;
            order.PaymentId = orderReq.PaymentId;
            order.BranchId = orderReq.BranchId;
            order.ShipAddress = orderReq.ShipAddress;
            order.OrderDate = orderReq.OrderDate;
            order.ShipDate = orderReq.ShipDate;
            order.StatusId = orderReq.StatusId;
            res = OrderRep.UpdateOrder(order);
            return res;
        }

        //public SingleRsp SearchOrder(SearchOrderReq)
        //{
        //    var res = new SimpleReq();
        //    //Lấy danh sách sản phẩm theo từ khóa

        //    //Xử lý phân trang
        //    return res;
        //}
        
        public SingleRsp Delete(int id)
        {
            OrderRep orderRep = new OrderRep();

            var res = new SingleRsp();
            try
            {
                var orderToDel = orderRep.Read(id);
                if (orderToDel == null)
                {
                    res.SetError("Đơn hàng không tồn tại");
                    return res;
                }
                res = orderRep.DeleteOrder(orderToDel);
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
