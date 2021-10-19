using e_Locadora5.Dominio.TaxasServicosModule;
using e_Locadora5.Infra.ORM.LocadoraModule;
using e_Locadora5.Infra.ORM.ParceiroModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.TaxasServicosModule
{
    public class TaxasServicosOrmDAO : RepositoryBase<TaxasServicos, int>, ITaxasServicosRepository
    {
        LocadoraDbContext locadoraDbContext;
        public TaxasServicosOrmDAO(LocadoraDbContext locadoraDbContext) : base(locadoraDbContext)
        {
            this.locadoraDbContext = locadoraDbContext;
        }

        public bool ExisteTaxasComEsseNome(int id,string nome)
        {        

            try
            {
                Serilog.Log.Logger.Information("Verificando se existe Taxa com nome {@nome} no bancos de dados...", nome);

                bool existeNome = locadoraDbContext.TaxasServicos.ToList().Exists(x => x.Descricao == nome);
                if (existeNome)
                {
                    var estaInserindo = id == 0;
                    if (estaInserindo)
                    {
                        return true;
                    }

                    var TaxaComNomeRepetido = locadoraDbContext.TaxasServicos .ToList().Find(x => x.Descricao == nome);
                    var TaxaParaEdicao = SelecionarPorId(id);

                    if (TaxaComNomeRepetido.Id != TaxaParaEdicao.Id)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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
