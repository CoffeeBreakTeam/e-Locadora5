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
            Db.Update("DELETE FROM TBCUPONS");
        }

        public CupomEFTest()
        {
            cupomOrm = new CupomOrmDAO(new LocadoraDbContext());
            parceiroOrm = new ParceiroOrmDAO(new LocadoraDbContext());
        }

        [TestMethod]
        public void Deve_InserirNovo_Cupom()
        {
            //arrange
            Parceiro parceiro = new Parceiro("Deko");

            //action
            parceiroOrm.InserirNovo(parceiro);

            Cupons NovoCupom = new Cupons("Lucas", 100, 50, DateTime.Now, parceiro, 100);

            cupomOrm.InserirNovo(NovoCupom);

            //assert
            Assert.AreEqual(parceiro, cupomOrm.SelecionarPorId(NovoCupom.Id));
        }

        [TestMethod]
        public void Deve_Editar_Cupom()
        {
            //arrange
            Parceiro parceiro = new Parceiro("Deko");

            parceiroOrm.InserirNovo(parceiro);

            Cupons cupom = new Cupons("Lucas", 100, 50, DateTime.Now, parceiro, 100);

            cupomOrm.InserirNovo(cupom);

            Cupons cupomAtualizado = new Cupons("Marcos", 100, 50, DateTime.Now, parceiro, 100);

            //action

            cupomOrm.Editar(cupom.Id, cupomAtualizado);

            //assert
            Assert.AreEqual(parceiro, cupomOrm.SelecionarPorId(cupom.Id));
        }

        [TestMethod]
        public void Deve_Excluir_Cupom()
        {
            //arrange
            Parceiro parceiro = new Parceiro("Deko");

            parceiroOrm.InserirNovo(parceiro);

            Cupons cupom = new Cupons("Lucas", 100, 50, DateTime.Now, parceiro, 100);

            //action
            cupomOrm.InserirNovo(cupom);

            cupomOrm.Excluir(cupom.Id);

            //assert
            Assert.AreEqual(parceiro, cupomOrm.SelecionarPorId(cupom.Id) == null);
        }

        [TestMethod]
        public void Deve_Selecionar_Cupom_Por_ID()
        {
            //arrange
            Parceiro parceiro = new Parceiro("Deko");

            parceiroOrm.InserirNovo(parceiro);

            Cupons cupom = new Cupons("Lucas", 100, 50, DateTime.Now, parceiro, 100);

            //action
            cupomOrm.InserirNovo(cupom);

            //assert
            Assert.AreEqual(parceiro, cupomOrm.SelecionarPorId(cupom.Id));
        }

        [TestMethod]
        public void Deve_Selecionar_Todos_Cupom()
        {
            //arrange
            Parceiro parceiro = new Parceiro("Deko");

            parceiroOrm.InserirNovo(parceiro);
 
            Cupons cupom = new Cupons("Lucas", 100, 50, DateTime.Now, parceiro, 100);

            //action
            cupomOrm.InserirNovo(cupom);

            //assert
            Assert.AreEqual(parceiro, cupomOrm.SelecionarTodos());
        }
    }
}
