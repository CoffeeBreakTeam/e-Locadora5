using e_Locadora5.Aplicacao.ParceiroModule;
using e_Locadora5.DataBuilderTest.ParceiroModule;
using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Tests.ParceirosModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.AppServiceTests.ParceiroModule
{
    [TestClass]
    public class ParceiroAppServiceTest
    {
        ParceiroAppService parceiroAppService;
        Mock<IParceiroRepository> mockParceiroRepository;
        Mock<Parceiro> mockParceiro;

        public ParceiroAppServiceTest()
        {
            mockParceiroRepository = new Mock<IParceiroRepository>();
            parceiroAppService = new ParceiroAppService(mockParceiroRepository.Object);
            mockParceiro = new Mock<Parceiro>();
        }

        [TestMethod]
        public void Deve_Chamar_Inserir()
        {
            //Arrange
            Mock<Parceiro> mockParceiro = new Mock<Parceiro>();

            mockParceiroRepository.Setup(x => x.ExisteParceiroComEsseNome("lucas")).Returns(() =>
            {
                return false;
            });

            mockParceiro.Setup(x => x.Validar()).Returns(() =>
            {
                return "ESTA_VALIDO";
            });

            //Action
            parceiroAppService.InserirNovo(mockParceiro.Object);

            //Assert
            mockParceiroRepository.Verify(x => x.InserirNovo(mockParceiro.Object));
        }

        [TestMethod]
        public void Deve_Chamar_Editar()
        {
            //Arrange
            Mock<Parceiro> mockCondutor = new Mock<Parceiro>();

            mockParceiroRepository.Setup(x => x.ExisteParceiroComEsseNome("lucas")).Returns(() =>
            {
                return false;
            });

            mockCondutor.Setup(x => x.Validar()).Returns(() =>
            {
                return "ESTA_VALIDO";
            });

            //Action
            parceiroAppService.Editar(1, mockCondutor.Object);

            //Assert
            mockParceiroRepository.Verify(x => x.Editar(1, mockCondutor.Object));
        }

        [TestMethod]
        public void Deve_Chamar_Excluir()
        {
            // action
            var resultado = parceiroAppService.Excluir(mockParceiro.Object.Id);

            //assert
            mockParceiroRepository.Verify(x => x.Excluir(mockParceiro.Object.Id));

            resultado.Should().Be(true);
        }

        [TestMethod]
        public void Deve_Chamar_SelecionarPorId()
        {
            //arrange
            Parceiro parceiro = new ParceiroDataBuilder().GerarParceiroCompleto();

            mockParceiroRepository.Setup(x => x.SelecionarPorId(1)).Returns(() =>
            {
                return parceiro;
            });

            //action
            var resultado = parceiroAppService.SelecionarPorId(1);

            //assert
            mockParceiroRepository.Verify(x => x.SelecionarPorId(1));
            resultado.Should().Be(parceiro);
        }

        [TestMethod]
        public void Deve_Chamar_Existe()
        {
            //Arrange
            Parceiro parceiro = new ParceiroDataBuilder().GerarParceiroCompleto();

            mockParceiroRepository.Setup(x => x.Existe(1)).Returns(() =>
            {
                return true;
            });

            //Action
            var resultado = parceiroAppService.Existe(1);

            //Assert
            mockParceiroRepository.Verify(x => x.Existe(1));
            resultado.Should().Be(true);
        }

        [TestMethod]
        public void Deve_Chamar_SelecionarTodos()
        {
            //Arrange
            Parceiro parceiro = new ParceiroDataBuilder().GerarParceiroCompleto();
            List<Parceiro> parceiros = new List<Parceiro>() { parceiro };

            mockParceiroRepository.Setup(x => x.SelecionarTodos()).Returns(() =>
            {
                return parceiros;
            });

            //Action
            var resultado = parceiroAppService.SelecionarTodos();

            //Assert
            resultado.Count.Should().Be(1);
        }
    }
}
