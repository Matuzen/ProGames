using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProGames.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabasev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoItem_Produto_ProdutoId1",
                table: "CarrinhoItem");

            migrationBuilder.DropIndex(
                name: "IX_CarrinhoItem_ProdutoId1",
                table: "CarrinhoItem");

            migrationBuilder.DropColumn(
                name: "ProdutoId1",
                table: "CarrinhoItem");

            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "CarrinhoItem",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoTotal",
                table: "CarrinhoItem",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ProdutoDescricao",
                table: "CarrinhoItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProdutoImagemURL",
                table: "CarrinhoItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProdutoNome",
                table: "CarrinhoItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preco",
                table: "CarrinhoItem");

            migrationBuilder.DropColumn(
                name: "PrecoTotal",
                table: "CarrinhoItem");

            migrationBuilder.DropColumn(
                name: "ProdutoDescricao",
                table: "CarrinhoItem");

            migrationBuilder.DropColumn(
                name: "ProdutoImagemURL",
                table: "CarrinhoItem");

            migrationBuilder.DropColumn(
                name: "ProdutoNome",
                table: "CarrinhoItem");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId1",
                table: "CarrinhoItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoItem_ProdutoId1",
                table: "CarrinhoItem",
                column: "ProdutoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoItem_Produto_ProdutoId1",
                table: "CarrinhoItem",
                column: "ProdutoId1",
                principalTable: "Produto",
                principalColumn: "Id");
        }
    }
}
