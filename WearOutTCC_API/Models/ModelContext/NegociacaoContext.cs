using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
