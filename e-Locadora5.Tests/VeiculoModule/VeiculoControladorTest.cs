using e_Locadora5.Aplicacao.GrupoVeiculoModule;
using e_Locadora5.Aplicacao.VeiculoModule;
using e_Locadora5.Dominio;
using e_Locadora5.Dominio.VeiculosModule;
using e_Locadora5.Infra.SQL;
using e_Locadora5.Infra.SQL.GrupoVeiculoModule;
using e_Locadora5.Infra.SQL.VeiculoModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Tests.Veiculos
{
    [TestClass]
    public class VeiculosControladorTest
    {
        VeiculoAppService veiculoAppService = null;
        GrupoVeiculoAppService grupoVeiculoAppService = null;

        public VeiculosControladorTest()
        {
            LimparTabelas();
            veiculoAppService = new VeiculoAppService(new VeiculoDAO());
            grupoVeiculoAppService = new GrupoVeiculoAppService(new GrupoVeiculoDAO());
        }

        [TestCleanup()]
        public void LimparTabelas()
        {
            Db.Update("DELETE FROM TBLOCACAO_TBTAXASSERVICOS");
            Db.Update("DELETE FROM TBLOCACAO");
            Db.Update("DELETE FROM TBVEICULOS");
            Db.Update("DELETE FROM CATEGORIAS");
        }

        [TestMethod]
        public void DeveInserir_Veiculo()
        {
            //arrange
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var grupoVeiculo = new GrupoVeiculo("SUV", 1000, 2000, 3000, 500, 4000, 500);
            var veiculo = new Veiculo("1234", "Modelo", "Fabricante", 0, 4, 4, "4", "azul", 4, 1994, "grande", "etanol", grupoVeiculo, imagem);

            //action
            grupoVeiculoAppService.InserirNovo(grupoVeiculo);
            veiculoAppService.InserirNovo(veiculo);

            //assert
            var veiculoEncontrado = veiculoAppService.SelecionarPorId(veiculo.Id);
            veiculoEncontrado.Should().Be(veiculo);
        }

        [TestMethod]
        public void DeveAtualizar_Veiculo()
        {
            //arrange
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var grupoVeiculo = new GrupoVeiculo("SUV", 1000, 2000, 3000, 500, 4000, 500);
            var veiculo = new Veiculo("1234", "Modelo", "Fabricante", 4, 4, 4, "4", "azul", 4, 1994, "grande", "etanol", grupoVeiculo, imagem);
            

            var novoVeiculo = new Veiculo("1234", "Modelo", "Fabricante", 4, 4, 4, "4", "azul", 4, 1996, "grande", "etanol", grupoVeiculo, imagem);

            //action
            grupoVeiculoAppService.InserirNovo(grupoVeiculo);
            veiculoAppService.InserirNovo(veiculo);
            veiculoAppService.Editar(veiculo.Id, novoVeiculo);

            //assert
            Veiculo grupoVeiculoAtualizado = veiculoAppService.SelecionarPorId(veiculo.Id);
            grupoVeiculoAtualizado.Should().Be(novoVeiculo);
        }

        [TestMethod]
        public void DeveExcluir_Veiculo()
        {
            //arrange
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var grupoVeiculo = new GrupoVeiculo("SUV", 1000, 2000, 3000, 500, 4000, 500);
            var veiculo = new Veiculo("1234", "Modelo", "Fabricante", 0, 4, 4, "4", "azul", 4, 1994, "grande", "etanol", grupoVeiculo, imagem);
            

            //action
            grupoVeiculoAppService.InserirNovo(grupoVeiculo);
            veiculoAppService.InserirNovo(veiculo);
            veiculoAppService.Excluir(veiculo.Id);

            //assert
            Veiculo grupoVeiculoEncontrado = veiculoAppService.SelecionarPorId(veiculo.Id);
            grupoVeiculoEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Veiculo_PorId()
        {
            //arrange
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var grupoVeiculo = new GrupoVeiculo("SUV", 1000, 2000, 3000, 500, 4000, 500);
            var veiculo = new Veiculo("1234", "Modelo", "Fabricante", 0, 4, 4, "4", "azul", 4, 1994, "grande", "etanol", grupoVeiculo, imagem);


            //action
            grupoVeiculoAppService.InserirNovo(grupoVeiculo);
            veiculoAppService.InserirNovo(veiculo);
            
            Veiculo grupoVeiculoEncontrado = veiculoAppService.SelecionarPorId(veiculo.Id);

            //assert
            grupoVeiculoEncontrado.Should().NotBeNull();
        }

        [TestMethod]
        public void DeveSelecionar_TodosVeiculos()
        {
            //arrange
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var grupoVeiculo = new GrupoVeiculo("SUV", 1000, 2000, 3000, 500, 4000, 500);
            grupoVeiculoAppService.InserirNovo(grupoVeiculo);
            var veiculo1 = new Veiculo("1234", "Modelo", "Fabricante", 0, 4, 4, "4", "azul", 4, 1994, "grande", "etanol", grupoVeiculo, imagem);
            veiculoAppService.InserirNovo(veiculo1);

            var veiculo2 = new Veiculo("2345", "Modelo", "Fabricante", 0, 4, 4, "4", "azul", 4, 1994, "grande", "etanol", grupoVeiculo, imagem);
            veiculoAppService.InserirNovo(veiculo2);

            var veiculo3 = new Veiculo("3456", "Modelo", "Fabricante", 0, 4, 4, "4", "azul", 4, 1994, "grande", "etanol", grupoVeiculo, imagem );
            veiculoAppService.InserirNovo(veiculo3);

            //action
            var veiculos = veiculoAppService.SelecionarTodos();

            //assert
            veiculos.Should().HaveCount(3);
            veiculos[0].Placa.Should().Be("1234");
            veiculos[1].Placa.Should().Be("2345");
            veiculos[2].Placa.Should().Be("3456");
        }
    }

}
