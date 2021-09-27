
using e_Locadora5.Aplicacao.ClienteModule;
using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Infra.GeradorLogs;
using e_Locadora5.Tests.ClientesModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace e_Locadora5.AppServiceTests.ClienteModule
{
    [TestClass]
    public class ClienteAppServiceTests
    {
        ClienteAppService clienteAppService;
        Mock<IClienteRepository> mockClienteRepository;
        Mock<Clientes> mockCliente;
      
       public ClienteAppServiceTests()
        {
            mockClienteRepository = new Mock<IClienteRepository>();
            clienteAppService = new ClienteAppService(mockClienteRepository.Object);
            mockCliente = new Mock<Clientes>();
            GeradorDeLog.ConfigurarLog();
        }
        
        [TestMethod]
        public void NaoDeveChamarInserirComCPFRepetido()
        {
            //arrange
            mockClienteRepository.Setup(x => x.ExisteClienteComEsteCPF(0, "123"))
                .Returns(() =>
                {
                    return true;
                });

            Clientes cliente = new ClienteDataBuilder().GerarClienteCompleto();
            cliente.CPF = "123";
            //act
            string resultado = clienteAppService.InserirNovo(cliente);
            //assert
            resultado.Should().Be("Já há um cliente cadastrado com este CPF");
        }
        [TestMethod]
        public void NaoDeveChamarInserirComRGRepetido()
        {
            //arrange
            mockClienteRepository.Setup(x => x.ExisteClienteComEsteRG(0, "123"))
                .Returns(() =>
                { return true; });

            Clientes cliente = new ClienteDataBuilder().GerarClienteCompleto();
            cliente.RG = "123";

            //act
            string resultado = clienteAppService.InserirNovo(cliente);
            //assert
            resultado.Should().Be("Já há um cliente cadastrado com este RG");
        }
        [TestMethod]
        public void NaoDeveChamarInserirComClientesClientesInvalido()
        {
            Mock<Clientes> mockCliente = new Mock<Clientes>();

            mockClienteRepository.Setup(x => x.ExisteClienteComEsteCPF(0, "123")).Returns(() =>
            {
                return false;
            });

            mockClienteRepository.Setup(x => x.ExisteClienteComEsteRG(0, "123")).Returns(() =>
            {
                return false;
            });

            mockCliente.Setup(x => x.Validar()).Returns(() =>
            {
                return "O atributo nome é obrigatório e não pode ser vazio.";
            });

            var resultado = clienteAppService.InserirNovo(mockCliente.Object);

            //assert
            resultado.Should().Be("O atributo nome é obrigatório e não pode ser vazio.");
        }
        [TestMethod]
        public void DeveChamarInserir()
        {
            Mock<Clientes> mockCliente = new Mock<Clientes>();

            mockClienteRepository.Setup(x => x.ExisteClienteComEsteCPF(0, "123")).Returns(() =>
            {
                return false;
            });

            mockClienteRepository.Setup(x => x.ExisteClienteComEsteRG(0, "123")).Returns(() =>
            {
                return false;
            });

            mockCliente.Setup(x => x.Validar()).Returns(() =>
            {
                return "ESTA_VALIDO";
            });

            clienteAppService.InserirNovo(mockCliente.Object);

            mockClienteRepository.Verify(x => x.InserirCliente(mockCliente.Object));
        }
        [TestMethod]
        public void DeveChamarEditar()
        {
            Mock<Clientes> mockCliente = new Mock<Clientes>();

            mockClienteRepository.Setup(x => x.ExisteClienteComEsteCPF(0, "123")).Returns(() =>
            {
                return false;
            });

            mockClienteRepository.Setup(x => x.ExisteClienteComEsteRG(0, "123")).Returns(() =>
            {
                return false;
            });

            mockCliente.Setup(x => x.Validar()).Returns(() =>
            {
                return "ESTA_VALIDO";
            });

            clienteAppService.Editar(1, mockCliente.Object);

            mockClienteRepository.Verify(x => x.EditarCliente(1, mockCliente.Object));
        }
        [TestMethod]
        public void DeveChamarExcluir()
        {

            // act
            var resultado = clienteAppService.Excluir(mockCliente.Object.Id);
            //assert          
            mockClienteRepository.Verify(x => x.ExcluirCliente(mockCliente.Object.Id));
      
            resultado.Should().Be(true);
        }
        [TestMethod]
        public void DeveChamarSelecionarPorId()
        {
            //arrange
            Clientes cliente = new ClienteDataBuilder().GerarClienteCompleto();

            mockClienteRepository.Setup(x => x.SelecionarClientePorId(1)).Returns(() =>
            {
                return cliente;
            });
            //act
            var resultado = clienteAppService.SelecionarPorId(1);
            //assert
            mockClienteRepository.Verify(x => x.SelecionarClientePorId(1));
            resultado.Should().Be(cliente);
        }
        [TestMethod]
        public void DeveChamarExiste()
        {
            Clientes cliente = new ClienteDataBuilder().GerarClienteCompleto();

            mockClienteRepository.Setup(x => x.Existe(1)).Returns(() =>
            {
                return true;
            });

            var resultado = clienteAppService.Existe(1);

            mockClienteRepository.Verify(x => x.Existe(1));
            resultado.Should().Be(true);
        }
        [TestMethod]
        public void DeveChamarSelecionarTodos()
        {
            Clientes cliente = new ClienteDataBuilder().GerarClienteCompleto();
            List<Clientes> clientees = new List<Clientes>() { cliente };
            
            mockClienteRepository.Setup(x => x.SelecionarTodosClientes()).Returns(() =>
            {
                return clientees;
            });

            var resultado = clienteAppService.SelecionarTodos();

            resultado.Count.Should().Be(1);
        }
    }
}
