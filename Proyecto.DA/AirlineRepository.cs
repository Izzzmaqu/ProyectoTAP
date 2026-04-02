using Microsoft.EntityFrameworkCore;
using Proyecto.BL;
using ProyectoTAP.Model;

namespace Proyecto.DA
{
    public class AirlineRepository : IAirlineRepository
    {
        private readonly DBContexto _context;

        public AirlineRepository(DBContexto context)
        {
            _context = context;
        }

        public List<Airline> GetAllAirlines() => _context.Airlines.ToList();

        public Airline? GetAirlineById(int id) =>
            _context.Airlines.FirstOrDefault(a => a.Id == id);

        public void AddAirline(Airline airline)
        {
            _context.Airlines.Add(airline);
            _context.SaveChanges();
        }

        public bool UpdateAirline(int id, Airline updatedAirline)
        {
            var existing = GetAirlineById(id);
            if (existing == null) return false;
            existing.Name = updatedAirline.Name;
            existing.Phone = updatedAirline.Phone;
            _context.SaveChanges();
            return true;
        }

        public List<Airline> SearchAirline(string? name, string? phone) =>
            _context.Airlines.Where(a =>
                (string.IsNullOrEmpty(name) || a.Name.Contains(name, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(phone) || a.Phone.Contains(phone, StringComparison.OrdinalIgnoreCase))
            ).ToList();
    }
}