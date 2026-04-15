using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoTAP.Model;

namespace Proyecto.BL
{
    // Define las operaciones que estarán disponibles para la gestión de aviones
    public interface IAirplaneService
    {
        // Obtiene todos los aviones registrados
        List<Airplane> GetAllAirplanes();

        // Busca un avión en concreto utilizando su ID
        Airplane? GetAirplaneById(int id);

        // Permite añadir un nuevo avión al servicio y obtiene respuesta de confirmación
        string AddAirplane(Airplane airplane);

        // Modifica un avión y retorna el resultado de la acción
        string UpdateAirplane(int id, Airplane updatedAirplane);

        // Obtiene una lista de aviones dependiendo de la aerolínea a la que pertenecen
        List<Airplane> GetAirplanesByAirlineId(int airlineId);
    }
}
