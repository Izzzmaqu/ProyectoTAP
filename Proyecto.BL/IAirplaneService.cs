using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoTAP.Model;

namespace Proyecto.BL
{
    public interface IAirplaneService
    {
        List<Airplane> GetAllAirplanes();
        Airplane? GetAirplaneById(int id);
        string AddAirplane(Airplane airplane);
        string UpdateAirplane(int id, Airplane updatedAirplane);
        List<Airplane> GetAirplanesByAirlineId(int airlineId);
    }
}
