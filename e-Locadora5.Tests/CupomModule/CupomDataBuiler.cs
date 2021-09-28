using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.ParceirosModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Tests.CupomModule
{
    public class CupomDataBuiler
    {
        string Nome;
        int ValorPercentual;
        double ValorFixo;
        DateTime DataValidade;
        Parceiro parceiro;
        double ValorMinimo;

        private Cupons cupom;

        public Cupons Build()
        {
            return cupom;
        }

        public CupomDataBuiler()
        {
            cupom = new Cupons();

            Nome = "CHGDS";
            ValorPercentual = 100;
            ValorFixo = 100;
            DataValidade = DateTime.Now;
            parceiro = new Parceiro("Deko");
            ValorMinimo = 200;
        }

        public CupomDataBuiler ComNome(string nome)
        {
            cupom.Nome = nome;
            return this;
        }
        public CupomDataBuiler ComValorPercentual(int valorPercentual)
        {
            cupom.ValorPercentual = valorPercentual;
            return this;
        }

        public CupomDataBuiler ComValorFixo(double valorFixo)
        {
            cupom.ValorFixo = valorFixo;
            return this;
        }

        public CupomDataBuiler ComDataValidade(DateTime dataValidade)
        {
            cupom.DataValidade = dataValidade;
            return this;
        }

        public CupomDataBuiler ComParceiro(Parceiro parceiro)
        {
            cupom.Parceiro = parceiro;
            return this;
        }
     
        public CupomDataBuiler ComValorMinimo(double valorMinimo)
        {
            cupom.ValorMinimo = valorMinimo;
            return this;
        }

        public Cupons GerarCupomCompleto()
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
