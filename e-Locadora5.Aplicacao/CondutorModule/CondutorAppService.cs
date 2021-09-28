using e_Locadora5.Dominio.CondutoresModule;
using Serilog;
using System;
using System.Collections.Generic;

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
            if (condutorRepository.ExisteCondutorComEsteCPF(registro.Id,registro.Cpf))
            {
                Log.Warning("Já há um condutor cadastrado com este CPF {cpf}", registro.Cpf);
                return "Já há um condutor cadastrado com este CPF";
            }                         
            if (condutorRepository.ExisteCondutorComEsteRG(registro.Id, registro.Rg))
            {
                Log.Warning("Já há um condutor cadastrado com este RG {rg}", registro.Rg);
                return "Já há um condutor cadastrado com este RG";
            }           
            if (resultadoValidacao == "ESTA_VALIDO")
            {
                try
                {
                    condutorRepository.InserirNovo(registro);
                    Log.Information("condutor {@condutor} foi inserido com sucesso.", registro);        
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Não foi possível inserir o condutor {@condutor}", registro);
                }        
            }
            else
            {
                Log.CloseAndFlush();
                Log.Warning("condutor inválido: {resultadoValidacao}", resultadoValidacao);
            }
            return resultadoValidacao;
        }

        public string Editar(int id, Condutor registro)
        {
            string resultadoValidacao = registro.Validar();

            if (condutorRepository.ExisteCondutorComEsteCPF(registro.Id, registro.Cpf))
            {
                Log.Warning("Já há um condutor cadastrado com este CPF {cpf}", registro.Cpf);
                return "Já há um condutor cadastrado com este CPF";
            }
            if (condutorRepository.ExisteCondutorComEsteRG(registro.Id, registro.Rg))
            {
                Log.Warning("Já há um condutor cadastrado com este RG {rg}", registro.Rg);
                return "Já há um condutor cadastrado com este RG";
            }

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                try
                {
                    condutorRepository.Editar(id, registro);
                    Log.Information("condutor {condutor} foi editado com sucesso.", registro);
                }
                catch (Exception ex)
                {

                    Log.Error(ex, "Não foi possível editar o condutor {condutor}", registro);
                }

            }
            else
            {
                Log.Warning("condutor inválido: {resultadoValidacao}", resultadoValidacao);
            }

            return resultadoValidacao;
        }

        public bool Excluir(int id)
        {
            try
            {
                condutorRepository.Excluir(id);
                Log.Information("Condutor de id {idcondutor} foi excluído com sucesso", id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Não foi possível excluir o condutor com id {id}", id);
                return false;
            }

            return true;
        }

        public bool Existe(int id)
        {
            try
            {
                bool existe = condutorRepository.Existe(id);
                Log.Information("Verificado se existe o condutor com id {idcondutor}", id);
                return existe;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Não foi possível verificar se existe o condutor com id {idcondutor}", id);
                return false;
            }
           
        }

        public Condutor SelecionarPorId(int id)
        {
            try
            {
                Condutor condutorSelecionado = condutorRepository.SelecionarPorId(id);
                Log.Information("Selecionado condutor {condutorSelecionado}", condutorSelecionado);
                return condutorSelecionado;

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Não foi possível selecionar o condutor com id {idcondutor}", id);
                return null;
            }
        }

        public List<Condutor> SelecionarTodos()
        {
            try
            {
                List<Condutor> todosCondutores = condutorRepository.SelecionarTodos();
                Log.Information("Selecionado todos os condutor {todosCondutores}", todosCondutores);
                return todosCondutores;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Não foi possível selecionar todos os condutor");
                return null;
            }      
        }

        public List<Condutor> SelecionarCondutoresComCnhVencida(DateTime data)
        {
            try
            {
                List<Condutor> todosCondutoresCNHVencida = condutorRepository.SelecionarTodos();
                Log.Information("Selecionado todos os condutores {todosCondutores} com CNH Vencida", todosCondutoresCNHVencida);
                return todosCondutoresCNHVencida;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Não foi possível selecionar todos os condutores com CNH Vencida");
                return null;
            }
        }

        public string ValidarCondutor(Condutor novoCondutores, int id = 0)
        {
            //validar cpf iguais
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
