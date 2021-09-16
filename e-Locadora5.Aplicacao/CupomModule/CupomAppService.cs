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

        public string InserirNovo(Cupons cupons)
        {
            string resultadoValidacao = cupons.Validar();
            string resultadoValidacaoControlador = Validar(cupons);

            if (resultadoValidacao == "ESTA_VALIDO" && resultadoValidacaoControlador == "ESTA_VALIDO")
            {
                cupomRepository.InserirNovo(cupons);
            }

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                return resultadoValidacao;
            }
            else
            {
                return resultadoValidacaoControlador;
            }
        }

        public string Editar(int id, Cupons cupons)
        {
            string resultadoValidacaoDominio = cupons.Validar();
            string resultadoValidacaoControlador = Validar(cupons, id);

            if (resultadoValidacaoDominio == "ESTA_VALIDO" && resultadoValidacaoControlador == "ESTA_VALIDO")
            {
                cupomRepository.Editar(id, cupons);
            }

            if (resultadoValidacaoDominio != "ESTA_VALIDO")
            {
                return resultadoValidacaoDominio;
            }
            else
            {
                return resultadoValidacaoControlador;
            }
        }

        public bool Excluir(int id)
        {
            return cupomRepository.Excluir(id);
        }

        public List<Cupons> SelecionarTodos()
        {
            return cupomRepository.SelecionarTodos();
        }

        public Cupons SelecionarPorId(int id)
        {
            return cupomRepository.SelecionarPorId(id);
        }

        public string Validar(Cupons novoCupons, int id = 0)
        {
            //validar placas iguais
            if (novoCupons != null)
            {
                if (id != 0)
                {//situação de editar
                    int countCuponsIguaiss = 0;
                    List<Cupons> todosCupons = SelecionarTodos();
                    foreach (Cupons cupons in todosCupons)
                    {
                        if (novoCupons.Nome.Equals(cupons.Nome) && cupons.Id != id)
                            countCuponsIguaiss++;
                    }
                    if (countCuponsIguaiss > 0)
                        return "Cupom já cadastrada, tente novamente.";
                }
                else
                {//situação de inserir
                    int countTaxasIguais = 0;
                    List<Cupons> todosCupons = SelecionarTodos();
                    foreach (Cupons cupons in todosCupons)
                    {
                        if (novoCupons.Nome.Equals(cupons.Nome))
                            countTaxasIguais++;
                    }
                    if (countTaxasIguais > 0)
                        return "Cupom já cadastrada, tente novamente.";
                }
            }
            return "ESTA_VALIDO";
        }
    }
}
