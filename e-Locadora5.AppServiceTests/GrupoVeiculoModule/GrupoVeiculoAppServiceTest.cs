using e_Locadora5.Aplicacao.GrupoVeiculoModule;
using e_Locadora5.Dominio;
using e_Locadora5.Dominio.GrupoVeiculoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.AppServiceTests.GrupoVeiculoModule
{
    [TestClass]
    public class GrupoVeiculoAppServiceTest
    {
        [TestMethod]
        public void Deve_CadastrarGrupoVeiculo_Valido()
        {
            //arrange
            Mock<GrupoVeiculo> GrupoVeiculoMock = new Mock<GrupoVeiculo>();

            GrupoVeiculoMock.Setup(x => x.Validar())
                .Returns(() => { return "ESTA_VALIDO"; });

            Mock<IGrupoVeiculoRepository> mockRepository = new Mock<IGrupoVeiculoRepository>();

            GrupoVeiculo grupoVeiculo = GrupoVeiculoMock.Object;

            //action
            GrupoVeiculoAppService sut = new GrupoVeiculoAppService(mockRepository.Object);

            var resultado = sut.InserirNovo(GrupoVeiculoMock.Object);

            //assert
            mockRepository.Verify(x => x.InserirNovo(grupoVeiculo));
        }

        [TestMethod]
        public void Deve_EditarGrupoVeiculo()
        {
            //arrange
            Mock<GrupoVeiculo> grupoVeiculoMock = new Mock<GrupoVeiculo>();

            grupoVeiculoMock.Setup(x => x.Validar())
                .Returns(() => { return "ESTA_VALIDO"; });

            Mock<IGrupoVeiculoRepository> mockRepository = new Mock<IGrupoVeiculoRepository>();

            GrupoVeiculo grupoVeiculo = grupoVeiculoMock.Object;

            //action
            GrupoVeiculoAppService sut = new GrupoVeiculoAppService(mockRepository.Object);

            var resultado = sut.Editar(grupoVeiculoMock.Object.Id, grupoVeiculoMock.Object);

            //assert
            mockRepository.Verify(x => x.Editar(grupoVeiculo.Id, grupoVeiculo));
        }

        public void Deve_ExcluirGrupoVeiculo()
        {
            //arrange
            Mock<GrupoVeiculo> grupoVeiculoMock = new Mock<GrupoVeiculo>();

            grupoVeiculoMock.Setup(x => x.Validar())
                .Returns(() => { return "ESTA_VALIDO"; });

            Mock<IGrupoVeiculoRepository> mockRepository = new Mock<IGrupoVeiculoRepository>();

            GrupoVeiculo grupoVeiculo = grupoVeiculoMock.Object;

            //action
            GrupoVeiculoAppService sut = new GrupoVeiculoAppService(mockRepository.Object);

            var resultado = sut.Excluir(grupoVeiculoMock.Object.Id);

            //assert
            mockRepository.Verify(x => x.Excluir(grupoVeiculo.Id));
        }
        [TestMethod]
        public void Deve_ExistirGrupoVeiculo()
        {
            //arrange
            Mock<GrupoVeiculo> grupoVeiculoMock = new Mock<GrupoVeiculo>();

            grupoVeiculoMock.Setup(x => x.Validar())
                .Returns(() => { return "ESTA_VALIDO"; });

            Mock<IGrupoVeiculoRepository> mockRepository = new Mock<IGrupoVeiculoRepository>();

            GrupoVeiculo veiculo = grupoVeiculoMock.Object;

            //action
            GrupoVeiculoAppService sut = new GrupoVeiculoAppService(mockRepository.Object);

            var resultado = sut.Existe(grupoVeiculoMock.Object.Id);

            //assert
            mockRepository.Verify(x => x.Existe(veiculo.Id));
        }
        [TestMethod]
        public void Deve_SelecionarTodosGrupoVeiculos()
        {
            //arrange
            Mock<GrupoVeiculo> grupoVeiculoMock = new Mock<GrupoVeiculo>();

            grupoVeiculoMock.Setup(x => x.Validar())
                .Returns(() => { return "ESTA_VALIDO"; });

            Mock<IGrupoVeiculoRepository> mockRepository = new Mock<IGrupoVeiculoRepository>();

            //action
            GrupoVeiculoAppService sut = new GrupoVeiculoAppService(mockRepository.Object);

            var resultado = sut.SelecionarTodos();

            //assert
            mockRepository.Verify(x => x.SelecionarTodos());
        }
    }
}
