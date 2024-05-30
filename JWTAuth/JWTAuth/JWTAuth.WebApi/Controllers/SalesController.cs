using JWTAuth.WebApi.Interface;
using JWTAuth.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.WebApi.Controllers
{
    [Route("api/Sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISALES _ISales;

        public SalesController(ISALES ISales)
        {
            _ISales = ISales;
        }

        // GET: api/employee>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sales>>> Get()
        {
            return await Task.FromResult(_ISales.GetSalesDetails());
        }

        // GET api/employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sales>> Get(int id)
        {
            if (!SalesExists(id))
            {
                return NotFound();
            }
            else
            {
                var salesRequest = await Task.FromResult(_ISales.GetSalesDetails(id));
                if (salesRequest == null)
                {
                    return NotFound();
                }
                return salesRequest;
            }

        }

        // POST api/employee
        [HttpPost]
        public async Task<ActionResult<Sales>> Post(Sales sales)
        {
            _ISales.AddSales(sales);
            return await Task.FromResult(sales);
        }


        // PUT api/employee/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Sales>> Put(int id, Sales sales)
        {
            if (id != sales.SalesId)
            {
                return BadRequest();
            }
            try
            {
                _ISales.UpdateSales(sales);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(sales);
        }

        // DELETE api/employee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sales>> Delete(int id)
        {
            var feedback = _ISales.DeleteSales(id);
            if (feedback == null)
            {
                return await Task.FromResult(feedback);
            }
            return await Task.FromResult(feedback);
        }

        private bool SalesExists(int id)
        {
            return _ISales.CheckSales(id);
        }
    
}
}
