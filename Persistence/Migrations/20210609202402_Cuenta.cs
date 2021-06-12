using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Cuenta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreBanco = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NombreCliente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaApertura = table.Column<DateTime>(type: "datetime2", maxLength: 30, nullable: false),
                    NumeroCuenta = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    TipoCuenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Retiros = table.Column<float>(type: "real", maxLength: 10, nullable: false),
                    Depositos = table.Column<float>(type: "real", maxLength: 10, nullable: false),
                    Saldo = table.Column<float>(type: "real", maxLength: 10, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuentas");
        }
    }
}
