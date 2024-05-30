using JWTAuth.WebApi.Interface;
using JWTAuth.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace JWTAuth.WebApi.Controllers
{
   
    [Route("api/Fuel")]
    [ApiController]
    public class FuelController : ControllerBase
    {
        private readonly IFuel _iFuel;
        public FuelController(IFuel ifuel)
        {
            _iFuel = ifuel;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaceMaster>>> Get()
        {
            try
            {
                var request = await Task.FromResult(_iFuel.GetFuelDetails());
                if (request == null)
                {
                    return NotFound();
                }
                return Ok(request);
            }
            catch (Exception ex) {
                return NotFound();
            }

        }
    }
}
