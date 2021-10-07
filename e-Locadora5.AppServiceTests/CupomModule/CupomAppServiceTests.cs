using e_Locadora5.Aplicacao.CupomModule;
using e_Locadora5.DataBuilderTest.CupomModule;
using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Tests.CupomModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.AppServiceTests.CupomModule
{
    [TestClass]
    public class CupomAppServiceTests
    {
        CupomAppService cupomAppService;
        Mock<ICupomRepository> mockCupomRepository;

        public CupomAppServiceTests()
        {
            mockCupomRepository = new Mock<ICupomRepository>();
            cupomAppService = new CupomAppService(mockCupomRepository.Object);
        }

        [TestMethod]
        public void Deve_Chamar_InserirNovo()
        {
            //arrange
            Mock<Cupom> cupomMock = new Mock<Cupom>();

            cupomMock.Setup(x => x.Validar())
                .Returns(() => { return "ESTA_VALIDO"; });

            Mock<ICupomRepository> MockCupom = new Mock<ICupomRepository>();

            Cupom cupom = cupomMock.Object;

            //Action
            CupomAppService sut = new CupomAppService(MockCupom.Object);

            var resultado = sut.InserirNovo(cupomMock.Object);

            //Assert
            MockCupom.Verify(x => x.InserirNovo(cupom));
        }

        [TestMethod]
        public void Deve_Chamar_Editar()
        {
            //arrange
            Mock<Cupom> cupomMock = new Mock<Cupom>();

            cupomMock.Setup(x => x.Validar())
                .Returns(() => { return "ESTA_VALIDO"; });

            Mock<ICupomRepository> mockRepository = new Mock<ICupomRepository>();

            Cupom cupom = cupomMock.Object;

            //action
            CupomAppService sut = new CupomAppService(mockRepository.Object);

            sut.Editar(1, cupomMock.Object);

            //assert
            //mockRepository.Verify(x => x.Editar(1, cupomMock.Object));
        }

        [TestMethod]
        public void Deve_Chamar_Excluir()
        {
            //arrange
            Mock<Cupom> cupomMock = new Mock<Cupom>();

            cupomMock.Setup(x => x.Validar())
                .Returns(() => { return "ESTA_VALIDO"; });

            Mock<ICupomRepository> mockRepository = new Mock<ICupomRepository>();

            Cupom cupom = cupomMock.Object;

            //action
            CupomAppService sut = new CupomAppService(mockRepository.Object);

            var resultado = sut.Excluir(cupomMock.Object.Id);

            //assert
            mockRepository.Verify(x => x.Excluir(cupom.Id));
        }

        [TestMethod]
        public void Deve_Chamar_ExistirCupom()
        {
            //arrange
            Mock<Cupom> cupomMock = new Mock<Cupom>();

            cupomMock.Setup(x => x.Validar())
                .Returns(() => { return "ESTA_VALIDO"; });

            Mock<ICupomRepository> mockRepository = new Mock<ICupomRepository>();

            Cupom cupom = cupomMock.Object;

            //action
            CupomAppService sut = new CupomAppService(mockRepository.Object);

            var resultado = sut.Existe(cupomMock.Object.Id);

            //assert
            mockRepository.Verify(x => x.Existe(cupom.Id));
        }

        [TestMethod]
        public void Deve_Chamar_SelecionarTodosCupons()
        {
            //arrange
            Mock<Cupom> cupomMock = new Mock<Cupom>();

            cupomMock.Setup(x => x.Validar())
                .Returns(() => { return "ESTA_VALIDO"; });

            Mock<ICupomRepository> mockRepository = new Mock<ICupomRepository>();

            //action
            CupomAppService sut = new CupomAppService(mockRepository.Object);

            var resultado = sut.SelecionarTodos();

            //assert
            mockRepository.Verify(x => x.SelecionarTodos());
        }

        [TestMethod]
        public void Deve_Chamar_SelecionarCupom_ID()
        {
            //arrange
            Cupom cupom = new CupomDataBuilder().GerarCupomCompleto();

            mockCupomRepository.Setup(x => x.SelecionarPorId(1)).Returns(() =>
            {
                return cupom;
            });
            //act
            var resultado = cupomAppService.SelecionarPorId(1);
            //assert
            mockCupomRepository.Verify(x => x.SelecionarPorId(1));
            resultado.Should().Be(cupom);
        }

            [TestMethod]
        public void NaoDeve_CadastrarCupon_ComMesmoNome()
        {
            //arrange
            Mock<ICupomRepository> mockRepository = new Mock<ICupomRepository>();

            mockRepository.Setup(x => x.ExisteCupomMesmoNome("ADS1234")).Returns(() => { return true; });

            CupomAppService sut = new CupomAppService(mockRepository.Object);

            var NovoCupom = new Cupom("ADS1234", 100, 200, DateTime.Now, new Parceiro("Lucas"), 100);

            //action
            var resultado = sut.InserirNovo(NovoCupom);

            //assert
            resultado.Should().Be("Já há um cupom com este nome cadastrado");
        }

            [TestMethod]
        public void Deve_Chamar_ValidarDominio()
        {
            //arrange
            Cupom cupomExistente = new CupomDataBuilder().GerarCupomCompleto();
                
            Mock<Cupom> novoCupomMock = new Mock<Cupom>();
            
            Mock<ICupomRepository> cupomDAOMock = new Mock<ICupomRepository>();

            cupomDAOMock.Setup(x => x.SelecionarTodos())
                .Returns(() =>
                {
                    return new List<Cupom>() { cupomExistente };
                });

            //action
            CupomAppService cupomAppService = new CupomAppService(cupomDAOMock.Object);
            cupomAppService.InserirNovo(novoCupomMock.Object);

            //assert
            novoCupomMock.Verify(x => x.Validar());
        }
    }
}
