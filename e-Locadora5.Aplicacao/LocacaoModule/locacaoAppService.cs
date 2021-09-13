using e_Locadora5.Dominio.LocacaoModule;
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

        public string RegistrarNovaLocacao(Locacao locacao)
        {
            string resultadoValidacaoDominio = locacao.Validar();

            if(resultadoValidacaoDominio=="ESTA_VALIDO")
                locacaoRepository.InserirLocacao(locacao);

            return resultadoValidacaoDominio;
        }

    }
}
