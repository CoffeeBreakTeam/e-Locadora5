using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Infra.ORM.LocadoraModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.ParceiroModule
{
    public class ParceiroOrmDAO : RepositoryBase<Parceiro, int> , IParceiroRepository
    {
       
        public ParceiroOrmDAO(LocadoraDbContext locadoraDbContext): base(locadoraDbContext)
        {          
        }

        public bool ExisteParceiroComEsseNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
