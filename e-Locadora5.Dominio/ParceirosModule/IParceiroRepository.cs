using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio.ParceirosModule
{
    public interface IParceiroRepository<T> : IDisposable where T : class
    {
        public void InserirParceiro(T entity);

        public void EditarParceiro(T entity);

        public void ExcluirParceiro(Guid id);

        IEnumerable<T> SelecionarTodosParceiros();

        public bool Existe(Guid id);

        T SelecionarParceiroPorId(Guid id);

        public bool ExisteParceiroComEsseNome(string nome);

        void Salvar();
    }
}
