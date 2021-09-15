using e_Locadora5.Dominio.ParceirosModule;
using System;
using System.Collections.Generic;


namespace e_Locadora5.Aplicacao.ParceiroModule
{
    public class ParceiroAppService
    {
        IParceiroRepository parceiroRepository;
        public ParceiroAppService(IParceiroRepository parceiroRepository)
        {
            this.parceiroRepository = parceiroRepository;
        }

        public string InserirNovoParceiro(Parceiro parceiro)
        {
            string resultadoValidacao = parceiro.Validar();
            string resultadoValidacaoControlador = ValidarParceiros(parceiro);

            if (resultadoValidacao == "ESTA_VALIDO" && resultadoValidacaoControlador == "ESTA_VALIDO")
            {
                parceiroRepository.InserirParceiro(parceiro);
                
            }
            return resultadoValidacao;
          
        }
        public string EditarParceiro(int id, Parceiro registro)
        {
            string resultadoValidacao = registro.Validar();
            string resultadoValidacaoControlador = ValidarParceiros(registro, id);

            if (resultadoValidacao == "ESTA_VALIDO" && resultadoValidacaoControlador == "ESTA_VALIDO")
            {
                registro.Id = id;
                parceiroRepository.EditarParceiro(id, registro);
            }

            return resultadoValidacao;
        }

        public bool ExcluirParceiro(int id)
        {
            try
            {
                parceiroRepository.ExcluirParceiro(id);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool Existe(int id)
        {
            return parceiroRepository.Existe(id);
        }

        public Parceiro SelecionarParceiroPorId(int id)
        {
            return parceiroRepository.SelecionarParceiroPorId(id);
        }

        public List<Parceiro> SelecionarTodosParceiro()
        {
            return parceiroRepository.SelecionarTodosParceiros();
        }

        private string ValidarParceiros(Parceiro NovosParceiros, int id = 0)
        {
            if (NovosParceiros != null)
            {
                if (id != 0)
                {//situação de editar
                    int countparceirosIguais = 0;
                    List<Parceiro> todosParceiros = SelecionarTodosParceiro();
                    foreach (Parceiro parceiro in todosParceiros)
                    {
                        if (NovosParceiros.nome.Equals(parceiro.nome) && parceiro.Id != id)
                            countparceirosIguais++;
                    }
                    if (countparceirosIguais > 0)
                        return "Parceiro já Cadastrado, tente novamente.";
                }
                else
                {//situação de inserir
                    int countparceirosIguais = 0;
                    List<Parceiro> todosParceiros = SelecionarTodosParceiro();
                    foreach (Parceiro parceiro in todosParceiros)
                    {
                        if (NovosParceiros.nome.Equals(parceiro.nome))
                            countparceirosIguais++;
                    }
                    if (countparceirosIguais > 0)
                        return "Parceiro já Cadastrado, tente novamente.";
                }
            }
            return "ESTA_VALIDO";
        }
    }
}
