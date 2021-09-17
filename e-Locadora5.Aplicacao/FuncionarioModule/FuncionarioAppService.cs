using e_Locadora5.Dominio.FuncionarioModule;
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

            string validarRepeticoes = ValidarFuncionarios(registro);
            if (resultadoValidacao == "ESTA_VALIDO" && validarRepeticoes == "ESTA_VALIDO")
            {
                funcionarioRepository.InserirNovo(registro);
            }
            else
                resultadoValidacao += validarRepeticoes;

            return resultadoValidacao;
        }

        public string Editar(int id, Funcionario registro)
        {
            string resultadoValidacao = registro.Validar();

            string validarRepeticoes = ValidarFuncionarios(registro, id);
            if (resultadoValidacao == "ESTA_VALIDO" && validarRepeticoes == "ESTA_VALIDO")
            {
                funcionarioRepository.Editar(id, registro);
            }

            return resultadoValidacao;
        }

        public bool Excluir(int id)
        {
            try
            {
                funcionarioRepository.Excluir(id);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool Existe(int id)
        {
            return funcionarioRepository.Existe(id);
        }

        public Funcionario SelecionarPorId(int id)
        {
            return funcionarioRepository.SelecionarPorId(id);
        }

        public List<Funcionario> SelecionarTodos()
        {
            return funcionarioRepository.SelecionarTodos();
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