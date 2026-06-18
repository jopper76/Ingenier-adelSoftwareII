using Microsoft.EntityFrameworkCore;

namespace CrudNet7MVC.Datos
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {



        }

        public DbSet<Contacto> Contacto { get; set; }

    }
}
