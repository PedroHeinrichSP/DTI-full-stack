using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeadManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLeadEntityAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Leads",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Leads",
                columns: new[] { "Id", "Category", "DateCreated", "Description", "DiscountedPrice", "Email", "FirstName", "LastName", "Phone", "Price", "Status", "Suburb" },
                values: new object[,]
                {
                    { 1, "Eletricista", new DateTime(2025, 11, 6, 23, 36, 58, 216, DateTimeKind.Utc).AddTicks(8169), "Instalações e manutenções elétricas residenciais.", null, "joao.silva@email.com", "João", "Silva", "11999999999", 800m, "invited", "São Paulo" },
                    { 2, "Pintora", new DateTime(2025, 11, 6, 23, 36, 58, 216, DateTimeKind.Utc).AddTicks(9214), "Serviços de pintura residencial e comercial.", null, "maria.souza@email.com", "Maria", "Souza", "11988888888", 450m, "invited", "Campinas" },
                    { 3, "Encanador", new DateTime(2025, 11, 6, 23, 36, 58, 216, DateTimeKind.Utc).AddTicks(9598), "Reparo e instalação hidráulica completa.", 1080m, "carlos.lima@email.com", "Carlos", "Lima", "11977777777", 1200m, "accepted", "Santos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Leads",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Leads",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Leads",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Leads",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
