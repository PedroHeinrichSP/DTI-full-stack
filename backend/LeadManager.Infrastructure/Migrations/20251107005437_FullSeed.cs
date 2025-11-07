using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeadManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FullSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountedPrice",
                table: "Leads");

            migrationBuilder.UpdateData(
                table: "Leads",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Instalações elétricas residenciais.");

            migrationBuilder.UpdateData(
                table: "Leads",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Pintura residencial e comercial.");

            migrationBuilder.UpdateData(
                table: "Leads",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Reparo e instalação hidráulica.");

            migrationBuilder.InsertData(
                table: "Leads",
                columns: new[] { "Id", "Category", "DateCreated", "Description", "Email", "FirstName", "LastName", "Phone", "Price", "Status", "Suburb" },
                values: new object[,]
                {
                    { 4, "Jardineira", new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Serviços de jardinagem e paisagismo.", "fernanda.oliveira@email.com", "Fernanda", "Oliveira", "11966666666", 300m, "invited", "São Paulo" },
                    { 5, "Marceneiro", new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Móveis planejados sob medida.", "rafael.costa@email.com", "Rafael", "Costa", "11955555555", 950m, "invited", "Guarulhos" },
                    { 6, "Diarista", new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Limpeza residencial e comercial.", "patricia.ferreira@email.com", "Patrícia", "Ferreira", "11944444444", 250m, "invited", "Santo André" },
                    { 7, "Pedreiro", new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Reformas e construções gerais.", "diego.mendes@email.com", "Diego", "Mendes", "11933333333", 1100m, "invited", "Osasco" },
                    { 8, "Decoradora", new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), "Design de interiores e consultoria de ambientes.", "aline.pereira@email.com", "Aline", "Pereira", "11922222222", 600m, "invited", "Barueri" },
                    { 9, "Técnico em Ar Condicionado", new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Utc), "Instalação e manutenção de ar-condicionado.", "fabio.nunes@email.com", "Fábio", "Nunes", "11911111111", 500m, "invited", "São Caetano" },
                    { 10, "Faxineira", new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Serviços de faxina e limpeza rápida.", "camila.rodrigues@email.com", "Camila", "Rodrigues", "11900000000", 200m, "invited", "Diadema" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Leads",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Leads",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Leads",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Leads",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Leads",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Leads",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Leads",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountedPrice",
                table: "Leads",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Leads",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "DiscountedPrice" },
                values: new object[] { "Instalações e manutenções elétricas residenciais.", 720m });

            migrationBuilder.UpdateData(
                table: "Leads",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "DiscountedPrice" },
                values: new object[] { "Serviços de pintura residencial e comercial.", null });

            migrationBuilder.UpdateData(
                table: "Leads",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "DiscountedPrice" },
                values: new object[] { "Reparo e instalação hidráulica completa.", 1080m });
        }
    }
}
