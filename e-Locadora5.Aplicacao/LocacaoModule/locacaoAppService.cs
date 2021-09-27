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
            string resultadoValidacaoDominio = registro.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                try
                {
                    locacaoRepository.InserirNovo(registro);
                    Log.Information("Locação {locacao} foi inserido com sucesso.", registro);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Não foi possível inserir a locação {locacao}", registro);
                }
            }
            
            return resultadoValidacaoDominio;
        }

        public string Editar(int id, Locacao registro)
        {
            string resultadoValidacaoDominio = registro.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                locacaoRepository.Editar(id, registro);
            }

            return resultadoValidacaoDominio;
        }

        public bool Excluir(int id)
        {
            try
            {
                locacaoRepository.Excluir(id);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool Existe(int id)
        {
            return locacaoRepository.Existe(id);
        }

        public Locacao SelecionarPorId(int id)
        {
            return locacaoRepository.SelecionarPorId(id);
        }

        public List<Locacao> SelecionarTodos()
        {
            return locacaoRepository.SelecionarTodos();
        }

        public List<Locacao> SelecionarLocacoesPendentes(bool emAberto, DateTime dataDevolucao)
        {
            return locacaoRepository.SelecionarLocacoesPendentes(emAberto, dataDevolucao);
        }

        public List<Locacao> SelecionarLocacoesEmailPendente()
        {
            return locacaoRepository.SelecionarLocacoesEmailPendente();
        }

        public List<Locacao> SelecionarLocacoesPorVeiculoId(int idVeiculo)
        {
            return locacaoRepository.SelecionarLocacoesPorVeiculoId(idVeiculo);
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
                        return "O Condutor Selecionado está com a CNH vencida!";
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
            return locacaoRepository.SelecionarTodosLocacaoTaxasServicos();
        }

        public List<TaxasServicos> SelecionarTaxasServicosPorLocacaoId(int idLocacao)
        {
            return locacaoRepository.SelecionarTaxasServicosPorLocacaoId(idLocacao);
        }

    }
}
