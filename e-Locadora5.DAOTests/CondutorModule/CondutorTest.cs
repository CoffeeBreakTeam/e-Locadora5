using e_Locadora5.DataBuilderTest.ClienteModule;
using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.CondutoresModule;
using e_Locadora5.Infra.SQL;
using e_Locadora5.Infra.SQL.ClienteModule;
using e_Locadora5.Infra.SQL.CondutorModule;
using e_Locadora5.Tests.CondutoresModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.DAOTests.CondutorModule
{
    [TestClass]
    public class CondutorTest
    {
        CondutorDAO condutorDAO;
        ClienteDAO clienteDAO;
        public CondutorTest()
        {
            condutorDAO = new CondutorDAO();
            clienteDAO = new ClienteDAO();
            LimparTabelas();
        }
      

        public Clientes GerarCliente()
        {
            Clientes cliente = new ClienteDataBuilder().GerarClienteCompleto();
            clienteDAO.InserirCliente(cliente);

            return clienteDAO.SelecionarClientePorId(cliente.Id);

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
        public void deveInserirCondutor()
        {
            //arrange
            Condutor condutor = new CondutorDataBuilder().GerarCondutorCompleto();
            condutor.Cliente = GerarCliente();
            //act
            condutorDAO.InserirNovo(condutor);
            //assert
            var condutorEncontrado = condutorDAO.SelecionarPorId(condutor.Id);
            condutorEncontrado.Nome.Should().Be(condutor.Nome);

        }
        [TestMethod]
        public void deveEditarCondutor()
        {
            //arrange
            Condutor condutor = new CondutorDataBuilder().GerarCondutorCompleto();
            Clientes cliente = GerarCliente();
            condutor.Cliente = cliente;

            condutorDAO.InserirNovo(condutor);

            Condutor condutorNovo = new CondutorDataBuilder().GerarCondutorCompleto();
            condutorNovo.Cliente = cliente;
            condutorNovo.Nome = "Novo nome";
            //act


            condutorDAO.Editar(condutor.Id, condutorNovo);

            //assert
            var condutorEncontrado = condutorDAO.SelecionarPorId(condutor.Id);
            condutorEncontrado.Nome.Should().Be(condutorNovo.Nome);

        }
        [TestMethod]
        public void deveExcluirCondutor()
        {
            //arrange
            Condutor condutor = new CondutorDataBuilder().GerarCondutorCompleto();
            condutor.Cliente = GerarCliente();
            condutorDAO.InserirNovo(condutor);
            //act
            condutorDAO.Excluir(condutor.Id);

            //assert
            var condutorEncontrado = condutorDAO.SelecionarPorId(condutor.Id);
            condutorEncontrado.Should().Be(null);

        }
        [TestMethod]
        public void deveSelecionarCondutorPorID()
        {
            //arrange
            Condutor condutor = new CondutorDataBuilder().GerarCondutorCompleto();
            condutor.Cliente = GerarCliente();
            condutorDAO.InserirNovo(condutor);
            //act
            var condutorEncontrado = condutorDAO.SelecionarPorId(condutor.Id);
            //assert
            condutorEncontrado.Nome.Should().Be(condutor.Nome);

        }
        [TestMethod]
        public void deveSelecionarTodosCondutores()
        {
            //arrange
            Condutor condutor = new CondutorDataBuilder().GerarCondutorCompleto();
            condutor.Cliente = GerarCliente();

            condutorDAO.InserirNovo(condutor);          
            condutorDAO.InserirNovo(condutor);           
            
            //act
            var condutorEncontrado = condutorDAO.SelecionarTodos();
            //assert

            condutorEncontrado.Count.Should().Be(2);
        }

            [TestMethod]
        public void deveVerificarRepeticaoDeCPFParaEditar()
        {
            //arrange
            Condutor condutor = new CondutorDataBuilder().GerarCondutorCompleto();
            condutor.Cliente = GerarCliente();
            condutorDAO.InserirNovo(condutor);
            //act
            var resultado = condutorDAO.ExisteCondutorComEsteCPF(123,condutor.Cpf);

            //assert
            resultado.Should().Be(true);
        }
        [TestMethod]
        public void deveVerificarRepeticaoDeCPFParaInserir()
        {
            //arrange
            Condutor condutor = new CondutorDataBuilder().GerarCondutorCompleto();
            condutor.Cliente = GerarCliente();
            condutorDAO.InserirNovo(condutor);
            //act
            var resultado = condutorDAO.ExisteCondutorComEsteCPF(0, condutor.Cpf);

            //assert

            resultado.Should().Be(true);
        }
        [TestMethod]
        public void deveVerificarRepeticaoDeRGParaEditar()
        {
            //arrange
            Condutor condutor = new CondutorDataBuilder().GerarCondutorCompleto();
            condutor.Cliente = GerarCliente();
            condutorDAO.InserirNovo(condutor);
            //act 

            var resultado = condutorDAO.ExisteCondutorComEsteRG(123, condutor.Rg);

            //assert

            resultado.Should().Be(true);

        }
        [TestMethod]
        public void deveVerificarRepeticaoDeRGParaInserir()
        {
            //arrange
            Condutor condutor = new CondutorDataBuilder().GerarCondutorCompleto();
            condutor.Cliente = GerarCliente();
            condutorDAO.InserirNovo(condutor);
            //act 

            var resultado = condutorDAO.ExisteCondutorComEsteRG(0, condutor.Rg);

            //assert

            resultado.Should().Be(true);

        }
    }
}
