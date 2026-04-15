using ProyectoTAP.Model;

namespace Proyecto.BL
{
    // Interfaz que define las operaciones de negocio para las aerolíneas
    public interface IAirlineService
    {
        // Obtiene la lista de todas las aerolíneas
        List<Airline> GetAllAirlines();

        // Busca una aerolínea mediante su identificador
        Airline? GetAirlineById(int id);

        // Añade una nueva aerolínea y devuelve un mensaje de confirmación
        string AddAirline(Airline airline);

        // Modifica una aerolínea existente y devuelve el estado de la operación
        string UpdateAirline(int id, Airline updatedAirline);

        // Busca aerolíneas que coincidan en nombre o número de teléfono
        List<Airline> SearchAirline(string? name, string? phone);
    }
}