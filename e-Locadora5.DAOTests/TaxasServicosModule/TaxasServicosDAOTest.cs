using e_Locadora5.Aplicacao.TaxasServicosModule;
using e_Locadora5.Dominio.TaxasServicosModule;
using e_Locadora5.Infra.SQL;
using e_Locadora5.Infra.SQL.TaxasServicosModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace e_Locadora5.DAOTests.TaxasServicosModule
{
    [TestClass]
    public class TaxaServicoControladorTest
    {
        ITaxasServicosRepository TaxasServicosRepository = null;

        public TaxaServicoControladorTest()
        {
            TaxasServicosRepository = new TaxasServicosDAO();
            LimparTelas();
        }

        private void LimparTelas()
        {
            Db.Update("DELETE FROM TBLOCACAO_TBTAXASSERVICOS");
            Db.Update("DELETE FROM TBLOCACAO");
            Db.Update("DELETE FROM TBTAXASSERVICOS");
        }

        [TestMethod]
        public void Deve_Inserir_Novo_Taxas_E_Servicos()
        {
            //arrange
            var taxasServicos = new TaxasServicos("Taxa de Lavação", 250, 0);

            //action
            TaxasServicosRepository.InserirNovo(taxasServicos);

            //assert
            var grupoVeiculoEncontrado = TaxasServicosRepository.SelecionarPorId(taxasServicos.Id);
            grupoVeiculoEncontrado.Should().Be(taxasServicos);
        }

        [TestMethod]
        public void Deve_Inserir_Novo_TaxasEServicos_TaxaVariavel()
        {
            //arrange
            var taxasServicos = new TaxasServicos("Taxa de Lavação", 0, 300);

            //action
            TaxasServicosRepository.InserirNovo(taxasServicos);

            //assert
            var grupoVeiculoEncontrado = TaxasServicosRepository.SelecionarPorId(taxasServicos.Id);
            grupoVeiculoEncontrado.Should().Be(taxasServicos);
        }

        [TestMethod]
        public void Deve_Atualizar_Taxas_E_Servicos()
        {
            //arrange
            var taxasServicos = new TaxasServicos("Taxa de Lavação", 0, 300);
            TaxasServicosRepository.InserirNovo(taxasServicos);
            var taxaeAtualizado = new TaxasServicos("Taxa de manutenção", 50, 0);

            //action
            TaxasServicosRepository.Editar(taxasServicos.Id, taxaeAtualizado);

            //assert
            TaxasServicos tasxaseServicosEditado = TaxasServicosRepository.SelecionarPorId(taxasServicos.Id);
            tasxaseServicosEditado.Should().Be(taxaeAtualizado);
        }

        [TestMethod]
        public void Deve_SelecionarPorId_TaxasServicos_TaxaFixa()
        {
            //arrange
            var taxasServicos = new TaxasServicos("Taxa de Lavação", 250, 0);
            TaxasServicosRepository.InserirNovo(taxasServicos);
            //action
            TaxasServicos taxaEncontrado = TaxasServicosRepository.SelecionarPorId(taxasServicos.Id);

            //assert
            taxaEncontrado.Should().NotBeNull();
        }

        [TestMethod]
        public void Deve_SelecionarPorId_TaxasServicos_TaxaVariavel()
        {
            //arrange
            var taxasServicos = new TaxasServicos("Taxa de Lavação", 0, 250);
            TaxasServicosRepository.InserirNovo(taxasServicos);
            //action
            TaxasServicos taxaEncontrado = TaxasServicosRepository.SelecionarPorId(taxasServicos.Id);

            //assert
            taxaEncontrado.Should().NotBeNull();
        }

        [TestMethod]
        public void Deve_Excluir_TaxasServicos()
        {
            //arrange
            var taxasServicos = new TaxasServicos("Taxa de Lavação", 0, 250);
            TaxasServicosRepository.InserirNovo(taxasServicos);
            //action
            TaxasServicosRepository.Excluir(taxasServicos.Id);

            //assert
            var taxaEncrontrado = TaxasServicosRepository.SelecionarPorId(taxasServicos.Id);
            taxaEncrontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_TodosClientes()
        {
            //arrange
            var taxasServicos1 = new TaxasServicos("Taxa de Lavação", 0, 250);
            TaxasServicosRepository.InserirNovo(taxasServicos1);

            var taxasServicos2 = new TaxasServicos("Taxa de Manutenção", 250, 0);
            TaxasServicosRepository.InserirNovo(taxasServicos2);


            var taxasServicos3 = new TaxasServicos("Taxa de GPS", 0, 250);
            TaxasServicosRepository.InserirNovo(taxasServicos3);


            //action
            var taxasServicos = TaxasServicosRepository.SelecionarTodos();

            //assert
            taxasServicos.Should().HaveCount(3);
            taxasServicos[0].Descricao.Should().Be("Taxa de Lavação");
            taxasServicos[1].Descricao.Should().Be("Taxa de Manutenção");
            taxasServicos[2].Descricao.Should().Be("Taxa de GPS");
        }
    }
}
