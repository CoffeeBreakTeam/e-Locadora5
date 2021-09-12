using e_Locadora5.Controladores;
using e_Locadora5.Controladores.VeiculoModule;
using e_Locadora5.Dominio;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Tests.GrupoVeiculos
{
    [TestClass]
    public class GrupoVeiculosControladorTest
    {
        ControladorGrupoVeiculo controlador = null;

        public GrupoVeiculosControladorTest()
        {
            LimparTabelas();
            controlador = new ControladorGrupoVeiculo();
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
        public void DeveInserir_GrupoVeiculo()
        {
            //arrange
            var novoGrupoVeiculo = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);

            //action
            controlador.InserirNovo(novoGrupoVeiculo);

            //assert
            var grupoVeiculoEncontrado = controlador.SelecionarPorId(novoGrupoVeiculo.Id);
            grupoVeiculoEncontrado.Should().Be(novoGrupoVeiculo);
        }

        [TestMethod]
        public void DeveAtualizar_GrupoVeiculo()
        {
            //arrange
            var grupoVeiculo = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);
            controlador.InserirNovo(grupoVeiculo);

            var novoGrupoVeiculo = new GrupoVeiculo("Luxo", 2, 4, 6, 8, 10, 12);

            //action
            controlador.Editar(grupoVeiculo.Id, novoGrupoVeiculo);

            //assert
            GrupoVeiculo grupoVeiculoAtualizado = controlador.SelecionarPorId(grupoVeiculo.Id);
            grupoVeiculoAtualizado.Should().Be(novoGrupoVeiculo);
        }

        [TestMethod]
        public void DeveExcluir_GrupoVeiculo()
        {
            //arrange            
            var grupoVeiculo = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);
            controlador.InserirNovo(grupoVeiculo);

            //action            
            controlador.Excluir(grupoVeiculo.Id);

            //assert
            GrupoVeiculo grupoVeiculoEncontrado = controlador.SelecionarPorId(grupoVeiculo.Id);
            grupoVeiculoEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_GrupoVeiculo_PorId()
        {
            //arrange
            var grupoVeiculo = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);
            controlador.InserirNovo(grupoVeiculo);

            //action
            GrupoVeiculo grupoVeiculoEncontrado = controlador.SelecionarPorId(grupoVeiculo.Id);

            //assert
            grupoVeiculoEncontrado.Should().NotBeNull();
        }

        [TestMethod]
        public void DeveSelecionar_TodosGrupoVeiculos()
        {
            //arrange
            var c1 = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);
            controlador.InserirNovo(c1);

            var c2 = new GrupoVeiculo("Luxo", 10, 20, 25, 24, 35, 50);
            controlador.InserirNovo(c2);

            var c3 = new GrupoVeiculo("Esportivo", 20, 20, 30, 40, 50, 60);
            controlador.InserirNovo(c3);

            //action
            var grupoVeiculos = controlador.SelecionarTodos();

            //assert
            grupoVeiculos.Should().HaveCount(3);
            grupoVeiculos[0].categoria.Should().Be("Economico");
            grupoVeiculos[1].categoria.Should().Be("Luxo");
            grupoVeiculos[2].categoria.Should().Be("Esportivo");
        }
    }
    
}
