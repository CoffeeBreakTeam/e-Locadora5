using e_Locadora5.Aplicacao.TaxasServicosModule;
using e_Locadora5.Dominio.TaxasServicosModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.AppServiceTests.TaxasServicosModule
{
    [TestClass]
    public class TaxasServicosAppServiceTests
    {
        Mock<ITaxasServicosRepository> taxasServicosDAOMock;
        Mock<TaxasServicos> taxasServicosMock;

        public TaxasServicosAppServiceTests()
        {
            taxasServicosMock = new Mock<TaxasServicos>();

            taxasServicosDAOMock = new Mock<ITaxasServicosRepository>();
        }


        [TestMethod]
        public void Deve_Chamar_Inserir_Novo_Taxas_E_Servicos()
        {
            //arrange
            TaxasServicos novoTaxaServico = taxasServicosMock.Object;

            taxasServicosMock.Setup(x => x.Validar())
                .Returns(() =>
                {
                    return "ESTA_VALIDO";
                });

            taxasServicosDAOMock.Setup(x => x.SelecionarTodos())
                .Returns(() =>
                {
                    return null;
                });

            //action
            TaxasServicosAppService locacaoAppService = new TaxasServicosAppService(taxasServicosDAOMock.Object);
            locacaoAppService.InserirNovo(novoTaxaServico);

            //assert
            taxasServicosDAOMock.Verify(x => x.InserirNovo(novoTaxaServico));
        }

        [TestMethod]
        public void Deve_Chamar_Editar_Taxas_E_Servicos()
        {
            //arrange
            TaxasServicos novoTaxaServico = taxasServicosMock.Object;

            taxasServicosMock.Setup(x => x.Validar())
                .Returns(() =>
                {
                    return "ESTA_VALIDO";
                });

            taxasServicosDAOMock.Setup(x => x.SelecionarTodos())
                .Returns(() =>
                {
                    return null;
                });

            //action
            TaxasServicosAppService locacaoAppService = new TaxasServicosAppService(taxasServicosDAOMock.Object);
            locacaoAppService.Editar(novoTaxaServico.Id, novoTaxaServico);

            //assert
            taxasServicosDAOMock.Verify(x => x.Editar(novoTaxaServico.Id, novoTaxaServico));
        }

        [TestMethod]
        public void Deve_Chamar_SelecionarPorId_TaxasServicos_TaxaFixa()
        {
            //arrange
            TaxasServicos novoTaxaServico = taxasServicosMock.Object;

            //action
            TaxasServicosAppService locacaoAppService = new TaxasServicosAppService(taxasServicosDAOMock.Object);
            locacaoAppService.SelecionarPorId(novoTaxaServico.Id);

            //assert
            taxasServicosDAOMock.Verify(x => x.SelecionarPorId(novoTaxaServico.Id));
        }

        [TestMethod]
        public void Deve_Chamar_Excluir_TaxasServicos()
        {
            //arrange
            TaxasServicos novoTaxaServico = taxasServicosMock.Object;

            //action
            TaxasServicosAppService locacaoAppService = new TaxasServicosAppService(taxasServicosDAOMock.Object);
            locacaoAppService.Excluir(novoTaxaServico.Id);

            //assert
            taxasServicosDAOMock.Verify(x => x.Excluir(novoTaxaServico.Id));
        }

        [TestMethod]
        public void Deve_Chamar_Selecionar_TodosClientes()
        {
            //arrange
            TaxasServicos novoTaxaServico = taxasServicosMock.Object;

            //action
            TaxasServicosAppService locacaoAppService = new TaxasServicosAppService(taxasServicosDAOMock.Object);
            locacaoAppService.SelecionarTodos();

            //assert
            taxasServicosDAOMock.Verify(x => x.SelecionarTodos());
        }

        [TestMethod]

        public void Nao_Deve_Cadastrar_Descricao_Iguais()
        {

        }

        [TestMethod]
        public void Nao_Deve_Editar_Descricao_Iguais()
        {

        }
    }
}
