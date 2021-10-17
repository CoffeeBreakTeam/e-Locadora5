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
    public class LocacaoDominioTests
    {
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

        public LocacaoDominioTests()
        {
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
        }

        [TestMethod]
        public void DeveCriar_Locacao()
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
            string resultadoValidacao = locacao.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void DeveValidar_Locacao_Caucao()
        {
            //arrange
            var funcionario = new Funcionario("nome", "460162200", "usuario", "senha", DateTime.Now.Date, 600.0);
            var grupoVeiculo = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var veiculo = new Veiculo("placa", "modelo", "fabricante", 400.0, 50, 4, "123456", "azul", 4, 1996, "Grande", "Gasolina", grupoVeiculo, imagem);
            var cliente = new Cliente("Joao", "rua souza", "9524282242", "853242", "20220220222", "1239232", "Joao.pereira@gmail.com");
            var condutor = new Condutor("Joao", "Rua dos Joao", "9522185224", "5222522", "20202020222", "522542", new DateTime(2022, 05, 26), cliente);
            TaxasServicos taxaServico = new TaxasServicos("descricao", 200, 0);
            cupom = new Cupom("Cupom do Deko", 50, 0, dataAmanha, parceiro, 1);
            var locacao = new Locacao(funcionario, DateTime.Now.Date, DateTime.Now.Date, 200, "Livre", 200, 0, -500, grupoVeiculo, veiculo, cliente, condutor, true, cupom);

            //action
            string resultadoValidacao = locacao.Validar();

            //assert
            resultadoValidacao.Should().Be("Caução não pode ser negativo");
        }

        [TestMethod]
        public void DeveValidar_Locacao_SeguroCliente()
        {
            //arrange
            var funcionario = new Funcionario("nome", "460162200", "usuario", "senha", DateTime.Now.Date, 600.0);
            var grupoVeiculo = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var veiculo = new Veiculo("placa", "modelo", "fabricante", 400.0, 50, 4, "123456", "azul", 4, 1996, "Grande", "Gasolina", grupoVeiculo, imagem);
            var cliente = new Cliente("Joao", "rua souza", "9524282242", "853242", "20220220222", "1239232", "Joao.pereira@gmail.com");
            var condutor = new Condutor("Joao", "Rua dos Joao", "9522185224", "5222522", "20202020222", "522542", new DateTime(2022, 05, 26), cliente);
            cupom = new Cupom("Cupom do Deko", 50, 0, dataAmanha, parceiro, 1);
            TaxasServicos taxaServico = new TaxasServicos("descricao", 200, 0);
            var locacao = new Locacao(funcionario, DateTime.Now.Date, DateTime.Now.Date, 200, "Livre", -200, 0, 500, grupoVeiculo, veiculo, cliente, condutor, true,cupom);
            


            //action
            string resultadoValidacao = locacao.Validar();

            //assert
            resultadoValidacao.Should().Be("Seguro do cliente não pode ser negativo");
        }

        [TestMethod]
        public void DeveValidar_Locacao_SeguroTerceiro()
        {
            //arrange
            var funcionario = new Funcionario("nome", "460162200", "usuario", "senha", DateTime.Now.Date, 600.0);
            var grupoVeiculo = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var veiculo = new Veiculo("placa", "modelo", "fabricante", 400.0, 50, 4, "123456", "azul", 4, 1996, "Grande", "Gasolina", grupoVeiculo, imagem);
            var cliente = new Cliente("Joao", "rua souza", "9524282242", "853242", "20220220222", "1239232", "Joao.pereira@gmail.com");
            var condutor = new Condutor("Joao", "Rua dos Joao", "9522185224", "5222522", "20202020222", "522542", new DateTime(2022, 05, 26), cliente);
            TaxasServicos taxaServico = new TaxasServicos("descricao", 200, 0);
            cupom = new Cupom("Cupom do Deko", 50, 0, dataAmanha, parceiro, 1);
            var locacao = new Locacao(funcionario, DateTime.Now.Date, DateTime.Now.Date, 200, "Livre", 200, -10, 500, grupoVeiculo, veiculo, cliente, condutor, true,cupom);


            //action
            string resultadoValidacao = locacao.Validar();

            //assert
            resultadoValidacao.Should().Be("Seguro de terceiros não pode ser negativo");
        }

        [TestMethod]
        public void DeveCalcular_ValorPlano()
        {
            //arrange
            var funcionario = new Funcionario("nome", "460162200", "usuario", "senha", DateTime.Now.Date, 600.0);
            var grupoVeiculo = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var veiculo = new Veiculo("placa", "modelo", "fabricante", 400.0, 50, 4, "123456", "azul", 4, 1996, "Grande", "Gasolina", grupoVeiculo, imagem);
            var cliente = new Cliente("Joao", "rua souza", "9524282242", "853242", "20220220222", "1239232", "Joao.pereira@gmail.com");
            var condutor = new Condutor("Joao", "Rua dos Joao", "9522185224", "5222522", "20202020222", "522542", new DateTime(2022, 05, 26), cliente);
            TaxasServicos taxaServico = new TaxasServicos("descricao", 200, 0);
            cupom = new Cupom("Cupom do Deko", 50, 0, dataAmanha, parceiro, 1);
            var locacao = new Locacao(funcionario, DateTime.Now.Date, DateTime.Now.Date.AddDays(2), 200, "Km Livre", 200, -10, 500, grupoVeiculo, veiculo, cliente, condutor, true,cupom);

            //action
            double resultado = locacao.CalcularValorPlano();

            //assert
            resultado.Should().Be(12.0);
        }

        [TestMethod]
        public void DeveCalcular_ValorTaxas()
        {
            //arrange
            var funcionario = new Funcionario("nome", "460162200", "usuario", "senha", DateTime.Now.Date, 600.0);
            var grupoVeiculo = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var veiculo = new Veiculo("placa", "modelo", "fabricante", 400.0, 50, 4, "123456", "azul", 4, 1996, "Grande", "Gasolina", grupoVeiculo, imagem);
            var cliente = new Cliente("Joao", "rua souza", "9524282242", "853242", "20220220222", "1239232", "Joao.pereira@gmail.com");
            var condutor = new Condutor("Joao", "Rua dos Joao", "9522185224", "5222522", "20202020222", "522542", new DateTime(2022, 05, 26), cliente);
            cupom = new Cupom("Cupom do Deko", 50, 0, dataAmanha, parceiro, 1);
            TaxasServicos taxaServico = new TaxasServicos("descricao", 200, 0);
            var locacao = new Locacao(funcionario, DateTime.Now.Date, DateTime.Now.Date.AddDays(2), 200, "Km Livre", 200, -10, 500, grupoVeiculo, veiculo, cliente, condutor, true,cupom);
            locacao.TaxasServicos.Add(taxaServico);

            //action
            double resultado = locacao.CalcularValorTaxas();

            //assert
            resultado.Should().Be(200.0);
        }

        [TestMethod]
        public void DeveCalcular_ValorTotal_SemCupom()
        {
            //arrange
            var funcionario = new Funcionario("nome", "460162200", "usuario", "senha", DateTime.Now.Date, 600.0);
            var grupoVeiculo = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var veiculo = new Veiculo("placa", "modelo", "fabricante", 400.0, 50, 4, "123456", "azul", 4, 1996, "Grande", "Gasolina", grupoVeiculo, imagem);
            var cliente = new Cliente("Joao", "rua souza", "9524282242", "853242", "20220220222", "1239232", "Joao.pereira@gmail.com");
            var condutor = new Condutor("Joao", "Rua dos Joao", "9522185224", "5222522", "20202020222", "522542", new DateTime(2022, 05, 26), cliente);
            TaxasServicos taxaServico = new TaxasServicos("descricao", 200, 0);
            cupom = new Cupom("Cupom do Deko", 50, 0, dataAmanha, parceiro, 1);
            var locacao = new Locacao(funcionario, DateTime.Now.Date, DateTime.Now.Date.AddDays(2), 200, "Km Livre", 200, 00, 500, grupoVeiculo, veiculo, cliente, condutor, true,cupom);
            locacao.TaxasServicos.Add(taxaServico);
            
            //action
            double resultado = locacao.CalcularValorLocacao();

            //assert
            resultado.Should().Be(212.0);
        }

        [TestMethod]
        public void DeveCalcular_ValorTotal_ComCupom()
        {
            //arrange
            var funcionario = new Funcionario("nome", "460162200", "usuario", "senha", DateTime.Now.Date, 600.0);
            var grupoVeiculo = new GrupoVeiculo("Economico", 1, 2, 3, 4, 5, 6);
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var veiculo = new Veiculo("placa", "modelo", "fabricante", 400.0, 50, 4, "123456", "azul", 4, 1996, "Grande", "Gasolina", grupoVeiculo, imagem);
            var cliente = new Cliente("Joao", "rua souza", "9524282242", "853242", "20220220222", "1239232", "Joao.pereira@gmail.com");
            var condutor = new Condutor("Joao", "Rua dos Joao", "9522185224", "5222522", "20202020222", "522542", new DateTime(2022, 05, 26), cliente);
            TaxasServicos taxaServico = new TaxasServicos("descricao", 200, 0);
            var parceiro = new Parceiro("Deko");
            var cupom = new Cupom("Deko-1236", 50, 0, new DateTime(2022, 10, 26).Date, parceiro, 1);
            var locacao = new Locacao(funcionario, DateTime.Now.Date, DateTime.Now.Date.AddDays(2), 200, "Km Livre", 200, 0, 500, grupoVeiculo, veiculo, cliente, condutor, true,cupom);
            locacao.TaxasServicos.Add(taxaServico);
           
           
            locacao.Cupom = cupom;

            //action
            double resultado = locacao.CalcularValorLocacao();

            //assert
            resultado.Should().Be(106.0);
        }
        
    }
}
