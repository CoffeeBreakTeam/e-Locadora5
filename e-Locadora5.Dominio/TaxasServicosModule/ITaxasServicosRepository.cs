using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio.TaxasServicosModule
{
    public interface ITaxasServicosRepository
    {
        public void InserirNovo(TaxasServicos registro);

        public void Editar(int id, TaxasServicos registro);

        public void Excluir(int id);

        public bool Existe(int id);

        public TaxasServicos SelecionarPorId(int id);

        public List<TaxasServicos> SelecionarTodos();
    }
}
