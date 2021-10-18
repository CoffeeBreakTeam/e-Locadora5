using e_Locadora5.Dominio;
using e_Locadora5.Dominio.Shared;
using e_Locadora5.Infra.ORM.ParceiroModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.LocadoraModule
{

    public class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>,
        IReadOnlyRepository<TEntity, TKey> 
        where TEntity : EntidadeBase<TKey>, new() 
    {

        private LocadoraDbContext locadoraDbContext;
        private readonly DbSet<TEntity> dbSet;

        public RepositoryBase(LocadoraDbContext locadoraDbContext)
        {
            this.locadoraDbContext = locadoraDbContext;
            this.dbSet = locadoraDbContext.Set<TEntity>();
        }

        public virtual bool Editar(int id, TEntity entidadeAtualizada)
        {
            try
            {
                Log.Information("Tentando editar {entidade} no banco de dados...", entidadeAtualizada);                      

                if (locadoraDbContext.Entry(entidadeAtualizada).State != EntityState.Modified)
                {
                    var entidadeAntiga = SelecionarPorId(id);
                    
                    entidadeAtualizada.Id = id;

                    locadoraDbContext.Entry(entidadeAntiga).CurrentValues.SetValues(entidadeAtualizada);               

                }                              

                locadoraDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Log.Information(ex, "Erro ao editar {entidade} no banco de dados...", entidadeAtualizada);
                return false;
            }           
        }

        public bool Excluir(int id)
        {
            TEntity entidadeBaseParaRemocao = null;
            try
            {
                entidadeBaseParaRemocao = SelecionarPorId(id);
                Log.Information("Tentando excluir {entidade} do banco de dados...", entidadeBaseParaRemocao);
                
                dbSet.Remove(entidadeBaseParaRemocao);
                locadoraDbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Log.Information(ex, "Erro ao editar {entidade} no banco de dados...", entidadeBaseParaRemocao);
                return false;
            }
        }

        public bool Existe(int id)
        {
            return dbSet.ToList().Exists(x => x.Id == id);
        }

        public virtual bool InserirNovo(TEntity entidadeBase)
        {
            try
            {
                Log.Information("Tentando inserir {entidade} no banco de dados...", entidadeBase);
                dbSet.Add(entidadeBase);
                locadoraDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Log.Information(ex,"Erro ao inserir {entidade} no banco de dados...", entidadeBase);
                return false;                
            }          
        }

        public virtual TEntity SelecionarPorId(int id)
        {
            return dbSet.ToList().Find(x => x.Id == id);
        }

        public virtual List<TEntity> SelecionarTodos()
        {
            return dbSet.ToList();
        }
    }
}
