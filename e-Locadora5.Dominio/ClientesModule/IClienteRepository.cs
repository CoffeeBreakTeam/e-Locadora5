using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio.ClientesModule
{
    public interface IClienteRepository
    {
        public void InserirCliente(Cliente cliente);

        public void EditarCliente(int id,Cliente cliente);

        public void ExcluirCliente(int id);

        public List<Cliente> SelecionarTodosClientes();

        public bool Existe(int id);

        public bool ExisteClienteComEsteCPF(int id, string cpf);

        public bool ExisteClienteComEsteRG(int id, string rg);

        public Cliente SelecionarClientePorId(int id);
        
    }
}
