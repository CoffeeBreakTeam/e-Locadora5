using e_Locadora5.Dominio.ClientesModule;
using System;
using System.Collections.Generic;

namespace e_Locadora5.Aplicacao.ClienteModule
{
    public class ClienteAppService
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteAppService(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public string InserirNovo(Clientes cliente)
        {
            string resultadoValidacao = cliente.Validar();

            if (clienteRepository.ExisteClienteComEsteCPF(cliente.Id, cliente.CPF))
            {
                return "Já há um cliente cadastrado com este CPF";
            }
            if (clienteRepository.ExisteClienteComEsteRG(cliente.Id, cliente.RG))
            {
                return "Já há um cliente cadastrado com este RG";
            }

            bool clienteValido = resultadoValidacao == "ESTA_VALIDO";
            if (clienteValido)
            {
                clienteRepository.InserirCliente(cliente);               
            }
            return resultadoValidacao;
        }

        public string Editar(int id, Clientes cliente)
        {
            string resultadoValidacao = cliente.Validar();
            if (clienteRepository.ExisteClienteComEsteCPF(cliente.Id, cliente.CPF))
            {
                return "Já há um cliente cadastrado com este CPF";
            }
            if (clienteRepository.ExisteClienteComEsteRG(cliente.Id, cliente.RG))
            {
                return "Já há um cliente cadastrado com este RG";
            }
            bool clienteValido = resultadoValidacao == "ESTA_VALIDO";
            if ( clienteValido)
            {
                cliente.Id = id;
                clienteRepository.EditarCliente(id, cliente);
            }
            return resultadoValidacao;
        }

        public bool Excluir(int id)
        {
            try
            {
                clienteRepository.ExcluirCliente(id);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool Existe(int id)
        {
            return clienteRepository.Existe(id);
        }

        public Clientes SelecionarPorId(int id)
        {
            return clienteRepository.SelecionarClientePorId(id);
        }

        public  List<Clientes> SelecionarTodos()
        {
            return clienteRepository.SelecionarTodosClientes();
        }     

    }
}
