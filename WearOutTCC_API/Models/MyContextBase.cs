using Microsoft.EntityFrameworkCore;

namespace WearOutTCC_API.Models
{
    #region Model
    public class MyContextBase : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fornecedor> Fornecedors { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Negociacao> Negociacoes { get; set; }
        public DbSet<Vendedor> Vendedors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
                
        }


    }
    #endregion
}
