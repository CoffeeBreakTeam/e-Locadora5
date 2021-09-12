using e_Locadora5.Controladores;
using e_Locadora5.Controladores.ClientesModule;
using e_Locadora5.Controladores.CondutorModule;
using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.CondutoresModule;
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
        ControladorCondutor controladorCondutor = null;
        ControladorClientes controladorCliente = null;

        public ControladorCondutorTests()
        {
            controladorCondutor = new ControladorCondutor();
            controladorCliente = new ControladorClientes();

            Db.Update("DELETE FROM TBLOCACAO_TBTAXASSERVICOS");
            Db.Update("DELETE FROM TBLOCACAO");
            Db.Update("DELETE FROM [TBCONDUTOR]");
            Db.Update("DELETE FROM [TBCLIENTES]");
            
        }

        [TestMethod]
        public void Deve_InserirUmCondutor()
        {
            Clientes cliente = new Clientes("Arnaldo", "rua sem numero", "9524282242", "853242", "20220220222", "", "Joao.pereira@gmail.com");

            controladorCliente.InserirNovo(cliente);

            Condutor condutor = new Condutor("Joao", "Rua dos joao", "9522185224", "5222522", "20202020222", "522542",
                new DateTime(2022, 05, 26), cliente);

            controladorCondutor.InserirNovo(condutor);


            var condutorEncontrado = controladorCondutor.SelecionarPorId(condutor.Id);
            condutorEncontrado.Should().Be(condutor);

        }
        [TestMethod]
        public void DeveAtualizar_Condutor()
        {
            Clientes cliente = new Clientes("Arnaldo", "rua sem numero", "9524282242", "853242", "20220220222", "", "Joao.pereira@gmail.com");

            controladorCliente.InserirNovo(cliente);

            Condutor condutor = new Condutor("Joao", "Rua dos joao", "9522185224", "5222522", "20202020222", "522542",
                new DateTime(2022, 05, 26), cliente);

            controladorCondutor.InserirNovo(condutor);

            var condutorEditado = new Condutor("Joao", "rua sssds", "9522185224", "5222522", "20202020222", "522542",
                new DateTime(2022, 05, 22), cliente);

            controladorCondutor.Editar(condutor.Id, condutorEditado);

            Condutor condutorEncontrado = controladorCondutor.SelecionarPorId(condutor.Id);
            condutorEncontrado.Should().Be(condutorEditado);

        }
        [TestMethod]
        public void DeveExcluir_Condutor()
        {
            Clientes cliente = new Clientes("Arnaldo", "rua sem numero", "9524282242", "853242", "20220220222", "", "Joao.pereira@gmail.com");

            controladorCliente.InserirNovo(cliente);

            Condutor condutor = new Condutor("Joao", "Rua dos joao", "9522185224", "5222522", "20202020222", "522542",
                new DateTime(2022, 05, 26), cliente);

            controladorCondutor.InserirNovo(condutor);

            controladorCondutor.Excluir(condutor.Id);

            Condutor condutorEncontrado = controladorCondutor.SelecionarPorId(condutor.Id);
            condutorEncontrado.Should().BeNull();
        }
        [TestMethod]
        public void DeveSelecionar_Condutor_PorId()
        {
            Clientes cliente = new Clientes("Arnaldo", "rua sem numero", "9524282242", "853242", "20220220222", "", "Joao.pereira@gmail.com");

            controladorCliente.InserirNovo(cliente);

            Condutor condutor = new Condutor("Joao", "Rua dos joao", "9522185224", "5222522", "20202020222", "522542",
                new DateTime(2022, 05, 26), cliente);

            controladorCondutor.InserirNovo(condutor);

            Condutor condutor1 = controladorCondutor.SelecionarPorId(condutor.Id);
            condutor1.Should().NotBeNull();

        }
        [TestMethod]
        public void DeveSelecionar_TodosCondutores()
        {
            Clientes cliente = new Clientes("Arnaldo", "rua sem numero", "9524282242", "853242", "20220220222", "", "Joao.pereira@gmail.com");

            controladorCliente.InserirNovo(cliente);
            var condutores = new List<Condutor>
            {
                new Condutor("Joao", "Rua dos joao", "9522185224", "5222525", "20202020221", "522541",new DateTime(2022, 05, 26), cliente),
                new Condutor("marcelo", "Rua dos joao", "9522185224", "5222526", "20202020252", "522542",new DateTime(2022, 05, 26), cliente),
                new Condutor("carlos", "Rua dos joao", "9522185224", "5222527", "20202020282", "522543",new DateTime(2022, 05, 26), cliente),
                new Condutor("ze", "Rua dos joao", "9522185224", "5222528", "20202020292", "522544",new DateTime(2022, 05, 26), cliente),
                new Condutor("Bastiao", "Rua dos joao", "9522185224", "5222529", "20202020242", "522545",new DateTime(2022, 05, 26), cliente)

            };
            foreach (var c in condutores)
                controladorCondutor.InserirNovo(c);

            var condutoreSelecionado = controladorCondutor.SelecionarTodos();

            condutoreSelecionado.Should().HaveCount(5);

        }
        [TestMethod]
        public void DeveSelecionar_Condutores_Com_CNH_Vencida()
        {
            Clientes cliente = new Clientes("Arnaldo", "rua sem numero", "9524282242", "853242", "20220220221", "", "Joao.pereira@gmail.com");

            controladorCliente.InserirNovo(cliente);
            var condutores = new List<Condutor>
            {
               new Condutor("Joao", "Rua dos joao", "9522185224", "5222525", "20202020221", "522541",new DateTime(2022, 05, 26), cliente),
                new Condutor("marcelo", "Rua dos joao", "9522185224", "5222526", "20202020252", "522542",new DateTime(2022, 05, 26), cliente),
                new Condutor("carlos", "Rua dos joao", "9522185224", "5222527", "20202020282", "522543",new DateTime(2020, 08, 30), cliente),
                new Condutor("ze", "Rua dos joao", "9522185224", "5222528", "20202020292", "522544",new DateTime(2022, 05, 26), cliente),
                new Condutor("Bastiao", "Rua dos joao", "9522185224", "5222529", "20202020242", "522545",new DateTime(2022, 05, 26), cliente)

            };
            foreach (var c in condutores)
                controladorCondutor.InserirNovo(c);

            DateTime hoje = new DateTime(2021, 8, 31);
            var CnhVencida = controladorCondutor.SelecionarCondutoresComCnhVencida(hoje);

            CnhVencida.Should().HaveCount(0);
        }
    }
}
