using e_Locadora5.Aplicacao.ClienteModule;
using e_Locadora5.Aplicacao.CondutorModule;
using e_Locadora5.Aplicacao.CupomModule;
using e_Locadora5.Aplicacao.FuncionarioModule;
using e_Locadora5.Aplicacao.GrupoVeiculoModule;
using e_Locadora5.Aplicacao.LocacaoModule;
using e_Locadora5.Aplicacao.ParceiroModule;
using e_Locadora5.Aplicacao.TaxasServicosModule;
using e_Locadora5.Aplicacao.VeiculoModule;
using e_Locadora5.DataBuilderTest.LocacaoModule;
using e_Locadora5.Dominio;
using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.CondutoresModule;
using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.FuncionarioModule;
using e_Locadora5.Dominio.LocacaoModule;
using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Dominio.TaxasServicosModule;
using e_Locadora5.Dominio.VeiculosModule;
using e_Locadora5.Infra.SQL;
using e_Locadora5.Infra.SQL.ClienteModule;
using e_Locadora5.Infra.SQL.CondutorModule;
using e_Locadora5.Infra.SQL.CupomModule;
using e_Locadora5.Infra.SQL.FuncionarioModule;
using e_Locadora5.Infra.SQL.GrupoVeiculoModule;
using e_Locadora5.Infra.SQL.LocacaoModule;
using e_Locadora5.Infra.SQL.ParceiroModule;
using e_Locadora5.Infra.SQL.TaxasServicosModule;
using e_Locadora5.Infra.SQL.VeiculoModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.DAOTests.LocacaoModule
{
    [TestClass]
    public class LocacaoDAOTest
    {
        FuncionarioDAO funcionarioDAO = null;
        GrupoVeiculoDAO grupoVeiculoDAO = null;
        VeiculoDAO veiculoDAO = null;
        ClienteDAO clienteDAO = null;
        CondutorDAO condutorDAO = null;
        TaxasServicosDAO taxasServicosDAO = null;
        ParceiroDAO parceiroDAO = null;
        CupomDAO cupomDAO = null;
        ILocacaoRepository locacaoRepository = null;
        DateTime dataHoje;
        DateTime dataAmanha;
        Funcionario funcionario;
        GrupoVeiculo grupoVeiculo;
        byte[] imagem;
        Veiculo veiculo;
        Cliente cliente;
        Condutor condutor;
        TaxasServicos taxaServico;
        Parceiro parceiro;
        Cupom cupom;

        public LocacaoDAOTest()
        {
            LimparTabelas();
            funcionarioDAO = new FuncionarioDAO();
            grupoVeiculoDAO = new GrupoVeiculoDAO();
            veiculoDAO = new VeiculoDAO();
            clienteDAO = new ClienteDAO();
            condutorDAO = new CondutorDAO();
            taxasServicosDAO = new TaxasServicosDAO();
            parceiroDAO = new ParceiroDAO();
            cupomDAO = new CupomDAO();
            locacaoRepository = new LocacaoDAO();

            dataHoje = DateTime.Now.Date;
            dataAmanha = DateTime.Now.Date.AddDays(1);
            funcionario = new Funcionario("nome", "460162200", "usuario", "senha", DateTime.Now.Date, 600.0);
            grupoVeiculo = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);
            imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            veiculo = new Veiculo("placa", "modelo", "fabricante", 400.0, 50, 4, "123456", "azul", 4, 1996, "Grande", "Gasolina", grupoVeiculo, imagem);
            cliente = new Cliente("Joao", "rua souza", "9524282242", "853242", "20220220222", "1239232", "Joao.pereira@gmail.com");
            condutor = new Condutor("Joao", "Rua dos Joao", "9522185224", "5222522", "20202020222", "522542", new DateTime(2022, 05, 26), cliente);
            taxaServico = new TaxasServicos("descricao", 200, 0);
            parceiro = new Parceiro("Deko");
            cupom = new Cupom("Cupom do Deko", 50, 0, dataAmanha, parceiro, 1);

            funcionarioDAO.InserirNovo(funcionario);
            grupoVeiculoDAO.InserirNovo(grupoVeiculo);
            veiculoDAO.InserirNovo(veiculo);
            clienteDAO.InserirNovo(cliente);
            condutorDAO.InserirNovo(condutor);
            taxasServicosDAO.InserirNovo(taxaServico);
            parceiroDAO.InserirNovo(parceiro);
            cupomDAO.InserirNovo(cupom);
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
                .ComCupom(null)
                .ComDataLocacao(dataHoje)
                .ComDataDevolucao(dataAmanha)
                .ComEmAberto(false)
                .ComQuilometragemDevolucao(veiculo.Quilometragem + 200)
                .ComSeguroCliente(250)
                .ComSeguroTerceiro(500)
                .ComPlano("Diario")
                .Build();

            //action
            locacaoRepository.InserirNovo(locacao);

            //assert
            var locacaoEncontrado = locacaoRepository.SelecionarPorId(locacao.Id);
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
            locacaoRepository.InserirNovo(locacao);

            locacaoRepository.Editar(locacao.Id, novoLocacao);

            //assert
            var locacaoEncontrado = locacaoRepository.SelecionarPorId(locacao.Id);
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
            locacaoRepository.InserirNovo(locacao);

            locacaoRepository.Excluir(locacao.Id);

            //assert
            var locacaoEncontrado = locacaoRepository.SelecionarPorId(locacao.Id);
            locacaoEncontrado.Should().Be(null);
        }

        [TestMethod]
        public void Deve_Selecionar_Chegadas_Pendentes()
        {
            //arrange
            DateTime dataLocacao = new DateTime(2021, 08, 10);
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
            locacaoRepository.InserirNovo(locacao);


            //assert
            bool estaAberto = true;
            DateTime date = new DateTime(2021, 08, 22);
            var locacaoEncontrado = locacaoRepository.SelecionarLocacoesPendentes(estaAberto, date);
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

            Locacao locacao2 = new LocacaoDataBuilder()
                .ComFuncionario(funcionario)
                .ComGrupoVeiculo(grupoVeiculo)
                .ComVeiculo(veiculo)
                .ComCliente(cliente)
                .ComCondutor(condutor)
                .ComTaxaServico(taxaServico)
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
            locacaoRepository.InserirNovo(locacao1);
            locacaoRepository.InserirNovo(locacao2);


            //assert
            var taxaServicoSelecionados1 = locacaoRepository.SelecionarTaxasServicosPorLocacaoId(locacao1.Id);
            foreach (TaxasServicos taxaServicoIndividual in taxaServicoSelecionados1)
                taxaServicoIndividual.Should().Be(taxaServico);
            taxaServicoSelecionados1.Count.Should().Be(1);

            var taxaServicoSelecionados2 = locacaoRepository.SelecionarTaxasServicosPorLocacaoId(locacao2.Id);
            foreach (TaxasServicos taxaServicoIndividual in taxaServicoSelecionados2)
                taxaServicoIndividual.Should().Be(taxaServico);
            taxaServicoSelecionados2.Count.Should().Be(2);
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
            locacaoRepository.InserirNovo(locacao);
            locacaoRepository.Excluir(locacao.Id);

            //assert
            var locacaoEncontrado = locacaoRepository.SelecionarPorId(locacao.Id);
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
            locacaoRepository.InserirNovo(locacao);
            locacaoRepository.Editar(locacao.Id, novoLocacao);

            //assert
            var locacaoEncontrado = locacaoRepository.SelecionarPorId(locacao.Id);
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
            locacaoRepository.InserirNovo(locacao);

            //assert
            var locacaoEncontrado = locacaoRepository.SelecionarPorId(locacao.Id);
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
            locacaoRepository.InserirNovo(locacao);

            //assert
            var locacaoEncontrado = locacaoRepository.SelecionarPorId(locacao.Id);
            locacaoEncontrado.Should().Be(locacao);
        }
    }
}
