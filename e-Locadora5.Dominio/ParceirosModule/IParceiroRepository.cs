using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio.ParceirosModule
{
    public interface IParceiroRepository
    {
        public void InserirParceiro(Parceiro parceiro);

        public void EditarParceiro(int id, Parceiro parceiro);

        public void ExcluirParceiro(int id);

        public List<Parceiro> SelecionarTodosParceiros();

        public bool Existe(int id);

        public Parceiro SelecionarParceiroPorId(int id);

        public bool ExisteParceiroComEsseNome(string nome);
    }
}
