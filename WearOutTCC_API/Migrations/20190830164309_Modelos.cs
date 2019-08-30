using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WearOutTCC_API.Migrations
{
    public partial class Modelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "WearOut_Final");

            migrationBuilder.CreateTable(
                name: "tbCliente",
                schema: "WearOut_Final",
                columns: table => new
                {
                    userId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userName = table.Column<string>(maxLength: 12, nullable: true),
                    fullName = table.Column<string>(maxLength: 50, nullable: true),
                    email = table.Column<string>(maxLength: 50, nullable: true),
                    password = table.Column<string>(maxLength: 20, nullable: true),
                    cpf = table.Column<long>(nullable: false),
                    endereco = table.Column<string>(maxLength: 20, nullable: true),
                    cidade = table.Column<string>(maxLength: 20, nullable: true),
                    estado = table.Column<string>(maxLength: 20, nullable: true),
                    cep = table.Column<long>(nullable: false),
                    tipo = table.Column<string>(nullable: false, defaultValue: "C")
                },
                constraints: table =>
                {
                    table.PrimaryKey("userId", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "tbVendedor",
                schema: "WearOut_Final",
                columns: table => new
                {
                    vendedorId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userName = table.Column<string>(maxLength: 12, nullable: true),
                    fullName = table.Column<string>(maxLength: 50, nullable: true),
                    email = table.Column<string>(maxLength: 50, nullable: true),
                    password = table.Column<string>(maxLength: 20, nullable: true),
                    cpf = table.Column<long>(nullable: false),
                    endereco = table.Column<string>(maxLength: 20, nullable: true),
                    cidade = table.Column<string>(maxLength: 20, nullable: true),
                    estado = table.Column<string>(maxLength: 20, nullable: true),
                    cep = table.Column<long>(nullable: false),
                    tipo = table.Column<string>(nullable: false, defaultValue: "F")
                },
                constraints: table =>
                {
                    table.PrimaryKey("vendedorId", x => x.vendedorId);
                });

            migrationBuilder.CreateTable(
                name: "tbFornecedor",
                schema: "WearOut_Final",
                columns: table => new
                {
                    fornecedorId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userName = table.Column<string>(maxLength: 12, nullable: true),
                    fullName = table.Column<string>(maxLength: 50, nullable: true),
                    email = table.Column<string>(maxLength: 50, nullable: true),
                    password = table.Column<string>(maxLength: 20, nullable: true),
                    cpf = table.Column<long>(nullable: false),
                    endereco = table.Column<string>(maxLength: 20, nullable: true),
                    cidade = table.Column<string>(maxLength: 20, nullable: true),
                    estado = table.Column<string>(maxLength: 20, nullable: true),
                    cep = table.Column<long>(nullable: false),
                    tipo = table.Column<string>(nullable: false, defaultValue: "F"),
                    phone = table.Column<long>(nullable: false),
                    VendedorUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("fornecedorId", x => x.fornecedorId);
                    table.ForeignKey(
                        name: "FK_tbFornecedor_tbVendedor_VendedorUserId",
                        column: x => x.VendedorUserId,
                        principalSchema: "WearOut_Final",
                        principalTable: "tbVendedor",
                        principalColumn: "vendedorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbNegociacao",
                schema: "WearOut_Final",
                columns: table => new
                {
                    NegociacaoId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dtNegociacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    valorTotal = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    ClienteUserId = table.Column<long>(nullable: true),
                    VendedorUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("negociacaoId", x => x.NegociacaoId);
                    table.ForeignKey(
                        name: "FK_tbNegociacao_tbCliente_ClienteUserId",
                        column: x => x.ClienteUserId,
                        principalSchema: "WearOut_Final",
                        principalTable: "tbCliente",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbNegociacao_tbVendedor_VendedorUserId",
                        column: x => x.VendedorUserId,
                        principalSchema: "WearOut_Final",
                        principalTable: "tbVendedor",
                        principalColumn: "vendedorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbProduto",
                schema: "WearOut_Final",
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
                    VendedorUserId = table.Column<long>(nullable: true),
                    FornecedorUserId = table.Column<long>(nullable: true),
                    NegociacaoId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("produtoId", x => x.produtoId);
                    table.ForeignKey(
                        name: "FK_tbProduto_tbFornecedor_FornecedorUserId",
                        column: x => x.FornecedorUserId,
                        principalSchema: "WearOut_Final",
                        principalTable: "tbFornecedor",
                        principalColumn: "fornecedorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbProduto_tbNegociacao_NegociacaoId",
                        column: x => x.NegociacaoId,
                        principalSchema: "WearOut_Final",
                        principalTable: "tbNegociacao",
                        principalColumn: "NegociacaoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbProduto_tbVendedor_VendedorUserId",
                        column: x => x.VendedorUserId,
                        principalSchema: "WearOut_Final",
                        principalTable: "tbVendedor",
                        principalColumn: "vendedorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbFornecedor_VendedorUserId",
                schema: "WearOut_Final",
                table: "tbFornecedor",
                column: "VendedorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbNegociacao_ClienteUserId",
                schema: "WearOut_Final",
                table: "tbNegociacao",
                column: "ClienteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbNegociacao_VendedorUserId",
                schema: "WearOut_Final",
                table: "tbNegociacao",
                column: "VendedorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbProduto_FornecedorUserId",
                schema: "WearOut_Final",
                table: "tbProduto",
                column: "FornecedorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbProduto_NegociacaoId",
                schema: "WearOut_Final",
                table: "tbProduto",
                column: "NegociacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tbProduto_VendedorUserId",
                schema: "WearOut_Final",
                table: "tbProduto",
                column: "VendedorUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbProduto",
                schema: "WearOut_Final");

            migrationBuilder.DropTable(
                name: "tbFornecedor",
                schema: "WearOut_Final");

            migrationBuilder.DropTable(
                name: "tbNegociacao",
                schema: "WearOut_Final");

            migrationBuilder.DropTable(
                name: "tbCliente",
                schema: "WearOut_Final");

            migrationBuilder.DropTable(
                name: "tbVendedor",
                schema: "WearOut_Final");
        }
    }
}
