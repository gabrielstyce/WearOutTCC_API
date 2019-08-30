using Microsoft.EntityFrameworkCore.Migrations;

namespace WearOutTCC_API.Migrations
{
    public partial class Modelo_Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "wearOut_TCC");

            migrationBuilder.RenameTable(
                name: "tbVendedor",
                schema: "WearOut_Final",
                newName: "tbVendedor",
                newSchema: "wearOut_TCC");

            migrationBuilder.RenameTable(
                name: "tbProduto",
                schema: "WearOut_Final",
                newName: "tbProduto",
                newSchema: "wearOut_TCC");

            migrationBuilder.RenameTable(
                name: "tbNegociacao",
                schema: "WearOut_Final",
                newName: "tbNegociacao",
                newSchema: "wearOut_TCC");

            migrationBuilder.RenameTable(
                name: "tbFornecedor",
                schema: "WearOut_Final",
                newName: "tbFornecedor",
                newSchema: "wearOut_TCC");

            migrationBuilder.RenameTable(
                name: "tbCliente",
                schema: "WearOut_Final",
                newName: "tbCliente",
                newSchema: "wearOut_TCC");

            migrationBuilder.AlterColumn<string>(
                name: "tipo",
                schema: "wearOut_TCC",
                table: "tbVendedor",
                nullable: false,
                defaultValue: "F",
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "tipo",
                schema: "wearOut_TCC",
                table: "tbFornecedor",
                nullable: false,
                defaultValue: "F",
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "tipo",
                schema: "wearOut_TCC",
                table: "tbCliente",
                nullable: false,
                defaultValue: "C",
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "WearOut_Final");

            migrationBuilder.RenameTable(
                name: "tbVendedor",
                schema: "wearOut_TCC",
                newName: "tbVendedor",
                newSchema: "WearOut_Final");

            migrationBuilder.RenameTable(
                name: "tbProduto",
                schema: "wearOut_TCC",
                newName: "tbProduto",
                newSchema: "WearOut_Final");

            migrationBuilder.RenameTable(
                name: "tbNegociacao",
                schema: "wearOut_TCC",
                newName: "tbNegociacao",
                newSchema: "WearOut_Final");

            migrationBuilder.RenameTable(
                name: "tbFornecedor",
                schema: "wearOut_TCC",
                newName: "tbFornecedor",
                newSchema: "WearOut_Final");

            migrationBuilder.RenameTable(
                name: "tbCliente",
                schema: "wearOut_TCC",
                newName: "tbCliente",
                newSchema: "WearOut_Final");

            migrationBuilder.AlterColumn<string>(
                name: "tipo",
                schema: "WearOut_Final",
                table: "tbVendedor",
                nullable: false,
                oldClrType: typeof(string),
                oldDefaultValue: "F");

            migrationBuilder.AlterColumn<string>(
                name: "tipo",
                schema: "WearOut_Final",
                table: "tbFornecedor",
                nullable: false,
                oldClrType: typeof(string),
                oldDefaultValue: "F");

            migrationBuilder.AlterColumn<string>(
                name: "tipo",
                schema: "WearOut_Final",
                table: "tbCliente",
                nullable: false,
                oldClrType: typeof(string),
                oldDefaultValue: "C");
        }
    }
}
