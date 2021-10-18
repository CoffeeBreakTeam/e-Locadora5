using e_Locadora5.Dominio.CondutoresModule;
using e_Locadora5.Infra.ORM.LocadoraModule;
using e_Locadora5.Infra.ORM.ParceiroModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.CondutorModule
{
    public class CondutorOrmDAO : RepositoryBase<Condutor, int>, ICondutorRepository
    {
        LocadoraDbContext locadoraDbContext;
        public CondutorOrmDAO(LocadoraDbContext locadoraDbContext) : base(locadoraDbContext)
        {
            this.locadoraDbContext = locadoraDbContext;      
        }

        public bool ExisteCondutorComEsteCPF(int id, string cpf)
        {
            try
            {
                Serilog.Log.Logger.Information("Verificando se existe cliente com cpf {@cpf} no bancos de dados...", cpf);

                bool existeCPF = locadoraDbContext.Condutores.ToList().Exists(x => x.Cpf == cpf);
                if (existeCPF)
                {
                    var estaInserindo = id == 0;
                    if (estaInserindo)
                    {
                        return true;
                    }

                    var ClienteComCpfRepetido = locadoraDbContext.Condutores.ToList().Find(x => x.Cpf == cpf);
                    var ClienteParaEdicao = SelecionarPorId(id);

                    if (ClienteComCpfRepetido.Id != ClienteParaEdicao.Id)
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
        public bool ExisteCondutorComEsteRG(int id, string rg)
        {
            try
            {
                Serilog.Log.Logger.Information("Verificando se existe condutor com rg {@rg} no bancos de dados...", rg);

                bool existeRG = locadoraDbContext.Condutores.ToList().Exists(x => x.Rg == rg);
                if (existeRG)
                {
                    var estaInserindo = id == 0;
                    if (estaInserindo)
                    {
                        return true;
                    }

                    var ClienteComRGRepetido = locadoraDbContext.Condutores.ToList().Find(x => x.Rg == rg);
                    var ClienteParaEdicao = SelecionarPorId(id);

                    if (ClienteComRGRepetido.Id != ClienteParaEdicao.Id)
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
        public List<Condutor> SelecionarCondutoresComCnhVencida(DateTime data)
        {
           
            List<Condutor> condutoresCNHVencida = locadoraDbContext.Condutores.ToList().FindAll(x => x.ValidadeCNH <= data);

            return condutoresCNHVencida;
            
        }
    }
}
