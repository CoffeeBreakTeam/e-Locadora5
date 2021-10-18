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
        LocadoraDbContext locadoraDb;
        public TaxasServicosOrmDAO(LocadoraDbContext locadoraDbContext) : base(locadoraDbContext)
        {
            locadoraDb = locadoraDbContext;
        }

        public bool ExisteTaxasComEsseNome(string nome)
        {
            return locadoraDb.TaxasServicos.ToList().Exists(x => x.Descricao == nome);
        }
    }
}
