using Microsoft.EntityFrameworkCore;
using ProyectoTAP.Model;

namespace Proyecto.DA
{
    // Contexto de base de datos de Entity Framework que gestiona cómo se conectan las clases con las tablas
    public class DBContexto : DbContext
    {
        public DBContexto(DbContextOptions<DBContexto> options) : base(options)
        {
        }

        // Representa la tabla de aerolíneas en la base de datos
        public DbSet<Airline> Airlines { get; set; }

        // Representa la tabla de aviones en la base de datos
        public DbSet<Airplane> Airplanes { get; set; }
    }
}
