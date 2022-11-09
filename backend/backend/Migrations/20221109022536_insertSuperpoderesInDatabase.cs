using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class insertSuperpoderesInDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Superpoderes",
                columns: new[] { "Id", "Descricao", "Superpoder" },
                values: new object[,]
                {
                    { 1, "Voa Alto", "Voar" },
                    { 2, "Muito Forte", "Super Força" },
                    { 3, "Muito Veloz", "Super Velocidade" },
                    { 4, "Muita Inteligencia", "Super Inteligencia" },
                    { 5, "Muito Resistente", "Super Resistencia" },
                    { 6, "XD", "Conversar com Peixes" },
                    { 7, "", "Soltar Laser dos Olhos" },
                    { 8, "Consegue controlar metal da forma que quiser", "Controlar Metal" },
                    { 9, "Telepatia", "Telepatia" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Superpoderes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Superpoderes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Superpoderes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Superpoderes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Superpoderes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Superpoderes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Superpoderes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Superpoderes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Superpoderes",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
