using Proyecto.BL;
using ProyectoTAP.Model;

namespace Proyecto.DA
{
    public class AirplaneRepository : IAirplaneRepository
    {
        private readonly DBContexto _context;

        // Inyectamos el contexto de base de datos para manejar los aviones
        public AirplaneRepository(DBContexto context)
        {
            _context = context;
        }

        // Recupera todos los aviones registrados en la BD
        public List<Airplane> GetAllAirplanes() => _context.Airplanes.ToList();

        // Busca el avión asociado al ID dado
        public Airplane? GetAirplaneById(int id) =>
            _context.Airplanes.FirstOrDefault(a => a.Id == id);

        // Guarda un nuevo avión en la base de datos
        public void AddAirplane(Airplane airplane)
        {
            _context.Airplanes.Add(airplane);
            _context.SaveChanges();
        }

        // Modifica el modelo o ID de aerolínea de un avión existente
        public bool UpdateAirplane(int id, Airplane updatedAirplane)
        {
            var existing = GetAirplaneById(id);
            if (existing == null) return false;

            existing.Model = updatedAirplane.Model;
            existing.AirlineId = updatedAirplane.AirlineId;
            _context.SaveChanges();
            return true;
        }

        // Consulta los aviones que comparten el mismo identificador de aerolínea
        public List<Airplane> GetAirplanesByAirlineId(int airlineId) =>
            _context.Airplanes.Where(a => a.AirlineId == airlineId).ToList();
    }
}
