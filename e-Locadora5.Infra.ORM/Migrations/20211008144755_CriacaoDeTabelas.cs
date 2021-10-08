using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace e_Locadora5.Infra.ORM.Migrations
{
    public partial class CriacaoDeTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GrupoVeiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    planoDiarioValorKm = table.Column<double>(type: "float", nullable: false),
                    planoDiarioValorDiario = table.Column<double>(type: "float", nullable: false),
                    planoKmControladoValorKm = table.Column<double>(type: "float", nullable: false),
                    planoKmControladoQuantidadeKm = table.Column<double>(type: "float", nullable: false),
                    planoKmControladoValorDiario = table.Column<double>(type: "float", nullable: false),
                    planoKmLivreValorDiario = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoVeiculo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBCliente",
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
                    table.PrimaryKey("PK_TBCliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBFuncionario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    NumeroCpf = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Usuario = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataAdmissao = table.Column<DateTime>(type: "DATE", nullable: false),
                    Salario = table.Column<decimal>(type: "NUMERIC(38,17)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBFuncionario", x => x.Id);
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
                name: "TBVeiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Modelo = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Fabricante = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Quilometragem = table.Column<decimal>(type: "NUMERIC(38,17)", nullable: false),
                    QtdLitrosTanque = table.Column<int>(type: "INT", nullable: false),
                    QtdPortas = table.Column<int>(type: "INT", nullable: false),
                    NumeroChassi = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Cor = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    CapacidadeOcupantes = table.Column<int>(type: "INT", nullable: false),
                    AnoFabricacao = table.Column<int>(type: "INT", nullable: false),
                    TamanhoPortaMalas = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Combustivel = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    IdGrupoVeiculo = table.Column<int>(type: "INT", nullable: false),
                    GrupoVeiculoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBVeiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBVeiculo_GrupoVeiculo_GrupoVeiculoId",
                        column: x => x.GrupoVeiculoId,
                        principalTable: "GrupoVeiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBCondutor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(60)", nullable: true),
                    Endereco = table.Column<string>(type: "VARCHAR(110)", nullable: true),
                    Telefone = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    Rg = table.Column<string>(type: "VARCHAR(30)", nullable: true),
                    Cpf = table.Column<string>(type: "VARCHAR(30)", nullable: true),
                    NumeroCNH = table.Column<string>(type: "VARCHAR(30)", nullable: true),
                    ClienteId = table.Column<int>(type: "INT", nullable: false),
                    ValidadeCNH = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCondutor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBCondutor_TBCliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TBCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "Locacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dataLocacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataDevolucao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    quilometragemDevolucao = table.Column<double>(type: "float", nullable: false),
                    plano = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    seguroCliente = table.Column<double>(type: "float", nullable: false),
                    seguroTerceiro = table.Column<double>(type: "float", nullable: false),
                    caucao = table.Column<double>(type: "float", nullable: false),
                    funcionarioId = table.Column<int>(type: "int", nullable: true),
                    grupoVeiculoId = table.Column<int>(type: "int", nullable: true),
                    veiculoId = table.Column<int>(type: "int", nullable: true),
                    clienteId = table.Column<int>(type: "int", nullable: true),
                    condutorId = table.Column<int>(type: "int", nullable: true),
                    cupomId = table.Column<int>(type: "int", nullable: true),
                    emAberto = table.Column<bool>(type: "bit", nullable: false),
                    valorTotal = table.Column<double>(type: "float", nullable: false),
                    emailEnviado = table.Column<bool>(type: "bit", nullable: false),
                    MarcadorCombustivel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locacao_GrupoVeiculo_grupoVeiculoId",
                        column: x => x.grupoVeiculoId,
                        principalTable: "GrupoVeiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locacao_TBCliente_clienteId",
                        column: x => x.clienteId,
                        principalTable: "TBCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locacao_TBCondutor_condutorId",
                        column: x => x.condutorId,
                        principalTable: "TBCondutor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locacao_TBCupom_cupomId",
                        column: x => x.cupomId,
                        principalTable: "TBCupom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locacao_TBFuncionario_funcionarioId",
                        column: x => x.funcionarioId,
                        principalTable: "TBFuncionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locacao_TBVeiculo_veiculoId",
                        column: x => x.veiculoId,
                        principalTable: "TBVeiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaxasServicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxaFixa = table.Column<double>(type: "float", nullable: false),
                    TaxaDiaria = table.Column<double>(type: "float", nullable: false),
                    LocacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxasServicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxasServicos_Locacao_LocacaoId",
                        column: x => x.LocacaoId,
                        principalTable: "Locacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locacao_clienteId",
                table: "Locacao",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Locacao_condutorId",
                table: "Locacao",
                column: "condutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Locacao_cupomId",
                table: "Locacao",
                column: "cupomId");

            migrationBuilder.CreateIndex(
                name: "IX_Locacao_funcionarioId",
                table: "Locacao",
                column: "funcionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Locacao_grupoVeiculoId",
                table: "Locacao",
                column: "grupoVeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Locacao_veiculoId",
                table: "Locacao",
                column: "veiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxasServicos_LocacaoId",
                table: "TaxasServicos",
                column: "LocacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBCondutor_ClienteId",
                table: "TBCondutor",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TBCupom_ParceiroId",
                table: "TBCupom",
                column: "ParceiroId");

            migrationBuilder.CreateIndex(
                name: "IX_TBVeiculo_GrupoVeiculoId",
                table: "TBVeiculo",
                column: "GrupoVeiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxasServicos");

            migrationBuilder.DropTable(
                name: "Locacao");

            migrationBuilder.DropTable(
                name: "TBCondutor");

            migrationBuilder.DropTable(
                name: "TBCupom");

            migrationBuilder.DropTable(
                name: "TBFuncionario");

            migrationBuilder.DropTable(
                name: "TBVeiculo");

            migrationBuilder.DropTable(
                name: "TBCliente");

            migrationBuilder.DropTable(
                name: "TBParceiro");

            migrationBuilder.DropTable(
                name: "GrupoVeiculo");
        }
    }
}
