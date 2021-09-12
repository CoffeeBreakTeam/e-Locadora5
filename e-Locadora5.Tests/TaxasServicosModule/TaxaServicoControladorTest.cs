using e_Locadora5.Controladores;
using e_Locadora5.Controladores.TaxasServicoModule;
using e_Locadora5.Dominio.TaxasServicosModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace e_Locadora5.Tests.TaxasServicosModule
{
    [TestClass]
    [TestCategory("Controladores")]
    public class TaxaServicoControladorTest
    {
        ControladorTaxasServicos controlador = null;

        public TaxaServicoControladorTest()
        {
            controlador = new ControladorTaxasServicos();
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
            controlador.InserirNovo(taxasServicos);

            //assert
            var grupoVeiculoEncontrado = controlador.SelecionarPorId(taxasServicos.Id);
            grupoVeiculoEncontrado.Should().Be(taxasServicos);
        }

        [TestMethod]
        public void Deve_Inserir_Novo_TaxasEServicos_TaxaVariavel()
        {
            //arrange
            var taxasServicos = new TaxasServicos("Taxa de Lavação", 0, 300);

            //action
            controlador.InserirNovo(taxasServicos);

            //assert
            var grupoVeiculoEncontrado = controlador.SelecionarPorId(taxasServicos.Id);
            grupoVeiculoEncontrado.Should().Be(taxasServicos);
        }

        [TestMethod]
        public void Deve_Atualizar_Taxas_E_Servicos()
        {
            //arrange
            var taxasServicos = new TaxasServicos("Taxa de Lavação", 0, 300);
            controlador.InserirNovo(taxasServicos);
            var taxaeAtualizado = new TaxasServicos("Taxa de manutenção", 50, 0);

            //action
            controlador.Editar(taxasServicos.Id, taxaeAtualizado);

            //assert
            TaxasServicos tasxaseServicosEditado = controlador.SelecionarPorId(taxasServicos.Id);
            tasxaseServicosEditado.Should().Be(taxaeAtualizado);
        }

        [TestMethod]
        public void Deve_SelecionarPorId_TaxasServicos_TaxaFixa()
        {
            //arrange
            var taxasServicos = new TaxasServicos("Taxa de Lavação", 250, 0); 
            controlador.InserirNovo(taxasServicos);
            //action
            TaxasServicos taxaEncontrado = controlador.SelecionarPorId(taxasServicos.Id);

            //assert
            taxaEncontrado.Should().NotBeNull();
        }

        [TestMethod]
        public void Deve_SelecionarPorId_TaxasServicos_TaxaVariavel()
        {
            //arrange
            var taxasServicos = new TaxasServicos("Taxa de Lavação", 0, 250);
            controlador.InserirNovo(taxasServicos);
            //action
            TaxasServicos taxaEncontrado = controlador.SelecionarPorId(taxasServicos.Id);

            //assert
            taxaEncontrado.Should().NotBeNull();
        }

        [TestMethod]
        public void Deve_Excluir_TaxasServicos()
        {
            //arrange
            var taxasServicos = new TaxasServicos("Taxa de Lavação", 0, 250);
            controlador.InserirNovo(taxasServicos);
            //action
            controlador.Excluir(taxasServicos.Id);

            //assert
            var taxaEncrontrado = controlador.SelecionarPorId(taxasServicos.Id);
            taxaEncrontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_TodosClientes()
        {
            //arrange
            var taxasServicos1 = new TaxasServicos("Taxa de Lavação", 0, 250);
            controlador.InserirNovo(taxasServicos1);

            var taxasServicos2 = new TaxasServicos("Taxa de Manutenção", 250, 0);
            controlador.InserirNovo(taxasServicos2);


            var taxasServicos3 = new TaxasServicos("Taxa de GPS", 0, 250);
            controlador.InserirNovo(taxasServicos3);


            //action
            var taxasServicos = controlador.SelecionarTodos();

            //assert
            taxasServicos.Should().HaveCount(3);
            taxasServicos[0].Descricao.Should().Be("Taxa de Lavação");
            taxasServicos[1].Descricao.Should().Be("Taxa de Manutenção");
            taxasServicos[2].Descricao.Should().Be("Taxa de GPS");
        }

        [TestMethod]

        public void Nao_Deve_Cadastrar_Descricap_Iguais()
        {
            var taxasServico1 = new TaxasServicos("Taxa de Lavação", 0, 50);
            controlador.InserirNovo(taxasServico1);

            var taxasServico2 = new TaxasServicos("Taxa de Lavação", 0, 50);
            controlador.InserirNovo(taxasServico2);
 
            string resultado = controlador.InserirNovo(taxasServico2);

            resultado.Should().Be("Taxa ou serviço já cadastrada, tente novamente.");
            List<TaxasServicos> taxasServicos = controlador.SelecionarTodos();

            taxasServicos.Should().HaveCount(1);

        }

        [TestMethod]
        public void Nao_Deve_Editar_Descricao_Iguais()
        {
            var taxasServico1 = new TaxasServicos("Taxa de Lavação", 0, 50);
            controlador.InserirNovo(taxasServico1);


            var taxasServicoAtualiza = new TaxasServicos("Taxa de Lavação", 0, 50);
           
            string resultado = controlador.Editar(taxasServicoAtualiza.Id, taxasServicoAtualiza);

            resultado.Should().Be("Taxa ou serviço já cadastrada, tente novamente.");
            List<TaxasServicos> taxasServicos = controlador.SelecionarTodos();

            taxasServicos.Should().HaveCount(1);

        }

    }
}
