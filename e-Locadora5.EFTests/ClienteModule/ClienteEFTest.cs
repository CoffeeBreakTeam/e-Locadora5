﻿using e_Locadora5.DataBuilderTest.ClienteModule;
using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Infra.ORM.ClienteModule;
using e_Locadora5.Infra.ORM.ParceiroModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.EFTests.ClienteModule
{
    [TestClass]
    public class ClienteEFTest
    {
        ClienteOrmDAO clienteRepositoryEF;
        string nome;
        string endereco;
        string telefone;
        string rg;
        string cpf;
        string cnpj;
        string email;
        public ClienteEFTest()
        {
            nome = "Joao";
            endereco = "rua joao manoel numero 195";
            telefone = "49995625361";
            rg = "5231255";
            cpf = "10250540499";
            cnpj = "";
            email = "Joao.pereira@gmail.com";

            clienteRepositoryEF = new ClienteOrmDAO(new LocadoraDbContext());
        }

        [TestMethod]
        public void Deve_InserirNovo_Cliente_CPF()
        {
            //arrange        
            Clientes cliente = new ClienteDataBuilder().GerarClienteCompleto();
            //action
            clienteRepositoryEF.InserirNovo(cliente);

            //assert
            var clienteEncontado = clienteRepositoryEF.SelecionarPorId(cliente.Id);
            Assert.AreEqual(cliente, clienteEncontado);
        }
        [TestMethod]
        public void Deve_Atualizar_Cliente()
        {
            //arrange
            var cliente = new Clientes("FDG", "rua souza", "9524282242", "", "", "02914460029615", "Joao.pereira@gmail.com");
            clienteRepositoryEF.InserirNovo(cliente);
            //var clienteAtualizado = new Clientes("FDG limitada", "rua souza khdsd", "9524282242", "", "", "02914460029615", "Joao.pereira@gmail.com");

            Clientes clienteAtualizado = new ClienteDataBuilder().ComCPF("111212139")
              .ComEmail(email)
              .ComEndereco(endereco)
              .ComTelefone(telefone)
              .ComRG(rg).ComCNPJ(cnpj)
              .ComNome(nome)
              .Build();

            //action
            clienteRepositoryEF.Editar(cliente.Id, clienteAtualizado);

            //assert
            Clientes clienteeditado = clienteRepositoryEF.SelecionarPorId(cliente.Id);
            Assert.AreEqual(cliente, clienteeditado);

        }
        [TestMethod]
        public void Deve_SelecionarPorId_Cliente_Cnpj()
        {
            //arrange
            var cliente = new Clientes("FDG", "rua souza", "9524282242", "", "", "02914460029615", "Joao.pereira@gmail.com");
            clienteRepositoryEF.InserirNovo(cliente);
            //action
            Clientes clienteEncontrado = clienteRepositoryEF.SelecionarPorId(cliente.Id);

            //assert
            Assert.IsNotNull(clienteEncontrado);
        }
        [TestMethod]
        public void Deve_Excluir_Cliente_Cnpj()
        {
            //arrange
            var cliente = new Clientes("FDG", "rua souza", "9524282242", "", "", "02914460029615", "Joao.pereira@gmail.com");
            clienteRepositoryEF.InserirNovo(cliente);
            //action
            clienteRepositoryEF.Excluir(cliente.Id);

            //assert
            var ClienteEncontrado = clienteRepositoryEF.SelecionarPorId(cliente.Id);
            Assert.IsNull(ClienteEncontrado);
        }
        [TestMethod]
        public void DeveSelecionar_TodosClientes()
        {
            //arrange
            var c1 = new Clientes("FDG", "rua souza", "9524282242", "", "", "02914460029615", "Joao.pereira@gmail.com");
            clienteRepositoryEF.InserirNovo(c1);

            var c2 = new Clientes("NDD", "rua souza", "9524282242", "", "", "02914460029614", "Joao.pereira@gmail.com");
            clienteRepositoryEF.InserirNovo(c2);

            var c3 = new Clientes("JBS", "rua souza", "9524282242", "", "", "02914460029616", "Joao.pereira@gmail.com");
            clienteRepositoryEF.InserirNovo(c3);

            //action
            var clientes = clienteRepositoryEF.SelecionarTodos();

            //assert
            Assert.AreEqual(3, clientes.Count);          

        }
        [TestMethod]
        public void deveVerificarRepeticaoDeCPFParaEditar()
        {
            //arrange
            Clientes cliente = new ClienteDataBuilder().GerarClienteCompleto();
            clienteRepositoryEF.InserirNovo(cliente);
            //act
            var resultado = clienteRepositoryEF.ExisteClienteComEsteCPF(123, cliente.CPF);

            //assert   
            Assert.IsTrue(resultado);
        }
        [TestMethod]
        public void deveVerificarRepeticaoDeRGParaEditar()
        {
            //arrange
            Clientes cliente = new ClienteDataBuilder().GerarClienteCompleto();
            clienteRepositoryEF.InserirNovo(cliente);
            //act
            var resultado = clienteRepositoryEF.ExisteClienteComEsteRG(123, cliente.RG);

            //assert
            Assert.IsTrue(resultado);
        }
        [TestMethod]
        public void deveVerificarRepeticaoDeCPFParaInsetir()
        {
            //arrange
            Clientes cliente = new ClienteDataBuilder().GerarClienteCompleto();
            clienteRepositoryEF.InserirNovo(cliente);
            //act
            var resultado = clienteRepositoryEF.ExisteClienteComEsteCPF(0, cliente.CPF);

            //assert
            Assert.IsTrue(resultado);
        }
        [TestMethod]
        public void deveVerificarRepeticaoDeRGParaInserir()
        {
            //arrange
            Clientes cliente = new ClienteDataBuilder().GerarClienteCompleto();
            clienteRepositoryEF.InserirNovo(cliente);
            //act
            var resultado = clienteRepositoryEF.ExisteClienteComEsteRG(0, cliente.RG);

            //assert
            Assert.IsTrue(resultado);
        }
    }
}
