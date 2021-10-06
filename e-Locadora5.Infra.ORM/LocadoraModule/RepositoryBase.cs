using e_Locadora5.Dominio;
using e_Locadora5.Dominio.Shared;
using e_Locadora5.Infra.ORM.ParceiroModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.LocadoraModule
{

    public class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>,
        IReadOnlyRepository<TEntity, TKey> 
        where TEntity : EntidadeBase<TKey> 
    {

        private LocadoraDbContext locadoraDbContext;
        private readonly DbSet<TEntity> dbSet;

        public RepositoryBase(LocadoraDbContext locadoraDbContext)
        {
            this.locadoraDbContext = locadoraDbContext;
            this.dbSet = locadoraDbContext.Set<TEntity>();
        }

        public bool Editar(TKey id, TEntity entidadaBase)
        {
            throw new NotImplementedException();
        }

        public bool Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public bool Existe(int id)
        {
            throw new NotImplementedException();
        }

        public bool InserirNovo(TEntity entidadaBase)
        {
            throw new NotImplementedException();
        }

        public TEntity SelecionarPorId()
        {
            throw new NotImplementedException();
        }

        public List<TEntity> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
