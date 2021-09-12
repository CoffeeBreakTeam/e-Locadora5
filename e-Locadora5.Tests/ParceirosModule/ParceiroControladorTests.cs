using e_Locadora5.Controladores;
using e_Locadora5.Controladores.ParceiroModule;
using e_Locadora5.Dominio.ParceirosModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace e_Locadora5.Tests.ParceirosModule
{
    [TestClass]
    [TestCategory("Controladores")]
    public class ParceiroControladorTests
    {
        ControladorParceiro controlador = null;

        public ParceiroControladorTests()
        {
            controlador = new ControladorParceiro();
            LimparTebelas();
        }

        private void LimparTebelas()
        {
            Db.Update("DELETE FROM TBCUPONS");
            Db.Update("DELETE FROM TBPARCEIROS");
        }

        [TestMethod]
        public void DeveInserirUmParceiro()
        {
            //arrange
            var parceiros = new Parceiro("Desconto");

            //action
            controlador.InserirNovo(parceiros);

            //assert
            var ParceiroEncontrado = controlador.SelecionarPorId(parceiros.Id);
            ParceiroEncontrado.Should().Be(parceiros);
        }
        [TestMethod]
        public void DeveEditarUmParceiro()
        {
            //arrange
            var parceiros = new Parceiro("Desconto");
            controlador.InserirNovo(parceiros);
            var parceiroEdita = new Parceiro("Radio Band FM Lages");

            //action
            controlador.Editar(parceiros.Id, parceiroEdita);

            //assert
            var ParceiroEncontrado = controlador.SelecionarPorId(parceiros.Id);
            ParceiroEncontrado.Should().Be(parceiroEdita);
        }
        [TestMethod]
        public void DeveExcluirUmParceiro()
        {
            //arrange
            var parceiros = new Parceiro("Desconto");
            controlador.InserirNovo(parceiros);


            //action
            controlador.Excluir(parceiros.Id);

            //assert
            var ParceiroEncontrado = controlador.SelecionarPorId(parceiros.Id);
            ParceiroEncontrado.Should().BeNull();
        }
        [TestMethod]
        public void DeveSelecionarTodosOsParceiro()
        {
            //arrange
            var parceiros = new Parceiro("Desconto do Deko");
            controlador.InserirNovo(parceiros);
            var parceiros1 = new Parceiro("Band FM");
            controlador.InserirNovo(parceiros1);
            var parceiros2 = new Parceiro("Clube Fm");
            controlador.InserirNovo(parceiros2);

            //action

            var selecionarParceiros = controlador.SelecionarTodos();

            //assert
            selecionarParceiros.Should().HaveCount(3);
            selecionarParceiros[0].nome.Should().Be("Desconto do Deko");
            selecionarParceiros[1].nome.Should().Be("Band FM");
            selecionarParceiros[2].nome.Should().Be("Clube Fm");
        }
    }
}
