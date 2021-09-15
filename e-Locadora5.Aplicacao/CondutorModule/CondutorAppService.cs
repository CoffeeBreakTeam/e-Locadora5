using e_Locadora5.Dominio.CondutoresModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Aplicacao.CondutorModule
{
    public class CondutorAppService
    {
        private readonly ICondutorRepository condutorRepository;

        public CondutorAppService(ICondutorRepository condutorRepository)
        {
            this.condutorRepository = condutorRepository;
        }

        public string InserirNovo(Condutor registro)
        {
            string resultadoValidacao = registro.Validar();
            string resultadoValidacaoRepeticoes = ValidarCondutor(registro);

            if (resultadoValidacao == "ESTA_VALIDO" && resultadoValidacaoRepeticoes == "ESTA_VALIDO")
            {
                condutorRepository.InserirNovo(registro);
            }

            return resultadoValidacao;
        }

        public string Editar(int id, Condutor registro)
        {
            string resultadoValidacao = registro.Validar();
            string resultadoValidacaoRepeticoes = ValidarCondutor(registro, id);

            if (resultadoValidacao == "ESTA_VALIDO" && resultadoValidacaoRepeticoes == "ESTA_VALIDO")
            {
                condutorRepository.Editar(id, registro);
            }

            return resultadoValidacao;
        }

        public bool Excluir(int id)
        {

            try
            {
                condutorRepository.Excluir(id);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool Existe(int id)
        {
            return condutorRepository.Existe(id);
        }

        public Condutor SelecionarPorId(int id)
        {
            return condutorRepository.SelecionarPorId(id);
        }

        public List<Condutor> SelecionarTodos()
        {
            return condutorRepository.SelecionarTodos();
        }
        public List<Condutor> SelecionarCondutoresComCnhVencida(DateTime data)
        {
            return condutorRepository.SelecionarCondutoresComCnhVencida(data);
        }

        public string ValidarCondutor(Condutor novoCondutores, int id = 0)
        {
            //validar placas iguais
            if (novoCondutores != null)
            {
                if (id != 0)
                {//situação de editar
                    int countCPFsIguais = 0;
                    int countRGsIguais = 0;
                    int countCNPJsIguais = 0;
                    List<Condutor> todosCondutores = SelecionarTodos();
                    foreach (Condutor cliente in todosCondutores)
                    {
                        if (novoCondutores.Cpf.Equals(cliente.Cpf) && cliente.Id != id && novoCondutores.Cpf != "")
                            countCPFsIguais++;
                        if (novoCondutores.Rg.Equals(cliente.Rg) && cliente.Id != id && novoCondutores.Rg != "")
                            countRGsIguais++;
                        if (novoCondutores.NumeroCNH.Equals(cliente.NumeroCNH) && cliente.Id != id && novoCondutores.NumeroCNH != "")
                            countCNPJsIguais++;
                    }
                    if (countCPFsIguais > 0)
                        return "CPF já cadastrado, tente novamente.";
                    if (countRGsIguais > 0)
                        return "RG já cadastrado, tente novamente.";
                    if (countCNPJsIguais > 0)
                        return "CNH já cadastrada, tente novamente.";
                }
                else
                {//situação de inserir
                    int countCPFsIguais = 0;
                    int countRGsIguais = 0;
                    int countCNHsIguais = 0;
                    List<Condutor> todosCondutores = SelecionarTodos();
                    foreach (Condutor cliente in todosCondutores)
                    {
                        if (novoCondutores.Cpf.Equals(cliente.Cpf) && novoCondutores.Cpf != "")
                            countCPFsIguais++;
                        if (novoCondutores.Rg.Equals(cliente.Rg) && novoCondutores.Rg != "")
                            countRGsIguais++;
                        if (novoCondutores.NumeroCNH.Equals(cliente.NumeroCNH) && novoCondutores.NumeroCNH != "")
                            countCNHsIguais++;
                    }
                    if (countCPFsIguais > 0)
                        return "CPF já cadastrado, tente novamente.";
                    if (countRGsIguais > 0)
                        return "RG já cadastrado, tente novamente.";
                    if (countCNHsIguais > 0)
                        return "CNH já cadastrada, tente novamente.";
                }
            }
            return "ESTA_VALIDO";
        }

    }
}
