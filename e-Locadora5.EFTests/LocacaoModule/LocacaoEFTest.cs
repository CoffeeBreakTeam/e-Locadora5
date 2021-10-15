using e_Locadora5.DataBuilderTest.ClienteModule;
using e_Locadora5.DataBuilderTest.LocacaoModule;
using e_Locadora5.Dominio;
using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.CondutoresModule;
using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.FuncionarioModule;
using e_Locadora5.Dominio.GrupoVeiculoModule;
using e_Locadora5.Dominio.LocacaoModule;
using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Dominio.TaxasServicosModule;
using e_Locadora5.Dominio.VeiculosModule;
using e_Locadora5.Infra.ORM.ClienteModule;
using e_Locadora5.Infra.ORM.CondutorModule;
using e_Locadora5.Infra.ORM.CupomModule;
using e_Locadora5.Infra.ORM.FuncionarioModule;
using e_Locadora5.Infra.ORM.GrupoVeiculoModule;
using e_Locadora5.Infra.ORM.LocacaoModule;
using e_Locadora5.Infra.ORM.ParceiroModule;
using e_Locadora5.Infra.ORM.TaxasServicosModule;
using e_Locadora5.Infra.ORM.VeiculoModule;
using e_Locadora5.Infra.SQL;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.EFTests.LocacaoModule
{
    [TestClass]
    public class LocacaoEFTest
    {
        IFuncionarioRepository funcionarioRepository = null;
        IGrupoVeiculoRepository  grupoVeiculoRepository = null;
        IVeiculoRepository veiculoRepository = null;
        IClienteRepository clienteRepository = null;
        ICondutorRepository condutorRepository = null;
        ITaxasServicosRepository taxasServicosRepository = null;
        IParceiroRepository parceiroRepository = null;
        ICupomRepository cupomRepository = null;
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

        public LocacaoEFTest()
        {
            Db.Update("DELETE FROM LOCACAOTAXASSERVICOS");
            Db.Update("DELETE FROM TBLOCACAO");
            Db.Update("DELETE FROM TBCUPOM");
            Db.Update("DELETE FROM TBPARCEIRO");
            Db.Update("DELETE FROM TBTAXASSERVICOS");
            Db.Update("DELETE FROM TBCONDUTOR");
            Db.Update("DELETE FROM TBCliente");
            Db.Update("DELETE FROM TBFUNCIONARIO");
            Db.Update("DELETE FROM TBVEICULO");
            Db.Update("DELETE FROM TBGRUPOVEICULO");
   
            LocadoraDbContext locadoraDbContext = new LocadoraDbContext();
           

            funcionarioRepository = new FuncionarioOrmDAO(locadoraDbContext);

            grupoVeiculoRepository = new GrupoVeiculoOrmDAO(locadoraDbContext);
            veiculoRepository = new VeiculoOrmDAO(locadoraDbContext);

            clienteRepository = new ClienteOrmDAO(locadoraDbContext);
            condutorRepository = new CondutorOrmDAO(locadoraDbContext);

            taxasServicosRepository = new TaxasServicosOrmDAO(locadoraDbContext);

            parceiroRepository = new ParceiroOrmDAO(locadoraDbContext);
            cupomRepository = new CupomOrmDAO(locadoraDbContext);

            locacaoRepository = new LocacaoOrmDAO(locadoraDbContext);

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

            funcionarioRepository.InserirNovo(funcionario);
            grupoVeiculoRepository.InserirNovo(grupoVeiculo);
            veiculoRepository.InserirNovo(veiculo);
            clienteRepository.InserirNovo(cliente);
            condutorRepository.InserirNovo(condutor);
            taxasServicosRepository.InserirNovo(taxaServico);
            parceiroRepository.InserirNovo(parceiro);
            cupomRepository.InserirNovo(cupom);
        }

        [TestCleanup()]
        public void LimparTabelas()
        {
            Db.Update("DELETE FROM LOCACAOTAXASSERVICOS");
            Db.Update("DELETE FROM TBLOCACAO");
            Db.Update("DELETE FROM TBCUPOM");
            Db.Update("DELETE FROM TBPARCEIRO");
            Db.Update("DELETE FROM TBTAXASSERVICOS");
            Db.Update("DELETE FROM TBCONDUTOR");
            Db.Update("DELETE FROM TBCLIENTE");
            Db.Update("DELETE FROM TBFUNCIONARIO");
            Db.Update("DELETE FROM TBVEICULO");
            Db.Update("DELETE FROM TBGRUPOVEICULO");

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
                .ComCupom(cupom)
                .ComDataLocacao(dataHoje)
                .ComDataDevolucao(dataAmanha)
                .ComEmAberto(false)
                .ComQuilometragemDevolucao(veiculo.Quilometragem + 200)
                .ComSeguroCliente(250)
                .ComSeguroTerceiro(500)
                .ComPlano("Diario")
                .Build();

            locacaoRepository.InserirNovo(locacao);

            Locacao novoLocacao = new LocacaoDataBuilder()
                .ComFuncionario(funcionario)
                .ComGrupoVeiculo(grupoVeiculo)
                .ComVeiculo(veiculo)
                .ComCliente(cliente)
                .ComCondutor(condutor)
                .ComCaucao(1000)
                .ComCupom(cupom)
                .ComDataLocacao(dataHoje)
                .ComDataDevolucao(dataAmanha)
                .ComEmAberto(false)
                .ComQuilometragemDevolucao(veiculo.Quilometragem + 300)
                .ComSeguroCliente(350)
                .ComSeguroTerceiro(660)
                .ComPlano("Diario")
                .Build();
            //action              

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
                .ComCupom(cupom)
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
        public void DeveInserir_Locacao()
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
                 .ComCupom(cupom)
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

            //assert
            Assert.AreEqual(locacao1, locacaoRepository.SelecionarPorId(locacao1.Id));

         
        }

        [TestMethod]
        public void DeveBuscarTaxasServicosPeloIdDaLocacao()
        {
            //arrange
            Locacao locacao = new LocacaoDataBuilder()
                .ComFuncionario(funcionario)
                .ComGrupoVeiculo(grupoVeiculo)
                .ComVeiculo(veiculo)
                .ComCliente(cliente)
                .ComCondutor(condutor)
                .ComTaxaServico(taxaServico)
                .ComCaucao(100)
                .ComCupom(cupom)
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

            var taxaServicoSelecionados = locacaoRepository.SelecionarTaxasServicosPorLocacaoId(locacao.Id);
            //locacaoRepository.InserirNovo(locacao2);

            //assert
            Assert.AreEqual(1, taxaServicoSelecionados.Count);

            //foreach (TaxasServicos taxaServicoIndividual in taxaServicoSelecionados1)
            //    taxaServicoIndividual.Should().Be(taxaServico);
            //taxaServicoSelecionados1.Count.Should().Be(1);

            //var taxaServicoSelecionados2 = locacaoRepository.SelecionarTaxasServicosPorLocacaoId(locacao2.Id);

            //foreach (TaxasServicos taxaServicoIndividual in taxaServicoSelecionados2)
            //    taxaServicoIndividual.Should().Be(taxaServico);
            //taxaServicoSelecionados2.Count.Should().Be(2);
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
                .ComCupom(cupom)
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
