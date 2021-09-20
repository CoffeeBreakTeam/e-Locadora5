using e_Locadora5.Aplicacao.ClienteModule;
using e_Locadora5.Dominio.ClientesModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        [TestMethod]
        public void NaoDeveChamarInserirComCPFRepetido()
        {
            //arrange
            mockClienteRepository.Setup(x => x.ExisteCondutorComEsteCPF(0, "123"))
                .Returns(() =>
                {
                    return true;
                });

            Condutor cliente = new CondutorDataBuilder().GerarCondutorCompleto();
            cliente.Cpf = "123";

            //act
            string resultado = clienteAppService.InserirNovo(cliente);
            //assert
            resultado.Should().Be("Já há um cliente cadastrado com este CPF");
        }
        [TestMethod]
        public void NaoDeveChamarInserirComRGRepetido()
        {
            //arrange
            mockClienteRepository.Setup(x => x.ExisteCondutorComEsteRG(0, "123"))
                .Returns(() =>
                { return true; });

            Condutor cliente = new CondutorDataBuilder().GerarCondutorCompleto();
            cliente.Rg = "123";

            //act
            string resultado = clienteAppService.InserirNovo(cliente);
            //assert
            resultado.Should().Be("Já há um cliente cadastrado com este RG");
        }
        [TestMethod]
        public void NaoDeveChamarInserirComCondutorCondutorInvalido()
        {
            Mock<Condutor> mockCliente = new Mock<Condutor>();

            mockClienteRepository.Setup(x => x.ExisteCondutorComEsteCPF(0, "123")).Returns(() =>
            {
                return false;
            });

            mockClienteRepository.Setup(x => x.ExisteCondutorComEsteRG(0, "123")).Returns(() =>
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
            Mock<Condutor> mockCliente = new Mock<Condutor>();

            mockClienteRepository.Setup(x => x.ExisteCondutorComEsteCPF(0, "123")).Returns(() =>
            {
                return false;
            });

            mockClienteRepository.Setup(x => x.ExisteCondutorComEsteRG(0, "123")).Returns(() =>
            {
                return false;
            });

            mockCliente.Setup(x => x.Validar()).Returns(() =>
            {
                return "ESTA_VALIDO";
            });

            clienteAppService.InserirNovo(mockCliente.Object);

            mockClienteRepository.Verify(x => x.InserirNovo(mockCliente.Object));
        }
        [TestMethod]
        public void DeveChamarEditar()
        {
            Mock<Condutor> mockCliente = new Mock<Condutor>();

            mockClienteRepository.Setup(x => x.ExisteCondutorComEsteCPF(0, "123")).Returns(() =>
            {
                return false;
            });

            mockClienteRepository.Setup(x => x.ExisteCondutorComEsteRG(0, "123")).Returns(() =>
            {
                return false;
            });

            mockCliente.Setup(x => x.Validar()).Returns(() =>
            {
                return "ESTA_VALIDO";
            });

            clienteAppService.Editar(1, mockCliente.Object);

            mockClienteRepository.Verify(x => x.Editar(1, mockCliente.Object));
        }
        [TestMethod]
        public void DeveChamarExcluir()
        {

            // act
            var resultado = clienteAppService.Excluir(mockCliente.Object.Id);
            //assert
            mockClienteRepository.Verify(x => x.Excluir(mockCliente.Object.Id));

            resultado.Should().Be(true);
        }
        [TestMethod]
        public void DeveChamarSelecionarPorId()
        {
            //arrange
            Condutor cliente = new CondutorDataBuilder().GerarCondutorCompleto();

            mockClienteRepository.Setup(x => x.SelecionarPorId(1)).Returns(() =>
            {
                return cliente;
            });
            //act
            var resultado = clienteAppService.SelecionarPorId(1);
            //assert
            mockClienteRepository.Verify(x => x.SelecionarPorId(1));
            resultado.Should().Be(cliente);
        }
        [TestMethod]
        public void DeveChamarExiste()
        {
            Condutor cliente = new CondutorDataBuilder().GerarCondutorCompleto();

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

            Condutor cliente = new CondutorDataBuilder().GerarCondutorCompleto();
            List<Condutor> clientees = new List<Condutor>() { cliente };

            mockClienteRepository.Setup(x => x.SelecionarTodos()).Returns(() =>
            {
                return clientees;
            });

            var resultado = clienteAppService.SelecionarTodos();

            resultado.Count.Should().Be(1);
        }
    }
}
