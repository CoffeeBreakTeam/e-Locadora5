using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio.ClientesModule
{
    public interface IClienteRepository
    {
        public void InserirCliente(Clientes cliente);

        public void EditarCliente(int id,Clientes cliente);

        public void ExcluirCliente(int id);

        public List<Clientes> SelecionarTodosClientes();

        public bool Existe(int id);

        public bool ExisteCondutorComEsteCPF(int id, string cpf);

        public bool ExisteCondutorComEsteRG(int id, string rg);

        public Clientes SelecionarClientePorId(int id);
    }
}
