using e_Locadora5.Dominio.ParceirosModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.ParceiroModule
{
    public class ParceiroRepositoryEF : IParceiroRepository
    {
        ParceiroDbContext parceiroDbContext;
        public ParceiroRepositoryEF()
        {
            this.parceiroDbContext = new ParceiroDbContext();
        }

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
            parceiroDbContext.Parceiros.Add(parceiro);
            parceiroDbContext.SaveChanges();
        }

        public Parceiro SelecionarParceiroPorId(int id)
        {
            return parceiroDbContext.Parceiros.ToList().Find(x => x.Id == id);
        }

        public List<Parceiro> SelecionarTodosParceiros()
        {
            return parceiroDbContext.Parceiros.ToList();
        }
    }
}
