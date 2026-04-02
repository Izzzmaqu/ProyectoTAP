using Proyecto.BL;
using ProyectoTAP.Model;

namespace Proyecto.DA
{
    public class AirplaneRepository : IAirplaneRepository
    {
        private readonly DBContexto _context;

        public AirplaneRepository(DBContexto context)
        {
            _context = context;
        }

        public List<Airplane> GetAllAirplanes() => _context.Airplanes.ToList();

        public Airplane? GetAirplaneById(int id) =>
            _context.Airplanes.FirstOrDefault(a => a.Id == id);

        public void AddAirplane(Airplane airplane)
        {
            _context.Airplanes.Add(airplane);
            _context.SaveChanges();
        }

        public bool UpdateAirplane(int id, Airplane updatedAirplane)
        {
            var existing = GetAirplaneById(id);
            if (existing == null) return false;

            existing.Model = updatedAirplane.Model;
            existing.AirlineId = updatedAirplane.AirlineId;
            _context.SaveChanges();
            return true;
        }

        public List<Airplane> GetAirplanesByAirlineId(int airlineId) =>
            _context.Airplanes.Where(a => a.AirlineId == airlineId).ToList();
    }
}
