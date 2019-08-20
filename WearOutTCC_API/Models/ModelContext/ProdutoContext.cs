using Microsoft.EntityFrameworkCore;

namespace WearOutTCC_API.Models.ModelContext
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options)
            : base(options)
        { }

        public DbSet<Produto> Produtos { get; set; }
    }
}
