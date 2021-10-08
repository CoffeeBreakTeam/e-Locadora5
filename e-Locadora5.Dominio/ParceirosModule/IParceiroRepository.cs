using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio.ParceirosModule
{
    public interface IParceiroRepository : IRepository<Parceiro, int> , IReadOnlyRepository<Parceiro, int>
    {     
        public bool ExisteParceiroComEsseNome(string nome);
    }
}
