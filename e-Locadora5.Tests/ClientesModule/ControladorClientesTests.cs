using e_Locadora5.Controladores;
using e_Locadora5.Controladores.ClientesModule;
using e_Locadora5.Dominio.ClientesModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace e_Locadora5.Tests.ClientesModule
{
    [TestClass]
    [TestCategory("Controladores")]
    public class ControladorClientesTests
    {
        ControladorClientes controlador = null;

        public ControladorClientesTests()
        {
            controlador = new ControladorClientes();
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
            controlador.InserirNovo(cliente);

            //assert
            var grupoVeiculoEncontrado = controlador.SelecionarPorId(cliente.Id);
            grupoVeiculoEncontrado.Should().Be(cliente);
        }
        [TestMethod]
        public void Deve_InserirNovo_Cliente_Cnpj()
        {
            //arrange
            var cliente = new Clientes("FDG", "rua souza", "9524282242", "", "", "02914460029615", "Joao.pereira@gmail.com");

            //action
            controlador.InserirNovo(cliente);

            //assert
            var ClienteEncontrado = controlador.SelecionarPorId(cliente.Id);
            ClienteEncontrado.Should().Be(cliente);
        }
        [TestMethod]
        public void Deve_Atualizar_Cliente()
        {
            //arrange
            var cliente = new Clientes("FDG", "rua souza", "9524282242", "", "", "02914460029615", "Joao.pereira@gmail.com");
            controlador.InserirNovo(cliente);
            var clienteAtualizado = new Clientes("FDG limitada", "rua souza khdsd", "9524282242", "", "", "02914460029615", "Joao.pereira@gmail.com");

            //action
            controlador.Editar(cliente.Id, clienteAtualizado);

            //assert
            Clientes clienteeditado = controlador.SelecionarPorId(cliente.Id);
            clienteeditado.Should().Be(clienteAtualizado);
        }
        [TestMethod]
        public void Deve_SelecionarPorId_Cliente_Cnpj()
        {
            //arrange
            var cliente = new Clientes("FDG", "rua souza", "9524282242", "", "", "02914460029615", "Joao.pereira@gmail.com");
            controlador.InserirNovo(cliente);
            //action
            Clientes clienteEncontrado = controlador.SelecionarPorId(cliente.Id);

            //assert
            clienteEncontrado.Should().NotBeNull();
        }
        [TestMethod]
        public void Deve_Excluir_Cliente_Cnpj()
        {
            //arrange
            var cliente = new Clientes("FDG", "rua souza", "9524282242", "", "", "02914460029615", "Joao.pereira@gmail.com");
            controlador.InserirNovo(cliente);
            //action
            controlador.Excluir(cliente.Id);

            //assert
            var ClienteEncrontrado = controlador.SelecionarPorId(cliente.Id);
            ClienteEncrontrado.Should().BeNull();
        }
        [TestMethod]
        public void DeveSelecionar_TodosClientes()
        {
            //arrange
            var c1 = new Clientes("FDG", "rua souza", "9524282242", "", "", "02914460029615", "Joao.pereira@gmail.com");
            controlador.InserirNovo(c1);

            var c2 = new Clientes("NDD", "rua souza", "9524282242", "", "", "02914460029614", "Joao.pereira@gmail.com");
            controlador.InserirNovo(c2);

            var c3 = new Clientes("JBS", "rua souza", "9524282242", "", "", "02914460029616", "Joao.pereira@gmail.com");
            controlador.InserirNovo(c3);

            //action
            var clientes = controlador.SelecionarTodos();

            //assert
            clientes.Should().HaveCount(3);
            clientes[0].Nome.Should().Be("FDG");
            clientes[1].Nome.Should().Be("NDD");
            clientes[2].Nome.Should().Be("JBS");
        }
    }
}
