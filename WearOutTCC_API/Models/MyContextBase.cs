using Microsoft.EntityFrameworkCore;

namespace WearOutTCC_API.Models
{
    public class MyContextBase : DbContext
    {
        public MyContextBase() { }

        public MyContextBase(DbContextOptions<MyContextBase> options)
            : base(options)
        { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fornecedor> Fornecedors { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Negociacao> Negociacoes { get; set; }
        public DbSet<Vendedor> Vendedors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForSqlServerUseIdentityColumns();
            modelBuilder.HasDefaultSchema("wearOut_TCC");

            ConfigureCliente(modelBuilder);
            ConfigureFornecedor(modelBuilder);
            ConfigureVendedor(modelBuilder);
            ConfigureProduto(modelBuilder);
            ConfigureNegociacao(modelBuilder);
        }

        private void ConfigureCliente(ModelBuilder construtorDeModel)
        {
            construtorDeModel.Entity<Cliente>(
                ent =>
                {
                    ent.ToTable("tbCliente");
                    ent.HasKey(c => c.UserId).HasName("userId");
                    ent.Property(c => c.UserId).HasColumnName("userId").ValueGeneratedOnAdd();
                    ent.Property(c => c.UserName).HasColumnName("userName").HasMaxLength(12);
                    ent.Property(c => c.FullName).HasColumnName("fullName").HasMaxLength(50);
                    ent.Property(c => c.Email).HasColumnName("email").HasMaxLength(50);
                    ent.Property(c => c.Password).HasColumnName("password").HasMaxLength(20);
                    ent.Property(c => c.Cpf).HasColumnName("cpf");
                    ent.Property(c => c.Endereco).HasColumnName("endereco").HasMaxLength(20);
                    ent.Property(c => c.Cidade).HasColumnName("cidade").HasMaxLength(20);
                    ent.Property(c => c.Estado).HasColumnName("estado").HasMaxLength(20);
                    ent.Property(c => c.Cep).HasColumnName("cep");
                    ent.Property(c => c.tipo).HasColumnName("tipo").HasDefaultValue('C');
                });
        }

        private void ConfigureFornecedor(ModelBuilder construtorDeModel)
        {
            construtorDeModel.Entity<Fornecedor>(
                ent =>
                {
                    ent.ToTable("tbFornecedor");
                    ent.HasKey(f => f.UserId).HasName("fornecedorId");
                    ent.Property(f => f.UserId).HasColumnName("fornecedorId").ValueGeneratedOnAdd();
                    ent.Property(f => f.UserName).HasColumnName("userName").HasMaxLength(12);
                    ent.Property(f => f.FullName).HasColumnName("fullName").HasMaxLength(50);
                    ent.Property(f => f.Email).HasColumnName("email").HasMaxLength(50);
                    ent.Property(f => f.Password).HasColumnName("password").HasMaxLength(20);
                    ent.Property(f => f.Cpf).HasColumnName("cpf");
                    ent.Property(f => f.Endereco).HasColumnName("endereco").HasMaxLength(20);
                    ent.Property(f => f.Cidade).HasColumnName("cidade").HasMaxLength(20);
                    ent.Property(f => f.Estado).HasColumnName("estado").HasMaxLength(20);
                    ent.Property(f => f.Cep).HasColumnName("cep");
                    ent.Property(f => f.tipo).HasColumnName("tipo").HasDefaultValue('F');
                    ent.Property(f => f.Phone).HasColumnName("phone");
                    ent.HasOne(f => f.Vendedor).WithMany(f => f.Fornecedores);
                    
                    
                });
        }

        private void ConfigureVendedor(ModelBuilder construtorDeModel)
        {
            construtorDeModel.Entity<Vendedor>(
                ent =>
                {
                    ent.ToTable("tbVendedor");
                    ent.HasKey(v => v.UserId).HasName("vendedorId");
                    ent.Property(v => v.UserId).HasColumnName("vendedorId").ValueGeneratedOnAdd();
                    ent.Property(v => v.UserName).HasColumnName("userName").HasMaxLength(12);
                    ent.Property(v => v.FullName).HasColumnName("fullName").HasMaxLength(50);
                    ent.Property(v => v.Email).HasColumnName("email").HasMaxLength(50);
                    ent.Property(v => v.Password).HasColumnName("password").HasMaxLength(20);
                    ent.Property(v => v.Cpf).HasColumnName("cpf");
                    ent.Property(v => v.Endereco).HasColumnName("endereco").HasMaxLength(20);
                    ent.Property(v => v.Cidade).HasColumnName("cidade").HasMaxLength(20);
                    ent.Property(v => v.Estado).HasColumnName("estado").HasMaxLength(20);
                    ent.Property(v => v.Cep).HasColumnName("cep");
                    ent.Property(v => v.tipo).HasColumnName("tipo").HasDefaultValue('F');
                });
        }

        private void ConfigureProduto(ModelBuilder construtorDeModel)
        {
            construtorDeModel.Entity<Produto>(
                ent =>
                {
                    ent.ToTable("tbProduto");
                    ent.HasKey(p => p.ProdutoId).HasName("produtoId");
                    ent.Property(p => p.ProdutoId).HasColumnName("produtoId").ValueGeneratedOnAdd();
                    ent.Property(p => p.Codigo).HasColumnName("codigo");
                    ent.Property(p => p.Name).HasColumnName("name").HasMaxLength(50);
                    ent.Property(p => p.Descricao).HasColumnName("descricao").HasMaxLength(50);
                    ent.Property(p => p.Categoria).HasColumnName("categoria").HasMaxLength(50);
                    ent.Property(p => p.Preco).HasColumnName("preco").HasColumnType("decimal(10, 2)");
                    ent.Property(p => p.QtdProduto).HasColumnName("qtdProduto");
                    ent.Property(p => p.IdEstoque).HasColumnName("idEstoque");
                    ent.Property(p => p.NomeEstoque).HasColumnName("nomeEstoque").HasMaxLength(50);
                    ent.Property(p => p.QtdFornecida).HasColumnName("qtdFornecida");
                    ent.Property(p => p.DtFornecida).HasColumnName("dtFornecida").HasColumnType("datetime");
                    ent.HasOne(p => p.Vendedor).WithMany(p => p.Produtos);
                });
        }

        private void ConfigureNegociacao(ModelBuilder construtorDeModel)
        {
            construtorDeModel.Entity<Negociacao>(
                ent =>
                {
                    ent.ToTable("tbNegociacao");
                    ent.HasKey(n => n.NegociacaoId).HasName("negociacaoId");
                    ent.Property(n => n.DtNegociacao).HasColumnName("dtNegociacao").HasColumnType("datetime");
                    ent.Property(n => n.ValorTotal).HasColumnName("valorTotal").HasColumnType("decimal(10, 2)");
                    ent.HasOne(n => n.Cliente).WithMany(n => n.Negociacoes);
                });
        }
    }
}

