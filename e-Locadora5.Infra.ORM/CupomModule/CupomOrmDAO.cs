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
        public CupomOrmDAO(LocadoraDbContext locadoraDbContext) : base(locadoraDbContext)
        {
        }

        public bool ExisteCupomMesmoNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
