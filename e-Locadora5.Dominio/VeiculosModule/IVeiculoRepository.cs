using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio.VeiculosModule
{
    public interface IVeiculoRepository : IRepository<Veiculo, int>, IReadOnlyRepository<Veiculo, int>
    {
    
        public Veiculo SelecionarPorIdCarregandoLocacoes(int id);

        public bool ExisteVeiculoComEssaPlaca(string placa);

    
    }
}
