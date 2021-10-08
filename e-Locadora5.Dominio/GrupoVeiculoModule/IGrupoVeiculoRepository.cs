using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio.GrupoVeiculoModule
{
    public interface IGrupoVeiculoRepository : IRepository<GrupoVeiculo, int>, IReadOnlyRepository<GrupoVeiculo, int>
    {
       
    }
}
