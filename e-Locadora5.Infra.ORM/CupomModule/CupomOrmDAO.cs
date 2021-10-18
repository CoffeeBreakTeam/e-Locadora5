using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Infra.ORM.LocadoraModule;
using e_Locadora5.Infra.ORM.ParceiroModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.CupomModule
{
    public class CupomOrmDAO : RepositoryBase<Cupom, int> , ICupomRepository
    {
        LocadoraDbContext locadoraDbContext;
        public CupomOrmDAO(LocadoraDbContext locadoraDbContext) : base(locadoraDbContext)
        {
            this.locadoraDbContext = locadoraDbContext;
        }

        public bool ExisteCupomMesmoNome(string nome)
        {
            var listaCupons = locadoraDbContext.Cupons.ToList();
            if (listaCupons == null)
            {
                return false;
            }
            else
            {
                return listaCupons.Exists(x => x.Nome == nome);
            }
           
        }
    }
}
