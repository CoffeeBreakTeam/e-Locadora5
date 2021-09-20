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

        public LocacaoAppServiceTests()
        {
            locacaoMock = new Mock<Locacao>();

            locacaoDAOMock = new Mock<ILocacaoRepository>();
        }

        
        [TestMethod]
        public void Deve_Chamar_InserirNovo()
        {
            //arrange
            Locacao novaLocacao = locacaoMock.Object;

            locacaoMock.Setup(x => x.Validar())
                .Returns(() =>
                {
                    return "ESTA_VALIDO";
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
            LocacaoAppService locacaoAppService = new LocacaoAppService(locacaoDAOMock.Object);

            //action
            locacaoAppService.InserirNovo(locacaoMock.Object);

            //assert
            locacaoMock.Verify(x => x.Validar());
        }
    }
}
