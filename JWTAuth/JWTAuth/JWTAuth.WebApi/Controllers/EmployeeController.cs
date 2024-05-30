
using JWTAuth.WebApi.Interface;
using JWTAuth.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.WebApi.Controllers
{
    //[Authorize]
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _iEmployee;

        public EmployeeController(IEmployee IEmployee)
        {
            _iEmployee = IEmployee;
        }

        // GET: api/employee>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            return await Task.FromResult(_iEmployee.GetEmployeeDetails());
        }
        //[HttpGet]
        //[Route("AdminFeedbackDetailList")]
        //public async Task<ActionResult<IEnumerable<FeedbackAdminView>>> GetAdminFeedbackDetailList()
        //{
        //    return await Task.FromResult(_iEmployee.GetEmployeeDetails());
        //}
        
        // GET api/employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            if (!RequestExists(id))
            {
                return NotFound();
            }
            else
            {
                var request = await Task.FromResult(_iEmployee.GetEmployeeDetails(id));
                if (request == null)
                {
                    return NotFound();
                }
                return request;
            }
            
        }

        // POST api/employee
        [HttpPost]
        public async Task<ActionResult<Employee>> Post(Employee employee)
        {
            _iEmployee.AddEmployee(employee);           
            return await Task.FromResult(employee);
        }

        //[HttpPut]
        //[Route("AdminFeedbackUpdate")]
        //public async Task<ActionResult<FeedbackAdmin>> AdminFeedbackUpdate(FeedbackAdmin feedback)
        //{

        //    try
        //    {
        //        _IFeedback.UpdateAdminFeedback(feedback);
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RequestExists(feedback.FeedbackID))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    return await Task.FromResult(feedback);
        //}
        //// PUT api/employee/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> Put(int id, Employee employee)
        {
            if (id != employee.EmployeeID)
            {
                return BadRequest();
            }
            try
            {
                _iEmployee.UpdateEmployee(employee);
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
            return await Task.FromResult(employee);
        }

        [HttpPut("{id}")]
        [Route("BlockEmployee")]
        public async Task<ActionResult<int>> BlockEmployee(Employee employee)
        {
            
            try
            {
                _iEmployee.BlockEmployee(employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!RequestExists(employee.EmployeeID))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }
            return await Task.FromResult(employee.EmployeeID);
        }

      
        [HttpPut("{id}")]
        [Route("UnBlockEmployee")]
        public async Task<ActionResult<int>> UnBlockEmployee(Employee employee)
        {

            try
            {
                _iEmployee.UnBlockEmployee(employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!RequestExists(employee.EmployeeID))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }
            return await Task.FromResult(employee.EmployeeID);
        }

        // DELETE api/employee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            var feedback = _iEmployee.DeleteEmployee(id);
            if(feedback == null)
            {
                return await Task.FromResult(feedback);
            }
            return await Task.FromResult(feedback);
        }

        private bool RequestExists(int id)
        {
            return _iEmployee.CheckEmployee(id);
        }
    }
}
