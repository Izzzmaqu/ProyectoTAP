using ProyectoTAP.Model;

namespace Proyecto.BL
{
    public interface IAirlineService
    {
        List<Airline> GetAllAirlines();
        Airline? GetAirlineById(int id);
        string AddAirline(Airline airline);
        string UpdateAirline(int id, Airline updatedAirline);
        List<Airline> SearchAirline(string? name, string? phone);
    }
}