using e_Locadora5.DataBuilderTest.CondutorModule;
using e_Locadora5.Dominio.CondutoresModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.DominioTests.CondutorModule
{
    [TestClass]
    public class CondutorDominioTest
    {
        
        [TestMethod]
        public void Deve_Validar_Condutor_UtilizandoDataBuilder()
        {
            Condutor condutor = new CondutorDataBuilder().GerarCondutorCompleto();
            Assert.AreEqual("ESTA_VALIDO", condutor.Validar());
        }
    }
}
