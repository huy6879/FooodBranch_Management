using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;

namespace QLBH.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderSvc orderSvc;
        public OrderController()
        {
            orderSvc = new OrderSvc();
        }

        [HttpGet]
        public IActionResult GetOrder()
        {
            var res = new SingleRsp();
            res.Data = orderSvc.All.OrderBy(p => p.OrderId);
            return Ok(res.Data);
        }

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetCategoryByID(int id)
        {
            var res = new SingleRsp();
            res = orderSvc.Read(id);
            return Ok(res.Data);
        }

        [HttpPost("create-order")]
        public IActionResult CreateOrder([FromForm] OrderReq orderReq)
        {
            var res = new SingleRsp();
            res = orderSvc.CreateOrder(orderReq);
            return Ok(res);
        }


        //[HttpPost("search-order")]
        //public IActionResult SearchOrder([FromBody] SearchOrderReq searchOrderReq)
        //{
        //    var res = new SingleRsp();
        //    res.Data = orderSvc.SearchOrder(searchOrderReq);
        //    return Ok(res.Data);
        //}

        [HttpPut("update-order/{id}")]
        public IActionResult UpdateOrder([FromForm] OrderReq updateOrderReq, int id)
        {
            var res = new SingleRsp();
            try
            {
                updateOrderReq.OrderId = id;
                res = orderSvc.UpdateOrder(updateOrderReq);
                if (res.Success)
                {
                    return Ok(res);
                }
                else
                {
                    return BadRequest(res.Message);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-order/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var res = new SingleRsp();
            res = orderSvc.Delete(id);
            return Ok(res);
        }
    }
    
}
