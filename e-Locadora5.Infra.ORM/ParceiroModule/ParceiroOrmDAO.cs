using e_Locadora5.Dominio.ParceirosModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.ParceiroModule
{
    public class ParceiroOrmDAO : IParceiroRepository
    {
        LocadoraDbContext parceiroDbContext;
        public ParceiroOrmDAO()
        {
            this.parceiroDbContext = new LocadoraDbContext();
        }

        public void EditarParceiro(int id, Parceiro parceiro)
        {
            //parceiro.Id 
        }

        public void ExcluirParceiro(int id)
        {
            throw new NotImplementedException();
        }

        public bool Existe(int id)
        {
            return parceiroDbContext.Parceiros.ToList().Exists(x => x.Id == id);
        }

        public bool ExisteParceiroComEsseNome(string nome)
        {
            return parceiroDbContext.Parceiros.ToList().Exists(x => x.nome == nome);
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
