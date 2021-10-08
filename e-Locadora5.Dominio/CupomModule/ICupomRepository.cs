using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio.CupomModule
{
    public interface ICupomRepository : IReadOnlyRepository<Cupom, int>, IRepository<Cupom, int>
    {
        public bool ExisteCupomMesmoNome(string nome);
    }
}
