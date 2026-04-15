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

        // Constructor donde inyectamos el repositorio para manejar datos de aviones
        public AirplaneService(IAirplaneRepository airplaneRepository)
        {
            _airplaneRepository = airplaneRepository;
        }

        // Obtiene la lista completa de aviones en el sistema
        public List<Airplane> GetAllAirplanes() =>
            _airplaneRepository.GetAllAirplanes();

        // Busca la información detallada de un avión usando su ID
        public Airplane? GetAirplaneById(int id) =>
            _airplaneRepository.GetAirplaneById(id);

        // Agrega un nuevo registro de avión a la base de datos
        public string AddAirplane(Airplane airplane)
        {
            _airplaneRepository.AddAirplane(airplane);
            return "Airplane added successfully.";
        }

        // Actualiza los cambios de un avión existente, validando si se encuentra
        public string UpdateAirplane(int id, Airplane updatedAirplane)
        {
            if (!_airplaneRepository.UpdateAirplane(id, updatedAirplane))
                return "Airplane not found.";

            return "Airplane updated successfully.";
        }

        // Filtra y obtiene todos los aviones que pertenezcan a una aerolínea específica
        public List<Airplane> GetAirplanesByAirlineId(int airlineId) =>
            _airplaneRepository.GetAirplanesByAirlineId(airlineId);
    }
}