using Microsoft.EntityFrameworkCore;

namespace Proyecto_Progra_II.MiDbContext
{
    public class MyAppDbContext
    {
        public class MyoDbContext : DbContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseInMemoryDatabase("MyDbTest");
            }
        }
    }
}
