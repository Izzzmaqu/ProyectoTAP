using Microsoft.AspNetCore.Mvc;
using Proyecto.BL;
using ProyectoTAP.Model;

namespace ProyectoTAP.SI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AirplanesController : ControllerBase
    {
        private readonly IAirplaneService _airplaneService;

        public AirplanesController(IAirplaneService airplaneService)
        {
            _airplaneService = airplaneService;
        }

        [HttpGet("by-airline/{airlineId}")]
        public IActionResult GetAirplanesByAirline(int airlineId)
        {
            var result = _airplaneService.GetAirplanesByAirlineId(airlineId);

            if (!result.Any())
            {
                return NotFound("No airplanes found for the provided airline.");
            }

            return Ok(result);
        }
    }
}