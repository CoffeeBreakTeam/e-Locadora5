using e_Locadora5.Dominio.LocacaoModule;
using e_Locadora5.Dominio.TaxasServicosModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Aplicacao.LocacaoModule
{
    public class locacaoAppService
    {
        private readonly ILocacaoRepository locacaoRepository;

        public locacaoAppService(ILocacaoRepository locacaoRepo)
        {
            locacaoRepository = locacaoRepo;
        }
        public string ValidarLocacao(Locacao novoLocacao, int id = 0)
        {
            //validar carros alugados
            if (novoLocacao != null)
            {
                if (id != 0)
                {//situação de editar
                    int countVeiculoIndisponivel = 0;
                    List<Locacao> todasLocacoes = locacaoRepository.SelecionarTodasLocacoes();
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
                    List<Locacao> todosLocacaos = locacaoRepository.SelecionarTodasLocacoes();
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

        public List<Locacao> SelecionarTodasLocacoes()
        {
            List<Locacao> todasLocacoes = new List<Locacao>();
            todasLocacoes = locacaoRepository.SelecionarTodasLocacoes();//Db.GetAll(sqlSelecionarTodasLocacoes, ConverterEmLocacao);

            foreach (Locacao locacaoIndividual in todasLocacoes)
            {
                //List<TaxasServicos> taxasServicosIndividuais = SelecionarTaxasServicosPorLocacaoId(locacaoIndividual.Id);
                //locacaoIndividual.taxasServicos = taxasServicosIndividuais;
            }

            return todasLocacoes;
        }
        public string RegistrarNovaLocacao(Locacao locacao)
        {
            string resultadoValidacaoDominio = locacao.Validar();
            string resultadoValidacaoControlador = ValidarLocacao(locacao);

            if (resultadoValidacaoDominio=="ESTA_VALIDO")
                locacaoRepository.InserirLocacao(locacao);

            if (resultadoValidacaoDominio != "ESTA_VALIDO")
                return resultadoValidacaoDominio;
            else
                return resultadoValidacaoControlador;
        }

    }
}
