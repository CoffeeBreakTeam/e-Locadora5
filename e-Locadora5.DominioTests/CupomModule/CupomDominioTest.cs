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
            Parceiro Parceiro = new Parceiro("Deko");
            double ValorMinimo = 100;

            Cupom cupom = new Cupom(Nome,ValorPercentual,ValorFixo,DataValidade,Parceiro,ValorMinimo);
            Assert.AreEqual("ESTA_VALIDO", cupom.Validar());
        }

        [TestMethod]
        public void Deve_Validar_Cupom_UtilizandoDataBuilder()
        {
            Cupom cupom = new CupomDataBuilder().GerarCupomCompleto();
            Assert.AreEqual("ESTA_VALIDO", cupom.Validar());
        }

        [TestMethod]
        public void Nao_Deve_Validar_Nome()
        {
            string Nome = "";
            int ValorPercentual = 100;
            double ValorFixo = 100;
            DateTime DataValidade = DateTime.Now;
            Parceiro Parceiro = new Parceiro("Deko");
            double ValorMinimo = 100;

            Cupom cupom = new Cupom(Nome, ValorPercentual, ValorFixo, DataValidade, Parceiro, ValorMinimo);
            Assert.AreEqual("O campo nome é obrigatório e não pode ser vazio.", cupom.Validar());
        }

        [TestMethod]
        public void Nao_Deve_Validar_ValorPercentual()
        {
            string Nome = "DSQ";
            int ValorPercentual = int.MinValue;
            double ValorFixo = 100;
            DateTime DataValidade = DateTime.Now;
            Parceiro Parceiro = new Parceiro("Deko");
            double ValorMinimo = 100;

            Cupom cupom = new Cupom(Nome, ValorPercentual, ValorFixo, DataValidade, Parceiro, ValorMinimo);
            Assert.AreEqual("Valor Percentual não pode ser menor que Zero.", cupom.Validar());
        }

        [TestMethod]
        public void Nao_Deve_Validar_ValorFixo()
        {
            string Nome = "DSQ";
            int ValorPercentual = 100;
            double ValorFixo = double.MinValue;
            DateTime DataValidade = DateTime.Now;
            Parceiro Parceiro = new Parceiro("Deko");
            double ValorMinimo = 100;

            Cupom cupom = new Cupom(Nome, ValorPercentual, ValorFixo, DataValidade, Parceiro, ValorMinimo);
            Assert.AreEqual("Valor Fixo não pode ser Menor que Zero.", cupom.Validar());
        }

        [TestMethod]
        public void Nao_Deve_Validar_DataValidade()
        {
            string Nome = "DSQ";
            int ValorPercentual = 100;
            double ValorFixo = 100;
            DateTime DataValidade = DateTime.MinValue;
            Parceiro Parceiro = new Parceiro("Deko");
            double ValorMinimo = 100;

            Cupom cupom = new Cupom(Nome, ValorPercentual, ValorFixo, DataValidade, Parceiro, ValorMinimo);
            Assert.AreEqual("A data Invalida, Insira uma data valida", cupom.Validar());
        }

        [TestMethod]
        public void Nao_Deve_Validar_Parceiro()
        {
            string Nome = "DSQ";
            int ValorPercentual = 100;
            double ValorFixo = 100;
            DateTime DataValidade = DateTime.Now;
            Parceiro Parceiro = null;
            double ValorMinimo = 100;

            Cupom cupom = new Cupom(Nome, ValorPercentual, ValorFixo, DataValidade, Parceiro, ValorMinimo);
            Assert.AreEqual("O campo Parceiro é obrigatório e não pode ser vazio.", cupom.Validar());
        }

        [TestMethod]
        public void Nao_Deve_Validar_ValorMinimo()
        {
            string Nome = "DSQ";
            int ValorPercentual = 100;
            double ValorFixo = 100;
            DateTime DataValidade = DateTime.Now;
            Parceiro Parceiro = new Parceiro("Deko");
            double ValorMinimo = double.MinValue;

            Cupom cupom = new Cupom(Nome, ValorPercentual, ValorFixo, DataValidade, Parceiro, ValorMinimo);
            Assert.AreEqual("O campo Valor Minimo não pode ser menor que Zero." + "O valor Minimo não pode ser menor que o valor de Desconto", cupom.Validar());
        }
    }
}
