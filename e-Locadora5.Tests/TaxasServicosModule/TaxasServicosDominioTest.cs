using e_Locadora5.Dominio.TaxasServicosModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace e_Locadora5.Tests.TaxasServicosModule
{
    [TestClass]
    public class TaxasServicosDominioTest
    {
        [TestMethod]
        public void Deve_Validar_Taxas_E_Servicos()
        {
            TaxasServicos taxasServicos = new TaxasServicos("Taxa de Lavação", 1, 1);
            Assert.AreEqual("ESTA_VALIDO", taxasServicos.Validar());
        }

        [TestMethod]
        public void Nao_Deve_Validar_Descricao()
        {
            TaxasServicos taxasServicos = new TaxasServicos("",1,1);
            Assert.AreEqual("O campo descrição é obrigatório e não pode ser vazio.", taxasServicos.Validar());
        }

        [TestMethod]
        public void Nao_Deve_Validar_Taxa_Fixa()
        {
            TaxasServicos taxasServicos = new TaxasServicos("Taxa de Lavação", -1, 10);
            Assert.AreEqual("Taxa Fixa não pode ser menor que Zero.", taxasServicos.Validar());
        }

        [TestMethod]
        public void Nao_Deve_Validar_Taxa_Diaria()
        {
            TaxasServicos taxasServicos = new TaxasServicos("Taxa de Lavação", 300, -1);
            Assert.AreEqual("Taxa Diaria não pode ser Menor que Zero.", taxasServicos.Validar());
        }
    }
}
