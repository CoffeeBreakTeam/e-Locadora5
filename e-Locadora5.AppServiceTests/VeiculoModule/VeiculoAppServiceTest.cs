using e_Locadora5.Aplicacao.VeiculoModule;
using e_Locadora5.Dominio;
using e_Locadora5.Dominio.VeiculosModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.AppServiceTests.VeiculoModule
{
    [TestClass]
    public class VeiculoAppServiceTest
    {
        
        [TestMethod]
        public void Deve_CadastrarVeiculo_Valido()
        {
            //arrange
            Mock<Veiculo> veiculoMock = new Mock<Veiculo>();

            veiculoMock.Setup(x => x.Validar())
                .Returns(() => { return "ESTA_VALIDO"; });

            Mock<IVeiculoRepository> mockRepository = new Mock<IVeiculoRepository>();

            Veiculo veiculo = veiculoMock.Object;

            //action
            VeiculoAppService sut = new VeiculoAppService(mockRepository.Object);

            var resultado = sut.InserirNovo(veiculoMock.Object);

            //assert
            mockRepository.Verify(x => x.InserirNovo(veiculo));
        }
        [TestMethod]
        public void Deve_EditarVeiculo()
        {
            //arrange
            Mock<Veiculo> veiculoMock = new Mock<Veiculo>();

            veiculoMock.Setup(x => x.Validar())
                .Returns(() => { return "ESTA_VALIDO"; });

            Mock<IVeiculoRepository> mockRepository = new Mock<IVeiculoRepository>();

            Veiculo veiculo = veiculoMock.Object;

            //action
            VeiculoAppService sut = new VeiculoAppService(mockRepository.Object);

            var resultado = sut.Editar(veiculoMock.Object.Id,veiculoMock.Object);

            //assert
            mockRepository.Verify(x => x.Editar(veiculo.Id, veiculo));
        }
        [TestMethod]
        public void Deve_ExcluirVeiculo()
        {
            //arrange
            Mock<Veiculo> veiculoMock = new Mock<Veiculo>();

            veiculoMock.Setup(x => x.Validar())
                .Returns(() => { return "ESTA_VALIDO"; });

            Mock<IVeiculoRepository> mockRepository = new Mock<IVeiculoRepository>();

            Veiculo veiculo = veiculoMock.Object;

            //action
            VeiculoAppService sut = new VeiculoAppService(mockRepository.Object);

            var resultado = sut.Excluir(veiculoMock.Object.Id);

            //assert
            mockRepository.Verify(x => x.Excluir(veiculo.Id));
        }
        [TestMethod]
        public void Deve_ExistirVeiculo()
        {
            //arrange
            Mock<Veiculo> veiculoMock = new Mock<Veiculo>();

            veiculoMock.Setup(x => x.Validar())
                .Returns(() => { return "ESTA_VALIDO"; });

            Mock<IVeiculoRepository> mockRepository = new Mock<IVeiculoRepository>();

            Veiculo veiculo = veiculoMock.Object;

            //action
            VeiculoAppService sut = new VeiculoAppService(mockRepository.Object);

            var resultado = sut.Existe(veiculoMock.Object.Id);

            //assert
            mockRepository.Verify(x => x.Existe(veiculo.Id));
        }
        [TestMethod]
        public void Deve_SelecionarTodosVeiculos()
        {
            //arrange
            Mock<Veiculo> veiculoMock = new Mock<Veiculo>();

            veiculoMock.Setup(x => x.Validar())
                .Returns(() => { return "ESTA_VALIDO"; });

            Mock<IVeiculoRepository> mockRepository = new Mock<IVeiculoRepository>();

            //action
            VeiculoAppService sut = new VeiculoAppService(mockRepository.Object);

            var resultado = sut.SelecionarTodos();

            //assert
            mockRepository.Verify(x => x.SelecionarTodos());
        }
        [TestMethod]
        public void NaoDeve_CadastrarVeiculos_ComMesmaPlaca()
        {
            //arrange
            string placa = "ADS1234";

            Mock<IVeiculoRepository> mockRepository = new Mock<IVeiculoRepository>();

            mockRepository.Setup(x => x.ExisteVeiculoComEssaPlaca("ADS1234")).Returns(() => { return true; });
            
            VeiculoAppService sut = new VeiculoAppService(mockRepository.Object);

            var grupoVeiculo = new GrupoVeiculo("dgfsdfgs",2,2,2,2,2,2);

            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            
            var novoVeiculo = new Veiculo(placa, "asdf","asdf",2,2,2,"asfd","afd",4,2020,"afas","afddsf", grupoVeiculo,imagem);

            //action
            var resultado = sut.InserirNovo(novoVeiculo);

            //assert
            resultado.Should().Be("Placa já cadastrada, tente novamente.");
        }
    }
}
