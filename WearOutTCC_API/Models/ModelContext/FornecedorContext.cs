using Microsoft.EntityFrameworkCore;

namespace WearOutTCC_API.Models.ModelContext
{
    public class FornecedorContext : DbContext
    {
        public FornecedorContext(DbContextOptions<FornecedorContext> options)
            : base(options)
        { }

        public DbSet<Fornecedor> Fornecedors { get; set; }
    }
}
