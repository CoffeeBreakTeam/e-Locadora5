using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace e_Locadora5.Infra.ORM.Migrations
{
    public partial class tabelasFinais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "TBGrupoVeiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoria = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    planoDiarioValorKm = table.Column<double>(type: "float", nullable: false),
                    planoDiarioValorDiario = table.Column<double>(type: "float", nullable: false),
                    planoKmControladoValorKm = table.Column<double>(type: "float", nullable: false),
                    planoKmControladoQuantidadeKm = table.Column<double>(type: "float", nullable: false),
                    planoKmControladoValorDiario = table.Column<double>(type: "float", nullable: false),
                    planoKmLivreValorDiario = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBGrupoVeiculo", x => x.Id);
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
                name: "TBTaxasServicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    TaxaFixa = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    TaxaDiaria = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTaxasServicos", x => x.Id);
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
                    GrupoVeiculoId = table.Column<int>(type: "int", nullable: false),
                    Imagem = table.Column<byte[]>(type: "IMAGE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBVeiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBVeiculo_TBGrupoVeiculo",
                        column: x => x.GrupoVeiculoId,
                        principalTable: "TBGrupoVeiculo",
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
                    ValorFixo = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "DATE", nullable: false),
                    ParceiroId = table.Column<int>(type: "INT", nullable: false),
                    ValorMinimo = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false)
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
                name: "TBLocacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dataLocacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    dataDevolucao = table.Column<DateTime>(type: "datetime", nullable: false),
                    quilometragemDevolucao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    plano = table.Column<string>(type: "varchar(50)", nullable: true),
                    seguroCliente = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    seguroTerceiro = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    caucao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    GrupoVeiculoId = table.Column<int>(type: "int", nullable: false),
                    VeiculoId = table.Column<int>(type: "int", nullable: false),
                    CondutorId = table.Column<int>(type: "int", nullable: false),
                    CupomId = table.Column<int>(type: "int", nullable: true),
                    emAberto = table.Column<bool>(type: "bit", nullable: false),
                    valorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    emailEnviado = table.Column<bool>(type: "bit", nullable: false),
                    MarcadorCombustivel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLocacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBCliente",
                        column: x => x.ClienteId,
                        principalTable: "TBCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBCondutor",
                        column: x => x.CondutorId,
                        principalTable: "TBCondutor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBCupom",
                        column: x => x.CupomId,
                        principalTable: "TBCupom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBFuncionario",
                        column: x => x.FuncionarioId,
                        principalTable: "TBFuncionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBGrupoVeiculo",
                        column: x => x.GrupoVeiculoId,
                        principalTable: "TBGrupoVeiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBVeiculo",
                        column: x => x.VeiculoId,
                        principalTable: "TBVeiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocacaoTaxasServicos",
                columns: table => new
                {
                    TaxasServicosId = table.Column<int>(type: "int", nullable: false),
                    locacoesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocacaoTaxasServicos", x => new { x.TaxasServicosId, x.locacoesId });
                    table.ForeignKey(
                        name: "FK_LocacaoTaxasServicos_TBLocacao_locacoesId",
                        column: x => x.locacoesId,
                        principalTable: "TBLocacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocacaoTaxasServicos_TBTaxasServicos_TaxasServicosId",
                        column: x => x.TaxasServicosId,
                        principalTable: "TBTaxasServicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocacaoTaxasServicos_locacoesId",
                table: "LocacaoTaxasServicos",
                column: "locacoesId");

            migrationBuilder.CreateIndex(
                name: "IX_TBCondutor_ClienteId",
                table: "TBCondutor",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TBCupom_ParceiroId",
                table: "TBCupom",
                column: "ParceiroId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_ClienteId",
                table: "TBLocacao",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_CondutorId",
                table: "TBLocacao",
                column: "CondutorId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_CupomId",
                table: "TBLocacao",
                column: "CupomId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_FuncionarioId",
                table: "TBLocacao",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_GrupoVeiculoId",
                table: "TBLocacao",
                column: "GrupoVeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_VeiculoId",
                table: "TBLocacao",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBVeiculo_GrupoVeiculoId",
                table: "TBVeiculo",
                column: "GrupoVeiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocacaoTaxasServicos");

            migrationBuilder.DropTable(
                name: "TBLocacao");

            migrationBuilder.DropTable(
                name: "TBTaxasServicos");

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
                name: "TBGrupoVeiculo");
        }
    }
}
