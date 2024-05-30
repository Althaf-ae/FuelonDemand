
using JWTAuth.WebApi.Interface;
using JWTAuth.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.WebApi.Controllers
{
    //[Authorize]
    [Route("api/FeedBack")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedback _IFeedback;

        public FeedbackController(IFeedback IFeedback)
        {
            _IFeedback = IFeedback;
        }

        // GET: api/employee>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> Get()
        {
            return await Task.FromResult(_IFeedback.GetFeedbackDetails());
        }
        [HttpGet]
        [Route("AdminFeedbackDetailList")]
        public async Task<ActionResult<IEnumerable<FeedbackAdminView>>> GetAdminFeedbackDetailList()
        {
            return await Task.FromResult(_IFeedback.GetAdminFeedbackDetailList());
        }
        
        // GET api/employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> Get(int id)
        {
            if (!RequestExists(id))
            {
                return NotFound();
            }
            else
            {
                var request = await Task.FromResult(_IFeedback.GetFeedbackDetails(id));
                if (request == null)
                {
                    return NotFound();
                }
                return request;
            }
            
        }

        // POST api/employee
        [HttpPost]
        public async Task<ActionResult<Feedback>> Post(Feedback feedback)
        {
            _IFeedback.AddFeedback(feedback);           
            return await Task.FromResult(feedback);
        }

        [HttpPut]
        [Route("AdminFeedbackUpdate")]
        public async Task<ActionResult<FeedbackAdmin>> AdminFeedbackUpdate(FeedbackAdmin feedback)
        {

            try
            {
                _IFeedback.UpdateAdminFeedback(feedback);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(feedback.FeedbackID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(feedback);
        }
        // PUT api/employee/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Feedback>> Put(int id, Feedback feedback)
        {
            if (id != feedback.FeedbackID)
            {
                return BadRequest();
            }
            try
            {
                _IFeedback.UpdateFeedback(feedback);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(feedback);
        }

        // DELETE api/employee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Feedback>> Delete(int id)
        {
            var feedback = _IFeedback.DeleteFeedback(id);
            if(feedback == null)
            {
                return await Task.FromResult(feedback);
            }
            return await Task.FromResult(feedback);
        }

        private bool RequestExists(int id)
        {
            return _IFeedback.CheckFeedback(id);
        }
    }
}
