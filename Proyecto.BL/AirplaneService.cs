using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoTAP.Model;

namespace Proyecto.BL
{
    public class AirplaneService : IAirplaneService
    {
        private readonly IAirplaneRepository _airplaneRepository;

        public AirplaneService(IAirplaneRepository airplaneRepository)
        {
            _airplaneRepository = airplaneRepository;
        }

        public List<Airplane> GetAllAirplanes() =>
            _airplaneRepository.GetAllAirplanes();

        public Airplane? GetAirplaneById(int id) =>
            _airplaneRepository.GetAirplaneById(id);

        public string AddAirplane(Airplane airplane)
        {
            _airplaneRepository.AddAirplane(airplane);
            return "Airplane added successfully.";
        }

        public string UpdateAirplane(int id, Airplane updatedAirplane)
        {
            if (!_airplaneRepository.UpdateAirplane(id, updatedAirplane))
                return "Airplane not found.";

            return "Airplane updated successfully.";
        }

        public List<Airplane> GetAirplanesByAirlineId(int airlineId) =>
            _airplaneRepository.GetAirplanesByAirlineId(airlineId);
    }
}