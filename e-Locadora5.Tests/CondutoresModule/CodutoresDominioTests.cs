using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.CondutoresModule;
using e_Locadora5.Tests.ClientesModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace e_Locadora5.Tests.CondutoresModule
{
    [TestClass]
    [TestCategory("Dominio")]
    public class CodutoresDominioTests
    {
        string nome;
        string endereco;
        string telefone;
        string rg;
        string cpf;
        string cnpj;
        string email;
        DateTime data;
        string numero;
        public CodutoresDominioTests()
        {
            nome = "Joao";
            endereco = "rua joao manoel numero 195";
            telefone = "49995625361";
            rg = "5231255";
            cpf = "10250540499";
            cnpj = "";
            email = "Joao.pereira@gmail.com";
            data = DateTime.Now.AddDays(4);
            numero = "12312312";
        }

        [TestMethod]
        public void Deve_Validar_Condutor()
        {                  
            Cliente cliente = new ClienteDataBuilder().ComCPF(cpf)
              .ComEmail(email)
              .ComEndereco(endereco)
              .ComTelefone(telefone)
              .ComRG(rg).ComCNPJ(cnpj)
              .ComNome(nome)         
              .Build();

            Condutor condutor = new CondutorDataBuilder().ComCliente(cliente)
              .ComCPF(cpf)
              .ComEndereco(endereco)
              .ComTelefone(telefone)
              .ComRG(rg)  
              .ComValidadeCNH(data)
              .ComNumeroCNH(numero)
              .ComNome(nome)
              .Build();
            
            var validar = condutor.Validar();

            validar.Should().Be("ESTA_VALIDO");
        }
        [TestMethod]
        public void Deve_Validar_informacoes()
        {
            Cliente cliente = new ClienteDataBuilder()
             .ComCPF(cpf)
             .ComEmail(email)
             .ComEndereco(endereco)
             .ComTelefone(telefone)
             .ComRG(rg)
             .ComCNPJ(cnpj)
             .ComNome(nome)
             .Build();

            Condutor condutor = new CondutorDataBuilder()
               .ComCliente(cliente)
               .ComCPF("")
               .ComEndereco("")
               .ComTelefone("")
               .ComRG("")
               .ComNumeroCNH("")
               .ComValidadeCNH(DateTime.MinValue)
               .ComNome("")
               .Build();

            var validar = condutor.Validar();

            var resultadoEsperado =
                "O atributo nome é obrigatório e não pode ser vazio."
               + Environment.NewLine
               + "O atributo endereço é obrigatório e não pode ser vazio."
               + Environment.NewLine
               + "O atributo Telefone está invalido."
               + Environment.NewLine
               + "O atributo Numero do Rg é obrigatório e não pode ser vazio."
               + Environment.NewLine
               + "O atributo Numero do Cpf é obrigatório e não pode ser vazio."
               + Environment.NewLine
               + "O atributo Numero da CNH é obrigatório e não pode ser vazio."
               + Environment.NewLine
               + "O campo Validade da CNH é obrigatório"
               + Environment.NewLine
               + "A validade da cnh inserida está expirada, tente novamente";

            Assert.AreEqual(validar, resultadoEsperado);          
        }
    }
}
