
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
            var funcionario = new Funcionario("nome", "460162200", "usuario", "senha", DateTime.Now.Date, 600.0);
            var grupoVeiculo = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var veiculo = new Veiculo("placa", "modelo", "fabricante", 400.0, 50, 4, "123456", "azul", 4, 1996, "Grande", "Gasolina", grupoVeiculo, imagem);
            var cliente = new Clientes("Joao", "rua souza", "9524282242", "853242", "20220220222", "1239232", "Joao.pereira@gmail.com");
            var condutor = new Condutor("Joao", "Rua dos Joao", "9522185224", "5222522", "20202020222", "522542", new DateTime(2022, 05, 26), cliente);
            TaxasServicos taxaServico = new TaxasServicos("descricao", 200, 0);
            var locacao = new Locacao(funcionario, DateTime.Now.Date, DateTime.Now.Date, 200, "Livre", 200, 0, 500, grupoVeiculo, veiculo, cliente, condutor, true);

            
            //action
            controladorFuncionario.InserirNovo(funcionario);
            controladorGrupoVeiculo.InserirNovo(grupoVeiculo);
            controladorVeiculo.InserirNovo(veiculo);
            controladorCliente.InserirNovo(cliente);
            controladorCondutor.InserirNovo(condutor);
            controladorTaxasServicos.InserirNovo(taxaServico);
            controladorLocacao.InserirNovo(locacao);



            //assert
            var locacaoEncontrado = controladorLocacao.SelecionarPorId(locacao.Id);
            locacaoEncontrado.Should().Be(locacao);
        }

        [TestMethod]
        public void DeveEditar_Locacao()
        {
            //arrange
            var funcionario = new Funcionario("nome", "460162200", "usuario", "senha", DateTime.Now.Date, 600.0);
            var grupoVeiculo = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var veiculo1 = new Veiculo("placa", "modelo", "fabricante", 400.0, 50, 4, "123456", "azul", 4, 1996, "Grande", "Gasolina", grupoVeiculo, imagem);
            var veiculo2 = new Veiculo("placa2", "modelo2", "fabricante2", 400.0, 50, 4, "1234562", "azul2", 4, 1996, "Grande", "Gasolina", grupoVeiculo, imagem);
            var cliente = new Clientes("Joao", "rua souza", "9524282242", "853242", "20220220222", "1239232", "Joao.pereira@gmail.com");
            var condutor = new Condutor("Joao", "Rua dos Joao", "9522185224", "5222522", "20202020222", "522542", new DateTime(2022, 05, 26), cliente);
            var taxaServico = new TaxasServicos("descricao", 200, 0);
            var locacao = new Locacao(funcionario, DateTime.Now.Date, DateTime.Now.Date, 200, "Livre", 200, 0, 500, grupoVeiculo, veiculo1, cliente, condutor, true);
            var novoLocacao = new Locacao(funcionario, DateTime.Now.Date, DateTime.Now.Date, 200, "Diário", 200, 0, 400, grupoVeiculo, veiculo2, cliente, condutor, true);

            //action
            controladorFuncionario.InserirNovo(funcionario);
            controladorGrupoVeiculo.InserirNovo(grupoVeiculo);
            controladorVeiculo.InserirNovo(veiculo1);
            controladorVeiculo.InserirNovo(veiculo2);
            controladorCliente.InserirNovo(cliente);
            controladorCondutor.InserirNovo(condutor);
            controladorTaxasServicos.InserirNovo(taxaServico);
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
            var funcionario = new Funcionario("nome", "460162200", "usuario", "senha", DateTime.Now.Date, 600.0);
            var grupoVeiculo = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var veiculo = new Veiculo("placa", "modelo", "fabricante", 400.0, 50, 4, "123456", "azul", 4, 1996, "Grande", "Gasolina", grupoVeiculo, imagem);
            var cliente = new Clientes("Joao", "rua souza", "9524282242", "853242", "20220220222", "1239232", "Joao.pereira@gmail.com");
            var condutor = new Condutor("Joao", "Rua dos Joao", "9522185224", "5222522", "20202020222", "522542", new DateTime(2022, 05, 26), cliente);
            var taxaServico = new TaxasServicos("descricao", 200, 0);
            var locacao = new Locacao(funcionario, DateTime.Now.Date, DateTime.Now.Date, 200, "Livre", 200, 0, 500, grupoVeiculo, veiculo, cliente, condutor, true);

            //action
            controladorFuncionario.InserirNovo(funcionario);
            controladorGrupoVeiculo.InserirNovo(grupoVeiculo);
            controladorVeiculo.InserirNovo(veiculo);
            controladorCliente.InserirNovo(cliente);
            controladorCondutor.InserirNovo(condutor);
            controladorTaxasServicos.InserirNovo(taxaServico);
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
            var funcionario = new Funcionario("nome", "460162200", "usuario", "senha", DateTime.Now.Date, 600.0);
            var grupoVeiculo = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var veiculo = new Veiculo("placa", "modelo", "fabricante", 400.0, 50, 4, "123456", "azul", 4, 1996, "Grande", "Gasolina", grupoVeiculo, imagem);
            var cliente = new Clientes("Joao", "rua souza", "9524282242", "853242", "20220220222", "1239232", "Joao.pereira@gmail.com");
            var condutor = new Condutor("Joao", "Rua dos Joao", "9522185224", "5222522", "20202020222", "522542", new DateTime(2022, 05, 26), cliente);
            var taxaServico = new TaxasServicos("descricao", 200, 0);
            var locacao = new Locacao(funcionario, DateTime.Now.Date, DateTime.Now.Date, 200, "Livre", 200, 0, 600, grupoVeiculo, veiculo, cliente, condutor, true);


            //action
            controladorFuncionario.InserirNovo(funcionario);
            controladorGrupoVeiculo.InserirNovo(grupoVeiculo);
            controladorVeiculo.InserirNovo(veiculo);
            controladorCliente.InserirNovo(cliente);
            controladorCondutor.InserirNovo(condutor);
            controladorTaxasServicos.InserirNovo(taxaServico);
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
            var funcionario = new Funcionario("nome", "460162200", "usuario", "senha", DateTime.Now.Date, 600.0);
            var grupoVeiculo = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var veiculo = new Veiculo("placa", "modelo", "fabricante", 400.0, 50, 4, "123456", "azul", 4, 1996, "Grande", "Gasolina", grupoVeiculo, imagem);
            var cliente = new Clientes("Joao", "rua souza", "9524282242", "853242", "20220220222", "1239232", "Joao.pereira@gmail.com");
            var condutor = new Condutor("Joao", "Rua dos Joao", "9522185224", "5222522", "20202020222", "522542", new DateTime(2022, 05, 26), cliente);
            var taxaServico = new TaxasServicos("descricao", 200, 0);
            DateTime dataLocacao = new DateTime(2021,08,10);
            DateTime dataDevolucao = new DateTime(2021, 08, 21);
            var locacao = new Locacao(funcionario, dataLocacao, dataDevolucao, 200, "Livre", 200, 0, 500, grupoVeiculo, veiculo, cliente, condutor, true);


            //action
            controladorFuncionario.InserirNovo(funcionario);
            controladorGrupoVeiculo.InserirNovo(grupoVeiculo);
            controladorVeiculo.InserirNovo(veiculo);
            controladorCliente.InserirNovo(cliente);
            controladorCondutor.InserirNovo(condutor);
            controladorTaxasServicos.InserirNovo(taxaServico);
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
            var funcionario = new Funcionario("nome", "460162200", "usuario", "senha", DateTime.Now.Date, 600.0);
            var grupoVeiculo = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var veiculo = new Veiculo("placa", "modelo", "fabricante", 400.0, 50, 4, "123456", "azul", 4, 1996, "Grande", "Gasolina", grupoVeiculo, imagem);
            var cliente = new Clientes("Joao", "rua souza", "9524282242", "853242", "20220220222", "1239232", "Joao.pereira@gmail.com");
            var condutor = new Condutor("Joao", "Rua dos Joao", "9522185224", "5222522", "20202020222", "522542", new DateTime(2022, 05, 26), cliente);
            TaxasServicos taxaServico = new TaxasServicos("descricao", 200, 0);
            var locacao1 = new Locacao(funcionario, DateTime.Now.Date, DateTime.Now.Date, 200, "Livre", 200, 0, 500, grupoVeiculo, veiculo, cliente, condutor, true);
            locacao1.taxasServicos.Add(taxaServico);
            var locacao2 = new Locacao(funcionario, DateTime.Now.Date, DateTime.Now.Date, 200, "Livre", 200, 0, 500, grupoVeiculo, veiculo, cliente, condutor, true);
            locacao2.taxasServicos.Add(taxaServico);


            //action
            controladorFuncionario.InserirNovo(funcionario);
            controladorGrupoVeiculo.InserirNovo(grupoVeiculo);
            controladorVeiculo.InserirNovo(veiculo);
            controladorCliente.InserirNovo(cliente);
            controladorCondutor.InserirNovo(condutor);
            controladorTaxasServicos.InserirNovo(taxaServico);
            controladorLocacao.InserirNovo(locacao1);



            //assert
            var taxaServicoSelecionados1 = controladorLocacao.SelecionarTaxasServicosPorLocacaoId(locacao1.Id);
            foreach(TaxasServicos taxaServicoIndividual in taxaServicoSelecionados1)
                taxaServicoIndividual.Should().Be(taxaServico);
            taxaServicoSelecionados1.Count.Should().Be(1);

            var taxaServicoSelecionados2 = controladorLocacao.SelecionarTaxasServicosPorLocacaoId(locacao1.Id);
            foreach (TaxasServicos taxaServicoIndividual in taxaServicoSelecionados2)
                taxaServicoIndividual.Should().Be(taxaServico);
            taxaServicoSelecionados2.Count.Should().Be(1);
        }

        [TestMethod]
        public void DeveExcluir_LocacaoTaxaServico()
        {
            //arrange
            var funcionario = new Funcionario("nome", "460162200", "usuario", "senha", DateTime.Now.Date, 600.0);
            var grupoVeiculo = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var veiculo = new Veiculo("placa", "modelo", "fabricante", 400.0, 50, 4, "123456", "azul", 4, 1996, "Grande", "Gasolina", grupoVeiculo, imagem);
            var cliente = new Clientes("Joao", "rua souza", "9524282242", "853242", "20220220222", "1239232", "Joao.pereira@gmail.com");
            var condutor = new Condutor("Joao", "Rua dos Joao", "9522185224", "5222522", "20202020222", "522542", new DateTime(2022, 05, 26), cliente);
            TaxasServicos taxaServico = new TaxasServicos("descricao", 200, 0);
            var locacao = new Locacao(funcionario, DateTime.Now.Date, DateTime.Now.Date, 200, "Livre", 200, 0, 500, grupoVeiculo, veiculo, cliente, condutor, true);
            locacao.taxasServicos.Add(taxaServico);


            //action
            controladorFuncionario.InserirNovo(funcionario);
            controladorGrupoVeiculo.InserirNovo(grupoVeiculo);
            controladorVeiculo.InserirNovo(veiculo);
            controladorCliente.InserirNovo(cliente);
            controladorCondutor.InserirNovo(condutor);
            controladorTaxasServicos.InserirNovo(taxaServico);
            controladorLocacao.InserirNovo(locacao);



            //assert
            controladorLocacao.Excluir(locacao.Id);

            //assert
            var locacaoEncontrado = controladorLocacao.SelecionarPorId(locacao.Id);
            locacaoEncontrado.Should().Be(null);
        }

        [TestMethod]
        public void DeveEditar_LocacaoTaxaServico()
        {
            //arrange
            var funcionario = new Funcionario("nome", "460162200", "usuario", "senha", DateTime.Now.Date, 600.0);
            var grupoVeiculo = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var veiculo = new Veiculo("placa", "modelo", "fabricante", 400.0, 50, 4, "123456", "azul", 4, 1996, "Grande", "Gasolina", grupoVeiculo, imagem);
            var cliente = new Clientes("Joao", "rua souza", "9524282242", "853242", "20220220222", "1239232", "Joao.pereira@gmail.com");
            var condutor = new Condutor("Joao", "Rua dos Joao", "9522185224", "5222522", "20202020222", "522542", new DateTime(2022, 05, 26), cliente);
            TaxasServicos taxaServico = new TaxasServicos("descricao", 200, 0);
            var locacao = new Locacao(funcionario, DateTime.Now.Date, DateTime.Now.Date, 200, "Livre", 200, 0, 500, grupoVeiculo, veiculo, cliente, condutor, true);
            locacao.taxasServicos.Add(taxaServico);
            var novoLocacao = new Locacao(funcionario, DateTime.Now.Date, DateTime.Now.Date, 200, "Diário", 200, 0, 400, grupoVeiculo, veiculo, cliente, condutor, true);
            novoLocacao.taxasServicos.Add(taxaServico);

            //action
            controladorFuncionario.InserirNovo(funcionario);
            controladorGrupoVeiculo.InserirNovo(grupoVeiculo);
            controladorVeiculo.InserirNovo(veiculo);
            controladorCliente.InserirNovo(cliente);
            controladorCondutor.InserirNovo(condutor);
            controladorTaxasServicos.InserirNovo(taxaServico);
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
            var funcionario = new Funcionario("nome", "460162200", "usuario", "senha", DateTime.Now.Date, 600.0);
            var grupoVeiculo = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var veiculo = new Veiculo("placa", "modelo", "fabricante", 400.0, 50, 4, "123456", "azul", 4, 1996, "Grande", "Gasolina", grupoVeiculo, imagem);
            var cliente = new Clientes("Joao", "rua souza", "9524282242", "853242", "20220220222", "1239232", "Joao.pereira@gmail.com");
            var condutor = new Condutor("Joao", "Rua dos Joao", "9522185224", "5222522", "20202020222", "522542", new DateTime(2022, 05, 26), cliente);
            TaxasServicos taxaServico = new TaxasServicos("descricao", 200, 0);
            var locacao = new Locacao(funcionario, DateTime.Now.Date, DateTime.Now.Date, 200, "Livre", 200, 0, 500, grupoVeiculo, veiculo, cliente, condutor, true);
            locacao.taxasServicos.Add(taxaServico);
            var novoLocacao = new Locacao(funcionario, DateTime.Now.Date, DateTime.Now.Date, 200, "Diário", 200, 0, 400, grupoVeiculo, veiculo, cliente, condutor, true);
            novoLocacao.taxasServicos.Add(taxaServico);

            //action
            controladorFuncionario.InserirNovo(funcionario);
            controladorGrupoVeiculo.InserirNovo(grupoVeiculo);
            controladorVeiculo.InserirNovo(veiculo);
            controladorCliente.InserirNovo(cliente);
            controladorCondutor.InserirNovo(condutor);
            controladorTaxasServicos.InserirNovo(taxaServico);
            controladorLocacao.InserirNovo(locacao);
            controladorLocacao.Editar(locacao.Id, novoLocacao);

            //assert
            var locacaoEncontrado = controladorLocacao.SelecionarPorId(locacao.Id);
            locacaoEncontrado.Should().Be(novoLocacao);
        }

        [TestMethod]
        public void DeveInserir_Locacao_Com_CupomDesconto()
        {
            //arrange
            var funcionario = new Funcionario("nome", "460162200", "usuario", "senha", DateTime.Now.Date, 600.0);
            var grupoVeiculo = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var veiculo = new Veiculo("placa", "modelo", "fabricante", 400.0, 50, 4, "123456", "azul", 4, 1996, "Grande", "Gasolina", grupoVeiculo, imagem);
            var cliente = new Clientes("Joao", "rua souza", "9524282242", "853242", "20220220222", "1239232", "Joao.pereira@gmail.com");
            var condutor = new Condutor("Joao", "Rua dos Joao", "9522185224", "5222522", "20202020222", "522542", new DateTime(2022, 05, 26), cliente);
            TaxasServicos taxaServico = new TaxasServicos("descricao", 200, 0);
            var parceiro = new Parceiro("Desconto do Deko");
            var cupom = new Cupons("Deko-1236", 50, 0, new DateTime(2022, 10, 26).Date, parceiro, 1);
            var locacao = new Locacao(funcionario, DateTime.Now.Date, DateTime.MaxValue.Date, 200, "Livre", 200, 80, 500, grupoVeiculo, veiculo, cliente, condutor, true);
            locacao.taxasServicos.Add(taxaServico);
            locacao.cupom = cupom;

            //action
            controladorFuncionario.InserirNovo(funcionario);
            controladorGrupoVeiculo.InserirNovo(grupoVeiculo);
            controladorVeiculo.InserirNovo(veiculo);
            controladorCliente.InserirNovo(cliente);
            controladorCondutor.InserirNovo(condutor);
            controladorTaxasServicos.InserirNovo(taxaServico);
            controladorParceiro.InserirNovo(parceiro);
            controladorCupom.InserirNovo(cupom);
            controladorLocacao.InserirNovo(locacao);

            //assert
            var locacaoEncontrado = controladorLocacao.SelecionarPorId(locacao.Id);
            locacaoEncontrado.Should().Be(locacao);
        }
    }
}
