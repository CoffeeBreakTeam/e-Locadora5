
using e_Locadora5.Controladores;
using e_Locadora5.Controladores.ClientesModule;
using e_Locadora5.Controladores.CondutorModule;
using e_Locadora5.Controladores.CupomModule;
using e_Locadora5.Controladores.FuncionarioModule;
using e_Locadora5.Controladores.LocacaoModule;
using e_Locadora5.Controladores.ParceiroModule;
using e_Locadora5.Controladores.TaxasServicoModule;
using e_Locadora5.Controladores.VeiculoModule;
using e_Locadora5.Dominio;
using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.CondutoresModule;
using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.FuncionarioModule;
using e_Locadora5.Dominio.LocacaoModule;
using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Dominio.TaxasServicosModule;
using e_Locadora5.Dominio.VeiculosModule;
using e_Locadora5.WindowsApp.Features.LocacaoModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Tests.LocacaoModule
{
    [TestClass]
    public class LocacaoControladorTests
    {
        ControladorFuncionario controladorFuncionario = null;
        ControladorGrupoVeiculo controladorGrupoVeiculo = null;
        ControladorVeiculos controladorVeiculo = null;
        ControladorClientes controladorCliente = null;
        ControladorCondutor controladorCondutor = null;
        ControladorTaxasServicos controladorTaxasServicos = null;
        ControladorParceiro controladorParceiro = null;
        ControladorCupons controladorCupom = null;
        ControladorLocacao controladorLocacao = null;
        DateTime dataHoje;
        DateTime dataAmanha;
        Funcionario funcionario;
        GrupoVeiculo grupoVeiculo;
        byte[] imagem;
        Veiculo veiculo;
        Clientes cliente;
        Condutor condutor;
        TaxasServicos taxaServico;
        Parceiro parceiro;
        Cupons cupom;

        public LocacaoControladorTests()
        {
            LimparTabelas();
            controladorFuncionario = new ControladorFuncionario();
            controladorGrupoVeiculo = new ControladorGrupoVeiculo();
            controladorVeiculo = new ControladorVeiculos();
            controladorCliente = new ControladorClientes();
            controladorCondutor = new ControladorCondutor();
            controladorTaxasServicos = new ControladorTaxasServicos();
            controladorParceiro = new ControladorParceiro();
            controladorCupom = new ControladorCupons();
            controladorLocacao = new ControladorLocacao();

            dataHoje = DateTime.Now.Date;
            dataAmanha = DateTime.Now.Date.AddDays(1);
            funcionario = new Funcionario("nome", "460162200", "usuario", "senha", DateTime.Now.Date, 600.0);
            grupoVeiculo = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);
            imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            veiculo = new Veiculo("placa", "modelo", "fabricante", 400.0, 50, 4, "123456", "azul", 4, 1996, "Grande", "Gasolina", grupoVeiculo, imagem);
            cliente = new Clientes("Joao", "rua souza", "9524282242", "853242", "20220220222", "1239232", "Joao.pereira@gmail.com");
            condutor = new Condutor("Joao", "Rua dos Joao", "9522185224", "5222522", "20202020222", "522542", new DateTime(2022, 05, 26), cliente);
            taxaServico = new TaxasServicos("descricao", 200, 0);
            parceiro = new Parceiro("Deko");
            cupom = new Cupons("Cupom do Deko", 50, 0, dataAmanha, parceiro, 1);

            controladorFuncionario.InserirNovo(funcionario);
            controladorGrupoVeiculo.InserirNovo(grupoVeiculo);
            controladorVeiculo.InserirNovo(veiculo);
            controladorCliente.InserirNovo(cliente);
            controladorCondutor.InserirNovo(condutor);
            controladorTaxasServicos.InserirNovo(taxaServico);
            controladorParceiro.InserirNovo(parceiro);
            controladorCupom.InserirNovo(cupom);
        }



        [TestCleanup()]
        public void LimparTabelas()
        {
            Db.Update("DELETE FROM TBLOCACAO_TBTAXASSERVICOS");
            Db.Update("DELETE FROM TBLOCACAO");
            Db.Update("DELETE FROM TBCUPONS");
            Db.Update("DELETE FROM TBPARCEIROS");
            Db.Update("DELETE FROM TBTAXASSERVICOS");
            Db.Update("DELETE FROM TBCONDUTOR");
            Db.Update("DELETE FROM TBCLIENTES");
            Db.Update("DELETE FROM TBFUNCIONARIO");
            Db.Update("DELETE FROM TBVEICULOS");
            Db.Update("DELETE FROM CATEGORIAS");

        }

        

        [TestMethod]
        public void DeveInserir_Locacao()
        {
            //arrange
            Locacao locacao = new LocacaoDataBuilder()
                .ComFuncionario(funcionario)
                .ComGrupoVeiculo(grupoVeiculo)
                .ComVeiculo(veiculo)
                .ComCliente(cliente)
                .ComCondutor(condutor)
                .ComCaucao(100)
                .ComDataLocacao(dataHoje)
                .ComDataDevolucao(dataAmanha)
                .ComEmAberto(false)
                .ComQuilometragemDevolucao(veiculo.Quilometragem + 200)
                .ComSeguroCliente(250)
                .ComSeguroTerceiro(500)
                .ComPlano("Diario")
                .Build();

            //action
            controladorLocacao.InserirNovo(locacao);

            //assert
            var locacaoEncontrado = controladorLocacao.SelecionarPorId(locacao.Id);
            locacaoEncontrado.Should().Be(locacao);
        }

        [TestMethod]
        public void DeveEditar_Locacao()
        {
            //arrange
            Locacao locacao = new LocacaoDataBuilder()
                .ComFuncionario(funcionario)
                .ComGrupoVeiculo(grupoVeiculo)
                .ComVeiculo(veiculo)
                .ComCliente(cliente)
                .ComCondutor(condutor)
                .ComCaucao(100)
                .ComDataLocacao(dataHoje)
                .ComDataDevolucao(dataAmanha)
                .ComEmAberto(false)
                .ComQuilometragemDevolucao(veiculo.Quilometragem + 200)
                .ComSeguroCliente(250)
                .ComSeguroTerceiro(500)
                .ComPlano("Diario")
                .Build();

            Locacao novoLocacao = new LocacaoDataBuilder()
                .ComFuncionario(funcionario)
                .ComGrupoVeiculo(grupoVeiculo)
                .ComVeiculo(veiculo)
                .ComCliente(cliente)
                .ComCondutor(condutor)
                .ComCaucao(100)
                .ComDataLocacao(dataHoje)
                .ComDataDevolucao(dataAmanha)
                .ComEmAberto(false)
                .ComQuilometragemDevolucao(veiculo.Quilometragem + 300)
                .ComSeguroCliente(350)
                .ComSeguroTerceiro(660)
                .ComPlano("Diario")
                .Build();
            //action
            controladorLocacao.InserirNovo(locacao);

            controladorLocacao.Editar(locacao.Id, novoLocacao);

            //assert
            var locacaoEncontrado = controladorLocacao.SelecionarPorId(locacao.Id);
            locacaoEncontrado.Should().Be(novoLocacao);
        }

        [TestMethod]
        public void DeveExcluir_Locacao()
        {
            //arrange
            Locacao locacao = new LocacaoDataBuilder()
                .ComFuncionario(funcionario)
                .ComGrupoVeiculo(grupoVeiculo)
                .ComVeiculo(veiculo)
                .ComCliente(cliente)
                .ComCondutor(condutor)
                .ComCaucao(100)
                .ComDataLocacao(dataHoje)
                .ComDataDevolucao(dataAmanha)
                .ComEmAberto(false)
                .ComQuilometragemDevolucao(veiculo.Quilometragem + 200)
                .ComSeguroCliente(250)
                .ComSeguroTerceiro(500)
                .ComPlano("Diario")
                .Build();


            //action
            controladorLocacao.InserirNovo(locacao);

            controladorLocacao.Excluir(locacao.Id);

            //assert
            var locacaoEncontrado = controladorLocacao.SelecionarPorId(locacao.Id);
            locacaoEncontrado.Should().Be(null);
        }

        [TestMethod]
        public void DeveImpedir_Inserir_Locacao_Veiculo_Ja_Alugado()
        {
            //arrange
            Locacao locacao = new LocacaoDataBuilder()
                .ComFuncionario(funcionario)
                .ComGrupoVeiculo(grupoVeiculo)
                .ComVeiculo(veiculo)
                .ComCliente(cliente)
                .ComCondutor(condutor)
                .ComCaucao(100)
                .ComDataLocacao(dataHoje)
                .ComDataDevolucao(dataAmanha)
                .ComEmAberto(true)
                .ComQuilometragemDevolucao(veiculo.Quilometragem + 200)
                .ComSeguroCliente(250)
                .ComSeguroTerceiro(500)
                .ComPlano("Diario")
                .Build();

            //action
            controladorLocacao.InserirNovo(locacao);
            controladorLocacao.InserirNovo(locacao);

            //assert

            var validacaoCarroJaAlugado = "Veiculo já alugado, tente novamente.";
            validacaoCarroJaAlugado.Should().Be(controladorLocacao.ValidarLocacao(locacao));
        }

        [TestMethod]
        public void Deve_Verificar_Chegadas_Pendentes()
        {
            //arrange
            DateTime dataLocacao = new DateTime(2021,08,10);
            DateTime dataDevolucao = new DateTime(2021, 08, 21);
            Locacao locacao = new LocacaoDataBuilder()
                .ComFuncionario(funcionario)
                .ComGrupoVeiculo(grupoVeiculo)
                .ComVeiculo(veiculo)
                .ComCliente(cliente)
                .ComCondutor(condutor)
                .ComCaucao(100)
                .ComDataLocacao(dataLocacao)
                .ComDataDevolucao(dataDevolucao)
                .ComEmAberto(true)
                .ComQuilometragemDevolucao(veiculo.Quilometragem + 200)
                .ComSeguroCliente(250)
                .ComSeguroTerceiro(500)
                .ComPlano("Diario")
                .Build();

            //action
            controladorLocacao.InserirNovo(locacao);


            //assert
            bool estaAberto = true;
            DateTime date = new DateTime(2021, 08, 22);
            var locacaoEncontrado = controladorLocacao.SelecionarLocacoesPendentes(estaAberto,date);
            locacaoEncontrado.Should().HaveCount(1);
        }

        [TestMethod]
        public void DeveInserir_LocacaoTaxaServico()
        {
            //arrange
            Locacao locacao1 = new LocacaoDataBuilder()
                .ComFuncionario(funcionario)
                .ComGrupoVeiculo(grupoVeiculo)
                .ComVeiculo(veiculo)
                .ComCliente(cliente)
                .ComCondutor(condutor)
                .ComCaucao(100)
                .ComDataLocacao(dataHoje)
                .ComDataDevolucao(dataAmanha)
                .ComEmAberto(false)
                .ComQuilometragemDevolucao(veiculo.Quilometragem + 200)
                .ComSeguroCliente(250)
                .ComSeguroTerceiro(500)
                .ComPlano("Diario")
                .Build();

            Locacao locacao2 = new LocacaoDataBuilder()
                .ComFuncionario(funcionario)
                .ComGrupoVeiculo(grupoVeiculo)
                .ComVeiculo(veiculo)
                .ComCliente(cliente)
                .ComCondutor(condutor)
                .ComTaxaServico(taxaServico)
                .ComCaucao(100)
                .ComDataLocacao(dataHoje)
                .ComDataDevolucao(dataAmanha)
                .ComEmAberto(false)
                .ComQuilometragemDevolucao(veiculo.Quilometragem + 200)
                .ComSeguroCliente(250)
                .ComSeguroTerceiro(500)
                .ComPlano("Diario")
                .Build();


            //action
            controladorLocacao.InserirNovo(locacao1);
            controladorLocacao.InserirNovo(locacao2);


            //assert
            var taxaServicoSelecionados1 = controladorLocacao.SelecionarTaxasServicosPorLocacaoId(locacao1.Id);
            foreach(TaxasServicos taxaServicoIndividual in taxaServicoSelecionados1)
                taxaServicoIndividual.Should().Be(taxaServico);
            taxaServicoSelecionados1.Count.Should().Be(0);

            var taxaServicoSelecionados2 = controladorLocacao.SelecionarTaxasServicosPorLocacaoId(locacao2.Id);
            foreach (TaxasServicos taxaServicoIndividual in taxaServicoSelecionados2)
                taxaServicoIndividual.Should().Be(taxaServico);
            taxaServicoSelecionados2.Count.Should().Be(1);
        }

        [TestMethod]
        public void DeveExcluir_LocacaoTaxaServico()
        {
            //arrange
            Locacao locacao = new LocacaoDataBuilder()
                .ComFuncionario(funcionario)
                .ComGrupoVeiculo(grupoVeiculo)
                .ComVeiculo(veiculo)
                .ComCliente(cliente)
                .ComCondutor(condutor)
                .ComCaucao(100)
                .ComDataLocacao(dataHoje)
                .ComDataDevolucao(dataAmanha)
                .ComEmAberto(false)
                .ComQuilometragemDevolucao(veiculo.Quilometragem + 200)
                .ComSeguroCliente(250)
                .ComSeguroTerceiro(500)
                .ComPlano("Diario")
                .Build();


            //action
            controladorLocacao.InserirNovo(locacao);
            controladorLocacao.Excluir(locacao.Id);

            //assert
            var locacaoEncontrado = controladorLocacao.SelecionarPorId(locacao.Id);
            locacaoEncontrado.Should().Be(null);
        }

        [TestMethod]
        public void DeveEditar_LocacaoTaxaServico()
        {
            //arrange
            Locacao locacao = new LocacaoDataBuilder()
                .ComFuncionario(funcionario)
                .ComGrupoVeiculo(grupoVeiculo)
                .ComVeiculo(veiculo)
                .ComCliente(cliente)
                .ComCondutor(condutor)
                .ComCaucao(100)
                .ComDataLocacao(dataHoje)
                .ComDataDevolucao(dataAmanha)
                .ComEmAberto(false)
                .ComQuilometragemDevolucao(veiculo.Quilometragem + 200)
                .ComSeguroCliente(250)
                .ComSeguroTerceiro(500)
                .ComPlano("Diario")
                .Build();

            Locacao novoLocacao = new LocacaoDataBuilder()
                .ComFuncionario(funcionario)
                .ComGrupoVeiculo(grupoVeiculo)
                .ComVeiculo(veiculo)
                .ComCliente(cliente)
                .ComCondutor(condutor)
                .ComCaucao(200)
                .ComDataLocacao(dataHoje)
                .ComDataDevolucao(dataAmanha)
                .ComEmAberto(false)
                .ComQuilometragemDevolucao(veiculo.Quilometragem + 300)
                .ComSeguroCliente(500)
                .ComSeguroTerceiro(750)
                .ComPlano("Km Controlado")
                .Build();

            //action
            controladorLocacao.InserirNovo(locacao);
            controladorLocacao.Editar(locacao.Id, novoLocacao);

            //assert
            var locacaoEncontrado = controladorLocacao.SelecionarPorId(locacao.Id);
            locacaoEncontrado.Should().Be(novoLocacao);
        }

        [TestMethod]
        public void DeveInserir_Locacao_Sem_CupomDesconto()
        {
            //arrange
            Locacao locacao = new LocacaoDataBuilder()
                .ComFuncionario(funcionario)
                .ComGrupoVeiculo(grupoVeiculo)
                .ComVeiculo(veiculo)
                .ComCliente(cliente)
                .ComCondutor(condutor)
                .ComCaucao(100)
                .ComDataLocacao(dataHoje)
                .ComDataDevolucao(dataAmanha)
                .ComEmAberto(false)
                .ComQuilometragemDevolucao(veiculo.Quilometragem + 200)
                .ComSeguroCliente(250)
                .ComSeguroTerceiro(500)
                .ComPlano("Diario")
                .Build();

            //action
            controladorLocacao.InserirNovo(locacao);

            //assert
            var locacaoEncontrado = controladorLocacao.SelecionarPorId(locacao.Id);
            locacaoEncontrado.Should().Be(locacao);
        }

        [TestMethod]
        public void DeveInserir_Locacao_Com_CupomDesconto()
        {
            //arrange
            Locacao locacao = new LocacaoDataBuilder()
                .ComFuncionario(funcionario)
                .ComGrupoVeiculo(grupoVeiculo)
                .ComVeiculo(veiculo)
                .ComCliente(cliente)
                .ComCondutor(condutor)
                .ComCaucao(100)
                .ComDataLocacao(dataHoje)
                .ComDataDevolucao(dataAmanha)
                .ComEmAberto(false)
                .ComQuilometragemDevolucao(veiculo.Quilometragem + 200)
                .ComSeguroCliente(250)
                .ComSeguroTerceiro(500)
                .ComPlano("Diario")
                .ComCupom(cupom)
                .Build();

            //action
            controladorLocacao.InserirNovo(locacao);

            //assert
            var locacaoEncontrado = controladorLocacao.SelecionarPorId(locacao.Id);
            locacaoEncontrado.Should().Be(locacao);
        }
    }
}
