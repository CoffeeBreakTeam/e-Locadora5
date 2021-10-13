using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Infra.ORM.CupomModule;
using e_Locadora5.Infra.ORM.ParceiroModule;
using e_Locadora5.Infra.SQL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.EFTests.CupomModule
{
    [TestClass]
    public class CupomEFTest
    {
        CupomOrmDAO cupomOrm;
        ParceiroOrmDAO parceiroOrm;

        [TestCleanup()]
        public void LimparTabelas()
        {
            Db.Update("DELETE FROM TBCUPOM");
        }

        public CupomEFTest()
        {
            LocadoraDbContext locadoraDbContext = new LocadoraDbContext();
            cupomOrm = new CupomOrmDAO(locadoraDbContext);
            parceiroOrm = new ParceiroOrmDAO(locadoraDbContext);
        }

        [TestMethod]
        public void Deve_InserirNovo_Cupom()
        {
            //arrange
            Parceiro parceiro = new Parceiro("Deko");

            //action
            parceiroOrm.InserirNovo(parceiro);

            Cupom NovoCupom = new Cupom("Lucas", 100, 250, DateTime.Now, parceiro, 250);

            cupomOrm.InserirNovo(NovoCupom);

            //assert
            Assert.AreEqual(NovoCupom, cupomOrm.SelecionarPorId(NovoCupom.Id));
        }

        [TestMethod]
        public void Deve_Editar_Cupom()
        {
            //arrange
            Parceiro parceiro = new Parceiro("Deko");

            parceiroOrm.InserirNovo(parceiro);

            Cupom cupom = new Cupom("Lucas", 100, 50, DateTime.Now, parceiro, 100);

            cupomOrm.InserirNovo(cupom);

            Cupom cupomAtualizado = new Cupom("Marcos", 100, 50, DateTime.Now, parceiro, 100);

            //action

            cupomOrm.Editar(cupom.Id, cupomAtualizado);

            //assert
            Assert.AreEqual(cupomAtualizado.Nome, cupomOrm.SelecionarPorId(cupom.Id).Nome);
        }

        [TestMethod]
        public void Deve_Excluir_Cupom()
        {
            //arrange
            Parceiro parceiro = new Parceiro("Deko");

            parceiroOrm.InserirNovo(parceiro);

            Cupom cupom = new Cupom("Lucas", 100, 50, DateTime.Now, parceiro, 100);

            //action
            cupomOrm.InserirNovo(cupom);

            cupomOrm.Excluir(cupom.Id);

            //assert
            Assert.AreEqual(null, cupomOrm.SelecionarPorId(cupom.Id));
        }

        [TestMethod]
        public void Deve_Selecionar_Cupom_Por_ID()
        {
            //arrange
            Parceiro parceiro = new Parceiro("Deko");

            parceiroOrm.InserirNovo(parceiro);

            Cupom cupom = new Cupom("Lucas", 100, 50, DateTime.Now, parceiro, 100);

            //action
            cupomOrm.InserirNovo(cupom);

            //assert
            Assert.AreEqual(cupom, cupomOrm.SelecionarPorId(cupom.Id));
        }

        [TestMethod]
        public void Deve_Selecionar_Todos_Cupom()
        {
            //arrange
            Parceiro parceiro = new Parceiro("Deko");

            parceiroOrm.InserirNovo(parceiro);
 
            Cupom cupom = new Cupom("Lucas", 100, 50, DateTime.Now, parceiro, 100);

            //action
            cupomOrm.InserirNovo(cupom);

            //assert
            Assert.AreEqual(1, cupomOrm.SelecionarTodos().Count);
        }
    }
}
