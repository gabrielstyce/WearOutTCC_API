using Microsoft.EntityFrameworkCore;

namespace WearOutTCC_API.Models.ModelContext
{
    public class NegociacaoContext : DbContext
    {
        public NegociacaoContext(DbContextOptions<NegociacaoContext> options)
            : base(options)
        { }

        public DbSet<Negociacao> Negociacoes { get; set; }
    }
}
