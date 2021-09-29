using e_Locadora5.Aplicacao.FuncionarioModule;
using e_Locadora5.DataBuilderTest.FuncionarioModule;
using e_Locadora5.Dominio.FuncionarioModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.AppServiceTests.FuncionarioModule
{
    [TestClass]
    public class FuncionarioAppServiceTest
    {
        FuncionarioAppService funcionarioAppService;
        Mock<IFuncionarioRepository> mockFuncionarioRepository;
        Mock<Funcionario> mockFuncionario;

        public FuncionarioAppServiceTest()
        {
            mockFuncionarioRepository =  new Mock<IFuncionarioRepository>();
            funcionarioAppService = new FuncionarioAppService(mockFuncionarioRepository.Object);
            mockFuncionario = new Mock<Funcionario>();
        }

        [TestMethod]
        public void DeveChamarInserir()
        {
            //arrange
            mockFuncionario.Setup(x => x.Validar()).Returns(() =>
                {
                    return "ESTA_VALIDO";
                }
            );
            //act
            funcionarioAppService.InserirNovo(mockFuncionario.Object);
            //assert
            mockFuncionarioRepository.Verify(x => x.InserirNovo(mockFuncionario.Object));

        }
        [TestMethod]
        public void DeveChamarEditar()
        {
            //arrange
            mockFuncionario.Setup(x => x.Validar()).Returns(() =>
            {
                return "ESTA_VALIDO";
            }
            );
            //act
            funcionarioAppService.Editar(0,mockFuncionario.Object);
            //assert
            mockFuncionarioRepository.Verify(x => x.Editar(0,mockFuncionario.Object));

        }
        [TestMethod]
        public void DeveChamarExcluir()
        {
            //arrange
            
            //act
            funcionarioAppService.Excluir(0);
            //assert
            mockFuncionarioRepository.Verify(x => x.Excluir(0));

        }
        [TestMethod]
        public void DeveChamarSelecionarPorId()
        {
            //arrange
            Funcionario funcionario = new FuncionarioDataBuilder().GerarFuncionarioCompleto();

            mockFuncionarioRepository.Setup(x => x.SelecionarPorId(1)).Returns(() =>
            {
                return funcionario;
            });


            //act
            funcionarioAppService.SelecionarPorId(1);
            //assert
            mockFuncionarioRepository.Verify(x => x.SelecionarPorId(1));

        }
        [TestMethod]
        public void DeveChamarSelecionarTodos()
        {
            //arrange
            Funcionario funcionario = new FuncionarioDataBuilder().GerarFuncionarioCompleto();
            List<Funcionario> funcionarios = new List<Funcionario>();
            funcionarios.Add(funcionario);

            mockFuncionarioRepository.Setup(x => x.SelecionarTodos()).Returns(() =>
            {
                return funcionarios;
            });


            //act
            funcionarioAppService.SelecionarTodos();
            //assert
            mockFuncionarioRepository.Verify(x => x.SelecionarTodos());

        }
    }
}
