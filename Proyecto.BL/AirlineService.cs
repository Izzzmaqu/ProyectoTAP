using ProyectoTAP.Model;

namespace Proyecto.BL
{
    public class AirlineService : IAirlineService
    {
        private readonly IAirlineRepository _airlineRepository;

        public AirlineService(IAirlineRepository airlineRepository)
        {
            _airlineRepository = airlineRepository;
        }

        // Obtener todas las aerolíneas
        public List<Airline> GetAllAirlines() => _airlineRepository.GetAllAirlines();

        // Obtener aerolínea por Id
        public Airline? GetAirlineById(int id) => _airlineRepository.GetAirlineById(id);

        // Agregar una nueva aerolínea
        public string AddAirline(Airline airline)
        {
            var exists = _airlineRepository.GetAllAirlines()
                .Any(a => a.Name.Equals(airline.Name, StringComparison.OrdinalIgnoreCase) ||
                          a.Phone.Equals(airline.Phone, StringComparison.OrdinalIgnoreCase));
            if (exists) return "An airline with the same name or phone already exists.";
            _airlineRepository.AddAirline(airline);
            return "Airline added successfully.";
        }

        // Actualizar una aerolínea
        public string UpdateAirline(int id, Airline updatedAirline)
        {
            if (!_airlineRepository.UpdateAirline(id, updatedAirline))
                return "Airline not found.";
            return "Airline updated successfully.";
        }

        // Buscar aerolíneas por nombre o teléfono
        public List<Airline> SearchAirline(string? name, string? phone) =>
            _airlineRepository.SearchAirline(name, phone);
    }
}