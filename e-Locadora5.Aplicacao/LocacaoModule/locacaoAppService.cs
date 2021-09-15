using e_Locadora5.Dominio.LocacaoModule;
using e_Locadora5.Dominio.TaxasServicosModule;
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
            string resultadoValidacaoDominio = registro.Validar();
            string resultadoValidacaoControlador = ValidarLocacao(registro);


            if (resultadoValidacaoDominio == "ESTA_VALIDO" && resultadoValidacaoControlador == "ESTA_VALIDO")
            {
                locacaoRepository.InserirNovo(registro);
            }

            if (resultadoValidacaoDominio != "ESTA_VALIDO")
                return resultadoValidacaoDominio;
            else
                return resultadoValidacaoControlador;
        }

        public string Editar(int id, Locacao registro)
        {
            string resultadoValidacaoDominio = registro.Validar();
            string resultadoValidacaoControlador = ValidarLocacao(registro, id);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                locacaoRepository.Editar(id, registro);
            }

            if (resultadoValidacaoDominio != "ESTA_VALIDO")
                return resultadoValidacaoDominio;
            else
                return resultadoValidacaoControlador;
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

        public string ValidarLocacao(Locacao novoLocacao, int id = 0)
        {
            //validar carros alugados
            if (novoLocacao != null)
            {
                if (id != 0)
                {//situação de editar
                    int countVeiculoIndisponivel = 0;
                    List<Locacao> todasLocacoes = SelecionarTodos();
                    foreach (Locacao locacao in todasLocacoes)
                    {
                        if (novoLocacao.veiculo.Id == locacao.veiculo.Id && locacao.emAberto == true && locacao.Id != id)
                            countVeiculoIndisponivel++;
                    }
                    if (countVeiculoIndisponivel > 0)
                        return "Veiculo já alugado, tente novamente.";
                }
                else
                {//situação de inserir
                    int countVeiculoIndisponivel = 0;
                    List<Locacao> todosLocacaos = SelecionarTodos();
                    foreach (Locacao locacao in todosLocacaos)
                    {
                        if (novoLocacao.veiculo.Id == locacao.veiculo.Id && locacao.emAberto == true)
                            countVeiculoIndisponivel++;
                    }
                    if (countVeiculoIndisponivel > 0)
                        return "Veiculo já alugado, tente novamente.";
                }
            }
            return "ESTA_VALIDO";
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
            return null;
        }

    }
}
