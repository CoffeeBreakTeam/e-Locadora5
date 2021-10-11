using e_Locadora5.Aplicacao.ParceiroModule;
using e_Locadora5.DataBuilderTest.ParceiroModule;
using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Infra.ORM.ParceiroModule;
using e_Locadora5.Infra.SQL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace e_Locadora5.EFTests.ParceiroModule
{
    [TestClass]
    public class ParceiroEFTest
    {
        ParceiroOrmDAO parceiroRepositoryEF;

        [TestCleanup()]
        public void LimparTabelas()
        {
            Db.Update("DELETE FROM TBParceiro");
        }

        public ParceiroEFTest()
        {
            parceiroRepositoryEF = new ParceiroOrmDAO(new LocadoraDbContext());
        }

        [TestMethod]
        public void DeveInserirParceiroNoBanco()
        {
            //Arrange
            Parceiro parceiro = new ParceiroDataBuilder().GerarParceiroCompleto();

            //Action
            parceiroRepositoryEF.InserirNovo(parceiro);

            //Assert
            Assert.AreEqual(parceiro,parceiroRepositoryEF.SelecionarPorId(parceiro.Id));
        }

        [TestMethod]
        public void DeveEditarParceiro()
        {
            //Arrange
            Parceiro parceiro = new ParceiroDataBuilder().GerarParceiroCompleto();
            Parceiro parceiroEditado = new ParceiroDataBuilder().GerarParceiroCompleto();
            parceiroEditado.Nome = "João pedro";

            //Action
            parceiroRepositoryEF.InserirNovo(parceiro);

            parceiroRepositoryEF.Editar(parceiro.Id, parceiroEditado);

            //Assert
            Assert.AreEqual(parceiroEditado, parceiroRepositoryEF.SelecionarPorId(parceiro.Id));
        }

        [TestMethod]
        public void DeveExcluirParceiro()
        {
            //Arrange
            Parceiro parceiro = new ParceiroDataBuilder().GerarParceiroCompleto();

            //Action
            parceiroRepositoryEF.InserirNovo(parceiro);
            
            parceiroRepositoryEF.Excluir(parceiro.Id);

            //Assert   
            Assert.IsNull(parceiroRepositoryEF.SelecionarPorId(parceiro.Id));
        }

        [TestMethod]
        public void DeveSelecionarParceiroPorID()
        {
            //Arrange
            Parceiro parceiro = new ParceiroDataBuilder().GerarParceiroCompleto();

            //Action
            parceiroRepositoryEF.InserirNovo(parceiro);

            //Assert
            Assert.AreEqual(parceiro, parceiroRepositoryEF.SelecionarPorId(parceiro.Id));
        }

        [TestMethod]
        public void DeveSelecionarTodosParceiros()
        {
            //Arrange
            Parceiro parceiro = new ParceiroDataBuilder().GerarParceiroCompleto();

            //Action
            parceiroRepositoryEF.InserirNovo(parceiro);

            //Assert
            Assert.AreEqual(1, parceiroRepositoryEF.SelecionarTodos().Count);
        }
    }
}
