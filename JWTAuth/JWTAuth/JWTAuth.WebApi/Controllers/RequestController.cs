
using JWTAuth.WebApi.Interface;
using JWTAuth.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.WebApi.Controllers
{
    //[Authorize]
    [Route("api/Request")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequest _IRequest;

        public RequestController(IRequest IRequest)
        {
            _IRequest = IRequest;
        }

        // GET: api/employee>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> Get()
        {
            var request = await Task.FromResult(_IRequest.GetRequestDetailList());
            if (request == null)
            {
                return NotFound();
            }
            return Ok(request);
             
        }
        [HttpGet]
        [Route("AdminRequestDetailList")]
        public async Task<ActionResult<IEnumerable<RequestAdminView>>> GetAdminRequestDetailList()
        {
            var request = await Task.FromResult(_IRequest.GetAdminRequestDetailList());
            if (request == null)
            {
                return NotFound();
            }
            return Ok(request);

        }
        // GET api/employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> Get(int id)
        {
            var request = await Task.FromResult(_IRequest.GetRequestDetails(id));
            if (request == null)
            {
                return NotFound();
            }
            return Ok(request);
        }

        // POST api/employee
        [HttpPost]
        public async Task<ActionResult<Request>> Post(Request request)
        {
            _IRequest.AddRequest(request);           
            return await Task.FromResult(request);
        }
              
       
        // PUT api/employee/5
        [HttpPut]
        public async Task<ActionResult<Request>> Put(Request request)
        {
            //if (id != request.RequestId)
            //{
            //    return BadRequest();
            //}
            try
            {
                _IRequest.UpdateRequest(request);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(Convert.ToInt32(request.RequestId)))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(request);
        }

        // DELETE api/employee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Request>> Delete(int id)
        {
            var request = _IRequest.DeleteRequest(id);
            return await Task.FromResult(request);
        }

        private bool RequestExists(int id)
        {
            return _IRequest.CheckRequest(id);
        }
    }
}
