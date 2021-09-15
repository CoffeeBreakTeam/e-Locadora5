using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio.CupomModule
{
    public interface ICupomRepository
    {
        void InserirNovo(Cupons cupons);

        void Editar(int id ,Cupons cupons);

        abstract bool Excluir(int id);

        abstract bool Existe(int id);

        List<Cupons> SelecionarTodos();

        Cupons SelecionarPorId(int id);
    }
}
