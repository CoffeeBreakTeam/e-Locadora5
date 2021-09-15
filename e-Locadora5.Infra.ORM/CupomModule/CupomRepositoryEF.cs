using e_Locadora5.Dominio.CupomModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.CupomModule
{
    public class CupomRepositoryEF : ICupomRepository
    {
        public string EditarCupom(int id, Cupons cupons)
        {
            throw new NotImplementedException();
        }

        public bool ExcluirCupom(int id)
        {
            throw new NotImplementedException();
        }

        public bool Existe(int id)
        {
            throw new NotImplementedException();
        }

        public void InserirCupom(Cupons cupons)
        {
            throw new NotImplementedException();
        }

        public Cupons SelecionarPorID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cupons> SelecionarTodos()
        {
            throw new NotImplementedException();
        }

        string ICupomRepository.InserirCupom(Cupons cupons)
        {
            throw new NotImplementedException();
        }
    }
}
