using e_Locadora5.Aplicacao.ClienteModule;
using e_Locadora5.Aplicacao.CondutorModule;
using e_Locadora5.Dominio.CondutoresModule;
using e_Locadora5.Infra.GeradorLogs;
using e_Locadora5.Infra.SQL.CondutorModule;
using e_Locadora5.Tests.CondutoresModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace e_Locadora5.AppServiceTests
{
    [TestClass]
    public class CondutorAppServiceTests
    {

        CondutorAppService condutorAppService;
        Mock<ICondutorRepository> mockCondutorRepository;
        Mock<Condutor> mockCondutor;
        
        public CondutorAppServiceTests()
        {
            mockCondutorRepository = new Mock<ICondutorRepository>();
            condutorAppService = new CondutorAppService(mockCondutorRepository.Object);
            mockCondutor = new Mock<Condutor>();
        }

        [TestMethod]
        public void NaoDeveChamarInserirComCPFRepetido()
        {
            //arrange
            mockCondutorRepository.Setup(x => x.ExisteCondutorComEsteCPF(0,"123"))
                .Returns(() =>
                { return true; 
               });

            Condutor condutor = new CondutorDataBuilder().GerarCondutorCompleto();
            condutor.Cpf = "123";

            //act
            string resultado = condutorAppService.InserirNovo(condutor);
            //assert
            resultado.Should().Be("Já há um condutor cadastrado com este CPF");
        }
        [TestMethod]
        public void NaoDeveChamarInserirComRGRepetido()
        {
            //arrange
            mockCondutorRepository.Setup(x => x.ExisteCondutorComEsteRG(0,"123"))
                .Returns(() =>
                { return true; });

            Condutor condutor = new CondutorDataBuilder().GerarCondutorCompleto();
            condutor.Rg = "123";

            //act
            string resultado = condutorAppService.InserirNovo(condutor);
            //assert
            resultado.Should().Be("Já há um condutor cadastrado com este RG");
        }
        [TestMethod]
        public void NaoDeveChamarInserirComCondutorCondutorInvalido()
        {
            Mock<Condutor> mockCondutor = new Mock<Condutor>();

            mockCondutorRepository.Setup(x => x.ExisteCondutorComEsteCPF(0,"123")).Returns(() =>
            {
                return false;
            });

            mockCondutorRepository.Setup(x => x.ExisteCondutorComEsteRG(0,"123")).Returns(() =>
            {
                return false;
            });

            mockCondutor.Setup(x => x.Validar()).Returns(() =>
            {
                return "O atributo nome é obrigatório e não pode ser vazio.";
            });

            var resultado = condutorAppService.InserirNovo(mockCondutor.Object);
        
            //assert
            resultado.Should().Be("O atributo nome é obrigatório e não pode ser vazio.");
        }
        [TestMethod]
        public void DeveChamarInserir()
        {
            Mock<Condutor> mockCondutor = new Mock<Condutor>();

            mockCondutorRepository.Setup(x => x.ExisteCondutorComEsteCPF(0,"123")).Returns(() =>
                {
                    return false;
                });

            mockCondutorRepository.Setup(x => x.ExisteCondutorComEsteRG(0,"123")).Returns(() =>
                {
                    return false;
                });

            mockCondutor.Setup(x => x.Validar()).Returns(() =>
                {
                    return "ESTA_VALIDO";
                });

            condutorAppService.InserirNovo(mockCondutor.Object);

            mockCondutorRepository.Verify(x => x.InserirNovo(mockCondutor.Object));
        }
        [TestMethod]
        public void DeveChamarEditar()
        {
            Mock<Condutor> mockCondutor = new Mock<Condutor>();

            mockCondutorRepository.Setup(x => x.ExisteCondutorComEsteCPF(0,"123")).Returns(() =>
            {
                return false;
            });

            mockCondutorRepository.Setup(x => x.ExisteCondutorComEsteRG(0,"123")).Returns(() =>
            {
                return false;
            });

            mockCondutor.Setup(x => x.Validar()).Returns(() =>
            {
                return "ESTA_VALIDO";
            });

            condutorAppService.Editar(1, mockCondutor.Object);

            mockCondutorRepository.Verify(x => x.Editar(1,mockCondutor.Object));
        }
        [TestMethod]
        public void DeveChamarExcluir()
        {

            // act
            var resultado = condutorAppService.Excluir(mockCondutor.Object.Id) ;
            //assert
            mockCondutorRepository.Verify(x => x.Excluir(mockCondutor.Object.Id));

            resultado.Should().Be(true);
        }
        [TestMethod]
        public void DeveChamarSelecionarPorId()
        {
            //arrange
            Condutor condutor = new CondutorDataBuilder().GerarCondutorCompleto();

            mockCondutorRepository.Setup(x => x.SelecionarPorId(1)).Returns(() =>
            {
                return condutor;
            });
            //act
            var resultado = condutorAppService.SelecionarPorId(1);
            //assert
            mockCondutorRepository.Verify(x => x.SelecionarPorId(1));
            resultado.Should().Be(condutor);
        }
        [TestMethod]
        public void DeveChamarExiste()
        {
            Condutor condutor = new CondutorDataBuilder().GerarCondutorCompleto();

            mockCondutorRepository.Setup(x => x.Existe(1)).Returns(() =>
            {
                return true;
            });

            var resultado = condutorAppService.Existe(1);

            mockCondutorRepository.Verify(x => x.Existe(1));
            resultado.Should().Be(true);
        }
        [TestMethod]
        public void DeveChamarSelecionarTodos()
        {

            Condutor condutor = new CondutorDataBuilder().GerarCondutorCompleto();
            List<Condutor> condutores = new List<Condutor>() { condutor};

            mockCondutorRepository.Setup(x => x.SelecionarTodos()).Returns(() =>
            {
                return  condutores;
            });

            var resultado = condutorAppService.SelecionarTodos();

            resultado.Count.Should().Be(1);
        }
    }
}
