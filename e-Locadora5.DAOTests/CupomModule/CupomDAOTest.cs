using e_Locadora5.DataBuilderTest.CupomModule;
using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Infra.SQL;
using e_Locadora5.Infra.SQL.CupomModule;
using e_Locadora5.Infra.SQL.ParceiroModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.DAOTests.CupomModule
{
    [TestClass]
    public class CupomDAOTest
    {
        string Nome;
        int ValorPercentual;
        double ValorFixo;
        DateTime DataValidade;
        Parceiro parceiro;
        double ValorMinimo;

        public CupomDAOTest()
        {
            Nome = "CHGDS";
            ValorPercentual = 100;
            ValorFixo = 100;
            DataValidade = DateTime.Now;
            parceiro = new Parceiro("Deko");
            ValorMinimo = 200;
        }

        [TestCleanup()]
        public void LimparTabelas()
        {
            //Db.Update("DELETE FROM TBPARCEIROS");
            Db.Update("DELETE FROM TBCUPONS");
        }

        [TestMethod]
        public void Deve_InserirNovo_Cupom()
        {
            CupomDAO cupomDAO = new CupomDAO();

            //arrange
            Cupons NovoCupom = new CupomDataBuilder()
                .ComNome(Nome)
                .ComValorPercentual(ValorPercentual)
                .ComValorFixo(ValorFixo)
                .ComDataValidade(DataValidade)
                .ComParceiro(parceiro)
                .ComValorMinimo(ValorMinimo)
                .Build();

            //action
            ParceiroDAO parceiroDao = new ParceiroDAO();

            parceiroDao.InserirParceiro(parceiro);
            cupomDAO.InserirNovo(NovoCupom);

            //assert
            var cupomEncontrado = cupomDAO.SelecionarPorId(NovoCupom.Id);
            cupomEncontrado.Should().Be(NovoCupom);
        }

        [TestMethod]
        public void Deve_Editar_Cupom()
        {
            CupomDAO cupomDAO = new CupomDAO();

            //arrange
            Cupons cupom = new CupomDataBuilder()
               .ComNome(Nome)
               .ComValorPercentual(ValorPercentual)
               .ComValorFixo(ValorFixo)
               .ComDataValidade(DataValidade)
               .ComParceiro(parceiro)
               .ComValorMinimo(ValorMinimo)
               .Build();

            Cupons CupomAtualizado = new CupomDataBuilder()
               .ComNome("Lucas")
               .ComValorPercentual(ValorPercentual)
               .ComValorFixo(ValorFixo)
               .ComDataValidade(DataValidade)
               .ComParceiro(parceiro)
               .ComValorMinimo(ValorMinimo)
               .Build();

            //action
            ParceiroDAO parceiroDao = new ParceiroDAO();

            parceiroDao.InserirParceiro(parceiro);
            cupomDAO.InserirNovo(cupom);

            cupomDAO.Editar(cupom.Id, CupomAtualizado);

            //assert
            var cupomEditado = cupomDAO.SelecionarPorId(cupom.Id);
            cupomEditado.Should().Be(CupomAtualizado);
        }

        [TestMethod]
        public void Deve_Excluir_Cupom()
        {
            CupomDAO cupomDAO = new CupomDAO();

            //arrange
            Cupons cupom = new CupomDataBuilder()
               .ComNome(Nome)
               .ComValorPercentual(ValorPercentual)
               .ComValorFixo(ValorFixo)
               .ComDataValidade(DataValidade)
               .ComParceiro(parceiro)
               .ComValorMinimo(ValorMinimo)
               .Build();

            //action
            ParceiroDAO parceiroDao = new ParceiroDAO();

            parceiroDao.InserirParceiro(parceiro);
            cupomDAO.InserirNovo(cupom);
            cupomDAO.Excluir(cupom.Id);

            //assert
            var cupomExcluido = cupomDAO.SelecionarPorId(cupom.Id);
            cupomExcluido.Should().BeNull();
        }

        [TestMethod]
        public void Deve_Selecionar_Cupom_Por_ID()
        {
            CupomDAO cupomDAO = new CupomDAO();

            //arrange
            Cupons cupom = new CupomDataBuilder()
               .ComNome(Nome)
               .ComValorPercentual(ValorPercentual)
               .ComValorFixo(ValorFixo)
               .ComDataValidade(DataValidade)
               .ComParceiro(parceiro)
               .ComValorMinimo(ValorMinimo)
               .Build();

            //action
            ParceiroDAO parceiroDao = new ParceiroDAO();

            parceiroDao.InserirParceiro(parceiro);
            cupomDAO.InserirNovo(cupom);

            //assert
            var cupomID = cupomDAO.SelecionarPorId(cupom.Id);
            cupomID.Should().Be(cupom);
        }

        [TestMethod]
        public void Deve_Selecionar_Todos_Cupom()
        {
            CupomDAO cupomDAO = new CupomDAO();

            //arrange
            Cupons cupom = new CupomDataBuilder()
               .ComNome(Nome)
               .ComValorPercentual(ValorPercentual)
               .ComValorFixo(ValorFixo)
               .ComDataValidade(DataValidade)
               .ComParceiro(parceiro)
               .ComValorMinimo(ValorMinimo)
               .Build();

            //action
            ParceiroDAO parceiroDao = new ParceiroDAO();

            parceiroDao.InserirParceiro(parceiro);
            cupomDAO.InserirNovo(cupom);

            //assert
            var todosCupons = cupomDAO.SelecionarTodos();
            todosCupons.Should().HaveCount(1);
        }
    }
}
