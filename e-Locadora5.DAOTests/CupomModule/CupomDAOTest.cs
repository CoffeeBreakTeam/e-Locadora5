using e_Locadora5.DataBuilderTest.CupomModule;
using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Infra.GeradorLogs;
using e_Locadora5.Infra.SQL;
using e_Locadora5.Infra.SQL.CupomModule;
using e_Locadora5.Infra.SQL.ParceiroModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.DAOTests.CupomModule
{
    [TestClass]
    public class CupomDAOTest
    {
        public CupomDAOTest()
        {
            GeradorDeLog.ConfigurarLog();
        }

        [TestCleanup()]
        public void LimparTabelas()
        {
            Db.Update("DELETE FROM TBCUPONS");
        }

        [TestMethod]
        public void Deve_InserirNovo_Cupom()
        {
            //arrange
            ParceiroDAO parceiroDao = new ParceiroDAO();

            Parceiro parceiro = new Parceiro("Deko");

            //action
            parceiroDao.InserirParceiro(parceiro);

            CupomDAO cupomDAO = new CupomDAO();

            Cupons NovoCupom = new Cupons("Lucas", 100, 50, DateTime.Now, parceiro, 100);

            cupomDAO.InserirNovo(NovoCupom);

            //assert
            var cupomEncontrado = cupomDAO.SelecionarPorId(NovoCupom.Id);
            cupomEncontrado.Should().Be(NovoCupom);
        }

        [TestMethod]
        public void Deve_Editar_Cupom()
        {
            //arrange
            ParceiroDAO parceiroDao = new ParceiroDAO();

            Parceiro parceiro = new Parceiro("Deko");

            parceiroDao.InserirParceiro(parceiro);

            CupomDAO cupomDAO = new CupomDAO();

            Cupons cupom = new Cupons("Lucas", 100, 50, DateTime.Now, parceiro, 100);

            cupomDAO.InserirNovo(cupom);

            Cupons cupomAtualizado = new Cupons("Marcos", 100, 50, DateTime.Now, parceiro, 100);

            //action
            
            cupomDAO.Editar(cupom.Id, cupomAtualizado);

            //assert
            var cupomEditado = cupomDAO.SelecionarPorId(cupom.Id);
            cupomEditado.Should().Be(cupomAtualizado);
        }

        [TestMethod]
        public void Deve_Excluir_Cupom()
        {
            //arrange
            ParceiroDAO parceiroDao = new ParceiroDAO();

            Parceiro parceiro = new Parceiro("Deko");

            parceiroDao.InserirParceiro(parceiro);

            CupomDAO cupomDAO = new CupomDAO();

            Cupons cupom = new Cupons("Lucas", 100, 50, DateTime.Now, parceiro, 100);

            //action
            cupomDAO.InserirNovo(cupom);

            cupomDAO.Excluir(cupom.Id);

            //assert
            var cupomExcluido = cupomDAO.SelecionarPorId(cupom.Id);
            cupomExcluido.Should().BeNull();
        }

        [TestMethod]
        public void Deve_Selecionar_Cupom_Por_ID()
        {
            //arrange
            ParceiroDAO parceiroDao = new ParceiroDAO();

            Parceiro parceiro = new Parceiro("Deko");

            parceiroDao.InserirParceiro(parceiro);

            CupomDAO cupomDAO = new CupomDAO();

            Cupons cupom = new Cupons("Lucas", 100, 50, DateTime.Now, parceiro, 100);

            //action
            cupomDAO.InserirNovo(cupom);

            //assert
            var cupomID = cupomDAO.SelecionarPorId(cupom.Id);
            cupomID.Should().Be(cupom);
        }

        [TestMethod]
        public void Deve_Selecionar_Todos_Cupom()
        {
            //arrange
            ParceiroDAO parceiroDao = new ParceiroDAO();

            Parceiro parceiro = new Parceiro("Deko");

            parceiroDao.InserirParceiro(parceiro);

            CupomDAO cupomDAO = new CupomDAO();

            Cupons cupom = new Cupons("Lucas", 100, 50, DateTime.Now, parceiro, 100);

            //action
            cupomDAO.InserirNovo(cupom);

            //assert
            var todosCupons = cupomDAO.SelecionarTodos();
            todosCupons.Should().HaveCount(1);
        }
    }
}
