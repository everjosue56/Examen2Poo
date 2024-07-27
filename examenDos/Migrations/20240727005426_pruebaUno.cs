using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace examenDos.Migrations
{
    /// <inheritdoc />
    public partial class pruebaUno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "customers",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    commissionRate = table.Column<decimal>(type: "decimal(18,2)", maxLength: 100, nullable: false),
                    interesRate = table.Column<int>(type: "int", nullable: false),
                    term = table.Column<int>(type: "int", nullable: false),
                    disbursementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    firstPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customers",
                schema: "dbo");
        }
    }
}
