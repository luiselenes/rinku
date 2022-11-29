using Microsoft.EntityFrameworkCore;
using rinku.Models;

namespace rinku
{
    public class rinkuContext : DbContext{
        public rinkuContext(DbContextOptions<rinkuContext>options) :base(options){
            
        }
        public DbSet<Empleados> empleados {set;get;}
        public DbSet<Movimiento_mes> movimientos_mes { get; set; }
    }
}
