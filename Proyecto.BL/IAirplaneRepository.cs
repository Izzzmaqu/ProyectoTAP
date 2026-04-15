using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoTAP.Model;

namespace Proyecto.BL
{
    // Contrato para las operaciones de base de datos relacionadas a aviones
    public interface IAirplaneRepository
    {
        // Obtiene todos los aviones registrados
        List<Airplane> GetAllAirplanes();

        // Busca un avión asegurando su ID
        Airplane? GetAirplaneById(int id);

        // Almacena un nuevo avión en la base de datos
        void AddAirplane(Airplane airplane);

        // Actualiza un avión y retorna si se pudo realizar o no el cambio
        bool UpdateAirplane(int id, Airplane updatedAirplane);

        // Localiza y devuelve los aviones para una misma aerolínea
        List<Airplane> GetAirplanesByAirlineId(int airlineId);
    }
}
