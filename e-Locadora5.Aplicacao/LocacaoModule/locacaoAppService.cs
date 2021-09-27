using e_Locadora5.Dominio.LocacaoModule;
using e_Locadora5.Dominio.TaxasServicosModule;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Aplicacao.LocacaoModule
{
    public class LocacaoAppService
    {
        private readonly ILocacaoRepository locacaoRepository;

        public LocacaoAppService(ILocacaoRepository locacaoRepository)
        {
            this.locacaoRepository = locacaoRepository;
        }

        public string InserirNovo(Locacao registro)
        {
            registro.veiculo.Locacoes = SelecionarLocacoesPorVeiculoId(registro.veiculo.Id);
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                try
                {
                    locacaoRepository.InserirNovo(registro);
                    Log.Information("Locação {@locacao} foi inserido com sucesso.", registro);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Não foi possível inserir a locação {@locacao}", registro);
                }
            }
            else
                Log.Warning("Locação inválida: {@resultadoValidacao}", resultadoValidacao);

            return resultadoValidacao;
        }

        public string Editar(int id, Locacao registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                try
                {
                    locacaoRepository.Editar(id, registro);
                    Log.Information("Locação {@locacao} foi editado com sucesso.", registro);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Não foi possível editar a locação {@locacao}", registro);
                }
            }
            else
                Log.Warning("Locação inválida: {@resultadoValidacao}", resultadoValidacao);

            return resultadoValidacao;
        }

        public bool Excluir(int id)
        {
            try
            {
                locacaoRepository.Excluir(id);
                Log.Information("Locação de id {@idLocacao} foi excluído com sucesso", id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Não foi possível excluir a locação com id {@idLocacao}", id);
                return false;
            }

            return true;
        }

        public bool Existe(int id)
        {
            try
            {
                bool existe = locacaoRepository.Existe(id);
                Log.Information("Verificado se existe a locação com id {@idLocacao}", id);
                return existe;
            }
            catch (Exception ex) 
            {
                Log.Error(ex, "Não foi possível verificar se existe a locação com id {@idLocacao}", id);
                return false;
            }
            
        }

        public Locacao SelecionarPorId(int id)
        {
            try
            {
                Locacao locacaoSelecionado = locacaoRepository.SelecionarPorId(id);
                Log.Information("Selecionado locação {@locacaoSelecionado}", locacaoSelecionado);
                return locacaoSelecionado;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Não foi possível selecionar a locação com id {@idLocacao}", id);
                return null;
            }
        }

        public List<Locacao> SelecionarTodos()
        {
            try
            {
                List<Locacao> todasLocacoes = locacaoRepository.SelecionarTodos();
                Log.Information("Selecionado todas as locações {@todasLocacoes}", todasLocacoes);
                return todasLocacoes;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Não foi possível selecionar todas as locações");
                return null;
            }
        }

        public List<Locacao> SelecionarLocacoesPendentes(bool emAberto, DateTime dataDevolucao)
        {
            try
            {
                List<Locacao> locacoesPendentes = locacaoRepository.SelecionarLocacoesPendentes(emAberto, dataDevolucao);
                Log.Information("Selecionado as locações pendentes {@locacoesPendentes}", locacoesPendentes);
                return locacoesPendentes;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Não foi possível selecionar as locações pendentes");
                return null;
            }
        }

        public List<Locacao> SelecionarLocacoesEmailPendente()
        {
            try
            {
                List<Locacao> locacoesEmailPendente = locacaoRepository.SelecionarLocacoesEmailPendente();
                Log.Information("Selecionado as locações com email pendente {@locacoesEmailPendente}", locacoesEmailPendente);
                return locacoesEmailPendente;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Não foi possível selecionar as locações com email pendente");
                return null;
            }

            return locacaoRepository.SelecionarLocacoesEmailPendente();
        }

        public List<Locacao> SelecionarLocacoesPorVeiculoId(int idVeiculo)
        {
            try
            {
                List<Locacao> locacoesPorVeiculoId = locacaoRepository.SelecionarLocacoesPorVeiculoId(idVeiculo);
                Log.Information("Selecionado todas as locações {@locacoesPorVeiculoId} do veículo de id {@idVeiculo}", locacoesPorVeiculoId, idVeiculo);
                return locacoesPorVeiculoId;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Não foi possível selecionar as locações pelo id do veículo {@idVeiculo}", idVeiculo);
                return null;
            }
        }

        public string ValidarCNH(Locacao novoLocacao, int id = 0)
        {
            //validar carros alugados
            if (novoLocacao != null)
            {
                if (id != 0)
                {//situação de editar
                    int countCNHVencida = 0;
                    List<Locacao> todasLocacoes = SelecionarTodos();
                    foreach (Locacao locacao in todasLocacoes)
                    {
                        if (novoLocacao.condutor.ValidadeCNH < DateTime.Now && novoLocacao.emAberto == true && locacao.condutor.Id != id)
                            countCNHVencida++;
                    }
                    if (countCNHVencida > 0)
                    {
                        Log.Warning("Não foi possível selecionar as locações pelo id do veículo {@CNH}", novoLocacao.condutor.NumeroCNH);
                        return "O Condutor Selecionado está com a CNH vencida!";
                    }
                        
                }
                else
                {//situação de inserir
                    int countCNHVencida = 0;
                    List<Locacao> todosLocacaos = SelecionarTodos();
                    foreach (Locacao locacao in todosLocacaos)
                    {
                        if (novoLocacao.condutor.ValidadeCNH < DateTime.Now && novoLocacao.emAberto == true)
                            countCNHVencida++;
                    }
                    if (countCNHVencida > 0)
                        return "O Condutor Selecionado está com a CNH vencida!";
                }
            }
            return "ESTA_VALIDO";
        }

        //LocacaoTaxaServico

        public List<LocacaoTaxasServicos> SelecionarTodosLocacaoTaxasServicos()
        {
            try
            {
                List<LocacaoTaxasServicos> todasLocacaoTaxasServicos = locacaoRepository.SelecionarTodosLocacaoTaxasServicos();
                Log.Information("Selecionado todas relações Locação e TaxaServico {@todasLocacaoTaxasServicos}", todasLocacaoTaxasServicos);
                return todasLocacaoTaxasServicos;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Não foi possível selecionar todas relações Locação e TaxaServico");
                return null;
            }
        }

        public List<TaxasServicos> SelecionarTaxasServicosPorLocacaoId(int idLocacao)
        {
            try
            {
                List<TaxasServicos> taxasServicosPorLocacaoId = locacaoRepository.SelecionarTaxasServicosPorLocacaoId(idLocacao);
                Log.Information("Selecionado todas as taxas e serviços {@taxasServicosPorLocacaoId} da locação com id {@idLocacao}", taxasServicosPorLocacaoId, idLocacao);
                return taxasServicosPorLocacaoId;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Não foi possível selecionar as taxas e serviços pelo id da locação {@idLocacao}", idLocacao);
                return null;
            }
        }

    }
}
