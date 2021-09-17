using e_Locadora5.Aplicacao.CupomModule;
using e_Locadora5.Aplicacao.LocacaoModule;
using e_Locadora5.Dominio;
using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.CondutoresModule;
using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.FuncionarioModule;
using e_Locadora5.Dominio.LocacaoModule;
using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Dominio.TaxasServicosModule;
using e_Locadora5.Dominio.VeiculosModule;
using e_Locadora5.Infra.SQL.LocacaoModule;
using e_Locadora5.WindowsApp.Features.LocacaoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace e_Locadora5.AppServiceTests.LocacaoModule
{
    [TestClass]
    public class LocacaoAppServiceTests
    {
        Mock<LocacaoAppService> locacaoAppServiceMock;
        Mock<ILocacaoRepository> locacaoDAOMock;
        Mock<Locacao> locacaoMock;

        DateTime dataHoje;
        DateTime dataAmanha;
        GrupoVeiculo grupoVeiculo;
        byte[] imagem;
        Veiculo uno;
        Funcionario funcionario;
        Clientes cliente;
        Condutor condutor;
        TaxasServicos taxaServico;
        Parceiro parceiro;
        Cupons cupom;

        public LocacaoAppServiceTests()
        {
            dataHoje = DateTime.Now.Date;
            dataAmanha = DateTime.Now.Date.AddDays(1);
            funcionario = new Funcionario("nome", "460162200", "usuario", "senha", DateTime.Now.Date, 600.0);
            grupoVeiculo = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);
            imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            uno = new Veiculo("placa", "Uno", "Fiat", 400.0, 50, 4, "123456", "azul", 4, 1996, "Grande", "Gasolina", grupoVeiculo, imagem);
            cliente = new Clientes("Joao", "rua souza", "9524282242", "853242", "20220220222", "1239232", "Joao.pereira@gmail.com");
            condutor = new Condutor("Joao", "Rua dos Joao", "9522185224", "5222522", "20202020222", "522542", new DateTime(2022, 05, 26), cliente);
            taxaServico = new TaxasServicos("descricao", 200, 0);
            parceiro = new Parceiro("Deko");
            cupom = new Cupons("Cupom do Deko", 50, 0, dataAmanha, parceiro, 1);

            locacaoMock = new Mock<Locacao>();
            locacaoMock.Object.veiculo = uno;

            locacaoDAOMock = new Mock<ILocacaoRepository>();
            
            locacaoAppServiceMock = new Mock<LocacaoAppService>(locacaoDAOMock.Object);
        }

        [TestMethod]
        public void Deve_Chamar_InserirNovo()
        {
            //arrange
            Locacao novaLocacao = locacaoMock.Object;
            Locacao locacaoExistente = new LocacaoDataBuilder()
                .ComFuncionario(funcionario)
                .ComGrupoVeiculo(grupoVeiculo)
                .ComVeiculo(uno)
                .ComCliente(cliente)
                .ComCondutor(condutor)
                .ComCaucao(100)
                .ComDataLocacao(dataHoje)
                .ComDataDevolucao(dataAmanha)
                .ComEmAberto(false)
                .ComQuilometragemDevolucao(uno.Quilometragem + 200)
                .ComSeguroCliente(250)
                .ComSeguroTerceiro(500)
                .ComPlano("Diario")
                .Build();

            locacaoDAOMock.Setup(x => x.SelecionarTodos())
                .Returns(() =>
                {
                    return new List<Locacao>() { locacaoExistente };
                });

            //action
            LocacaoAppService locacaoAppService = new LocacaoAppService(locacaoDAOMock.Object);
            locacaoAppService.InserirNovo(novaLocacao);

            //assert
            locacaoDAOMock.Verify(x => x.InserirNovo(novaLocacao));
        }

        [TestMethod]
        public void Deve_Chamar_ValidarDominio()
        {
            //arrange
            Locacao locacaoExistente = locacaoMock.Object;

            locacaoDAOMock.Setup(x => x.SelecionarTodos())
                .Returns(() =>
                {
                    return new List<Locacao>() { locacaoExistente };
                });

            //action
            LocacaoAppService locacaoAppService = new LocacaoAppService(locacaoDAOMock.Object);
            locacaoAppService.InserirNovo(locacaoMock.Object);

            //assert
            locacaoMock.Verify(x => x.Validar());
        }


        /*
        [TestMethod]
        public void Deve_Chamar_ValidarAppService()
        {
            //arrange
            Veiculo veiculoExistente = uno;
            locacaoDAOMock.Setup(x => x.ExisteVeiculo())
                .Returns(() =>
                {
                    return new List<Locacao>() { locacaoExistente };
                });
            
            //action
            string resultado = locacaoAppService.InserirNovo(novaLocacao);

            //assert
            resultado.Should().Be("ValidacaoResultadoNegativoAppService");
        }
        */
    }
}
