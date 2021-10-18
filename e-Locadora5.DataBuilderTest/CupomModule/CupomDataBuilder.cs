using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.ParceirosModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.DataBuilderTest.CupomModule
{
    public class CupomDataBuilder
    {
        string Nome;
        int ValorPercentual;
        double ValorFixo;
        DateTime DataValidade;
        Parceiro parceiro;
        double ValorMinimo;

        private Cupom cupom;

        public Cupom Build()
        {
            return cupom;
        }

        public CupomDataBuilder()
        {
            cupom = new Cupom();

            Nome = "Lucas";
            ValorPercentual = 100;
            ValorFixo = 50;
            DataValidade = DateTime.Now;
            parceiro = new Parceiro("Deko");
            ValorMinimo = 500;
        }

        public CupomDataBuilder ComNome(string nome)
        {
            cupom.Nome = nome;
            return this;
        }
        public CupomDataBuilder ComValorPercentual(int valorPercentual)
        {
            cupom.ValorPercentual = valorPercentual;
            return this;
        }

        public CupomDataBuilder ComValorFixo(double valorFixo)
        {
            cupom.ValorFixo = valorFixo;
            return this;
        }

        public CupomDataBuilder ComDataValidade(DateTime dataValidade)
        {
            cupom.DataValidade = dataValidade;
            return this;
        }

        public CupomDataBuilder ComParceiro(Parceiro parceiro)
        {
            cupom.Parceiro = parceiro;
            return this;
        }

        public CupomDataBuilder ComValorMinimo(double valorMinimo)
        {
            cupom.ValorMinimo = valorMinimo;
            return this;
        }

        public Cupom GerarCupomCompleto()
        {
            return this.ComNome(Nome)
                .ComValorPercentual(ValorPercentual)
                .ComValorFixo(ValorFixo)
                .ComDataValidade(DataValidade)
                .ComParceiro(parceiro)
                .ComValorMinimo(ValorMinimo)
                .Build();
        }
    }
}
