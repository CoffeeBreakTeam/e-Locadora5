using e_Locadora5.Aplicacao.GrupoVeiculoModule;
using e_Locadora5.Aplicacao.VeiculoModule;
using e_Locadora5.Dominio;
using e_Locadora5.Dominio.GrupoVeiculoModule;
using e_Locadora5.Dominio.VeiculosModule;
using e_Locadora5.Infra.ORM.GrupoVeiculoModule;
using e_Locadora5.Infra.ORM.ParceiroModule;
using e_Locadora5.Infra.ORM.VeiculoModule;
using e_Locadora5.Infra.SQL;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.EFTests.VeiculoModule
{
    [TestClass]
    public class VeiculoEFTest
    {
        IVeiculoRepository veiculoRepository = null;
        IGrupoVeiculoRepository grupoVeiculoRepository = null;

        [TestCleanup()]
        public void LimparTabelas()
        {
            Db.Update("DELETE FROM LOCACAOTAXASSERVICOS");
            Db.Update("DELETE FROM TBLOCACAO");
            Db.Update("DELETE FROM TBVEICULO");
            Db.Update("DELETE FROM TBGrupoVeiculo");
        }

        public VeiculoEFTest()
        {
            LimparTabelas();
            LocadoraDbContext locadoraDbContext = new LocadoraDbContext();
            veiculoRepository = new VeiculoOrmDAO(locadoraDbContext);
            grupoVeiculoRepository = new GrupoVeiculoOrmDAO(locadoraDbContext);
        }
        [TestMethod]
        public void DeveInserir_Veiculo()
        {
            //arrange
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var grupoVeiculo = new GrupoVeiculo("SUV", 1000, 2000, 3000, 500, 4000, 500);
            var veiculo = new Veiculo("1234", "Modelo", "Fabricante", 0, 4, 4, "4", "azul", 4, 1994, "grande", "etanol", grupoVeiculo, imagem);

            //action
            grupoVeiculoRepository.InserirNovo(grupoVeiculo);
            veiculoRepository.InserirNovo(veiculo);

            //assert
            var veiculoEncontrado = veiculoRepository.SelecionarPorId(veiculo.Id);
            veiculoEncontrado.Should().Be(veiculo);
        }

        [TestMethod]
        public void DeveAtualizar_Veiculo()
        {
            //arrange
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var grupoVeiculo = new GrupoVeiculo("SUV", 1000, 2000, 3000, 500, 4000, 500);
            var veiculo = new Veiculo("1234", "Modelo", "Fabricante", 4, 4, 4, "4", "azul", 4, 1994, "grande", "etanol", grupoVeiculo, imagem);


            var novoVeiculo = new Veiculo("4321", "Modelo", "Fabricante", 4, 4, 4, "4", "branco", 4, 1996, "grande", "etanol", grupoVeiculo, imagem);

            //action
            grupoVeiculoRepository.InserirNovo(grupoVeiculo);
            veiculoRepository.InserirNovo(veiculo);
            veiculoRepository.Editar(veiculo.Id, novoVeiculo);

            //assert
            Veiculo VeiculoAtualizado = veiculoRepository.SelecionarPorId(veiculo.Id);
            VeiculoAtualizado.Cor.Should().Be(novoVeiculo.Cor);
        }

        [TestMethod]
        public void DeveExcluir_Veiculo()
        {
            //arrange
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var grupoVeiculo = new GrupoVeiculo("SUV", 1000, 2000, 3000, 500, 4000, 500);
            var veiculo = new Veiculo("1234", "Modelo", "Fabricante", 0, 4, 4, "4", "azul", 4, 1994, "grande", "etanol", grupoVeiculo, imagem);


            //action
            grupoVeiculoRepository.InserirNovo(grupoVeiculo);
            veiculoRepository.InserirNovo(veiculo);
            veiculoRepository.Excluir(veiculo.Id);

            //assert
            Veiculo grupoVeiculoEncontrado = veiculoRepository.SelecionarPorId(veiculo.Id);
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
            grupoVeiculoRepository.InserirNovo(grupoVeiculo);
            veiculoRepository.InserirNovo(veiculo);

            Veiculo grupoVeiculoEncontrado = veiculoRepository.SelecionarPorId(veiculo.Id);

            //assert
            grupoVeiculoEncontrado.Should().NotBeNull();
        }

        [TestMethod]
        public void DeveSelecionar_TodosVeiculos()
        {
            //arrange
            var imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var grupoVeiculo = new GrupoVeiculo("SUV", 1000, 2000, 3000, 500, 4000, 500);
            grupoVeiculoRepository.InserirNovo(grupoVeiculo);
            var veiculo1 = new Veiculo("1234", "Modelo", "Fabricante", 0, 4, 4, "4", "azul", 4, 1994, "grande", "etanol", grupoVeiculo, imagem);
            veiculoRepository.InserirNovo(veiculo1);

            var veiculo2 = new Veiculo("2345", "Modelo", "Fabricante", 0, 4, 4, "4", "azul", 4, 1994, "grande", "etanol", grupoVeiculo, imagem);
            veiculoRepository.InserirNovo(veiculo2);

            var veiculo3 = new Veiculo("3456", "Modelo", "Fabricante", 0, 4, 4, "4", "azul", 4, 1994, "grande", "etanol", grupoVeiculo, imagem);
            veiculoRepository.InserirNovo(veiculo3);

            //action
            var veiculos = veiculoRepository.SelecionarTodos();

            //assert
            veiculos.Should().HaveCount(3);
            veiculos[0].Placa.Should().Be("1234");
            veiculos[1].Placa.Should().Be("2345");
            veiculos[2].Placa.Should().Be("3456");
        }
    }
}
