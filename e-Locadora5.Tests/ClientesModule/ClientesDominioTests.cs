
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
        [TestMethod]
        public void Deve_Validar_Clientes_PessoaFisica()
        {
            string nome = "Joao";
            string endereco = "rua joao manoel numero 195";
            string telefone = "49995625361";
            string rg = "5231255";
            string cpf = "10250540499";
            string cnpj = "";
            string email = "Joao.pereira@gmail.com";

            Clientes grupoVeiculo = new Clientes(nome, endereco, telefone, rg, cpf, cnpj,email);
            Assert.AreEqual("ESTA_VALIDO", grupoVeiculo.Validar());
        }

        [TestMethod]
        public void Deve_Validar_Clientes_PessoaJuridica()
        {
            string nome = "Seara Alimentos LTDA";
            string endereco = "Avenida Jucelino Kub. de Oliveira Numero 454";
            string telefone = "4932770295";
            string rg = "";
            string cpf = "";
            string cnpj = "02914460029615";
            string email = "Joao.pereira@gmail.com";



            Clientes grupoVeiculo = new Clientes(nome, endereco, telefone, rg, cpf, cnpj,email);
            Assert.AreEqual("ESTA_VALIDO", grupoVeiculo.Validar());
        }
        [TestMethod]
        public void Deve_Validar_Clientes_Nome()
        {
            string nome = "";
            string endereco = "Avenida Jucelino Kub. de Oliveira Numero 454";
            string telefone = "4932770295";
            string rg = "";
            string cpf = "";
            string cnpj = "02914460029615";
            string email = "Joao.pereira@gmail.com";



            Clientes grupoVeiculo = new Clientes(nome, endereco, telefone, rg, cpf, cnpj,email);
            Assert.AreEqual("O atributo nome é obrigatório e não pode ser vazio.", grupoVeiculo.Validar());
        }
        [TestMethod]
        public void Deve_Validar_Clientes_Endereco()
        {
            string nome = "Seara Alimentos LTDA";
            string endereco = "";
            string telefone = "4932770295";
            string rg = "";
            string cpf = "";
            string cnpj = "02914460029615";
            string email = "Joao.pereira@gmail.com";



            Clientes grupoVeiculo = new Clientes(nome, endereco, telefone, rg, cpf, cnpj,email);
            Assert.AreEqual("O atributo endereço é obrigatório e não pode ser vazio.", grupoVeiculo.Validar());
        }
        [TestMethod]
        public void Deve_Validar_Clientes_Telefone()
        {
            string nome = "Seara Alimentos LTDA";
            string endereco = "Avenida Jucelino Kub. de Oliveira Numero 454";
            string telefone = "";
            string rg = "";
            string cpf = "";
            string cnpj = "02914460029615";
            string email = "Joao.pereira@gmail.com";



            Clientes grupoVeiculo = new Clientes(nome, endereco, telefone, rg, cpf, cnpj,email);
            Assert.AreEqual("O atributo Telefone está invalido.", grupoVeiculo.Validar());
        }
        [TestMethod]
        public void Deve_Validar_Clientes_Email()
        {
            string nome = "Seara Alimentos LTDA";
            string endereco = "Avenida Jucelino Kub. de Oliveira Numero 454";
            string telefone = "98522422582";
            string rg = "";
            string cpf = "";
            string cnpj = "02914460029615";
            string email = "";



            Clientes grupoVeiculo = new Clientes(nome, endereco, telefone, rg, cpf, cnpj, email);
            Assert.AreEqual("O campo Email está inválido", grupoVeiculo.Validar());
        }
    }
}
