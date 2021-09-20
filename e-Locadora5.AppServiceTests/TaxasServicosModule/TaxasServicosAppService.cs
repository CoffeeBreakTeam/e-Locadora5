using e_Locadora5.Dominio.TaxasServicosModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.AppServiceTests.TaxasServicosModule
{
    [TestClass]
    public class TaxasServicosAppServiceTests
    {
        Mock<ITaxasServicosRepository> taxasServicosDAOMock;
        Mock<TaxasServicos> taxasServicosMock;

        public TaxasServicosAppServiceTests()
        {
            taxasServicosMock = new Mock<TaxasServicos>();

            taxasServicosDAOMock = new Mock<ITaxasServicosRepository>();
        }


        [TestMethod]
        public void Deve_Chamar_InserirNovo()
        {
            
        }
    }
}
