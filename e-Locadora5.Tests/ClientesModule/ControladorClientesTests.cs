using e_Locadora5.Aplicacao.ClienteModule;
using e_Locadora5.Controladores;
using e_Locadora5.Controladores.ClientesModule;
using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Infra.SQL.ClienteModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace e_Locadora5.Tests.ClientesModule
{
    [TestClass]
    [TestCategory("Controladores")]
    public class ControladorClientesTests
    {
        string nome;
        string endereco;
        string telefone;
        string rg;
        string cpf;
        string cnpj;
        string email;
        ClienteAppService clienteAppService;
        Clientes cliente;

        public ControladorClientesTests()
        {          
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
            cliente = new ClienteDataBuilder().ComCPF(cpf)
               .ComEmail(email)
               .ComEndereco(endereco)
               .ComTelefone(telefone)
               .ComRG(rg).ComCNPJ(cnpj)
               .ComNome(nome)
               .Build();

            //action
            clienteAppService.InserirNovoCliente(cliente);

            //assert
            var grupoVeiculoEncontrado = clienteAppService.SelecionarPorId(cliente.Id);
            grupoVeiculoEncontrado.Should().Be(cliente);
        }
        [TestMethod]
        public void Deve_InserirNovo_Cliente_Cnpj()
        {
            //arrange
           
            cliente = new ClienteDataBuilder().ComCPF("")
               .ComEmail(email)
               .ComEndereco(endereco)
               .ComTelefone(telefone)
               .ComRG("").ComCNPJ(cnpj)
               .ComNome(nome)
               .Build();
            //action
            clienteAppService.InserirNovoCliente(cliente);

            //assert
            var ClienteEncontrado = clienteAppService.SelecionarPorId(cliente.Id);
            ClienteEncontrado.Should().Be(cliente);
        }
        [TestMethod]
        public void Deve_Atualizar_Cliente()
        {
            //arrange
            cliente = new ClienteDataBuilder().ComCPF(cpf)
               .ComEmail(email)
               .ComEndereco(endereco)
               .ComTelefone(telefone)
               .ComRG(rg).ComCNPJ(cnpj)
               .ComNome(nome)
               .Build();
            clienteAppService.InserirNovoCliente(cliente);

            Clientes clienteAtualizado = new ClienteDataBuilder().ComCPF("111212139")
              .ComEmail(email)
              .ComEndereco(endereco)
              .ComTelefone(telefone)
              .ComRG(rg).ComCNPJ(cnpj)
              .ComNome(nome)
              .Build();

            //action
            clienteAppService.EditarCliente(cliente.Id, clienteAtualizado);

            //assert
            Clientes clienteeditado = clienteAppService.SelecionarPorId(cliente.Id);
            clienteeditado.Should().Be(clienteAtualizado);
        }
        [TestMethod]
        public void Deve_SelecionarPorId_Cliente_Cnpj()
        {
            //arrange
            cliente = new ClienteDataBuilder().ComCPF(cpf)
               .ComEmail(email)
               .ComEndereco(endereco)
               .ComTelefone(telefone)
               .ComRG(rg).ComCNPJ(cnpj)
               .ComNome(nome)
               .Build();

            clienteAppService.InserirNovoCliente(cliente);

            
            //action
            Clientes clienteEncontrado = clienteAppService.SelecionarPorId(cliente.Id);

            //assert
            clienteEncontrado.Should().NotBeNull();
        }
        [TestMethod]
        public void Deve_Excluir_Cliente_Cnpj()
        {
            //arrange
            cliente = new ClienteDataBuilder().ComCPF(cpf)
               .ComEmail(email)
               .ComEndereco(endereco)
               .ComTelefone(telefone)
               .ComRG(rg).ComCNPJ(cnpj)
               .ComNome(nome)
               .Build();
            clienteAppService.InserirNovoCliente(cliente);
           
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
            var c1 = new ClienteDataBuilder().ComCPF(cpf)
              .ComEmail(email)
              .ComEndereco(endereco)
              .ComTelefone(telefone)
              .ComRG(rg).ComCNPJ(cnpj)
              .ComNome(nome)
              .Build();

            clienteAppService.InserirNovoCliente(c1);

            var c2 = new ClienteDataBuilder().ComCPF("1231231")
              .ComEmail(email)
              .ComEndereco(endereco)
              .ComTelefone(telefone)
              .ComRG("5345345").ComCNPJ("23452345")
              .ComNome("Jucão")
              .Build();

            clienteAppService.InserirNovoCliente(c2);

            var c3 = new ClienteDataBuilder().ComCPF("6576756")
              .ComEmail(email)
              .ComEndereco(endereco)
              .ComTelefone(telefone)
              .ComRG("7777777").ComCNPJ("1453246")
              .ComNome("Arthur")
              .Build();

            clienteAppService.InserirNovoCliente(c3);

            //action
            var clientes = clienteAppService.SelecionarTodos();

            //assert
            clientes.Should().HaveCount(3);
            
        }
    }
}
