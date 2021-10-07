using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.ParceirosModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace e_Locadora5.Tests.CupomModule
{
    [TestClass]
    public class CupomDominioTest
    {
        [TestMethod]
        public void Deve_Validar_Cupons()
        {
            Parceiro parceiro = new Parceiro("Deko");
            Cupom cupons = new Cupom("Deco-5630", 0, 120,(new DateTime(2021,08,27)), parceiro,2300);
            Assert.AreEqual("ESTA_VALIDO", cupons.Validar());        
        }

        [TestMethod]
        public void Nao_Deve_Validar_Nome()
        {
            Parceiro parceiro = new Parceiro("Deko");
            Cupom cupons = new Cupom("", 0, 120, (new DateTime(2021, 08, 27)), parceiro,1200);
            Assert.AreEqual("O campo nome é obrigatório e não pode ser vazio.", cupons.Validar());
        }

        [TestMethod]
        public void Nao_Deve_Validar_Valor_Percentual()
        {
            Parceiro parceiro = new Parceiro("Deko");
            Cupom cupons = new Cupom("Deco-5630", -1, 0, (new DateTime(2021, 08, 27)), parceiro,1200);
            Assert.AreEqual("Valor Percentual não pode ser menor que Zero.", cupons.Validar());
        }

        [TestMethod]
        public void Nao_Deve_Validar_Valor_Fixo()
        {
            Parceiro parceiro = new Parceiro("Deko");
            Cupom cupons = new Cupom("Deco-5630", 0, -1, (new DateTime(2021, 08, 27)), parceiro,1200);
            Assert.AreEqual("Valor Fixo não pode ser Menor que Zero.", cupons.Validar());
        }

        [TestMethod]
        public void Nao_Deve_Validar_Data()
        {
            Parceiro parceiro = new Parceiro("Deko");
            Cupom cupons = new Cupom("Deco-5630", 0, 20, DateTime.MinValue, parceiro,1200);
            Assert.AreEqual("A data Invalida, Insira uma data valida", cupons.Validar());
        }

        [TestMethod]
        public void Nao_Deve_Validar_Parceiro()
        {
            Cupom cupons = new Cupom("Deco-5630", 0, 20, new DateTime(2021, 08, 27), null, 200);
            Assert.AreEqual("O campo Parceiro é obrigatório e não pode ser vazio.", cupons.Validar());
        }


        [TestMethod]
        public void Nao_Deve_Validar_Percentual()
        {
            Parceiro parceiro = new Parceiro("Deko");
            Cupom cupons = new Cupom("Deco-5630", 120, 0, new DateTime(2021, 08, 27), parceiro, 150);
            Assert.AreEqual("Valor Percentual não pode ser maior que Cem.", cupons.Validar());
        }
    }
}
