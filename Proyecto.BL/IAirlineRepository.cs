using ProyectoTAP.Model;

namespace Proyecto.BL
{
    // Interfaz que define los métodos de acceso a datos para las aerolíneas
    public interface IAirlineRepository
    {
        // Recupera todas las aerolíneas almacenadas
        List<Airline> GetAllAirlines();

        // Busca una aerolínea específica por su ID
        Airline? GetAirlineById(int id);

        // Registra una nueva aerolínea en el sistema
        void AddAirline(Airline airline);

        // Modifica la información de una aerolínea existente, retornando si hubo éxito
        bool UpdateAirline(int id, Airline updatedAirline);

        // Retorna aerolíneas cuyo nombre o teléfono coincidan con los criterios
        List<Airline> SearchAirline(string? name, string? phone);
    }
}