using e_Locadora5.Dominio.FuncionarioModule;
using e_Locadora5.Infra.GeradorLogs;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Aplicacao.FuncionarioModule
{
    public class FuncionarioAppService
    {
        private readonly IFuncionarioRepository funcionarioRepository;

        public FuncionarioAppService(IFuncionarioRepository funcionarioRepository)
        {
            this.funcionarioRepository = funcionarioRepository;
        }

        public string InserirNovo(Funcionario registro)
        {
            string resultadoValidacao = registro.Validar();

            //string validarRepeticoes = ValidarFuncionarios(registro);
            if (resultadoValidacao == "ESTA_VALIDO")
            {
                try
                {
                    funcionarioRepository.InserirNovo(registro);
                    Log.Logger.Contexto().Information("funcionario {@funcionario} foi inserido com sucesso.", registro);
                }
                catch (Exception ex)
                {
                    resultadoValidacao += "Não foi possível inserir o funcionario";
                    Log.Logger.Contexto().Error(ex, "Não foi possível inserir o funcionario {@funcionario}", registro);
                }

            }
            else
            {
                //resultadoValidacao += validarRepeticoes;
                Log.Warning("funcionario inválido: {resultadoValidacao}", resultadoValidacao);
            }


            return resultadoValidacao;
        }

        public string Editar(int id, Funcionario registro)
        {
            string resultadoValidacao = registro.Validar();

            //string validarRepeticoes = ValidarFuncionarios(registro, id);
            if (resultadoValidacao == "ESTA_VALIDO")
            {
                try
                {
                    funcionarioRepository.Editar(id, registro);
                    Log.Logger.Contexto().Information("funcionario {funcionario} foi editado com sucesso.", registro);
                }
                catch (Exception ex)
                {

                    Log.Logger.Contexto().Error(ex, "Não foi possível editar o funcionario {funcionario}", registro);
                }

            }
            else
            {
                Log.Logger.Contexto().Warning("funcionario inválido: {resultadoValidacao}", resultadoValidacao);
            }

            return resultadoValidacao;
        }

        public bool Excluir(int id)
        {
            try
            {
                funcionarioRepository.Excluir(id);
                Log.Logger.Contexto().Information("Funcionario de id {idfuncionario} foi excluído com sucesso", id);
            }
            catch (Exception ex)
            {
                Log.Logger.Contexto().Error(ex, "Não foi possível excluir o funcionario com id {id}", id);
                return false;
            }

            return true;
        }

        public bool Existe(int id)
        {
            try
            {
                bool existe = funcionarioRepository.Existe(id);
                Log.Logger.Contexto().Information("Verificado se existe o funcionario com id {idfuncionario}", id);
                return existe;
            }
            catch (Exception ex)
            {
                Log.Logger.Contexto().Error(ex, "Não foi possível verificar se existe o funcionario com id {idfuncionario}", id);
                return false;
            }

        }

        public Funcionario SelecionarPorId(int id)
        {
            try
            {
                Funcionario funcionario = funcionarioRepository.SelecionarPorId(id);
                Log.Logger.Contexto().Information("Selecionado funcionario {funcionarioSelecionado}", funcionario);
                return funcionario;
            }
            catch (Exception ex)
            {
                Log.Logger.Contexto().Error(ex, "Não foi possível selecionar o funcionario com id {idfuncionario}", id);
                return null;
            }
        }

        public List<Funcionario> SelecionarTodos()
        {

            try
            {
                List<Funcionario> funcionarios = funcionarioRepository.SelecionarTodos();
                Log.Logger.Contexto().Information("Selecionado todos os funcionarios {todosFuncionarios}", funcionarios);
                return funcionarios;
            }
            catch (Exception ex)
            {
                Log.Logger.Contexto().Error(ex, "Não foi possível selecionar todos os funcionarios");
                return null;
            }
        }

        public string ValidarFuncionarios(Funcionario novoFuncionario, int id = 0)
        {
            //validar CPF IGUAIS iguais
            if (novoFuncionario != null)
            {
                if (id != 0)
                {//situação de editar
                    int countCPFsIguais = 0;
                    int countUsuariosIguais = 0;
                    List<Funcionario> todosFuncionarios = SelecionarTodos();
                    foreach (Funcionario funcionario in todosFuncionarios)
                    {
                        if (novoFuncionario.NumeroCpf.Equals(funcionario.NumeroCpf) && funcionario.Id != id && novoFuncionario.NumeroCpf != "")
                            countCPFsIguais++;
                        if (novoFuncionario.Usuario.Equals(funcionario.Usuario) && funcionario.Id != id && novoFuncionario.Usuario != "")
                            countUsuariosIguais++;
                    }
                    if (countCPFsIguais > 0)
                        return "Funcionário com CPF já cadastrado, tente novamente.";
                    if (countUsuariosIguais > 0)
                        return "Este nome de usuário já está sendo usado, tente novamente.";
                }
                else
                {//situação de inserir
                    int countCPFsIguais = 0;
                    int countUsuariosIguais = 0;

                    List<Funcionario> todosFuncionarios = SelecionarTodos();
                    foreach (Funcionario funcionario in todosFuncionarios)
                    {
                        if (novoFuncionario.NumeroCpf.Equals(funcionario.NumeroCpf) && novoFuncionario.NumeroCpf != "")
                            countCPFsIguais++;
                        if (novoFuncionario.Usuario.Equals(funcionario.Usuario) && novoFuncionario.Usuario != "")
                            countUsuariosIguais++;

                    }
                    if (countCPFsIguais > 0)
                        return "Funcionário com CPF já cadastrado, tente novamente.";
                    if (countUsuariosIguais > 0)
                        return "Este nome de usuário já está sendo usado, tente novamente.";

                }
            }
            return "ESTA_VALIDO";
        }
    }
}