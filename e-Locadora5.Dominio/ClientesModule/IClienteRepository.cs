using e_Locadora5.Dominio.CondutoresModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio.ClientesModule
{
    public interface IClienteRepository : IRepository<Cliente, int>, IReadOnlyRepository<Cliente, int> 
    {
        

        public bool ExisteClienteComEsteCPF(int id, string cpf);

        public bool ExisteClienteComEsteRG(int id, string rg);

    
        
    }
}
