using Microsoft.EntityFrameworkCore;

namespace Proyecto_Progra_II
{
    public class MyAppDbContext
    {
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options) { }

            // Colorcar esto para cada una de las entidades public DbSet<Entidad> Entidad { get; set; }
        }
    }
}
