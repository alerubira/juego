
using Microsoft.EntityFrameworkCore;

namespace Juego.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Roles> Roles { get; set; }
        public DbSet<Personas> Personas { get; set; }
        public DbSet<Preguntas> Preguntas { get; set; }
        public DbSet<Respuestas> Respuestas { get; set; }
    }
}
