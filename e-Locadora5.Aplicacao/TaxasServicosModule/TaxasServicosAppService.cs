using e_Locadora5.Dominio.TaxasServicosModule;
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

        public string Editar(int id, TaxasServicos registro)
        {
            string resultadoValidacao = registro.Validar();
            string resultadoValidacaoControlador = ValidarTaxasServicos(registro, id);

            if (resultadoValidacao == "ESTA_VALIDO" && resultadoValidacaoControlador == "ESTA_VALIDO")
            {
                taxasServicosRepository.Editar(id, registro);
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

        public bool Excluir(int id)
        {
            try
            {
                taxasServicosRepository.Excluir(id);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool Existe(int id)
        {
            return taxasServicosRepository.Existe(id);
        }

        public string InserirNovo(TaxasServicos registro)
        {
            string resultadoValidacao = registro.Validar();
            string resultadoValidacaoControlador = ValidarTaxasServicos(registro);

            if (resultadoValidacao == "ESTA_VALIDO" && resultadoValidacaoControlador == "ESTA_VALIDO")
            {
                taxasServicosRepository.InserirNovo(registro);
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

        public TaxasServicos SelecionarPorId(int id)
        {
            return taxasServicosRepository.SelecionarPorId(id);
        }

        public List<TaxasServicos> SelecionarTodos()
        {
            return taxasServicosRepository.SelecionarTodos();
        }

        public string ValidarTaxasServicos(TaxasServicos novoTaxasServicos, int id = 0)
        {
            //validar placas iguais
            if (novoTaxasServicos != null)
            {
                if (id != 0)
                {//situação de editar
                    int countTaxasIguais = 0;
                    List<TaxasServicos> todosTaxasServicos = SelecionarTodos();
                    foreach (TaxasServicos taxasServicos in todosTaxasServicos)
                    {
                        if (novoTaxasServicos.Descricao.Equals(taxasServicos.Descricao) && taxasServicos.Id != id)
                            countTaxasIguais++;
                    }
                    if (countTaxasIguais > 0)
                        return "Taxa ou serviço já cadastrada, tente novamente.";
                }
                else
                {//situação de inserir
                    int countTaxasIguais = 0;
                    List<TaxasServicos> todosTaxasServicos = SelecionarTodos();
                    foreach (TaxasServicos taxasServicos in todosTaxasServicos)
                    {
                        if (novoTaxasServicos.Descricao.Equals(taxasServicos.Descricao))
                            countTaxasIguais++;
                    }
                    if (countTaxasIguais > 0)
                        return "Taxa ou serviço já cadastrada, tente novamente.";
                }
            }
            return "ESTA_VALIDO";
        }
    }
}
