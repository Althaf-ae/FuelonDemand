using JWTAuth.WebApi.Interface;
using JWTAuth.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace JWTAuth.WebApi.Controllers
{
   
    [Route("api/Place")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPlace _iPlace;
        public PlaceController(IPlace iPlace)
        {
            _iPlace = iPlace;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaceMaster>>> Get()
        {
            try
            {
                var request = await Task.FromResult(_iPlace.GetPlaceDetails());
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
