using e_Locadora5.DataBuilderTest.FuncionarioModule;
using e_Locadora5.Dominio.FuncionarioModule;
using e_Locadora5.Infra.ORM.FuncionarioModule;
using e_Locadora5.Infra.ORM.ParceiroModule;
using e_Locadora5.Infra.SQL;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.EFTests.FuncionarioModule
{
    [TestClass]
    public class FuncionarioEFTest
    {
        FuncionarioOrmDAO FuncionarioRepositoryEF;
        public FuncionarioEFTest()
        {
            FuncionarioRepositoryEF = new FuncionarioOrmDAO(new LocadoraDbContext());
            Db.Update("DELETE FROM [TBFUNCIONARIO]");
            //Db.Update("DELETE FROM TBLOCACAO_TBTAXASSERVICOS");
            //Db.Update("DELETE FROM TBLOCACAO");
        }

        [TestMethod]
        public void DeveInserirFuncionarioNoBanco()
        {
            DateTime hoje = new DateTime(2021, 08, 17);
            Funcionario funcionario = new Funcionario("Rodrigo Constantino", "20220220222", "roConsta", "dsa5d22", hoje, 1572);

            FuncionarioRepositoryEF.InserirNovo(funcionario);


            var funcionarioEncontrado = FuncionarioRepositoryEF.SelecionarPorId(funcionario.Id);
            funcionarioEncontrado.Should().Be(funcionario);
        }
        [TestMethod]
        public void DeveAtualizarUmFuncionario()
        {
            DateTime hoje = new DateTime(2021, 08, 17);
            Funcionario funcionario = new Funcionario("Rodrigo Constantino", "20220220222", "roConsta", "dsa5d22", hoje, 1572);

            FuncionarioRepositoryEF.InserirNovo(funcionario);
            var funcionarioEditado = new Funcionario("Rodrigo Constantino", "10110110111", "roConsta", "dsa5d22", hoje, 1572);

            FuncionarioRepositoryEF.Editar(funcionario.Id, funcionarioEditado);

            var funcionarioEncontrado = FuncionarioRepositoryEF.SelecionarPorId(funcionario.Id);
            funcionarioEncontrado.Should().Be(funcionarioEditado);
        }
        [TestMethod]
        public void DeveExcluirUmFuncionario()
        {
            DateTime hoje = new DateTime(2021, 08, 17);
            Funcionario funcionario = new Funcionario("Rodrigo Constantino", "20220220222", "roConsta", "dsa5d22", hoje, 1572);

            FuncionarioRepositoryEF.InserirNovo(funcionario);

            FuncionarioRepositoryEF.Excluir(funcionario.Id);

            var funcionarioEncontrado = FuncionarioRepositoryEF.SelecionarPorId(funcionario.Id);
            funcionarioEncontrado.Should().BeNull();
        }
        [TestMethod]
        public void DeveSelecionarUmFuncionarioPorId()
        {
            DateTime hoje = new DateTime(2021, 08, 17);
            Funcionario funcionario = new Funcionario("Rodrigo Constantino", "20220220222", "roConsta", "dsa5d22", hoje, 1572);

            FuncionarioRepositoryEF.InserirNovo(funcionario);


            var funcionarioEncontrado = FuncionarioRepositoryEF.SelecionarPorId(funcionario.Id);
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
                FuncionarioRepositoryEF.InserirNovo(f);


            var funcionarioEncontrado = FuncionarioRepositoryEF.SelecionarTodos();
            funcionarioEncontrado.Should().HaveCount(4);
        }
    }
}

