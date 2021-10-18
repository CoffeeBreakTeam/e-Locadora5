﻿using e_Locadora5.Dominio.TaxasServicosModule;
using e_Locadora5.Infra.GeradorLogs;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Aplicacao.TaxasServicosModule
{
    public class TaxasServicosAppService
    {
        ITaxasServicosRepository taxasServicosRepository;

        public TaxasServicosAppService(ITaxasServicosRepository taxasServicosRepository) {
            this.taxasServicosRepository = taxasServicosRepository;
        }

        public string InserirNovo(TaxasServicos registro)
        {
            try
            {
                string resultadoValidacao = registro.Validar();
                string resultadoValidacaoControlador = ValidarTaxasServicos(registro);

                if (resultadoValidacao == "ESTA_VALIDO" && resultadoValidacaoControlador == "ESTA_VALIDO")
                {
                    taxasServicosRepository.InserirNovo(registro);
                    Log.Logger.Contexto().Information("TaxaServico {@taxaServico} foi inserido com sucesso.", registro);
                    return "ESTA_VALIDO";
                }

                if (resultadoValidacao != "ESTA_VALIDO")
                {
                    Log.Logger.Contexto().Warning("TaxaServico {@taxaServico} inválida: {@resultadoValidacao}", registro, resultadoValidacao);
                    return resultadoValidacao;
                }
                else
                {
                    Log.Logger.Contexto().Warning("TaxaServico {@taxaServico} inválida: {@resultadoValidacaoControlador}", registro, resultadoValidacaoControlador);
                    return resultadoValidacaoControlador;
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Contexto().Error(ex, "Não foi possível inserir a taxaServico {@taxaServico}", registro);
                return "Não foi possível inserir a taxaServico";
            }
        }

        public string Editar(int id, TaxasServicos registro)
        {
            try 
            {
                string resultadoValidacao = registro.Validar();
                string resultadoValidacaoControlador = ValidarTaxasServicos(registro, id);

                if (resultadoValidacao == "ESTA_VALIDO" && resultadoValidacaoControlador == "ESTA_VALIDO")
                {
                    taxasServicosRepository.Editar(id, registro);
                    Log.Logger.Contexto().Information("TaxaServico {@taxaServico} foi editado com sucesso.", registro);
                }

                if (resultadoValidacao != "ESTA_VALIDO")
                {
                    Log.Logger.Contexto().Warning("TaxaServico {@taxaServico} inválida: {@resultadoValidacao}", registro, resultadoValidacao);
                    return resultadoValidacao;
                }
                else
                {
                    Log.Logger.Contexto().Information("TaxaServico {@taxaServico} editado com sucesso: {@resultadoValidacaoControlador}", registro, resultadoValidacaoControlador);
                    return resultadoValidacaoControlador;
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Contexto().Error(ex, "Não foi possível editar a taxaServico {@taxaServico}", registro);
                return "Não foi possível editar a taxaServico";
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                taxasServicosRepository.Excluir(id);
                Log.Logger.Contexto().Information("TaxaServico de id {@id} foi excluído com sucesso", id);
                return true;
            }
            catch (Exception ex)
            {
                Log.Logger.Contexto().Error(ex, "Não foi possível excluir o cliente com id {@id}", id);
                return false;
            }
        }

        public bool Existe(int id)
        {
            try
            {
                bool existe = taxasServicosRepository.Existe(id);
                Log.Logger.Contexto().Information("Verificado se existe a taxaServico com id {@idTaxaServico}", id);
                return existe;
            }
            catch (Exception ex)
            {
                Log.Logger.Contexto().Error(ex, "Não foi possível verificar se existe a taxaServico com id {@idTaxaServico}", id);
                return false;
            }
            return taxasServicosRepository.Existe(id);
        }
        
        public TaxasServicos SelecionarPorId(int id)
        {
            try
            {
                TaxasServicos taxaServicoSelecionado = taxasServicosRepository.SelecionarPorId(id);
                Log.Logger.Contexto().Information("Selecionado taxaServico {@taxaServicoSelecionado}", taxaServicoSelecionado);
                return taxaServicoSelecionado;
            }
            catch (Exception ex)
            {
                Log.Logger.Contexto().Error(ex, "Não foi possível selecionar a taxaServico com id {@idTaxaServico}", id);
                return null;
            }
        }

        public List<TaxasServicos> SelecionarTodos()
        {
            try
            {
                List<TaxasServicos> todasTaxasServicos = taxasServicosRepository.SelecionarTodos();
                Log.Logger.Contexto().Information("Selecionado todas as taxasServicos {@todasTaxasServicos}", todasTaxasServicos);
                return todasTaxasServicos;
            }
            catch (Exception ex)
            {
                Log.Logger.Contexto().Error(ex, "Não foi possível selecionar todas as taxasServicos");
                return null;
            }
        }

        public string ValidarTaxasServicos(TaxasServicos novoTaxasServicos, int id = 0)
        {
            if (taxasServicosRepository.ExisteTaxasComEsseNome(novoTaxasServicos.Descricao))
            {
                return "Taxa já cadastrada!";
            }
            return "ESTA_VALIDO";
        }
    }
}
