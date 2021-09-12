using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.CondutoresModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace e_Locadora5.Tests.CondutoresModule
{
    [TestClass]
    [TestCategory("Dominio")]
    public class CodutoresDominioTests
    {
        [TestMethod]
        public void Deve_Validar_Condutor()
        {
            var cliente = new Clientes("Joao","Rua dos joao","9522185224","5222522","20202020222","", "Joao.pereira@gmail.com");

            Condutor condutor = new Condutor("Joao", "Rua dos joao", "9522185224", "5222522", "20202020222", "522542",
                new DateTime(2022,05,26), cliente);

            var validar = condutor.Validar();

            validar.Should().Be("ESTA_VALIDO");
        }
        [TestMethod]
        public void Deve_Validar_informacoes()
        {
            var cliente = new Clientes("Joao", "Rua dos joao", "9522185224", "5222522", "20202020222", "", "Joao.pereira@gmail.com");

            Condutor condutor = new Condutor("", "", "", "", "", "",
                DateTime.MinValue, cliente);

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

            validar.Should().Be(resultadoEsperado);
        }
    }
}
