using e_Locadora5.Dominio.VeiculosModule;
using e_Locadora5.Infra.ORM.LocadoraModule;
using e_Locadora5.Infra.ORM.ParceiroModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.VeiculoModule
{
    public class VeiculoOrmDAO : RepositoryBase<Veiculo, int>, IVeiculoRepository
    {
        public VeiculoOrmDAO(LocadoraDbContext locadoraDbContext) : base(locadoraDbContext)
        {
        }

        public bool ExisteVeiculoComEssaPlaca(string placa)
        {
            throw new NotImplementedException();
        } 

        public Veiculo SelecionarPorIdCarregandoLocacoes(int id)
        {
            throw new NotImplementedException();
        }
    }
}
