using e_Locadora5.Dominio.TaxasServicosModule;
using e_Locadora5.Infra.ORM.LocadoraModule;
using e_Locadora5.Infra.ORM.ParceiroModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.TaxasServicosModule
{
    public class TaxasServicosOrmDAO : RepositoryBase<TaxasServicos, int>, ITaxasServicosRepository

    {
        public TaxasServicosOrmDAO(LocadoraDbContext locadoraDbContext) : base(locadoraDbContext)
        {
        }
    }
}
