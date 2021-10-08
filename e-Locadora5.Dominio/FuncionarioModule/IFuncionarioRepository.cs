using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio.FuncionarioModule
{
    public interface IFuncionarioRepository : IRepository<Funcionario, int>, IReadOnlyRepository<Funcionario, int>
    {
    
    }
}
