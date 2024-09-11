using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.BLL;
using QLBH.Common.Rsp;
using QLBH.Common.Req;
using QLBH.DAL;
using QLBH.DAL.Models;

namespace QLBH.Web.Controllers
{
    [Route("api/branch")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private BranchSvc branchSvc;
        public BranchController() 
        {
            branchSvc = new BranchSvc();
            
        }
        
        [HttpGet]
        public IActionResult GetBranch()
        {
            var res = new SingleRsp();
            res.Data = branchSvc.All.OrderBy(p => p.BranchId);
            return Ok(res.Data);
        }


        [HttpPost("create-branch")]
        public IActionResult CreateBranch([FromForm] BranchReq branchReq)
        {
            var res = new SingleRsp();
            res = branchSvc.CreateBranch(branchReq);
            return Ok(res);
        }

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetCategoryByID(int id)
        {
            var res = new SingleRsp();
            res = branchSvc.Read(id);
            return Ok(res.Data);
        }

        [HttpGet("search-branch/{kw}")]
        public IActionResult SearchProduct(string kw)
        {
            var res = new SingleRsp();
            res = branchSvc.SearchBranch(kw);
            return Ok(res.Data);
        }

        [HttpPut("update-branch/{id}")]
        public IActionResult UpdateBranch([FromForm] BranchReq updateBranch, int id)
        {
            var res = new SingleRsp();
            try
            {
                updateBranch.BranchID = id;
                res = branchSvc.UpdateBranch(updateBranch);
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

        [HttpDelete("delete-branch/{id}")]
        public IActionResult DeleteBranch(int id)
        {
            var res = new SingleRsp();
            res = branchSvc.Delete(id);
            return Ok(res);
        }
    }
}
