using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.BL;
using ProyectoTAP.Model;

namespace Proyecto.DA
{
    public class AirplaneRepository : IAirplaneRepository
    {
        private static readonly List<Airplane> airplanes = new List<Airplane>
        {
            new Airplane { Id = 1, Model = "Boeing 737", AirlineId = 1 },
            new Airplane { Id = 2, Model = "Airbus A320", AirlineId = 1 },
            new Airplane { Id = 3, Model = "Boeing 777", AirlineId = 2 },
            new Airplane { Id = 4, Model = "Embraer 190", AirlineId = 3 }
        };

        public List<Airplane> GetAllAirplanes() => airplanes;

        public Airplane? GetAirplaneById(int id) =>
            airplanes.FirstOrDefault(a => a.Id == id);

        public void AddAirplane(Airplane airplane)
        {
            airplane.Id = airplanes.Any() ? airplanes.Max(a => a.Id) + 1 : 1;
            airplanes.Add(airplane);
        }

        public bool UpdateAirplane(int id, Airplane updatedAirplane)
        {
            var existing = GetAirplaneById(id);
            if (existing == null) return false;

            existing.Model = updatedAirplane.Model;
            existing.AirlineId = updatedAirplane.AirlineId;
            return true;
        }

        public List<Airplane> GetAirplanesByAirlineId(int airlineId) =>
            airplanes.Where(a => a.AirlineId == airlineId).ToList();
    }
}
