using e_Locadora5.Controladores;
using e_Locadora5.Controladores.VeiculoModule;
using e_Locadora5.Dominio;
using e_Locadora5.Dominio.VeiculosModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Tests.VeiculoModule
{
    [TestClass]
    public class VeiculoControladorTest
    {
        [TestClass]
        [TestCategory("Controladores")]
        public class ControladorVeiculoTest
        {
            ControladorVeiculos controladorVeiculo = null;
            ControladorGrupoVeiculo controladorGrupoVeiculo = null;

            public ControladorVeiculoTest()
            {
                LimparTabelas();
                controladorVeiculo = new ControladorVeiculos();
                controladorGrupoVeiculo = new ControladorGrupoVeiculo();
            }

            [TestCleanup()]
            public void LimparTabelas()
            {
                
                Db.Update("DELETE FROM TBVEICULOS");
                Db.Update("DELETE FROM CATEGORIAS");
            }

            [TestMethod]
            public void DeveInserir_Veiculo()
            {
                //arrange
                var grupoVeiculo = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);
                controladorGrupoVeiculo.InserirNovo(grupoVeiculo);
                var novoVeiculo = new Veiculo("1234", "Modelo", "Fabricante", 0, 4, 4, "4", "azul", 4, 1994, "grande", "etanol", grupoVeiculo, null);
                //action
                controladorVeiculo.InserirNovo(novoVeiculo);

                //assert
                var veiculoEncontrado = controladorVeiculo.SelecionarPorId(novoVeiculo.Id);
                veiculoEncontrado.Should().Be(novoVeiculo);
            }

            [TestMethod]
            public void DeveAtualizar_Veiculo()
            {
                //arrange
                var grupoVeiculo = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);
                controladorGrupoVeiculo.InserirNovo(grupoVeiculo);
                var veiculo = new Veiculo("1234", "Modelo", "Fabricante", 0, 4, 4, "4", "azul", 4, 1994, "grande", "etanol", grupoVeiculo, null);
                controladorVeiculo.InserirNovo(veiculo);

                var novoVeiculo = new Veiculo("5678", "Modelo2", "Fabricante", 0, 4, 4, "4", "azul", 4, 1994, "grande", "etanol", grupoVeiculo, null);

                //action
                controladorVeiculo.Editar(veiculo.Id, novoVeiculo);

                //assert
                Veiculo veiculoAtualizado = controladorVeiculo.SelecionarPorId(veiculo.Id);
                veiculoAtualizado.Should().Be(novoVeiculo);
            }

            [TestMethod]
            public void DeveExcluir_Veiculo()
            {
                //arrange
                var grupoVeiculo = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);
                controladorGrupoVeiculo.InserirNovo(grupoVeiculo);
                var veiculo = new Veiculo("1234", "Modelo", "Fabricante", 0, 4, 4, "4", "azul", 4, 1994, "grande", "etanol", grupoVeiculo, null);
                controladorVeiculo.InserirNovo(veiculo);

                //action            
                controladorVeiculo.Excluir(veiculo.Id);

                //assert
                Veiculo veiculoEncontrado = controladorVeiculo.SelecionarPorId(veiculo.Id);
                veiculoEncontrado.Should().BeNull();
            }

            [TestMethod]
            public void DeveSelecionar_Veiculo_PorId()
            {
                //arrange
                var grupoVeiculo = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);
                controladorGrupoVeiculo.InserirNovo(grupoVeiculo);
                var veiculo = new Veiculo("1234", "Modelo", "Fabricante", 0, 4, 4, "4", "azul", 4, 1994, "grande", "etanol", grupoVeiculo, null);
                controladorVeiculo.InserirNovo(veiculo);

                //action
                Veiculo veiculoEncontrado = controladorVeiculo.SelecionarPorId(veiculo.Id);

                //assert
                veiculoEncontrado.Should().NotBeNull();
            }

            [TestMethod]
            public void DeveSelecionar_TodosVeiculos()
            {
                //arrange
                var grupoVeiculo = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);
                controladorGrupoVeiculo.InserirNovo(grupoVeiculo);

                var veiculo1 = new Veiculo("1234", "Modelo", "Fabricante", 0, 4, 4, "4", "azul", 4, 1994, "grande", "etanol", grupoVeiculo, null);
                controladorVeiculo.InserirNovo(veiculo1);

                var veiculo2 = new Veiculo("5678", "Modelo", "Fabricante", 0, 4, 4, "4", "azul", 4, 1994, "grande", "etanol", grupoVeiculo, null);
                controladorVeiculo.InserirNovo(veiculo2);

                var veiculo3 = new Veiculo("9345", "Modelo", "Fabricante", 0, 4, 4, "4", "azul", 4, 1994, "grande", "etanol", grupoVeiculo, null);
                controladorVeiculo.InserirNovo(veiculo3);

                //action
                var grupoVeiculos = controladorVeiculo.SelecionarTodos();

                //assert
                grupoVeiculos.Should().HaveCount(3);
                grupoVeiculos[0].Placa.Should().Be("1234");
                grupoVeiculos[1].Placa.Should().Be("5678");
                grupoVeiculos[2].Placa.Should().Be("9345");
            }
        }
    }
}
