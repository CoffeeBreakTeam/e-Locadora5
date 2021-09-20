using e_Locadora5.Dominio.ClientesModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.ClienteModule
{
    public class ClienteRepositoryEF : IClienteRepository
    {
        public void EditarCliente(int id, Clientes cliente)
        {
            throw new NotImplementedException();
        }

        public void ExcluirCliente(int id)
        {
            throw new NotImplementedException();
        }

        public bool Existe(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExisteClienteComEsteCPF(int id, string cpf)
        {
            throw new NotImplementedException();
        }

        public bool ExisteClienteComEsteRG(int id, string rg)
        {
            throw new NotImplementedException();
        }

        public void InserirCliente(Clientes cliente)
        {
            throw new NotImplementedException();
        }

        public Clientes SelecionarClientePorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Clientes> SelecionarTodosClientes()
        {
            throw new NotImplementedException();
        }
    }
}
