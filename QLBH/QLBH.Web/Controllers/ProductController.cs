using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;

namespace QLBH.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductSvc productSvc;
        public ProductController()
        {
            productSvc = new ProductSvc();
        }
        [HttpGet()]
        public  IActionResult GetProducts()
        {

            var res = new SingleRsp();
            res.Data = productSvc.All.OrderBy(p => p.ProductId);
            return Ok(res.Data);
        }


        [HttpPost("create-product")]
        public IActionResult CreateProduct([FromForm] ProductReq productReq)
        {
            var res = new SingleRsp();
            res = productSvc.CreateProduct(productReq);
            return Ok(res);
        }

        [HttpGet("search-product-byId/{productId}")]
        public IActionResult SearchProductId(int productId)
        {
            var res = new SingleRsp();
            res.Data = productSvc.All.FirstOrDefault(p=>p.ProductId == productId);
            return Ok(res.Data);
        }

        [HttpGet("search-product/{kw}")]
        public IActionResult SearchProduct(string kw)
        {
            var res = new SingleRsp();
            res = productSvc.SearchProduct(kw);
            return Ok(res.Data);
        }

        [HttpPut("update-product/{id}")]
        public IActionResult UpdateProduct([FromForm] ProductReq updateProductReq, int id)
        {
            var res = new SingleRsp();
            try
            {
                updateProductReq.ProductId = id;
                res = productSvc.UpdateProduct(updateProductReq);
                if(res.Success)
                {
                    return Ok(res);
                }    
                else
                {
                    return BadRequest(res.Message);
                }    
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-product/{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            var res = new SingleRsp();
            res = productSvc.DeleteProduct(productId);
            return Ok(res.Data);
        }
    }
}
