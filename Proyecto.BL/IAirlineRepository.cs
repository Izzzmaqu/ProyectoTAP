using ProyectoTAP.Model;

namespace Proyecto.BL
{
    public interface IAirlineRepository
    {
        List<Airline> GetAllAirlines();
        Airline? GetAirlineById(int id);
        void AddAirline(Airline airline);
        bool UpdateAirline(int id, Airline updatedAirline);
        List<Airline> SearchAirline(string? name, string? phone);
    }
}