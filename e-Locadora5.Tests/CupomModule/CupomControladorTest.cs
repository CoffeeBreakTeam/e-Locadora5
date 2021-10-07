using e_Locadora5.Aplicacao.CupomModule;
using e_Locadora5.Aplicacao.ParceiroModule;
using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Infra.SQL;
using e_Locadora5.Infra.SQL.CupomModule;
using e_Locadora5.Infra.SQL.ParceiroModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace e_Locadora5.Tests.CupomModule
{
    [TestClass]
    [TestCategory("Controladores")]
    public class CupomControladorTest
    {
        CupomAppService cupomAppService = null;
        ParceiroAppService controladorParceiro = null;

        public CupomControladorTest()
        {
            cupomAppService = new CupomAppService(new CupomDAO());
            controladorParceiro = new ParceiroAppService(new ParceiroDAO());
            LimparTelas();
        }

        private void LimparTelas()
        {
            Db.Update("DELETE FROM TBCUPONS");
            Db.Update("DELETE FROM TBPARCEIROS");
        }

        [TestMethod]
        public void Deve_Inserir_Novo_Cupom()
        {
            var parceiro = new Parceiro("Desconto do Deko");
            var cupom = new Cupom("Deko-1236", 50, 0, new DateTime(2021,08,26), parceiro, 230);

            //action
            controladorParceiro.InserirNovo(parceiro);
            cupomAppService.InserirNovo(cupom);

            //assert
            var cupomEncontrado = cupomAppService.SelecionarPorId(cupom.Id);
            cupomEncontrado.Should().Be(cupom);
        }

        [TestMethod]
        public void Deve_Atualizar_Cupom()
        {
            //arrange
            var parceiro = new Parceiro("Desconto do Deko");
            var cupom = new Cupom("Deko-1236", 50, 0, new DateTime(2021, 08, 26).Date, parceiro, 300);
            var cupomAtualizado = new Cupom("Deko-5946", 10, 0, new DateTime(2021, 08, 26).Date, parceiro, 250);

            //action
            controladorParceiro.InserirNovo(parceiro);
            cupomAppService.InserirNovo(cupom);
            cupomAppService.Editar(cupom.Id, cupomAtualizado);

            //assert
            var CupomEditado = cupomAppService.SelecionarPorId(cupomAtualizado.Id);
            CupomEditado.Should().Be(cupomAtualizado);
        }

        [TestMethod]
        public void Deve_SelecionarPorId_Cupons_ValorPercentual()
        {
            //arrange
            var parceiro = new Parceiro("Desconto do Deko");
            var cupom = new Cupom("Deko-1236", 50, 0, new DateTime(2021, 08, 26), parceiro, 300);

            //action
            controladorParceiro.InserirNovo(parceiro);
            cupomAppService.InserirNovo(cupom);
            var cupomEncontrado = cupomAppService.SelecionarPorId(cupom.Id);

            //assert
            cupomEncontrado.Should().NotBeNull();
        }

        [TestMethod]
        public void Deve_SelecionarPorId_Cupons_ValorFixo()
        {
            //arrange
            var parceiro = new Parceiro("Desconto do Deko");
            var cupom = new Cupom("Deko-1236", 0, 50, new DateTime(2021, 08, 26), parceiro, 300);

            //action
            controladorParceiro.InserirNovo(parceiro);
            cupomAppService.InserirNovo(cupom);
            var cupomEncontrado = cupomAppService.SelecionarPorId(cupom.Id);

            //assert
            cupomEncontrado.Should().NotBeNull();
        }

        [TestMethod]
        public void Deve_Excluir_TaxasServicos()
        {
            //arrange
            var parceiro = new Parceiro("Desconto do Deko");
            var cupom = new Cupom("Deko-1236", 50, 0, new DateTime(2021, 08, 26), parceiro, 300);

            //action
            controladorParceiro.InserirNovo(parceiro);
            cupomAppService.InserirNovo(cupom);
            cupomAppService.Excluir(cupom.Id);

            //assert
            var cupomEncrontrado = cupomAppService.SelecionarPorId(cupom.Id);
            cupomEncrontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_TodosCupons()
        {
            //arrange
            var parceiro = new Parceiro("Desconto do Deko");
            var cupom1 = new Cupom("Deko-1236", 50, 0, new DateTime(2021, 08, 26), parceiro, 301);
            var cupom2 = new Cupom("Deko-1656", 50, 0, new DateTime(2021, 08, 26), parceiro, 302);
            var cupom3 = new Cupom("Deko-2015", 50, 0, new DateTime(2021, 08, 26), parceiro, 303);

            //action
            controladorParceiro.InserirNovo(parceiro);
            cupomAppService.InserirNovo(cupom1);
            cupomAppService.InserirNovo(cupom2);
            cupomAppService.InserirNovo(cupom3);
            var taxasServicos = cupomAppService.SelecionarTodos();

            //assert
            taxasServicos.Should().HaveCount(3);
            taxasServicos[0].Nome.Should().Be("Deko-1236");
            taxasServicos[1].Nome.Should().Be("Deko-1656");
            taxasServicos[2].Nome.Should().Be("Deko-2015");
        }

        [TestMethod]
        public void Nao_Deve_Cadastrar_Cupons_Iguais()
        {
            //arrange
            var parceiro = new Parceiro("Desconto do Deko");
            var cupom1= new Cupom("Deko-1236", 50, 0, new DateTime(2021, 08, 26), parceiro, 300);

            var cupom2 = new Cupom("Deko-1236", 50, 0, new DateTime(2021, 08, 26), parceiro, 300);

            //action
            controladorParceiro.InserirNovo(parceiro);
            cupomAppService.InserirNovo(cupom1);
            string resultado = cupomAppService.InserirNovo(cupom2);

            //assert
            resultado.Should().Be("Cupom já cadastrada, tente novamente.");
            List<Cupom> taxasServicos = cupomAppService.SelecionarTodos();
            taxasServicos.Should().HaveCount(1);
        }

        [TestMethod]
        public void Nao_Deve_Editar_Cupons_Iguais()
        {
            //pensar sobre depois
            var parceiro = new Parceiro("Desconto do Deko");
            var cupom = new Cupom("Deko-1236", 50, 0, new DateTime(2021, 08, 26), parceiro, 300);
            controladorParceiro.InserirNovo(parceiro);
            cupomAppService.InserirNovo(cupom);


            var cupomAtualizar = new Cupom("Deko-1236", 50, 0, new DateTime(2021, 08, 26), parceiro, 300);

            string resultado = cupomAppService.Editar(cupomAtualizar.Id, cupomAtualizar);

            resultado.Should().Be("Cupom já cadastrada, tente novamente.");
            List<Cupom> taxasServicos = cupomAppService.SelecionarTodos();

            taxasServicos.Should().HaveCount(1);

        }

    }
    
}
