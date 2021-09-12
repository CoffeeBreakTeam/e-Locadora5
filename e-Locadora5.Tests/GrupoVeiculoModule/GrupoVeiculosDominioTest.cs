using e_Locadora5.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace e_Locadora5.Tests.GrupoVeiculos
{
    [TestClass]
    public class GrupoVeiculosDominioTest
    {
        [TestMethod]
        public void Deve_Validar_GrupoDeVeiculos()
        {
            string categoria = "SUV";
            double planoDiarioValorKm = 2000;
            double planoDiarioValorDiario = 3000;
            double planoKmControladoValorKm = 4000;
            double planoKmControladoQtdKm = 6000;
            double planoKmControladoValorDiario = 6000;
            double planoKmLivreValorDiario = 2000;

            GrupoVeiculo grupoVeiculo = new GrupoVeiculo(categoria, planoDiarioValorKm, planoDiarioValorDiario, planoKmControladoValorKm, planoKmControladoQtdKm, planoKmControladoValorDiario, planoKmLivreValorDiario);
            Assert.AreEqual("ESTA_VALIDO", grupoVeiculo.Validar());
        }

        [TestMethod]
        public void Nao_Deve_Validar_Categoria()
        {
            string categoria = "";
            double planoDiarioValorKm = 1000;
            double planoDiarioValorDiario = 2000;
            double planoKmControladoValorKm = 3000;
            double planoKmControladoQtdKm = 6000;
            double planoKmControladoValorDiario = 5000;
            double planoKmLivreValorDiario = 6000;

            GrupoVeiculo grupoVeiculo = new GrupoVeiculo(categoria, planoDiarioValorKm, planoDiarioValorDiario, planoKmControladoValorKm, planoKmControladoQtdKm, planoKmControladoValorDiario, planoKmLivreValorDiario);
            Assert.AreEqual("O atributo categoria é obrigatório e não pode ser vazio.", grupoVeiculo.Validar());
        }

        [TestMethod]
        public void Nao_Deve_Validar_Plano_Diario_Valor_Km()
        {
            string categoria = "SUV";
            double planoDiarioValorKm = 0;
            double planoDiarioValorDiario = 2000;
            double planoKmControladoValorKm = 3000;
            double planoKmControladoQtdKm = 6000;
            double planoKmControladoValorDiario = 5000;
            double planoKmLivreValorDiario = 6000;

            GrupoVeiculo grupoVeiculo = new GrupoVeiculo(categoria, planoDiarioValorKm, planoDiarioValorDiario, planoKmControladoValorKm, planoKmControladoQtdKm, planoKmControladoValorDiario, planoKmLivreValorDiario);
            Assert.AreEqual("O atributo planoDiarioValorKm deve ser maior que zero.", grupoVeiculo.Validar());
        }

        [TestMethod]
        public void Nao_Deve_Validar_Plano_Diario_Valor_Diario()
        {
            string categoria = "SUV";
            double planoDiarioValorKm = 2000;
            double planoDiarioValorDiario = 0;
            double planoKmControladoValorKm = 3000;
            double planoKmControladoQtdKm = 6000;
            double planoKmControladoValorDiario = 5000;
            double planoKmLivreValorDiario = 6000;

            GrupoVeiculo grupoVeiculo = new GrupoVeiculo(categoria, planoDiarioValorKm, planoDiarioValorDiario, planoKmControladoValorKm, planoKmControladoQtdKm, planoKmControladoValorDiario, planoKmLivreValorDiario);
            Assert.AreEqual("O atributo planoDiarioValorDiario deve ser maior que zero.", grupoVeiculo.Validar());
        }

        [TestMethod]
        public void Nao_Deve_Validar_Plano_Controlado_Valor_Km()
        {
            string categoria = "SUV";
            double planoDiarioValorKm = 2000;
            double planoDiarioValorDiario = 3000;
            double planoKmControladoValorKm = 0;
            double planoKmControladoQtdKm = 6000;
            double planoKmControladoValorDiario = 5000;
            double planoKmLivreValorDiario = 6000;

            GrupoVeiculo grupoVeiculo = new GrupoVeiculo(categoria, planoDiarioValorKm, planoDiarioValorDiario, planoKmControladoValorKm, planoKmControladoQtdKm, planoKmControladoValorDiario, planoKmLivreValorDiario);
            Assert.AreEqual("O atributo planoKmControladoValorKm deve ser maior que zero.", grupoVeiculo.Validar());
        }

        [TestMethod]
        public void Nao_Deve_Validar_Plano_Controlado_Qtd_Km()
        {
            string categoria = "SUV";
            double planoDiarioValorKm = 2000;
            double planoDiarioValorDiario = 3000;
            double planoKmControladoValorKm = 4000;
            double planoKmControladoQtdKm = 0;
            double planoKmControladoValorDiario = 6000;
            double planoKmLivreValorDiario = 6000;

            GrupoVeiculo grupoVeiculo = new GrupoVeiculo(categoria, planoDiarioValorKm, planoDiarioValorDiario, planoKmControladoValorKm, planoKmControladoQtdKm, planoKmControladoValorDiario, planoKmLivreValorDiario);
            Assert.AreEqual("O atributo planoKmControladoQuantidadeKm deve ser maior que zero.", grupoVeiculo.Validar());
        }

        [TestMethod]
        public void Nao_Deve_Validar_Plano_Controlado_Valor_Diario()
        {
            string categoria = "SUV";
            double planoDiarioValorKm = 2000;
            double planoDiarioValorDiario = 3000;
            double planoKmControladoValorKm = 4000;
            double planoKmControladoQtdKm = 6000;
            double planoKmControladoValorDiario = 0;
            double planoKmLivreValorDiario = 6000;

            GrupoVeiculo grupoVeiculo = new GrupoVeiculo(categoria, planoDiarioValorKm, planoDiarioValorDiario, planoKmControladoValorKm, planoKmControladoQtdKm, planoKmControladoValorDiario, planoKmLivreValorDiario);
            Assert.AreEqual("O atributo planoKmControladoValorDiario deve ser maior que zero.", grupoVeiculo.Validar());
        }

        [TestMethod]
        public void Nao_Deve_Validar_Plano_Km_Livre_Diario()
        {
            string categoria = "SUV";
            double planoDiarioValorKm = 2000;
            double planoDiarioValorDiario = 3000;
            double planoKmControladoValorKm = 4000;
            double planoKmControladoQtdKm = 6000;
            double planoKmControladoValorDiario = 6000;
            double planoKmLivreValorDiario = 0;

            GrupoVeiculo grupoVeiculo = new GrupoVeiculo(categoria, planoDiarioValorKm, planoDiarioValorDiario, planoKmControladoValorKm, planoKmControladoQtdKm,planoKmControladoValorDiario, planoKmLivreValorDiario);
            Assert.AreEqual("O atributo planoKmLivreValorDiario deve ser maior que zero.", grupoVeiculo.Validar());
        }
    }
}
