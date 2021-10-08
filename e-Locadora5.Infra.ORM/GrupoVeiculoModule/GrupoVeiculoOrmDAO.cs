using e_Locadora5.Dominio;
using e_Locadora5.Dominio.GrupoVeiculoModule;
using e_Locadora5.Infra.ORM.LocadoraModule;
using e_Locadora5.Infra.ORM.ParceiroModule;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.GrupoVeiculoModule
{
    public class GrupoVeiculoOrmDAO : RepositoryBase<GrupoVeiculo, int>, IGrupoVeiculoRepository
    {
        LocadoraDbContext locadoraDbContext;
        public GrupoVeiculoOrmDAO(LocadoraDbContext locadoraDbContext) : base(locadoraDbContext)
        {
            this.locadoraDbContext = locadoraDbContext;
        }

        public bool ExisteGrupoVeiculo(int id)
        {
            try
            {
                Serilog.Log.Logger.Information("Verificando se existe grupo de veículos com esse id: {@ID} no bancos de dados...", id);

                bool existeID = locadoraDbContext.Clientes.ToList().Exists(x => x.Id == id);
                if (existeID)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
    }
}
