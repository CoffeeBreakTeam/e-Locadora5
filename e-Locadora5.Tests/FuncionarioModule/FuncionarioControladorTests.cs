using e_Locadora5.Aplicacao.FuncionarioModule;
using e_Locadora5.Dominio.FuncionarioModule;
using e_Locadora5.Infra.SQL;
using e_Locadora5.Infra.SQL.FuncionarioModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace e_Locadora5.Tests.FuncionarioModule
{
    [TestClass]
    [TestCategory("Controladores")]
    public class FuncionarioControladorTests
    {
        FuncionarioAppService controlador = null;

        public FuncionarioControladorTests()
        {
            controlador = new FuncionarioAppService(new FuncionarioDAO());


            Db.Update("DELETE FROM [TBFUNCIONARIO]");
            Db.Update("DELETE FROM TBLOCACAO_TBTAXASSERVICOS");
            Db.Update("DELETE FROM TBLOCACAO");
        }

        [TestMethod]
        public void DeveInserirUmFuncionario()
        {
            DateTime hoje = new DateTime(2021, 08, 17);
            Funcionario funcionario = new Funcionario("Rodrigo Constantino","20220220222","roConsta","dsa5d22",hoje, 1572);

            controlador.InserirNovo(funcionario);


            var funcionarioEncontrado = controlador.SelecionarPorId(funcionario.Id);
            funcionarioEncontrado.Should().Be(funcionario);
        }
        [TestMethod]
        public void DeveAtualizarUmFuncionario()
        {
            DateTime hoje = new DateTime(2021, 08, 17);
            Funcionario funcionario = new Funcionario("Rodrigo Constantino", "20220220222", "roConsta", "dsa5d22", hoje, 1572);

            controlador.InserirNovo(funcionario);
            var funcionarioEditado = new Funcionario("Rodrigo Constantino", "10110110111", "roConsta", "dsa5d22", hoje, 1572);

            controlador.Editar(funcionario.Id, funcionarioEditado);

            var funcionarioEncontrado = controlador.SelecionarPorId(funcionario.Id);
            funcionarioEncontrado.Should().Be(funcionarioEditado);
        }
        [TestMethod]
        public void DeveExcluirUmFuncionario()
        {
            DateTime hoje = new DateTime(2021, 08, 17);
            Funcionario funcionario = new Funcionario("Rodrigo Constantino", "20220220222", "roConsta", "dsa5d22", hoje, 1572);

            controlador.InserirNovo(funcionario);

            controlador.Excluir(funcionario.Id);

            var funcionarioEncontrado = controlador.SelecionarPorId(funcionario.Id);
            funcionarioEncontrado.Should().BeNull();
        }
        [TestMethod]
        public void DeveSelecionarUmFuncionarioPorId()
        {
            DateTime hoje = new DateTime(2021, 08, 17);
            Funcionario funcionario = new Funcionario("Rodrigo Constantino", "20220220222", "roConsta", "dsa5d22", hoje, 1572);

            controlador.InserirNovo(funcionario);


            var funcionarioEncontrado = controlador.SelecionarPorId(funcionario.Id);
            funcionarioEncontrado.Should().NotBeNull();
        }
        [TestMethod]
        public void DeveSelecionarTodosFuncionarios()
        {
            DateTime hoje = new DateTime(2021, 08, 17);
            var funcionarios = new List<Funcionario>
            {
                new Funcionario("Rodrigo Constantino", "20220220222", "roConsta", "dsa5d22", hoje, 1572),
                new Funcionario("Rodrigo Constantino", "20220220223", "roConsta1", "dsa5d22", hoje, 1572),
                new Funcionario("Rodrigo Constantino", "20220220224", "roConsta2", "dsa5d22", hoje, 1572),
                new Funcionario("Rodrigo Constantino", "20220220225", "roConsta3", "dsa5d22", hoje, 1572),
            
            };
            foreach (var f in funcionarios)
                controlador.InserirNovo(f);


            var funcionarioEncontrado = controlador.SelecionarTodos();
            funcionarioEncontrado.Should().HaveCount(4);
        }
    }
}
