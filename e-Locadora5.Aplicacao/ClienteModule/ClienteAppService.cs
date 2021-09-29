﻿using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Infra.GeradorLogs;
using Serilog;
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
                Log.Logger.Contexto().Warning("Já há um cliente cadastrado com este CPF {@cpf}", cliente.CPF);
                return "Já há um cliente cadastrado com este CPF";
            }
            if (clienteRepository.ExisteClienteComEsteRG(cliente.Id, cliente.RG))
            {
                Log.Logger.Contexto().Warning("Já há um cliente cadastrado com este RG {@rg}", cliente.RG);
                return "Já há um cliente cadastrado com este RG";
            }

            bool clienteValido = resultadoValidacao == "ESTA_VALIDO";
            if (clienteValido)
            {
                try
                {
                    clienteRepository.InserirCliente(cliente);
                    Log.Logger.Contexto().Information("Cliente {@cliente} foi inserido com sucesso.", cliente);
                }
                catch (Exception ex)
                {
                    Log.Logger.Contexto().Error(ex, "Não foi possível inserir o cliente {@cliente}", cliente);
                }
            }
            else
                Log.Logger.Contexto().Warning("Cliente inválido: {@resultadoValidacao}", resultadoValidacao);
            return resultadoValidacao;
        }

        public string Editar(int id, Clientes cliente)
        {
            string resultadoValidacao = cliente.Validar();
            if (clienteRepository.ExisteClienteComEsteCPF(cliente.Id, cliente.CPF))
            {
                Log.Logger.Contexto().Warning("Já há um cliente cadastrado com este CPF {@cpf}", cliente.CPF);
                return "Já há um cliente cadastrado com este CPF";
            }
            if (clienteRepository.ExisteClienteComEsteRG(cliente.Id, cliente.RG))
            {
                Log.Logger.Contexto().Warning("Já há um cliente cadastrado com este RG {@rg}", cliente.RG);
                return "Já há um cliente cadastrado com este RG";
            }
            bool clienteValido = resultadoValidacao == "ESTA_VALIDO";
            if (clienteValido)
            {
                try
                {
                    cliente.Id = id;
                    clienteRepository.EditarCliente(id, cliente);
                    Log.Logger.Contexto().Information("Cliente {@cliente} foi editado com sucesso.", cliente);
                }
                catch (Exception ex)
                {
                    Log.Logger.Contexto().Error(ex, "Não foi possível editar o cliente {@cliente}", cliente);
                }
            }
            else
                Log.Logger.Contexto().Warning("Cliente inválido: {@resultadoValidacao}", resultadoValidacao);
            return resultadoValidacao;
        }

        public bool Excluir(int id)
        {
            try
            {
                clienteRepository.ExcluirCliente(id);
                Log.Logger.Contexto().Information("Cliente de id {@id} foi excluído com sucesso", id);
            }
            catch (Exception ex)
            {
                Log.Logger.Contexto().Error(ex, "Não foi possível excluir o cliente com id {@id}", id);
                return false;
            }

            return true;
        }

        public bool Existe(int id)
        {
            try
            {
                bool existe = clienteRepository.Existe(id);
                Log.Logger.Contexto().Information("Verificado se existe o cliente com id {@id}", id);
                return existe;
            }
            catch(Exception ex)
            {
                Log.Logger.Contexto().Error(ex, "Não foi possível verificar se existe o cliente com id {@id}", id);
                return false;
            }
            
        }

        public Clientes SelecionarPorId(int id)
        {
            try
            {
                Clientes clienteSelecionado = clienteRepository.SelecionarClientePorId(id);
                Log.Logger.Contexto().Information("Selecionado cliente {@clienteSelecionado}", clienteSelecionado);
                return clienteSelecionado;
            }
            catch (Exception ex)
            {
                Log.Logger.Contexto().Error(ex, "Não foi possível selecionar o cliente com id {@idCliente}", id);
                return null;
            }

        }

        public  List<Clientes> SelecionarTodos()
        {
            try 
            {
                List<Clientes> todosClientes = clienteRepository.SelecionarTodosClientes();
                Log.Logger.Contexto().Information("Selecionado todos os clientes {@todosClientes}", todosClientes);
                return todosClientes;
            }
            catch (Exception ex)
            {
                Log.Logger.Contexto().Error(ex, "Não foi possível selecionar todos os clientes");
                return null;
            }

        }     

    }
}
