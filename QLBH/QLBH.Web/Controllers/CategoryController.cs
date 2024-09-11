using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Console;
using QLBH.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;

namespace QLBH.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private CategorySvc categorySvc;
        public CategoryController()
        {
            categorySvc = new CategorySvc(); 
        }
        [HttpGet]
        public IActionResult GetCates()
        {
            var res = new SingleRsp();
            res.Data = categorySvc.All.OrderBy(p => p.CateId);
            return Ok(res.Data);
        }

        [HttpGet("get-by-id/{cateId}")]
        public IActionResult GetCategoryByID(int cateId)
        {
            var res = new SingleRsp();
            res = categorySvc.Read(cateId);
            return Ok(res.Data);
        }

        [HttpPost("create-category")]
        public IActionResult CreateCategory([FromForm] CategoryReq cateReq)
        {
            var res = new SingleRsp();
            res = categorySvc.CreateCate(cateReq);
            return Ok(res);
        }

        [HttpPut("update-product/{id}")]
        public IActionResult UpdateProduct([FromForm] CategoryReq updateCate, int id)
        {
            var res = new SingleRsp();
            try
            {
                updateCate.CateID = id;
                res = categorySvc.UpdateCate(updateCate);
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


        [HttpDelete("delete-category/{cateId}")]
        public IActionResult DeleteCategory(int cateId)
        {
            var res = new SingleRsp();
            res = categorySvc.DeleteCate(cateId);
            return Ok(res);
        }
    }
}
