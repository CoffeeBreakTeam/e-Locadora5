using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Infra.ORM.ParceiroModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.CupomModule
{
    public class CupomOrmDAO : ICupomRepository
    {
        LocadoraDbContext cupom;

        public CupomOrmDAO()
        {
            this.cupom = new LocadoraDbContext();
        }

        public void Editar(int id, Cupom cupons)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public bool Existe(int id)
        {
            return cupom.Cupons.ToList().Exists(x => x.Id == id);
        }

        public void InserirNovo(Cupom cupons)
        {
            cupom.Cupons.Add(cupons);
            cupom.SaveChanges();
        }

        public Cupom SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cupom> SelecionarTodos()
        {
            return cupom.Cupons.ToList();
        }

        public Cupom SelecionarPorID(int id)
        {
            return cupom.Cupons.ToList().Find(x => x.Id == id);
        }

        public bool ExisteCupomMesmoNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
