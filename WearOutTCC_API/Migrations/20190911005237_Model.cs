using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WearOutTCC_API.Migrations
{
    public partial class Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbCliente",
                columns: table => new
                {
                    userId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userName = table.Column<string>(maxLength: 12, nullable: true),
                    fullName = table.Column<string>(maxLength: 50, nullable: true),
                    email = table.Column<string>(maxLength: 50, nullable: true),
                    password = table.Column<string>(maxLength: 20, nullable: true),
                    cpf = table.Column<string>(maxLength: 14, nullable: true),
                    endereco = table.Column<string>(maxLength: 20, nullable: true),
                    cidade = table.Column<string>(maxLength: 20, nullable: true),
                    estado = table.Column<string>(maxLength: 20, nullable: true),
                    cep = table.Column<long>(nullable: false),
                    tipo = table.Column<string>(nullable: false, defaultValue: "C"),
                    NegociacoesID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("userId", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "tbFornecedor",
                columns: table => new
                {
                    fornecedorId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userName = table.Column<string>(maxLength: 12, nullable: true),
                    fullName = table.Column<string>(maxLength: 50, nullable: true),
                    email = table.Column<string>(maxLength: 50, nullable: true),
                    password = table.Column<string>(maxLength: 20, nullable: true),
                    cpf = table.Column<string>(maxLength: 14, nullable: true),
                    endereco = table.Column<string>(maxLength: 20, nullable: true),
                    cidade = table.Column<string>(maxLength: 20, nullable: true),
                    estado = table.Column<string>(maxLength: 20, nullable: true),
                    cep = table.Column<long>(nullable: false),
                    tipo = table.Column<string>(nullable: false, defaultValue: "F"),
                    phone = table.Column<long>(nullable: false),
                    ProdutosID = table.Column<string>(nullable: true),
                    VendedorID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("fornecedorId", x => x.fornecedorId);
                });

            migrationBuilder.CreateTable(
                name: "tbNegociacao",
                columns: table => new
                {
                    NegociacaoId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dtNegociacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    valorTotal = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    ClienteID = table.Column<long>(nullable: false),
                    VendedorID = table.Column<long>(nullable: false),
                    ProdutosID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("negociacaoId", x => x.NegociacaoId);
                });

            migrationBuilder.CreateTable(
                name: "tbProduto",
                columns: table => new
                {
                    produtoId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<long>(nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: true),
                    descricao = table.Column<string>(maxLength: 50, nullable: true),
                    categoria = table.Column<string>(maxLength: 50, nullable: true),
                    preco = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    qtdProduto = table.Column<long>(nullable: false),
                    idEstoque = table.Column<long>(nullable: false),
                    nomeEstoque = table.Column<string>(maxLength: 50, nullable: true),
                    qtdFornecida = table.Column<long>(nullable: false),
                    dtFornecida = table.Column<DateTime>(type: "datetime", nullable: false),
                    VendedorID = table.Column<long>(nullable: false),
                    FornecedorID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("produtoId", x => x.produtoId);
                });

            migrationBuilder.CreateTable(
                name: "tbVendedor",
                columns: table => new
                {
                    vendedorId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userName = table.Column<string>(maxLength: 12, nullable: true),
                    fullName = table.Column<string>(maxLength: 50, nullable: true),
                    email = table.Column<string>(maxLength: 50, nullable: true),
                    password = table.Column<string>(maxLength: 20, nullable: true),
                    cpf = table.Column<string>(maxLength: 14, nullable: true),
                    endereco = table.Column<string>(maxLength: 20, nullable: true),
                    cidade = table.Column<string>(maxLength: 20, nullable: true),
                    estado = table.Column<string>(maxLength: 20, nullable: true),
                    cep = table.Column<long>(nullable: false),
                    tipo = table.Column<string>(nullable: false, defaultValue: "F"),
                    ProdutosID = table.Column<string>(nullable: true),
                    FornecedoresID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("vendedorId", x => x.vendedorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbCliente");

            migrationBuilder.DropTable(
                name: "tbFornecedor");

            migrationBuilder.DropTable(
                name: "tbNegociacao");

            migrationBuilder.DropTable(
                name: "tbProduto");

            migrationBuilder.DropTable(
                name: "tbVendedor");
        }
    }
}
