using e_Locadora5.Dominio.FuncionarioModule;
using e_Locadora5.Infra.ORM.LocadoraModule;
using e_Locadora5.Infra.ORM.ParceiroModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.FuncionarioModule
{
    public class FuncionarioOrmDAO : RepositoryBase<Funcionario, int>, IFuncionarioRepository
    {
       
        public FuncionarioOrmDAO(LocadoraDbContext locadoraDbContext) : base(locadoraDbContext)
        {
        }
        //se precisar, implementações da interface IParceiroRepository 
    }
}
