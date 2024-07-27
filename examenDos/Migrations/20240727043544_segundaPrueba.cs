using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace examenDos.Migrations
{
    /// <inheritdoc />
    public partial class segundaPrueba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "loans",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    customerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    interestRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    term = table.Column<int>(type: "int", nullable: false),
                    disbursementDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loans", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AmortizationDetails",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    loanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    installmentNumber = table.Column<int>(type: "int", nullable: false),
                    paymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    days = table.Column<int>(type: "int", nullable: false),
                    interest = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    principal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    levelPaymentWithoutSVSD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    levelPaymentWithSVSD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    principalBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmortizationDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_AmortizationDetails_loans_loanId",
                        column: x => x.loanId,
                        principalSchema: "dbo",
                        principalTable: "loans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AmortizationDetails_loanId",
                table: "AmortizationDetails",
                column: "loanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmortizationDetails");

            migrationBuilder.DropTable(
                name: "loans",
                schema: "dbo");
        }
    }
}
