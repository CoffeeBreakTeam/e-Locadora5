using e_Locadora5.Aplicacao.CupomModule;
using e_Locadora5.Aplicacao.LocacaoModule;
using e_Locadora5.Dominio;
using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.FuncionarioModule;
using e_Locadora5.Dominio.LocacaoModule;
using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Dominio.TaxasServicosModule;
using e_Locadora5.Dominio.VeiculosModule;
using e_Locadora5.Infra.GeradorLogs;
using e_Locadora5.Infra.SQL.LocacaoModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace e_Locadora5.AppServiceTests.LocacaoModule
{
    [TestClass]
    public class LocacaoAppServiceTests
    {
        Mock<ILocacaoRepository> locacaoDAOMock;
        Mock<Locacao> locacaoMock;
        Mock<Veiculo> veiculoMock;

        public LocacaoAppServiceTests()
        {
            locacaoMock = new Mock<Locacao>();
            veiculoMock = new Mock<Veiculo>();

            locacaoDAOMock = new Mock<ILocacaoRepository>();
        }

        
        [TestMethod]
        public void Deve_Chamar_InserirNovo()
        {
            //arrange
            Locacao novaLocacao = locacaoMock.Object;
            novaLocacao.Veiculo = veiculoMock.Object;

            locacaoMock.Setup(x => x.Validar())
                .Returns(() =>
                {
                    return "ESTA_VALIDO";
                });

            locacaoDAOMock.Setup(x => x.SelecionarLocacoesPorVeiculoId(It.IsAny<int>()))
                .Returns(() =>
                {
                    return null;
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
            Locacao novaLocacao = locacaoMock.Object;
            novaLocacao.Veiculo = veiculoMock.Object;
            LocacaoAppService locacaoAppService = new LocacaoAppService(locacaoDAOMock.Object);

            //action
            locacaoAppService.InserirNovo(novaLocacao);

            //assert
            locacaoMock.Verify(x => x.Validar());
        }

        [TestMethod]
        public void DeveChamarEditar()
        {
            //arrange
            Locacao antigaLocacao = locacaoMock.Object;
            Locacao novaLocacao = locacaoMock.Object;
            novaLocacao.Veiculo = veiculoMock.Object;

            locacaoMock.Setup(x => x.Validar())
                .Returns(() =>
                {
                    return "ESTA_VALIDO";
                });

            locacaoDAOMock.Setup(x => x.SelecionarLocacoesPorVeiculoId(It.IsAny<int>()))
                .Returns(() =>
                {
                    return null;
                });

            //action
            LocacaoAppService locacaoAppService = new LocacaoAppService(locacaoDAOMock.Object);
            locacaoAppService.Editar(antigaLocacao.Id, novaLocacao);

            //assert
            locacaoDAOMock.Verify(x => x.Editar(antigaLocacao.Id, novaLocacao));
        }
        [TestMethod]
        public void DeveChamarExcluir()
        {
            //arrange
            Locacao novaLocacao = locacaoMock.Object;
            novaLocacao.Veiculo = veiculoMock.Object;

            //action
            LocacaoAppService locacaoAppService = new LocacaoAppService(locacaoDAOMock.Object);
            locacaoAppService.Excluir(novaLocacao.Id);

            //assert
            locacaoDAOMock.Verify(x => x.Excluir(novaLocacao.Id));
        }
        [TestMethod]
        public void DeveChamarSelecionarPorId()
        {
            //arrange
            Locacao novaLocacao = locacaoMock.Object;
            novaLocacao.Veiculo = veiculoMock.Object;

            //action
            LocacaoAppService locacaoAppService = new LocacaoAppService(locacaoDAOMock.Object);
            locacaoAppService.SelecionarPorId(novaLocacao.Id);

            //assert
            locacaoDAOMock.Verify(x => x.SelecionarPorId(novaLocacao.Id));
        }
        [TestMethod]
        public void DeveChamarSelecionarLocacoesEmailPendente()
        {
            //arrange
            Locacao novaLocacao = locacaoMock.Object;
            novaLocacao.Veiculo = veiculoMock.Object;

            //action
            LocacaoAppService locacaoAppService = new LocacaoAppService(locacaoDAOMock.Object);
            locacaoAppService.SelecionarLocacoesEmailPendente();

            //assert
            locacaoDAOMock.Verify(x => x.SelecionarLocacoesEmailPendente());
        }
        [TestMethod]
        public void DeveChamarSelecionarTaxasServicosPorLocacaoId()
        {
            //arrange
            Locacao novaLocacao = locacaoMock.Object;
            novaLocacao.Veiculo = veiculoMock.Object;

            //action
            LocacaoAppService locacaoAppService = new LocacaoAppService(locacaoDAOMock.Object);
            locacaoAppService.SelecionarTaxasServicosPorLocacaoId(novaLocacao.Id);

            //assert
            locacaoDAOMock.Verify(x => x.SelecionarTaxasServicosPorLocacaoId(novaLocacao.Id));
        }
        [TestMethod]
        public void DeveChamarSelecionarLocacoesPorVeiculoId()
        {
            //arrange
            Veiculo veiculo = veiculoMock.Object;

            //action
            LocacaoAppService locacaoAppService = new LocacaoAppService(locacaoDAOMock.Object);
            locacaoAppService.SelecionarLocacoesPorVeiculoId(veiculo.Id);

            //assert
            locacaoDAOMock.Verify(x => x.SelecionarLocacoesPorVeiculoId(veiculo.Id));
        }
        [TestMethod]
        public void DeveChamarExiste()
        {
            //arrange
            Locacao novaLocacao = locacaoMock.Object;
            novaLocacao.Veiculo = veiculoMock.Object;

            //action
            LocacaoAppService locacaoAppService = new LocacaoAppService(locacaoDAOMock.Object);
            locacaoAppService.Existe(novaLocacao.Id);

            //assert
            locacaoDAOMock.Verify(x => x.Existe(novaLocacao.Id));
        }
        [TestMethod]
        public void DeveChamarSelecionarTodos()
        {
            //arrange
            Locacao novaLocacao = locacaoMock.Object;
            novaLocacao.Veiculo = veiculoMock.Object;

            //action
            LocacaoAppService locacaoAppService = new LocacaoAppService(locacaoDAOMock.Object);
            locacaoAppService.SelecionarTodos();

            //assert
            locacaoDAOMock.Verify(x => x.SelecionarTodos());
        }
    }
}
