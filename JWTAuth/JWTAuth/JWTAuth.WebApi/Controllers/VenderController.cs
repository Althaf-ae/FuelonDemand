using JWTAuth.WebApi.Interface;
using JWTAuth.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.WebApi.Controllers
{
    [Authorize]
    [Route("api/Vendor")]
    [ApiController]
    public class VenderController : ControllerBase
    {
        private readonly IEmployee _IUser;

        public VenderController(IEmployee IUser)
        {
            _IUser = IUser;
        }

        
      
      
        // POST api/employee
        [HttpPost]
        public async Task<ActionResult<Employee>> Post(Employee employee)
        {
            _IUser.AddEmployee(employee);
            //return await Task.FromResult(CreatedAtAction("GetEmployees", new { id = employee.EmployeeID }, employee));
            return await Task.FromResult(employee);
        }

      
        // PUT api/employee/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> Put(int id, Employee employee)
        {
            if (id != employee.EmployeeID)
            {
                return BadRequest();
            }
            try
            {
                _IUser.UpdateEmployee(employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // DELETE api/employee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            var employee = _IUser.DeleteEmployee(id);
            return await Task.FromResult(employee);
        }

        private bool EmployeeExists(int id)
        {
            return _IUser.CheckEmployee(id);
        }
    }
}
