using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio.CupomModule
{
    public interface ICupomRepository
    {
        public void InserirNovo(Cupom cupons);

        public void Editar(int id ,Cupom cupons);

        public void Excluir(int id);

        public bool Existe(int id);

        public List<Cupom> SelecionarTodos();

        public Cupom SelecionarPorId(int id);

        public bool ExisteCupomMesmoNome(string nome);
    }
}
