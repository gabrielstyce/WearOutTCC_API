using Microsoft.EntityFrameworkCore;

namespace WearOutTCC_API.Models.ModelContext
{
    public class VendedorContext : DbContext
    {
        public VendedorContext(DbContextOptions<VendedorContext> options)
            : base(options)
        { }

        public DbSet<Vendedor> Vendedors { get; set; }
    }
}
