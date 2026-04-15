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

        // Constructor que inyecta el servicio de lógica de negocio para los aviones
        public AirplanesController(IAirplaneService airplaneService)
        {
            _airplaneService = airplaneService;
        }

        // Obtiene la lista completa de aviones disponibles
        [HttpGet]
        public IActionResult GetAllAirplanes()
        {
            var airplanes = _airplaneService.GetAllAirplanes();
            return Ok(airplanes);
        }

        // Obtiene la información detallada de un avión buscando por su ID
        [HttpGet("{id}")]
        public IActionResult GetAirplaneById(int id)
        {
            var airplane = _airplaneService.GetAirplaneById(id);
            if (airplane == null)
            {
                return NotFound("Airplane not found.");
            }
            return Ok(airplane);
        }

        // Permite crear y registrar un nuevo avión en el sistema
        [HttpPost]
        public IActionResult AddAirplane([FromBody] Airplane airplane)
        {
            var message = _airplaneService.AddAirplane(airplane);
            if (message == "Airplane added successfully.")
            {
                return Ok(message);
            }

            return BadRequest(message);
        }

        // Permite modificar los datos de un avión usando su ID
        [HttpPut("{id}")]
        public IActionResult UpdateAirplane(int id, [FromBody] Airplane updatedAirplane)
        {
            var message = _airplaneService.UpdateAirplane(id, updatedAirplane);
            if (message == "Airplane updated successfully.")
            {
                return Ok(message);
            }

            return BadRequest(message);
        }

        // Devuelve una lista de aviones que están asignados a una aerolínea específica
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