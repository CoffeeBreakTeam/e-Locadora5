using e_Locadora5.Dominio.CupomModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Aplicacao.CupomModule
{
    public class CupomAppService
    {
        private readonly ICupomRepository cupomRepository;

        public CupomAppService(ICupomRepository cupomRepo)
        {
            cupomRepository = cupomRepo;
        }

        public string RegistrarNovoCupom(Cupons cupons)
        {
            string resultadoValidacaoDominio = cupons.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
                cupomRepository.InserirCupom(cupons);

            return resultadoValidacaoDominio;
        }
    }
}
