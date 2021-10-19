using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio.TaxasServicosModule
{
    public interface ITaxasServicosRepository : IRepository<TaxasServicos, int>, IReadOnlyRepository<TaxasServicos, int>
    {
        bool ExisteTaxasComEsseNome(int id, string nome);
    }
}
