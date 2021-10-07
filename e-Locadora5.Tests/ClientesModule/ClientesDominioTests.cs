
using e_Locadora5.Dominio.ClientesModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Tests.ClientesModule
{

    [TestClass]
    public class ClientesDominioTests
    {
        string nome;
        string endereco;
        string telefone;
        string rg;
        string cpf;
        string cnpj;
        string email;
        public ClientesDominioTests()
        {
            nome = "Joao";
            endereco = "rua joao manoel numero 195";
            telefone= "49995625361";
            rg = "5231255";
            cpf = "10250540499";
            cnpj = "";
            email= "Joao.pereira@gmail.com";
        }
       
        

        [TestMethod]
        public void Deve_Validar_Clientes_PessoaFisica()
        {

            Cliente cliente = new ClienteDataBuilder().ComCPF(cpf)
                .ComEmail(email)
                .ComEndereco(endereco)
                .ComTelefone(telefone)
                .ComRG(rg).ComCNPJ(cnpj)
                .ComNome(nome)
                .Build();
            Assert.AreEqual("ESTA_VALIDO", cliente.Validar());
        }

        [TestMethod]
        public void Deve_Validar_Clientes_PessoaJuridica()
        {
            Cliente cliente = new ClienteDataBuilder().ComCPF("")
               .ComEmail(email)
               .ComEndereco(endereco)
               .ComTelefone(telefone)
               .ComRG("")
               .ComCNPJ("221323123123")
               .ComNome(nome)
               .Build();
            Assert.AreEqual("ESTA_VALIDO", cliente.Validar());
        }
        [TestMethod]
        public void Deve_Validar_Clientes_Nome()
        {
            Cliente cliente = new ClienteDataBuilder().ComCPF("")
               .ComEmail(email)
               .ComEndereco(endereco)
               .ComTelefone(telefone)
               .ComRG("")
               .ComCNPJ("221323123123")
               .ComNome("")
               .Build();
            Assert.AreEqual("O atributo nome é obrigatório e não pode ser vazio.", cliente.Validar());
        }
        [TestMethod]
        public void Deve_Validar_Clientes_Endereco()
        {
            Cliente cliente = new ClienteDataBuilder().ComCPF("")
               .ComEmail(email)
               .ComEndereco("")
               .ComTelefone(telefone)
               .ComRG("")
               .ComCNPJ("221323123123")
               .ComNome(nome)
               .Build();
            Assert.AreEqual("O atributo endereço é obrigatório e não pode ser vazio.", cliente.Validar());
        }
        [TestMethod]
        public void Deve_Validar_Clientes_Telefone()
        {
            Cliente cliente = new ClienteDataBuilder().ComCPF("")
               .ComEmail(email)
               .ComEndereco(endereco)
               .ComTelefone("")
               .ComRG("")
               .ComCNPJ("221323123123")
               .ComNome(nome)
               .Build();
            Assert.AreEqual("O atributo Telefone está invalido.", cliente.Validar());
        }
        [TestMethod]
        public void Deve_Validar_Clientes_Email()
        {
            Cliente cliente = new ClienteDataBuilder().ComCPF(cpf)
                .ComEmail("")
                .ComEndereco(endereco)
                .ComTelefone(telefone)
                .ComRG(rg).ComCNPJ(cnpj)
                .ComNome(nome)
                .Build();
            Assert.AreEqual("O campo Email está inválido", cliente.Validar());
        }
    }
}
