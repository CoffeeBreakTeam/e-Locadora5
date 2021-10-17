using e_Locadora5.DataBuilderTest.ParceiroModule;
using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Infra.SQL;
using e_Locadora5.Infra.SQL.ParceiroModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.DAOTests.ParceiroModule
{
    [TestClass]
    public class ParceiroDAOTest
    {
        ParceiroDAO parceiroDAO = new ParceiroDAO();

        [TestCleanup()]
        public void LimparTabelas()
        {
            Db.Update("DELETE FROM TBPARCEIROS");
        }

        [TestMethod]
        public void Deve_InserirNovo_Parceiro()
        {
            //Arrange
            Parceiro novoParceiro = new ParceiroDataBuilder().GerarParceiroCompleto();

            //Action
            parceiroDAO.InserirNovo(novoParceiro);

            //Assert
            var parceiroInserido = parceiroDAO.SelecionarPorId(novoParceiro.Id);
            parceiroInserido.Should().Be(novoParceiro);
        }

        [TestMethod]
        public void Deve_Editar_Parceiro()
        {
            //Arrange
            Parceiro parceiro = new ParceiroDataBuilder().GerarParceiroCompleto();
            Parceiro parceiroEditado = new ParceiroDataBuilder().ComNome("Roberto carlos").Build();
            

            //Action
            parceiroDAO.InserirNovo(parceiro);

            parceiroDAO.Editar(parceiro.Id, parceiroEditado);

            //Assert
            var parceiroEncontrado = parceiroDAO.SelecionarPorId(parceiro.Id);
            parceiroEncontrado.Nome.Should().Be(parceiroEditado.Nome);
        }

        [TestMethod]
        public void Deve_Excluir_Parceiro()
        {
            //Arrange
            Parceiro parceiro = new ParceiroDataBuilder().GerarParceiroCompleto();

            //Action
            parceiroDAO.InserirNovo(parceiro);

            parceiroDAO.Excluir(parceiro.Id);

            //Assert
            var parceiroExcludio = parceiroDAO.SelecionarPorId(parceiro.Id);
            parceiroExcludio.Should().BeNull();
        }

        [TestMethod]
        public void Deve_Selecionar_Parceiro_Por_ID()
        {
            //Arrange
            Parceiro parceiro = new ParceiroDataBuilder().GerarParceiroCompleto();

            //Action
            parceiroDAO.InserirNovo(parceiro);

            //Assert
            var parceiroExcludio = parceiroDAO.SelecionarPorId(parceiro.Id);
            parceiroExcludio.Should().Be(parceiro);
        }

        [TestMethod]
        public void Deve_Selecionar_Todos_Parceiros()
        {
            //Arrange
            Parceiro parceiro = new ParceiroDataBuilder().GerarParceiroCompleto();

            //Action
            parceiroDAO.InserirNovo(parceiro);

            //Assert
            var todosParceiros = parceiroDAO.SelecionarTodos();
            todosParceiros.Should().HaveCount(1);
        }
    }
}
