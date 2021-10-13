using e_Locadora5.DataBuilderTest.ClienteModule;
using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.CondutoresModule;
using e_Locadora5.Infra.ORM.ClienteModule;
using e_Locadora5.Infra.ORM.CondutorModule;
using e_Locadora5.Infra.ORM.ParceiroModule;
using e_Locadora5.Infra.SQL;
using e_Locadora5.Infra.SQL.ClienteModule;
using e_Locadora5.Tests.CondutoresModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.EFTests.CondutorModule
{
    [TestClass]
    public class CondutorEF
    {
        ICondutorRepository condutorRepository;
        IClienteRepository clienteRepository;
        public CondutorEF()
        {
            LocadoraDbContext locadoraDbContext = new LocadoraDbContext();
            condutorRepository = new CondutorOrmDAO(locadoraDbContext);
            clienteRepository = new ClienteOrmDAO(locadoraDbContext);
            Db.Update("DELETE FROM TBCONDUTOR");
            Db.Update("DELETE FROM TBCLIENTE");
        }

        [TestCleanup()]
        public void LimparTabelas()
        {
            //Db.Update("DELETE FROM TBLOCACAO_TBTAXASSERVICOS");
            //Db.Update("DELETE FROM TBLOCACAO");
            Db.Update("DELETE FROM TBCONDUTOR");
            Db.Update("DELETE FROM TBCLIENTE");
        }
        public Cliente GerarCliente()
        {
            Cliente cliente = new ClienteDataBuilder().GerarClienteCompleto();
            clienteRepository.InserirNovo(cliente);

            return clienteRepository.SelecionarPorId(cliente.Id);

        }

        [TestMethod]
        public void deveInserirCondutor()
        {
            //arrange
            Condutor condutor = new CondutorDataBuilder().GerarCondutorCompleto();
            condutor.Cliente = GerarCliente();
           
            //act
            condutorRepository.InserirNovo(condutor);
            //assert
            var condutorEncontrado = condutorRepository.SelecionarPorId(condutor.Id);
            condutorEncontrado.Nome.Should().Be(condutor.Nome);

        }
        [TestMethod]
        public void deveEditarCondutor()
        {
            //arrange
            Condutor condutor = new CondutorDataBuilder().GerarCondutorCompleto();
            Cliente cliente = GerarCliente();
            condutor.Cliente = cliente;

            condutorRepository.InserirNovo(condutor);

            Condutor condutorNovo = new CondutorDataBuilder().GerarCondutorCompleto();
            condutorNovo.Cliente = cliente;
            condutorNovo.Nome = "Novo nome";
            //act

            condutorRepository.Editar(condutor.Id, condutorNovo);

            //assert
            var condutorEncontrado = condutorRepository.SelecionarPorId(condutor.Id);
            Assert.AreEqual(condutorNovo.Nome, condutorEncontrado.Nome);
            
        }
        [TestMethod]
        public void deveExcluirCondutor()
        {
            //arrange
            Condutor condutor = new CondutorDataBuilder().GerarCondutorCompleto();
            condutor.Cliente = GerarCliente();
            condutorRepository.InserirNovo(condutor);
            //act
            condutorRepository.Excluir(condutor.Id);

            //assert
            var condutorEncontrado = condutorRepository.SelecionarPorId(condutor.Id);
            condutorEncontrado.Should().Be(null);

        }
        [TestMethod]
        public void deveSelecionarCondutorPorID()
        {
            //arrange
            Condutor condutor = new CondutorDataBuilder().GerarCondutorCompleto();
            condutor.Cliente = GerarCliente();
            condutorRepository.InserirNovo(condutor);
            //act
            var condutorEncontrado = condutorRepository.SelecionarPorId(condutor.Id);
            //assert
            condutorEncontrado.Nome.Should().Be(condutor.Nome);

        }
        [TestMethod]
        public void deveSelecionarTodosCondutores()
        {
            //arrange
            Condutor condutor = new CondutorDataBuilder().GerarCondutorCompleto();
            Condutor condutor2 = new CondutorDataBuilder().GerarCondutorCompleto();
            condutor.Cliente = GerarCliente();

            condutorRepository.InserirNovo(condutor);
            condutorRepository.InserirNovo(condutor2);

            //act
            var condutorEncontrado = condutorRepository.SelecionarTodos();
            //assert

            condutorEncontrado.Count.Should().Be(2);
        }
        [TestMethod]
        public void deveSelecionarTodosCondutoresComCNHVencida()
        {
            //arrange
            Condutor condutor = new CondutorDataBuilder().GerarCondutorCompleto();
            condutor.ValidadeCNH = new DateTime(2020,10,10);
            Condutor condutor2 = new CondutorDataBuilder().GerarCondutorCompleto();
            condutor2.ValidadeCNH = new DateTime(2020, 10, 10);

            var cliente = GerarCliente();
            condutor.Cliente = cliente;
            condutor2.Cliente = cliente;


            condutorRepository.InserirNovo(condutor);
            condutorRepository.InserirNovo(condutor2);

            //act
            var condutorEncontrado = condutorRepository.SelecionarCondutoresComCnhVencida(DateTime.Today);
            //assert

            condutorEncontrado.Count.Should().Be(2);
        }
        [TestMethod]
        public void deveVerificarRepeticaoDeCPFParaEditar()
        {
            //arrange
            Condutor condutor = new CondutorDataBuilder().GerarCondutorCompleto();
            Condutor condutor2 = new CondutorDataBuilder().GerarCondutorCompleto();
            condutor.Cliente = GerarCliente();
            condutor2.Cliente = GerarCliente();
            condutorRepository.InserirNovo(condutor);
            condutorRepository.InserirNovo(condutor2);
            //act
            var resultado = condutorRepository.ExisteCondutorComEsteCPF(condutor2.Id, condutor.Cpf);

            //assert
            resultado.Should().Be(true);
        }
        [TestMethod]
        public void deveVerificarRepeticaoDeCPFParaInserir()
        {
            //arrange
            Condutor condutor = new CondutorDataBuilder().GerarCondutorCompleto();
            condutor.Cliente = GerarCliente();
            condutorRepository.InserirNovo(condutor);
            //act
            var resultado = condutorRepository.ExisteCondutorComEsteCPF(0, condutor.Cpf);

            //assert

            resultado.Should().Be(true);
        }
        [TestMethod]
        public void deveVerificarRepeticaoDeRGParaEditar()
        {
            //arrange
            Condutor condutor = new CondutorDataBuilder().GerarCondutorCompleto();
            Condutor condutor2 = new CondutorDataBuilder().GerarCondutorCompleto();
            condutor.Cliente = GerarCliente();
            condutorRepository.InserirNovo(condutor);
            condutor2.Nome = "Jucão";
            condutorRepository.InserirNovo(condutor2);
            //act 

            var resultado = condutorRepository.ExisteCondutorComEsteRG(condutor2.Id, condutor.Rg);

            //assert

            resultado.Should().Be(true);

        }
        [TestMethod]
        public void deveVerificarRepeticaoDeRGParaInserir()
        {
            //arrange
            Condutor condutor = new CondutorDataBuilder().GerarCondutorCompleto();
            condutor.Cliente = GerarCliente();
            condutorRepository.InserirNovo(condutor);
            //act 

            var resultado = condutorRepository.ExisteCondutorComEsteRG(0, condutor.Rg);

            //assert

            resultado.Should().Be(true);

        }


    }
}
