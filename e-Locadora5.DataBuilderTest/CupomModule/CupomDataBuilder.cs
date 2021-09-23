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
        private Cupons cupom;

        public Cupons Build()
        {
            return cupom;
        }

        public CupomDataBuilder()
        {
            cupom = new Cupons();
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
    }
}
