using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio
{
    public interface IReadOnlyRepository<TEntity, TKey>
    {
        List<TEntity> SelecionarTodos();
        TEntity SelecionarPorId(int id);
    }
}
