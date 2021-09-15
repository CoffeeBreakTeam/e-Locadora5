using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio.CupomModule
{
    public interface ICupomRepository
    {
        string InserirCupom(Cupons cupons);

        string EditarCupom(int id ,Cupons cupons);

        abstract bool ExcluirCupom(int id);

        abstract bool Existe(int id);

        List<Cupons> SelecionarTodos();

        Cupons SelecionarPorID(int id);
    }
}
