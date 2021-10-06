using e_Locadora5.Dominio.ParceirosModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.ParceiroModule
{
    public class ParceiroRepositoryEF : IParceiroRepository
    {
        public void EditarParceiro(int id, Parceiro parceiro)
        {
            throw new NotImplementedException();
        }

        public void ExcluirParceiro(int id)
        {
            throw new NotImplementedException();
        }

        public bool Existe(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExisteParceiroComEsseNome(string nome)
        {
            throw new NotImplementedException();
        }

        public void InserirParceiro(Parceiro parceiro)
        {
            throw new NotImplementedException();
        }

        public Parceiro SelecionarParceiroPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Parceiro> SelecionarTodosParceiros()
        {
            throw new NotImplementedException();
        }
    }
}
