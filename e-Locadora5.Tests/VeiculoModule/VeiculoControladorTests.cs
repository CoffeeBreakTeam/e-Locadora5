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

namespace e_Locadora.Tests.Veiculos
{
    [TestClass]
    public class VeiculosControladorTest
    {
        ControladorVeiculos controladorVeiculo = null;
        ControladorGrupoVeiculo controladorGrupoVeiculo = null;

        public VeiculosControladorTest()
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
            Db.Update("DELETE FROM TBLOCACAO_TBTAXASSERVICOS");
            Db.Update("DELETE FROM TBLOCACAO");
        }

        [TestMethod]
        public void DeveInserir_Veiculo()
        {
            //arrange
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var grupoVeiculo = new GrupoVeiculo("SUV", 1000, 2000, 3000, 500, 4000, 500);
            var veiculo = new Veiculo("1234", "Modelo", "Fabricante", 0, 4, 4, "4", "azul", 4, 1994, "grande", "etanol", grupoVeiculo, imagem);

            //action
            controladorGrupoVeiculo.InserirNovo(grupoVeiculo);
            controladorVeiculo.InserirNovo(veiculo);

            //assert
            var veiculoEncontrado = controladorVeiculo.SelecionarPorId(veiculo.Id);
            veiculoEncontrado.Should().Be(veiculo);
        }

        [TestMethod]
        public void DeveAtualizar_Veiculo()
        {
            //arrange
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var grupoVeiculo = new GrupoVeiculo("SUV", 1000, 2000, 3000, 500, 4000, 500);
            var veiculo = new Veiculo("1234", "Modelo", "Fabricante", 0, 4, 4, "4", "azul", 4, 1994, "grande", "etanol", grupoVeiculo, imagem);


            var novoVeiculo = new Veiculo("1234", "Modelo", "Fabricante", 0, 4, 4, "4", "azul", 4, 1996, "grande", "etanol", grupoVeiculo, imagem);

            //action
            controladorGrupoVeiculo.InserirNovo(grupoVeiculo);
            controladorVeiculo.InserirNovo(veiculo);
            controladorVeiculo.Editar(veiculo.Id, novoVeiculo);

            //assert
            Veiculo grupoVeiculoAtualizado = controladorVeiculo.SelecionarPorId(veiculo.Id);
            grupoVeiculoAtualizado.Should().Be(novoVeiculo);
        }

        [TestMethod]
        public void DeveExcluir_Veiculo()
        {
            //arrange
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var grupoVeiculo = new GrupoVeiculo("SUV", 1000, 2000, 3000, 500, 4000, 500);
            var veiculo = new Veiculo("1234", "Modelo", "Fabricante", 0, 4, 4, "4", "azul", 4, 1994, "grande", "etanol", grupoVeiculo, imagem);


            //action
            controladorGrupoVeiculo.InserirNovo(grupoVeiculo);
            controladorVeiculo.InserirNovo(veiculo);
            controladorVeiculo.Excluir(veiculo.Id);

            //assert
            Veiculo grupoVeiculoEncontrado = controladorVeiculo.SelecionarPorId(veiculo.Id);
            grupoVeiculoEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Veiculo_PorId()
        {
            //arrange
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var grupoVeiculo = new GrupoVeiculo("SUV", 1000, 2000, 3000, 500, 4000, 500);
            var veiculo = new Veiculo("1234", "Modelo", "Fabricante", 0, 4, 4, "4", "azul", 4, 1994, "grande", "etanol", grupoVeiculo, imagem);


            //action
            controladorGrupoVeiculo.InserirNovo(grupoVeiculo);
            controladorVeiculo.InserirNovo(veiculo);

            Veiculo grupoVeiculoEncontrado = controladorVeiculo.SelecionarPorId(veiculo.Id);

            //assert
            grupoVeiculoEncontrado.Should().NotBeNull();
        }

        [TestMethod]
        public void DeveSelecionar_TodosVeiculos()
        {
            //arrange
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var grupoVeiculo = new GrupoVeiculo("SUV", 1000, 2000, 3000, 500, 4000, 500);
            controladorGrupoVeiculo.InserirNovo(grupoVeiculo);
            var veiculo1 = new Veiculo("1234", "Modelo", "Fabricante", 0, 4, 4, "4", "azul", 4, 1994, "grande", "etanol", grupoVeiculo, imagem);
            controladorVeiculo.InserirNovo(veiculo1);

            var veiculo2 = new Veiculo("2345", "Modelo", "Fabricante", 0, 4, 4, "4", "azul", 4, 1994, "grande", "etanol", grupoVeiculo, imagem);
            controladorVeiculo.InserirNovo(veiculo2);

            var veiculo3 = new Veiculo("3456", "Modelo", "Fabricante", 0, 4, 4, "4", "azul", 4, 1994, "grande", "etanol", grupoVeiculo, imagem);
            controladorVeiculo.InserirNovo(veiculo3);

            //action
            var veiculos = controladorVeiculo.SelecionarTodos();

            //assert
            veiculos.Should().HaveCount(3);
            veiculos[0].Placa.Should().Be("1234");
            veiculos[1].Placa.Should().Be("2345");
            veiculos[2].Placa.Should().Be("3456");
        }
    }

}