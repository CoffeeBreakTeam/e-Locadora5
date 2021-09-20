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
        private Cupons cupom;

        public Cupons Build()
        {
            return cupom;
        }

        public CupomDataBuiler()
        {
            cupom = new Cupons();
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
    }
}
