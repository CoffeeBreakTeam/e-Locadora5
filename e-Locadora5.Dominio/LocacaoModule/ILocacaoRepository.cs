using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio.LocacaoModule
{
    public interface ILocacaoRepository
    {
        List<Locacao> SelecionarTodasLocacoes();

        void InserirLocacao(Locacao locacao);

        Locacao SelecionarPorId(int id);
    }
}
