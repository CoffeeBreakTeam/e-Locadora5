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
            string resultadoValidacao = cupomRepository.InserirCupom(cupons);
            return resultadoValidacao;
        }

        public string EditarCupom(int id, Cupons cupons)
        {
            string resultadoValidacaoDominio = cupomRepository.EditarCupom(id, cupons);

            return resultadoValidacaoDominio;
        }

        public string ExcluirCupom(int id)
        {
            string resultadoValidacaoDominio = "ESTA_VALIDO";

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
                cupomRepository.ExcluirCupom(id);

            return resultadoValidacaoDominio;
        }

        public List<Cupons> SelecionarTodosCupom()
        {
            return cupomRepository.SelecionarTodos();
        }

        public Cupons SelecionarPorId(int id)
        {
            return cupomRepository.SelecionarPorID(id);
        }
    }
}
