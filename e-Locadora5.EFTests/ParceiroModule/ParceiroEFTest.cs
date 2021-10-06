using e_Locadora5.Aplicacao.ParceiroModule;
using e_Locadora5.DataBuilderTest.ParceiroModule;
using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Infra.ORM.ParceiroModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.EFTests.ParceiroModule
{
    [TestClass]
    public class ParceiroEFTest
    {
        ParceiroRepositoryEF parceiroRepositoryEF;
        public ParceiroEFTest()
        {

            parceiroRepositoryEF = new ParceiroRepositoryEF();

            
        }

        [TestMethod]
        public void DeveInserirParceiroNoBanco()
        {
            //arrange
            Parceiro parceiro = new ParceiroDataBuilder().GerarParceiroCompleto();
            //act
            parceiroRepositoryEF.InserirParceiro(parceiro);
            //assert
            Assert.AreEqual(parceiro,);
        }
    }
}
