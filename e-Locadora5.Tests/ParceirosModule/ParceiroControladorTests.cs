using e_Locadora5.Aplicacao.ParceiroModule;
using e_Locadora5.Controladores;
using e_Locadora5.Controladores.ParceiroModule;
using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Infra.SQL.ParceiroModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace e_Locadora5.Tests.ParceirosModule
{
    [TestClass]
    [TestCategory("Controladores")]
    public class ParceiroControladorTests
    {
        ParceiroAppService parceiroAppService;

        public ParceiroControladorTests()
        {
            parceiroAppService = new ParceiroAppService(new ParceiroDAO());
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
            parceiroAppService.InserirNovoParceiro(parceiros);

            //assert
            var ParceiroEncontrado = parceiroAppService.SelecionarParceiroPorId(parceiros.Id);
            ParceiroEncontrado.Should().Be(parceiros);
        }
        [TestMethod]
        public void DeveEditarUmParceiro()
        {
            //arrange
            var parceiros = new Parceiro("Desconto");
            parceiroAppService.InserirNovoParceiro(parceiros);
            var parceiroEdita = new Parceiro("Radio Band FM Lages");

            //action
            parceiroAppService.EditarParceiro(parceiros.Id, parceiroEdita);

            //assert
            var ParceiroEncontrado = parceiroAppService.SelecionarParceiroPorId(parceiros.Id);
            ParceiroEncontrado.Should().Be(parceiroEdita);
        }
        [TestMethod]
        public void DeveExcluirUmParceiro()
        {
            //arrange
            var parceiros = new Parceiro("Desconto");
            parceiroAppService.InserirNovoParceiro(parceiros);


            //action
            parceiroAppService.ExcluirParceiro(parceiros.Id);

            //assert
            var ParceiroEncontrado = parceiroAppService.SelecionarParceiroPorId(parceiros.Id);
            ParceiroEncontrado.Should().BeNull();
        }
        [TestMethod]
        public void DeveSelecionarTodosOsParceiro()
        {
            //arrange
            var parceiros = new Parceiro("Desconto do Deko");
            parceiroAppService.InserirNovoParceiro(parceiros);
            var parceiros1 = new Parceiro("Band FM");
            parceiroAppService.InserirNovoParceiro(parceiros1);
            var parceiros2 = new Parceiro("Clube Fm");
            parceiroAppService.InserirNovoParceiro(parceiros2);

            //action

            var selecionarParceiros = parceiroAppService.SelecionarTodosParceiro();

            //assert
            selecionarParceiros.Should().HaveCount(3);
            selecionarParceiros[0].nome.Should().Be("Desconto do Deko");
            selecionarParceiros[1].nome.Should().Be("Band FM");
            selecionarParceiros[2].nome.Should().Be("Clube Fm");
        }
    }
}
