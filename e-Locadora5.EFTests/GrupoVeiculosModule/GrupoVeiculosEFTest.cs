using e_Locadora5.Dominio;
using e_Locadora5.Dominio.GrupoVeiculoModule;
using e_Locadora5.Infra.ORM.GrupoVeiculoModule;
using e_Locadora5.Infra.ORM.ParceiroModule;
using e_Locadora5.Infra.SQL;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.EFTests.GrupoVeiculosModule
{
    [TestClass]
    public class GrupoVeiculosEFTest
    {
        IGrupoVeiculoRepository grupoVeiculoRepository;
        public GrupoVeiculosEFTest()
        {
            grupoVeiculoRepository = new GrupoVeiculoOrmDAO(new LocadoraDbContext());
        }

        [TestCleanup]
        public void LimparTabelas()
        {
            Db.Update("DELETE FROM TBGrupoVeiculo");
        }

        [TestMethod]
        public void DeveInserir()
        {
            //Arrange
            var grupoVeiculo = new GrupoVeiculo("Renault", 55, 20, 45, 26, 87, 10);

            //Action
            grupoVeiculoRepository.InserirNovo(grupoVeiculo);

            //Assert
            var grupoEncontrado = grupoVeiculoRepository.SelecionarPorId(grupoVeiculo.Id);
            Assert.AreEqual(grupoVeiculo, grupoEncontrado);
        }

        [TestMethod]
        public void DeveExcluir()
        {
            //Arrange
            var grupoVeiculo = new GrupoVeiculo("Renault", 55, 55, 55, 55, 55, 55);

            //Action
            grupoVeiculoRepository.InserirNovo(grupoVeiculo);

            grupoVeiculoRepository.Excluir(grupoVeiculo.Id);

            //Assert
            var grupoEncontrado = grupoVeiculoRepository.SelecionarPorId(grupoVeiculo.Id);
            grupoEncontrado.Should().Be(null);
        }

        [TestMethod]
        public void DeveEditar()
        {
            //Arrange
            var grupoVeiculo = new GrupoVeiculo("Renault", 55, 55, 55, 55, 55, 55);
            grupoVeiculoRepository.InserirNovo(grupoVeiculo);

            var grupoVeiculoEditado = new GrupoVeiculo("Ferrari", 55, 55, 55, 55, 55, 55);
            grupoVeiculoRepository.Editar(grupoVeiculo.Id, grupoVeiculoEditado);

            //Assert
            var grupoEncontrado = grupoVeiculoRepository.SelecionarPorId(grupoVeiculo.Id);
            grupoVeiculoEditado.categoria.Should().Be(grupoEncontrado.categoria);
        }

        [TestMethod]
        public void DeveSelecionarPeloID()
        {
            //Arrange
            var grupoVeiculo = new GrupoVeiculo("Renault", 55, 55, 55, 55, 55, 55);

            //Action
            grupoVeiculoRepository.InserirNovo(grupoVeiculo);

            //Assert
            var grupoEncontrado = grupoVeiculoRepository.SelecionarPorId(grupoVeiculo.Id);
            grupoEncontrado.Should().Be(grupoEncontrado);
        }

        [TestMethod]
        public void DeveSelecionarTodos()
        {
            //Arrange
            var grupoVeiculo = new GrupoVeiculo("Renault", 55, 55, 55, 55, 55, 55);

            //Action
            grupoVeiculoRepository.InserirNovo(grupoVeiculo);

            //Assert
            var grupoEncontrado = grupoVeiculoRepository.SelecionarTodos();
            grupoEncontrado.Count.Should().Be(1);
        }
    }
}
