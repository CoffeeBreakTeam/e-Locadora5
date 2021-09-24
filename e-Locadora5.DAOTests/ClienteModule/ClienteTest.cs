using e_Locadora5.Aplicacao.ClienteModule;
using e_Locadora5.DataBuilderTest.ClienteModule;
using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Infra.SQL;
using e_Locadora5.Infra.SQL.ClienteModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.DAOTests.ClienteModule
{
    [TestClass]
    public class ClienteTest
    {
        ClienteDAO clienteDAO;
        string nome;
        string endereco;
        string telefone;
        string rg;
        string cpf;
        string cnpj;
        string email;
        ClienteAppService clienteAppService;
        public ClienteTest()
        {
            clienteDAO = new ClienteDAO();
            LimparTabelas();
            clienteAppService = new ClienteAppService(new ClienteDAO());
            LimparTabelas();
            nome = "Joao";
            endereco = "rua joao manoel numero 195";
            telefone = "49995625361";
            rg = "5231255";
            cpf = "10250540499";
            cnpj = "";
            email = "Joao.pereira@gmail.com";

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
            Clientes cliente = new ClienteDataBuilder().GerarClienteCompleto();
            //action
            clienteDAO.InserirCliente(cliente);         

            //assert
            var grupoVeiculoEncontrado = clienteDAO.SelecionarClientePorId(cliente.Id);
            grupoVeiculoEncontrado.Should().Be(cliente);
        }      
        [TestMethod]
        public void Deve_Atualizar_Cliente()
        {           
            //arrange
            var cliente = new Clientes("FDG", "rua souza", "9524282242", "", "", "02914460029615", "Joao.pereira@gmail.com");
            clienteAppService.InserirNovo(cliente);
            //var clienteAtualizado = new Clientes("FDG limitada", "rua souza khdsd", "9524282242", "", "", "02914460029615", "Joao.pereira@gmail.com");

            Clientes clienteAtualizado = new ClienteDataBuilder().ComCPF("111212139")
              .ComEmail(email)
              .ComEndereco(endereco)
              .ComTelefone(telefone)
              .ComRG(rg).ComCNPJ(cnpj)
              .ComNome(nome)
              .Build();

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
            clienteDAO.InserirCliente(cliente);
            //action
            Clientes clienteEncontrado = clienteDAO.SelecionarClientePorId(cliente.Id);

            //assert
            clienteEncontrado.Should().NotBeNull();
        }
        [TestMethod]
        public void Deve_Excluir_Cliente_Cnpj()
        {
            //arrange
            var cliente = new Clientes("FDG", "rua souza", "9524282242", "", "", "02914460029615", "Joao.pereira@gmail.com");
            clienteDAO.InserirCliente(cliente);
            //action
            clienteDAO.ExcluirCliente(cliente.Id);

            //assert
            var ClienteEncrontrado = clienteDAO.SelecionarClientePorId(cliente.Id);
            ClienteEncrontrado.Should().BeNull();
        }
        [TestMethod]
        public void DeveSelecionar_TodosClientes()
        {
            //arrange
            var c1 = new Clientes("FDG", "rua souza", "9524282242", "", "", "02914460029615", "Joao.pereira@gmail.com");
            clienteDAO.InserirCliente(c1);

            var c2 = new Clientes("NDD", "rua souza", "9524282242", "", "", "02914460029614", "Joao.pereira@gmail.com");
            clienteDAO.InserirCliente(c2);

            var c3 = new Clientes("JBS", "rua souza", "9524282242", "", "", "02914460029616", "Joao.pereira@gmail.com");
            clienteDAO.InserirCliente(c3);

            //action
            var clientes = clienteDAO.SelecionarTodosClientes();

            //assert
            clientes.Should().HaveCount(3);

        }
        [TestMethod]
        public void deveVerificarRepeticaoDeCPFParaEditar()
        {
            //arrange
            Clientes cliente = new ClienteDataBuilder().GerarClienteCompleto();        
            clienteDAO.InserirCliente(cliente);
            //act
            var resultado = clienteDAO.ExisteClienteComEsteCPF(123, cliente.CPF);

            //assert
            resultado.Should().Be(true);
        }
        [TestMethod]
        public void deveVerificarRepeticaoDeRGParaEditar()
        {
            //arrange
            Clientes cliente = new ClienteDataBuilder().GerarClienteCompleto();
            clienteDAO.InserirCliente(cliente);
            //act
            var resultado = clienteDAO.ExisteClienteComEsteRG(123, cliente.RG);

            //assert
            resultado.Should().Be(true);
        }
        [TestMethod]
        public void deveVerificarRepeticaoDeCPFParaInsetir()
        {
            //arrange
            Clientes cliente = new ClienteDataBuilder().GerarClienteCompleto();
            clienteDAO.InserirCliente(cliente);
            //act
            var resultado = clienteDAO.ExisteClienteComEsteCPF(0, cliente.CPF);

            //assert
            resultado.Should().Be(true);
        }
        [TestMethod]
        public void deveVerificarRepeticaoDeRGParaInserir()
        {
            //arrange
            Clientes cliente = new ClienteDataBuilder().GerarClienteCompleto();
            clienteDAO.InserirCliente(cliente);
            //act
            var resultado = clienteDAO.ExisteClienteComEsteRG(0, cliente.RG);

            //assert
            resultado.Should().Be(true);
        }
    }
}
