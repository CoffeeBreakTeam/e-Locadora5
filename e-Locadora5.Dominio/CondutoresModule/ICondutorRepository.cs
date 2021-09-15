using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio.CondutoresModule
{
    public interface ICondutorRepository
    {
        public void InserirNovo(Condutor registro);

        public void Editar(int id, Condutor registro);

        public void Excluir(int id);

        public bool Existe(int id);

        public Condutor SelecionarPorId(int id);

        public List<Condutor> SelecionarTodos();

        public List<Condutor> SelecionarCondutoresComCnhVencida(DateTime data);
    }
}
