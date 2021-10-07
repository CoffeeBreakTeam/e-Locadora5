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

                bool existeCPF = locadoraDbContext.Clientes.ToList().Exists(x => x.CPF == cpf);
                if (existeCPF)
                {
                    var estaInserindo = id == 0;
                    if (estaInserindo)
                    {
                        return true;
                    }

                    var ClienteComCpfRepetido = locadoraDbContext.Clientes.ToList().Find(x => x.CPF == cpf);
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
                Serilog.Log.Logger.Information("Verificando se existe cliente com rg {@rg} no bancos de dados...", rg);

                bool existeRG = locadoraDbContext.Clientes.ToList().Exists(x => x.RG == rg);
                if (existeRG)
                {
                    var estaInserindo = id == 0;
                    if (estaInserindo)
                    {
                        return true;
                    }

                    var ClienteComRGRepetido = locadoraDbContext.Clientes.ToList().Find(x => x.RG == rg);
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
            throw new NotImplementedException();
        }
    }
}
