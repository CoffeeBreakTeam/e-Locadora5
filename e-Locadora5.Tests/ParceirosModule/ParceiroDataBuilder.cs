using e_Locadora5.Dominio.ParceirosModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Tests.ParceirosModule
{
    public class ParceiroDataBuilder
    {
        Parceiro parceiro;

        public ParceiroDataBuilder()
        {
            parceiro = new Parceiro();
        }
        public ParceiroDataBuilder ComNome(string nome)
        {
            parceiro.nome = nome;
            return this;
        }
        public Parceiro Build()
        {
            return parceiro;
        }

        public Parceiro GerarParceiroCompleto()
        {
            return this.ComNome("João")
            .Build();
        }
    }
}
