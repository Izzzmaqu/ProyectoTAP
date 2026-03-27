using Proyecto.BL;
using ProyectoTAP.Model;

namespace Proyecto.DA
{
    public class AirlineRepository : IAirlineRepository
    {
        private static readonly List<Airline> airlines = new List<Airline>
        {
            new Airline { Id = 1, Name = "Avianca", Phone = "2222-1111" },
            new Airline { Id = 2, Name = "Delta", Phone = "2222-2222" },
            new Airline { Id = 3, Name = "United", Phone = "2222-3333" }
        };

        public List<Airline> GetAllAirlines() => airlines;

        public Airline? GetAirlineById(int id) =>
            airlines.FirstOrDefault(a => a.Id == id);

        public void AddAirline(Airline airline)
        {
            airline.Id = airlines.Any() ? airlines.Max(a => a.Id) + 1 : 1;
            airlines.Add(airline);
        }

        public bool UpdateAirline(int id, Airline updatedAirline)
        {
            var existing = GetAirlineById(id);
            if (existing == null) return false;
            existing.Name = updatedAirline.Name;
            existing.Phone = updatedAirline.Phone;
            return true;
        }

        public List<Airline> SearchAirline(string? name, string? phone) =>
            airlines.Where(a =>
                (string.IsNullOrEmpty(name) || a.Name.Contains(name, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(phone) || a.Phone.Contains(phone, StringComparison.OrdinalIgnoreCase))
            ).ToList();
    }
}