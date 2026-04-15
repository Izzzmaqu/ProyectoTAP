using Microsoft.AspNetCore.Mvc;
using Proyecto.BL;
using ProyectoTAP.Model;

namespace ProyectoTAP.SI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AirlinesController : ControllerBase
    {
        private readonly IAirlineService _airlineService;

        // Constructor para inyectar el servicio de aerolíneas
        public AirlinesController(IAirlineService airlineService)
        {
            _airlineService = airlineService; // Instancia del servicio de negocio
        }

        // Devuelve una lista con todas las aerolíneas registradas
        [HttpGet]
        public IActionResult GetAllAirlines()
        {
            var airlines = _airlineService.GetAllAirlines();
            return Ok(airlines);
        }

        // Busca y devuelve una aerolínea específica utilizando su ID
        [HttpGet("{id}")]
        public IActionResult GetAirlineById(int id)
        {
            var airline = _airlineService.GetAirlineById(id);
            if (airline == null)
            {
                return NotFound("Airline not found.");
            }
            return Ok(airline);
        }

        // Registra una nueva aerolínea en el sistema
        [HttpPost]
        public IActionResult AddAirline([FromBody] Airline airline)
        {
            var message = _airlineService.AddAirline(airline);
            if (message == "Airline added successfully.")
            {
                return Ok(message);
            }

            return BadRequest(message);
        }

        // Actualiza los datos de una aerolínea existente
        [HttpPut("{id}")]
        public IActionResult UpdateAirline(int id, [FromBody] Airline updatedAirline)
        {
            var message = _airlineService.UpdateAirline(id, updatedAirline);
            if (message == "Airline updated successfully.")
            {
                return Ok(message);
            }

            return BadRequest(message);
        }

        // Busca aerolíneas que coincidan con el nombre o teléfono proporcionado
        [HttpGet("search")]
        public IActionResult SearchAirline([FromQuery] string? name, [FromQuery] string? phone)
        {
            var airlines = _airlineService.SearchAirline(name, phone);
            if (!airlines.Any())
            {
                return NotFound("No airline found.");
            }

            return Ok(airlines);
        }
    }
}