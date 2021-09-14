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

        public string InserirNovoCliente(Clientes cliente)
        {
            string resultadoValidacao = cliente.Validar();
            string validarRepeticoes = ValidarClientes(cliente);
            bool clienteValido = resultadoValidacao == "ESTA_VALIDO" && validarRepeticoes == "ESTA_VALIDO";
            if (clienteValido)
            {
                clienteRepository.InserirCliente(cliente);               
            }
            return resultadoValidacao;
        }

        public string EditarCliente(int id, Clientes cliente)
        {
            string resultadoValidacao = cliente.Validar();
            string validarRepeticoes = ValidarClientes(cliente, id);
            bool clienteValido = resultadoValidacao == "ESTA_VALIDO" && validarRepeticoes == "ESTA_VALIDO";
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

        public string ValidarClientes(Clientes novoClientes, int id = 0)
        {
            //validar placas iguais
            if (novoClientes != null)
            {
                if (id != 0)
                {//situação de editar
                    int countCPFsIguais = 0;
                    int countRGsIguais = 0;
                    int countCNPJsIguais = 0;
                    List<Clientes> todosClientes = SelecionarTodos();
                    foreach (Clientes cliente in todosClientes)
                    {
                        if (novoClientes.CPF.Equals(cliente.CPF) && cliente.Id != id && novoClientes.CPF != "")
                            countCPFsIguais++;
                        if (novoClientes.RG.Equals(cliente.RG) && cliente.Id != id && novoClientes.RG != "")
                            countRGsIguais++;
                        if (novoClientes.CNPJ.Equals(cliente.CNPJ) && cliente.Id != id && novoClientes.CNPJ != "")
                            countCNPJsIguais++;
                    }
                    if (countCPFsIguais > 0)
                        return "CPF já cadastrado, tente novamente.";
                    if (countRGsIguais > 0)
                        return "RG já cadastrado, tente novamente.";
                    if (countCNPJsIguais > 0)
                        return "CNPJ já cadastrado, tente novamente.";
                }
                else
                {//situação de inserir
                    int countCPFsIguais = 0;
                    int countRGsIguais = 0;
                    int countCNPJsIguais = 0;
                    List<Clientes> todosClientess = SelecionarTodos();
                    foreach (Clientes cliente in todosClientess)
                    {
                        if (novoClientes.CPF.Equals(cliente.CPF) && novoClientes.CPF != "")
                            countCPFsIguais++;
                        if (novoClientes.RG.Equals(cliente.RG) && novoClientes.RG != "")
                            countRGsIguais++;
                        if (novoClientes.CNPJ.Equals(cliente.CNPJ) && novoClientes.CNPJ != "")
                            countCNPJsIguais++;
                    }
                    if (countCPFsIguais > 0)
                        return "CPF já cadastrado, tente novamente.";
                    if (countRGsIguais > 0)
                        return "RG já cadastrado, tente novamente.";
                    if (countCNPJsIguais > 0)
                        return "CNPJ já cadastrado, tente novamente.";
                }
            }
            return "ESTA_VALIDO";
        }

    }
}
