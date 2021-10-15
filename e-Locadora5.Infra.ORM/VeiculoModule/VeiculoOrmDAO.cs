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
        LocadoraDbContext locadoraDb;
        public VeiculoOrmDAO(LocadoraDbContext locadoraDbContext) : base(locadoraDbContext)
        {
            locadoraDb = locadoraDbContext;
        }

        public bool ExisteVeiculoComEssaPlaca(string placa)
        {
            return locadoraDb.Veiculos.ToList().Exists(x => x.Placa == placa);
        } 

        public Veiculo SelecionarPorIdCarregandoLocacoes(int id)
        {
            //return locadoraDb.Veiculos.ToList().Include(x => x.lo)
            return null;
        }
    }
}
