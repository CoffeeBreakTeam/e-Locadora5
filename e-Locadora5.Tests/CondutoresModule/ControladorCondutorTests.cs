using e_Locadora5.Aplicacao.ClienteModule;
using e_Locadora5.Aplicacao.CondutorModule;
using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.CondutoresModule;
using e_Locadora5.Infra.GeradorLogs;
using e_Locadora5.Infra.SQL;
using e_Locadora5.Infra.SQL.ClienteModule;
using e_Locadora5.Infra.SQL.CondutorModule;
using e_Locadora5.Tests.ClientesModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace e_Locadora5.Tests.CondutoresModule
{
    [TestClass]
    [TestCategory("Controladores")]
    public class ControladorCondutorTests
    {
        CondutorAppService condutorAppService = null;
        ClienteAppService clienteAppService = null;
        string nome;
        string endereco;
        string telefone;
        string rg;
        string cpf;
        string cnpj;
        string email;
        DateTime data;
        string numero;
        public ControladorCondutorTests()
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

            condutorAppService = new CondutorAppService(new CondutorDAO());
            clienteAppService = new ClienteAppService(new ClienteDAO());


            Db.Update("DELETE FROM TBLOCACAO_TBTAXASSERVICOS");
            Db.Update("DELETE FROM TBLOCACAO");
            Db.Update("DELETE FROM [TBCONDUTOR]");
            Db.Update("DELETE FROM [TBCLIENTES]");

        }

        [TestMethod]
        public void Deve_InserirUmCondutor()
        {
            Cliente cliente = new ClienteDataBuilder().ComCPF(cpf)
              .ComEmail(email)
              .ComEndereco(endereco)
              .ComTelefone(telefone)
              .ComRG(rg).ComCNPJ(cnpj)
              .ComNome(nome)
              .Build();

            clienteAppService.InserirNovo(cliente);

            Condutor condutor = new CondutorDataBuilder().ComCliente(cliente)
              .ComCPF(cpf)
              .ComEndereco(endereco)
              .ComTelefone(telefone)
              .ComRG(rg)
              .ComValidadeCNH(data)
              .ComNumeroCNH(numero)
              .ComNome(nome)
              .Build();

            condutorAppService.InserirNovo(condutor);

            //assert
            Condutor condutorEncontrado = condutorAppService.SelecionarPorId(condutor.Id);
            Assert.AreEqual(condutor.Nome,condutorEncontrado.Nome);

        }

        [TestMethod]
        public void DeveAtualizar_Condutor()
        {
            Cliente cliente = new ClienteDataBuilder().ComCPF(cpf)
              .ComEmail(email)
              .ComEndereco(endereco)
              .ComTelefone(telefone)
              .ComRG(rg).ComCNPJ(cnpj)
              .ComNome(nome)
              .Build();

            clienteAppService.InserirNovo(cliente);

            Condutor condutor = new CondutorDataBuilder().ComCliente(cliente)
             .ComCPF(cpf)
             .ComEndereco(endereco)
             .ComTelefone(telefone)
             .ComRG(rg)
             .ComValidadeCNH(data)
             .ComNumeroCNH(numero)
             .ComNome(nome)
             .Build();

            condutorAppService.InserirNovo(condutor);

            Condutor condutorEditado = new CondutorDataBuilder().ComCliente(cliente)
             .ComCPF(cpf)
             .ComEndereco(endereco)
             .ComTelefone(telefone)
             .ComRG(rg)
             .ComValidadeCNH(data)
             .ComNumeroCNH(numero)
             .ComNome("Juca")
             .Build();

            condutorAppService.Editar(condutor.Id, condutorEditado);

            Condutor condutorEncontrado = condutorAppService.SelecionarPorId(condutor.Id);
            condutorEncontrado.Nome.Should().Be(condutorEditado.Nome);

        }
        [TestMethod]
        public void DeveExcluir_Condutor()
        {
            Cliente cliente = new ClienteDataBuilder().ComCPF(cpf)
              .ComEmail(email)
              .ComEndereco(endereco)
              .ComTelefone(telefone)
              .ComRG(rg).ComCNPJ(cnpj)
              .ComNome(nome)
              .Build();

            clienteAppService.InserirNovo(cliente);

            Condutor condutor = new CondutorDataBuilder().ComCliente(cliente)
             .ComCPF(cpf)
             .ComEndereco(endereco)
             .ComTelefone(telefone)
             .ComRG(rg)
             .ComValidadeCNH(data)
             .ComNumeroCNH(numero)
             .ComNome(nome)
             .Build();

            condutorAppService.InserirNovo(condutor);

            condutorAppService.Excluir(condutor.Id);

            Condutor condutorEncontrado = condutorAppService.SelecionarPorId(condutor.Id);
            condutorEncontrado.Should().BeNull();
        }
        [TestMethod]
        public void DeveSelecionar_Condutor_PorId()
        {
            Cliente cliente = new ClienteDataBuilder().ComCPF(cpf)
              .ComEmail(email)
              .ComEndereco(endereco)
              .ComTelefone(telefone)
              .ComRG(rg).ComCNPJ(cnpj)
              .ComNome(nome)
              .Build();

            clienteAppService.InserirNovo(cliente);

            Condutor condutor = new CondutorDataBuilder().ComCliente(cliente)
             .ComCPF(cpf)
             .ComEndereco(endereco)
             .ComTelefone(telefone)
             .ComRG(rg)
             .ComValidadeCNH(data)
             .ComNumeroCNH(numero)
             .ComNome(nome)
             .Build();

            condutorAppService.InserirNovo(condutor);

            Condutor condutor1 = condutorAppService.SelecionarPorId(condutor.Id);
            condutor1.Should().NotBeNull();

        }
        [TestMethod]
        public void DeveSelecionar_TodosCondutores()
        {
            Cliente cliente = new ClienteDataBuilder().ComCPF(cpf)
              .ComEmail(email)
              .ComEndereco(endereco)
              .ComTelefone(telefone)
              .ComRG(rg).ComCNPJ(cnpj)
              .ComNome(nome)
              .Build();

            clienteAppService.InserirNovo(cliente);
            var condutores = new List<Condutor>
            {
                new Condutor("Joao", "Rua dos joao", "9522185224", "5222525", "20202020221", "522541",new DateTime(2022, 05, 26), cliente),
                new Condutor("marcelo", "Rua dos joao", "9522185224", "5222526", "20202020252", "522542",new DateTime(2022, 05, 26), cliente),
                new Condutor("carlos", "Rua dos joao", "9522185224", "5222527", "20202020282", "522543",new DateTime(2022, 05, 26), cliente),
                new Condutor("ze", "Rua dos joao", "9522185224", "5222528", "20202020292", "522544",new DateTime(2022, 05, 26), cliente),
                new Condutor("Bastiao", "Rua dos joao", "9522185224", "5222529", "20202020242", "522545",new DateTime(2022, 05, 26), cliente)

            };
            foreach (var c in condutores)
                condutorAppService.InserirNovo(c);

            var condutoreSelecionado = condutorAppService.SelecionarTodos();

            condutoreSelecionado.Should().HaveCount(5);

        }
        [TestMethod]
        public void DeveSelecionar_Condutores_Com_CNH_Vencida()
        {
            Cliente cliente = new ClienteDataBuilder().ComCPF(cpf)
              .ComEmail(email)
              .ComEndereco(endereco)
              .ComTelefone(telefone)
              .ComRG(rg).ComCNPJ(cnpj)
              .ComNome(nome)
              .Build();

            clienteAppService.InserirNovo(cliente);
            var condutores = new List<Condutor>
            {
                 new CondutorDataBuilder().ComCliente(cliente)
             .ComCPF(cpf)
             .ComEndereco(endereco)
             .ComTelefone(telefone)
             .ComRG(rg)
             .ComValidadeCNH(data)
             .ComNumeroCNH(numero)
             .ComNome(nome)
             .Build(),

                 new CondutorDataBuilder().ComCliente(cliente)
             .ComCPF(cpf)
             .ComEndereco(endereco)
             .ComTelefone(telefone)
             .ComRG(rg)
             .ComValidadeCNH(new DateTime(2020, 08, 30))
             .ComNumeroCNH(numero)
             .ComNome("juca cnh vencida")
             .Build(),
            };

            foreach (var condutor in condutores)
                condutorAppService.InserirNovo(condutor);

            DateTime hoje = new DateTime(2021, 8, 31);
            var CnhVencida = condutorAppService.SelecionarCondutoresComCnhVencida(hoje);

            CnhVencida.Should().HaveCount(0);
        }
    }
}
