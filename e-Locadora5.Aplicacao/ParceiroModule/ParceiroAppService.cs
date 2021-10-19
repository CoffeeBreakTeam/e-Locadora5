using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Infra.GeradorLogs;
using Serilog;
using System;
using System.Collections.Generic;


namespace e_Locadora5.Aplicacao.ParceiroModule
{
    public class ParceiroAppService
    {
        IParceiroRepository parceiroRepository;
        public ParceiroAppService(IParceiroRepository parceiroRepository)
        {
            this.parceiroRepository = parceiroRepository;
        }

        public string InserirNovo(Parceiro parceiro)
        {
            string resultadoValidacao = parceiro.Validar();

            if (parceiroRepository.ExisteParceiroComEsseNome(parceiro.Nome))
            {
                Log.Logger.Contexto().Warning("Já há um parceiro cadastrado com este Nome: {@nome}", parceiro.Nome);
                return "Parceiro já Cadastrado, tente novamente.";
            }
            if (resultadoValidacao == "ESTA_VALIDO")
            {
                try
                {
                    parceiroRepository.InserirNovo(parceiro);
                    Log.Logger.Contexto().Information("Parceiro {@parceiro} foi inserido com sucesso.", parceiro);
                }
                catch (Exception ex)
                {
                    Log.Logger.Contexto().Error(ex, "Não foi possível inserir o parceiro {@parceiro}", parceiro);
                }
            }

            return resultadoValidacao;

        }
        public string Editar(int id, Parceiro parceiro)
        {
            string resultadoValidacao = parceiro.Validar();
           
            if (parceiroRepository.ExisteParceiroComEsseNome(parceiro.Nome))
            {
                Log.Logger.Contexto().Warning("Já há um parceiro cadastrado com este nome {@nome}", parceiro.Nome);
                return "Parceiro já Cadastrado, tente novamente.";
            }
            if (resultadoValidacao == "ESTA_VALIDO")
            {
                try
                {
                    Log.Logger.Contexto().Information("Parceiro {@parceiro} foi editado com sucesso.", parceiro);
                    parceiro.Id = id;
                    parceiroRepository.Editar(id, parceiro);
                }
                catch (Exception ex)
                {
                    Log.Logger.Contexto().Error(ex, "Não foi possível editar o parceiro {@parceiro}", parceiro);
                }
                
            }
            
            return resultadoValidacao;
        }
        public bool Excluir(int id)
        {
            try
            {
                parceiroRepository.Excluir(id);
                Log.Logger.Contexto().Information("Parceiro de id {@id} foi excluído com sucesso", id);
            }
            catch (Exception ex)
            {
                Log.Logger.Contexto().Error(ex, "Não foi possível excluir o parceiro com id {@id}", id);
                return false;
            }

            return true;
        }
        public bool Existe(int id)
        {
            try
            {
                bool existe = parceiroRepository.Existe(id);
                Log.Logger.Contexto().Information("Verificado se existe o parceiro com id {@id}", id);
                return existe;
            }
            catch (Exception ex)
            {
                Log.Logger.Contexto().Error(ex, "Não foi possível verificar se existe o parceiro com id {@id}", id);
                return false;
            }
        }
        public Parceiro SelecionarPorId(int id)
        {
            try
            {
                Parceiro parceiroSelecionado = parceiroRepository.SelecionarPorId(id);
                Log.Logger.Contexto().Information("Selecionado parceiro {@clienteSelecionado}", parceiroSelecionado);
                return parceiroSelecionado;
            }
            catch (Exception ex)
            {
                Log.Logger.Contexto().Error(ex, "Não foi possível selecionar o parceiro com id {@id}", id);
                return null;
            }
            
        }
        public List<Parceiro> SelecionarTodos()
        {
            try
            {
                List<Parceiro> todosParceiros = parceiroRepository.SelecionarTodos();
                Log.Logger.Contexto().Information("Selecionado todos os parceiros {@todosParceiros}", todosParceiros);
                return todosParceiros;
            }
            catch (Exception ex)
            {
                Log.Logger.Contexto().Error(ex, "Não foi possível selecionar todos os parceiros");
                return null;
            }
        }
        public string ValidarParceiros(Parceiro novoParceiro, int id = 0)
        {
            if (parceiroRepository.ExisteParceiroComEsseNome(novoParceiro.Nome))
            {
                return "Parceiro já cadastrado!";
            }
            return "ESTA_VALIDO";
        }
    }
}
