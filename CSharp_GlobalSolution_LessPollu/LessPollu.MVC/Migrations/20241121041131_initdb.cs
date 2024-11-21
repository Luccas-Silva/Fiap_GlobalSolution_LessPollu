using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LessPollu.MVC.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tabela_Industria",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    CEP = table.Column<string>(type: "NVARCHAR2(8)", maxLength: 8, nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabela_Industria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tabela_Relatorio",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    dataGeracao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    periodoCobertura = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Metricas = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: false),
                    Observacoes = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabela_Relatorio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tabela_Usuario",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabela_Usuario", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tabela_Industria");

            migrationBuilder.DropTable(
                name: "tabela_Relatorio");

            migrationBuilder.DropTable(
                name: "tabela_Usuario");
        }
    }
}
