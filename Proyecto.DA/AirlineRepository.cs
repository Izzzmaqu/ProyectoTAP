using Microsoft.EntityFrameworkCore;
using Proyecto.BL;
using ProyectoTAP.Model;

namespace Proyecto.DA
{
    public class AirlineRepository : IAirlineRepository
    {
        private readonly DBContexto _context;

        // Inyectamos el contexto de base de datos para manejar las consultas
        public AirlineRepository(DBContexto context)
        {
            _context = context;
        }

        // Recupera todos los registros de aerolíneas de la base de datos
        public List<Airline> GetAllAirlines() => _context.Airlines.ToList();

        // Busca la primera aerolínea que coincida con el ID proporcionado
        public Airline? GetAirlineById(int id) =>
            _context.Airlines.FirstOrDefault(a => a.Id == id);

        // Inserta en base de datos una nueva aerolínea y guarda los cambios
        public void AddAirline(Airline airline)
        {
            _context.Airlines.Add(airline);
            _context.SaveChanges();
        }

        // Modifica los datos de una aerolínea existente si la encuentra en base de datos
        public bool UpdateAirline(int id, Airline updatedAirline)
        {
            var existing = GetAirlineById(id);
            if (existing == null) return false;
            existing.Name = updatedAirline.Name;
            existing.Phone = updatedAirline.Phone;
            _context.SaveChanges();
            return true;
        }

        // Busca aerolíneas ignorando mayúsculas/minúsculas basándose en el nombre o teléfono
        public List<Airline> SearchAirline(string? name, string? phone) =>
            _context.Airlines.Where(a =>
                (string.IsNullOrEmpty(name) || a.Name.Contains(name, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(phone) || a.Phone.Contains(phone, StringComparison.OrdinalIgnoreCase))
            ).ToList();
    }
}