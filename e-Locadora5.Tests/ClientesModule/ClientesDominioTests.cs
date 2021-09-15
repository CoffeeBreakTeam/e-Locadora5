﻿
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

            Clientes grupoVeiculo = new ClienteDataBuilder().ComCPF(cpf)
                .ComEmail(email)
                .ComEndereco(endereco)
                .ComTelefone(telefone)
                .ComRG(rg).ComCNPJ(cnpj)
                .ComNome(nome)
                .Build();
            Assert.AreEqual("ESTA_VALIDO", grupoVeiculo.Validar());
        }

        [TestMethod]
        public void Deve_Validar_Clientes_PessoaJuridica()
        {
            Clientes grupoVeiculo = new ClienteDataBuilder().ComCPF("")
               .ComEmail(email)
               .ComEndereco(endereco)
               .ComTelefone(telefone)
               .ComRG("")
               .ComCNPJ("221323123123")
               .ComNome(nome)
               .Build();
            Assert.AreEqual("ESTA_VALIDO", grupoVeiculo.Validar());
        }
        [TestMethod]
        public void Deve_Validar_Clientes_Nome()
        {
            Clientes grupoVeiculo = new ClienteDataBuilder().ComCPF("")
               .ComEmail(email)
               .ComEndereco(endereco)
               .ComTelefone(telefone)
               .ComRG("")
               .ComCNPJ("221323123123")
               .ComNome("")
               .Build();
            Assert.AreEqual("O atributo nome é obrigatório e não pode ser vazio.", grupoVeiculo.Validar());
        }
        [TestMethod]
        public void Deve_Validar_Clientes_Endereco()
        {
            Clientes grupoVeiculo = new ClienteDataBuilder().ComCPF("")
               .ComEmail(email)
               .ComEndereco("")
               .ComTelefone(telefone)
               .ComRG("")
               .ComCNPJ("221323123123")
               .ComNome(nome)
               .Build();
            Assert.AreEqual("O atributo endereço é obrigatório e não pode ser vazio.", grupoVeiculo.Validar());
        }
        [TestMethod]
        public void Deve_Validar_Clientes_Telefone()
        {
            Clientes grupoVeiculo = new ClienteDataBuilder().ComCPF("")
               .ComEmail(email)
               .ComEndereco(endereco)
               .ComTelefone("")
               .ComRG("")
               .ComCNPJ("221323123123")
               .ComNome(nome)
               .Build();
            Assert.AreEqual("O atributo Telefone está invalido.", grupoVeiculo.Validar());
        }
        [TestMethod]
        public void Deve_Validar_Clientes_Email()
        {
            Clientes grupoVeiculo = new ClienteDataBuilder().ComCPF(cpf)
                .ComEmail("")
                .ComEndereco(endereco)
                .ComTelefone(telefone)
                .ComRG(rg).ComCNPJ(cnpj)
                .ComNome(nome)
                .Build();
            Assert.AreEqual("O campo Email está inválido", grupoVeiculo.Validar());
        }
    }
}
