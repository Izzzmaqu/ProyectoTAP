using Microsoft.EntityFrameworkCore;
using ProyectoTAP.Model;

namespace Proyecto.DA
{
    public class DBContexto : DbContext
    {
        public DBContexto(DbContextOptions<DBContexto> options) : base(options)
        {
        }

        public DbSet<Airline> Airlines { get; set; }

        public DbSet<Airplane> Airplanes { get; set; }
    }
}
