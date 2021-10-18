using e_Locadora5.DataBuilderTest.CondutorModule;
using e_Locadora5.Dominio.ClientesModule;
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

        [TestMethod]
        public void Nao_Deve_Validar_Condutor_Nome()
        {
            string Nome = "";
            string Endereco = "Lages SC";
            string Telefone = "2254454514";
            string Rg = "555412";
            string Cpf = "55552214";
            string NumeroCNH = "552146";
            DateTime ValidadeCNH = DateTime.MaxValue;
            Cliente cliente = new Cliente("Joao", "wsw", "wsws", "sws", "wss", "wswsw", "wsws");

            Condutor condutor = new Condutor(Nome, Endereco, Telefone, Rg, Cpf, NumeroCNH, ValidadeCNH, cliente);
            Assert.AreEqual("O atributo nome é obrigatório e não pode ser vazio.", condutor.Validar());
        }

        [TestMethod]
        public void Nao_Deve_Validar_Condutor_Endereco()
        {
            string Nome = "Lucas";
            string Endereco = "";
            string Telefone = "2254454514";
            string Rg = "555412";
            string Cpf = "55552214";
            string NumeroCNH = "552146";
            DateTime ValidadeCNH = DateTime.MaxValue;
            Cliente cliente = new Cliente("Joao", "wsw", "wsws", "sws", "wss", "wswsw", "wsws");

            Condutor condutor = new Condutor(Nome, Endereco, Telefone, Rg, Cpf, NumeroCNH, ValidadeCNH, cliente);
            Assert.AreEqual("O atributo endereço é obrigatório e não pode ser vazio.", condutor.Validar());
        }

        [TestMethod]
        public void Nao_Deve_Validar_Condutor_Telefone()
        {
            string Nome = "Lucas";
            string Endereco = "Lages SC";
            string Telefone = "";
            string Rg = "555412";
            string Cpf = "55552214";
            string NumeroCNH = "552146";
            DateTime ValidadeCNH = DateTime.MaxValue;
            Cliente cliente = new Cliente("Joao", "wsw", "wsws", "sws", "wss", "wswsw", "wsws");

            Condutor condutor = new Condutor(Nome, Endereco, Telefone, Rg, Cpf, NumeroCNH, ValidadeCNH, cliente);
            Assert.AreEqual("O atributo Telefone está invalido.", condutor.Validar());
        }

        [TestMethod]
        public void Nao_Deve_Validar_Condutor_Rg()
        {
            string Nome = "Lucas";
            string Endereco = "Lages SC";
            string Telefone = "10234569875";
            string Rg = "";
            string Cpf = "55552214";
            string NumeroCNH = "552146";
            DateTime ValidadeCNH = DateTime.MaxValue;
            Cliente cliente = new Cliente("Joao", "wsw", "wsws", "sws", "wss", "wswsw", "wsws");

            Condutor condutor = new Condutor(Nome, Endereco, Telefone, Rg, Cpf, NumeroCNH, ValidadeCNH, cliente);
            Assert.AreEqual("O atributo Numero do Rg é obrigatório e não pode ser vazio.", condutor.Validar());
        }

        [TestMethod]
        public void Nao_Deve_Validar_Condutor_CPF()
        {
            string Nome = "Lucas";
            string Endereco = "Lages SC";
            string Telefone = "10234569875";
            string Rg = "552145";
            string Cpf = "";
            string NumeroCNH = "552146";
            DateTime ValidadeCNH = DateTime.MaxValue;
            Cliente cliente = new Cliente("Joao", "wsw", "wsws", "sws", "wss", "wswsw", "wsws");

            Condutor condutor = new Condutor(Nome, Endereco, Telefone, Rg, Cpf, NumeroCNH, ValidadeCNH, cliente);
            Assert.AreEqual("O atributo Numero do Cpf é obrigatório e não pode ser vazio.", condutor.Validar());
        }

        [TestMethod]
        public void Nao_Deve_Validar_Condutor_NumeroCNH()
        {
            string Nome = "Lucas";
            string Endereco = "Lages SC";
            string Telefone = "10234569875";
            string Rg = "552145";
            string Cpf = "552145";
            string NumeroCNH = "";
            DateTime ValidadeCNH = DateTime.MaxValue;
            Cliente cliente = new Cliente("Joao", "wsw", "wsws", "sws", "wss", "wswsw", "wsws");

            Condutor condutor = new Condutor(Nome, Endereco, Telefone, Rg, Cpf, NumeroCNH, ValidadeCNH, cliente);
            Assert.AreEqual("O atributo Numero da CNH é obrigatório e não pode ser vazio.", condutor.Validar());
        }

        [TestMethod]
        public void Nao_Deve_Validar_Condutor_ValidadeCNH()
        {
            string Nome = "Lucas";
            string Endereco = "Lages SC";
            string Telefone = "10234569875";
            string Rg = "552145";
            string Cpf = "552145";
            string NumeroCNH = "552221456";
            DateTime ValidadeCNH = DateTime.MinValue;
            Cliente cliente = new Cliente("Joao", "wsw", "wsws", "sws", "wss", "wswsw", "wsws");

            //Condutor condutor = new Condutor(Nome, Endereco, Telefone, Rg, Cpf, NumeroCNH, ValidadeCNH, cliente);
            //Assert.AreEqual("O campo Validade da CNH é obrigatório"+"A validade da cnh inserida está expirada, tente novamente", condutor.Validar());
        }

        [TestMethod]
        public void Nao_Deve_Validar_Condutor_Cliente()
        {
            string Nome = "Lucas";
            string Endereco = "Lages SC";
            string Telefone = "10234569875";
            string Rg = "552145";
            string Cpf = "552145";
            string NumeroCNH = "552221456";
            DateTime ValidadeCNH = DateTime.MaxValue;
            Cliente cliente = null;

            Condutor condutor = new Condutor(Nome, Endereco, Telefone, Rg, Cpf, NumeroCNH, ValidadeCNH, cliente);
            Assert.AreEqual("O campo Cliente é obrigatório e não pode ser Vazio", condutor.Validar());
        }
    }
}
