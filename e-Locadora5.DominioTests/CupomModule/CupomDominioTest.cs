using e_Locadora5.DataBuilderTest.CupomModule;
using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.ParceirosModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.DominioTests.CupomModule
{
    [TestClass]
    public class CupomDominioTest
    {
        [TestMethod]
        public void Deve_Validar_Cupom()
        {
            string Nome = "DSW";
            int ValorPercentual = 100;
            double ValorFixo = 100;
            DateTime DataValidade = DateTime.Now;
            Parceiro ParceiroId = new Parceiro("Deko");
            double ValorMinimo = 100;

            Cupom cupom = new Cupom(Nome,ValorPercentual,ValorFixo,DataValidade,ParceiroId,ValorMinimo);
            Assert.AreEqual("ESTA_VALIDO", cupom.Validar());
        }

        [TestMethod]
        public void Deve_Validar_Cupom_UtilizandoDataBuilder()
        {
            Cupom cupom = new CupomDataBuilder().GerarCupomCompleto();
            Assert.AreEqual("ESTA_VALIDO", cupom.Validar());
        }
    }
}
