using e_Locadora5.Aplicacao.ClienteModule;
using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Infra.SQL;
using e_Locadora5.Infra.SQL.ClienteModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace e_Locadora5.Tests.ClientesModule
{
    [TestClass]
    [TestCategory("Controladores")]
    public class ClienteAppServiceTests
    {
          
        ClienteAppService clienteAppService;

        public ClienteAppServiceTests()
        {          
            clienteAppService = new ClienteAppService(new ClienteDAO());            
            LimparTabelas();
        }

        [TestCleanup()]
        public void LimparTabelas()
        {
            Db.Update("DELETE FROM TBLOCACAO_TBTAXASSERVICOS");
            Db.Update("DELETE FROM TBLOCACAO");
            Db.Update("DELETE FROM TBCONDUTOR");
            Db.Update("DELETE FROM TBCLIENTES");
        }

        [TestMethod]
        public void Deve_InserirNovo_Cliente_CPF()
        {
            //arrange
            var cliente = new Clientes("Joao", "rua souza", "9524282242", "853242", "20220220222","", "Joao.pereira@gmail.com");

            //action
            clienteAppService.InserirNovo(cliente);

            //assert
            var grupoVeiculoEncontrado = clienteAppService.SelecionarPorId(cliente.Id);
            grupoVeiculoEncontrado.Should().Be(cliente);
        }
        [TestMethod]
        public void Deve_InserirNovo_Cliente_Cnpj()
        {
            //arrange
            var cliente = new Clientes("FDG", "rua souza", "9524282242", "", "", "02914460029615", "Joao.pereira@gmail.com");

            //action
            clienteAppService.InserirNovo(cliente);

            //assert
            var ClienteEncontrado = clienteAppService.SelecionarPorId(cliente.Id);
            ClienteEncontrado.Should().Be(cliente);
        }
        [TestMethod]
        public void Deve_Atualizar_Cliente()
        {
            //arrange
            var cliente = new Clientes("FDG", "rua souza", "9524282242", "", "", "02914460029615", "Joao.pereira@gmail.com");
            clienteAppService.InserirNovo(cliente);
            var clienteAtualizado = new Clientes("FDG limitada", "rua souza khdsd", "9524282242", "", "", "02914460029615", "Joao.pereira@gmail.com");

            //action
            clienteAppService.Editar(cliente.Id, clienteAtualizado);

            //assert
            Clientes clienteeditado = clienteAppService.SelecionarPorId(cliente.Id);
            clienteeditado.Should().Be(clienteAtualizado);
        }
        [TestMethod]
        public void Deve_SelecionarPorId_Cliente_Cnpj()
        {
            //arrange
            var cliente = new Clientes("FDG", "rua souza", "9524282242", "", "", "02914460029615", "Joao.pereira@gmail.com");
            clienteAppService.InserirNovo(cliente);
            //action
            Clientes clienteEncontrado = clienteAppService.SelecionarPorId(cliente.Id);

            //assert
            clienteEncontrado.Should().NotBeNull();
        }
        [TestMethod]
        public void Deve_Excluir_Cliente_Cnpj()
        {
            //arrange
            var cliente = new Clientes("FDG", "rua souza", "9524282242", "", "", "02914460029615", "Joao.pereira@gmail.com");
            clienteAppService.InserirNovo(cliente);
            //action
            clienteAppService.Excluir(cliente.Id);

            //assert
            var ClienteEncrontrado = clienteAppService.SelecionarPorId(cliente.Id);
            ClienteEncrontrado.Should().BeNull();
        }
        [TestMethod]
        public void DeveSelecionar_TodosClientes()
        {
            //arrange
            var c1 = new Clientes("FDG", "rua souza", "9524282242", "", "", "02914460029615", "Joao.pereira@gmail.com");
            clienteAppService.InserirNovo(c1);

            var c2 = new Clientes("NDD", "rua souza", "9524282242", "", "", "02914460029614", "Joao.pereira@gmail.com");
            clienteAppService.InserirNovo(c2);

            var c3 = new Clientes("JBS", "rua souza", "9524282242", "", "", "02914460029616", "Joao.pereira@gmail.com");
            clienteAppService.InserirNovo(c3);

            //action
            var clientes = clienteAppService.SelecionarTodos();

            //assert
            clientes.Should().HaveCount(3);
            clientes[0].Nome.Should().Be("FDG");
            clientes[1].Nome.Should().Be("NDD");
            clientes[2].Nome.Should().Be("JBS");
        }
    }
}
