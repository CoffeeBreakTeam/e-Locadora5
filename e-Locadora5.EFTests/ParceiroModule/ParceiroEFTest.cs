using e_Locadora5.Aplicacao.ParceiroModule;
using e_Locadora5.DataBuilderTest.ParceiroModule;
using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Infra.ORM.ParceiroModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace e_Locadora5.EFTests.ParceiroModule
{
    [TestClass]
    public class ParceiroEFTest
    {
        ParceiroOrmDAO parceiroRepositoryEF;
        public ParceiroEFTest()
        {

            parceiroRepositoryEF = new ParceiroOrmDAO();

            
        }

        [TestMethod]
        public void DeveInserirParceiroNoBanco()
        {
            //arrange
            Parceiro parceiro = new ParceiroDataBuilder().GerarParceiroCompleto();
            //act
            //parceiroRepositoryEF.InserirParceiro(parceiro);
            ////assert
            //Assert.AreEqual(parceiro,parceiroRepositoryEF.SelecionarParceiroPorId(parceiro.Id));
        }
    }
}
