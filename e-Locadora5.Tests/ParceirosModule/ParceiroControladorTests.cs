using e_Locadora5.Aplicacao.ParceiroModule;
using e_Locadora5.DataBuilderTest.ParceiroModule;
using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Infra.SQL;
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
            var parceiros = new ParceiroDataBuilder().ComNome("Desconto").Build();

            //action
            parceiroAppService.InserirNovo(parceiros);

            //assert
            var ParceiroEncontrado = parceiroAppService.SelecionarPorId(parceiros.Id);
            ParceiroEncontrado.Should().Be(parceiros);
        }
        [TestMethod]
        public void DeveEditarUmParceiro()
        {
            //arrange
            var parceiros = new Parceiro("Desconto");
            parceiroAppService.InserirNovo(parceiros);
            var parceiroEdita = new Parceiro("Radio Band FM Lages");

            //action
            parceiroAppService.Editar(parceiros.Id, parceiroEdita);

            //assert
            var ParceiroEncontrado = parceiroAppService.SelecionarPorId(parceiros.Id);
            ParceiroEncontrado.Should().Be(parceiroEdita);
        }
        [TestMethod]
        public void DeveExcluirUmParceiro()
        {
            //arrange
            var parceiros = new Parceiro("Desconto");
            parceiroAppService.InserirNovo(parceiros);


            //action
            parceiroAppService.Excluir(parceiros.Id);

            //assert
            var ParceiroEncontrado = parceiroAppService.SelecionarPorId(parceiros.Id);
            ParceiroEncontrado.Should().BeNull();
        }
        [TestMethod]
        public void DeveSelecionarTodosOsParceiro()
        {
            //arrange
            var parceiros = new Parceiro("Desconto do Deko");
            parceiroAppService.InserirNovo(parceiros);
            var parceiros1 = new Parceiro("Band FM");
            parceiroAppService.InserirNovo(parceiros1);
            var parceiros2 = new Parceiro("Clube Fm");
            parceiroAppService.InserirNovo(parceiros2);

            //action

            var selecionarParceiros = parceiroAppService.SelecionarTodos();

            //assert
            selecionarParceiros.Should().HaveCount(3);
            selecionarParceiros[0].Nome.Should().Be("Desconto do Deko");
            selecionarParceiros[1].Nome.Should().Be("Band FM");
            selecionarParceiros[2].Nome.Should().Be("Clube Fm");
        }
    }
}
