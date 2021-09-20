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

        public string InserirNovo(Parceiro parceiro)
        {
            string resultadoValidacao = parceiro.Validar();

            if (parceiroRepository.ExisteParceiroComEsseNome(parceiro.nome))
            {
                return "Parceiro já Cadastrado, tente novamente.";
            }
            if (resultadoValidacao == "ESTA_VALIDO")
            {
                parceiroRepository.InserirParceiro(parceiro);
            }

            return resultadoValidacao;

        }
        public string Editar(int id, Parceiro parceiro)
        {
            string resultadoValidacao = parceiro.Validar();
           
            if (parceiroRepository.ExisteParceiroComEsseNome(parceiro.nome))
            {
                return "Parceiro já Cadastrado, tente novamente.";
            }
            if (resultadoValidacao == "ESTA_VALIDO")
            {
                parceiro.Id = id;
                parceiroRepository.EditarParceiro(id, parceiro);
            }
            
            return resultadoValidacao;
        }

        public bool Excluir(int id)
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

        public Parceiro SelecionarPorId(int id)
        {
            return parceiroRepository.SelecionarParceiroPorId(id);
        }

        public List<Parceiro> SelecionarTodos()
        {
            return parceiroRepository.SelecionarTodosParceiros();
        }

        public string ValidarParceiros(Parceiro novoParceiro, int id = 0)
        {
            if (novoParceiro != null)
            {
                if (id != 0)
                {//situação de editar
                    int countparceirosIguais = 0;
                    List<Parceiro> todosParceiros = SelecionarTodos();
                    foreach (Parceiro parceiro in todosParceiros)
                    {
                        if (novoParceiro.nome.Equals(parceiro.nome) && parceiro.Id != id)
                            countparceirosIguais++;
                    }
                    if (countparceirosIguais > 0)
                        return "Parceiro já Cadastrado, tente novamente.";
                }
                else
                {//situação de inserir
                    int countparceirosIguais = 0;
                    List<Parceiro> todosParceiros = SelecionarTodos();
                    foreach (Parceiro parceiro in todosParceiros)
                    {
                        if (novoParceiro.nome.Equals(parceiro.nome))
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
