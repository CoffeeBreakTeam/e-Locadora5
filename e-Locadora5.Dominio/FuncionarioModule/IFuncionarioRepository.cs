using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio.FuncionarioModule
{
    public interface IFuncionarioRepository
    {
        public void InserirNovo(Funcionario funcionario);

        public void Editar(int id, Funcionario registro);

        public void Excluir(int id);

        public bool Existe(int id);

        public Funcionario SelecionarPorId(int id);

        public List<Funcionario> SelecionarTodos();
    }
}
