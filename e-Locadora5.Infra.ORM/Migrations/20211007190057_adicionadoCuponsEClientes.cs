using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace e_Locadora5.Infra.ORM.Migrations
{
    public partial class adicionadoCuponsEClientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBClientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(60)", nullable: true),
                    Endereco = table.Column<string>(type: "VARCHAR(110)", nullable: true),
                    Telefone = table.Column<string>(type: "VARCHAR(30)", nullable: true),
                    RG = table.Column<string>(type: "VARCHAR(30)", nullable: true),
                    CPF = table.Column<string>(type: "VARCHAR(30)", nullable: true),
                    CNPJ = table.Column<string>(type: "VARCHAR(30)", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBClientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBParceiro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBParceiro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Condutores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroCNH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidadeCNH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condutores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Condutores_TBClientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TBClientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBCupom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    ValorPercentual = table.Column<int>(type: "INT", nullable: false),
                    ValorFixo = table.Column<decimal>(type: "DECIMAL(18,17)", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "DATE", nullable: false),
                    ParceiroId = table.Column<int>(type: "INT", nullable: false),
                    ValorMinimo = table.Column<decimal>(type: "DECIMAL(18,17)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCupom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBCupom_TBParceiro_ParceiroId",
                        column: x => x.ParceiroId,
                        principalTable: "TBParceiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Condutores_ClienteId",
                table: "Condutores",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TBCupom_ParceiroId",
                table: "TBCupom",
                column: "ParceiroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Condutores");

            migrationBuilder.DropTable(
                name: "TBCupom");

            migrationBuilder.DropTable(
                name: "TBClientes");

            migrationBuilder.DropTable(
                name: "TBParceiro");
        }
    }
}
