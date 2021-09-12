using e_Locadora5.Controladores.Shared;
using e_Locadora5.Dominio.FuncionarioModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Controladores.FuncionarioModule
{
    public class ControladorFuncionario : Controlador<Funcionario>
    {
        #region Queris
        private const string sqlInserirFuncionario =
            @"INSERT INTO TBFUNCIONARIO 
	                (
		                [NOME],
                        [NUMEROCPF],
		                [USUARIO], 
		                [SENHA],
                        [DATAADMISSAO], 
		                [SALARIO]
	                ) 
	                VALUES
	                (
                        @NOME, 
                        @NUMEROCPF,
		                @USUARIO, 
		                @SENHA,
                        @DATAADMISSAO, 
		                @SALARIO
	                )";

        private const string sqlEditarFuncionario =
            @"UPDATE TBFUNCIONARIO
                    SET
                        [NOME] = @NOME, 
                        [NUMEROCPF] = @NUMEROCPF,
		                [USUARIO] = @USUARIO, 
		                [SENHA] = @SENHA,
                        [DATAADMISSAO] = @DATAADMISSAO, 
		                [SALARIO] = @SALARIO
                    WHERE 
                        ID = @ID";

        private const string sqlExcluirFuncionario =
            @"DELETE 
	                FROM
                        TBFUNCIONARIO
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarFuncionarioPorId =
            @"SELECT
                        [ID],
                        [NOME], 
                        [NUMEROCPF],
		                [USUARIO], 
		                [SENHA],
                        [DATAADMISSAO], 
		                [SALARIO]
	                FROM
                        TBFUNCIONARIO
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarTodosFuncionarios =
            @"SELECT
                        [ID],
                        [NOME], 
                        [NUMEROCPF],
		                [USUARIO], 
		                [SENHA],
                        [DATAADMISSAO], 
		                [SALARIO]
             FROM 
                    TBFUNCIONARIO";

        private const string sqlExisteFuncionario =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBFUNCIONARIO]
            WHERE 
                [ID] = @ID";

        #endregion

        public override string InserirNovo(Funcionario registro)
        {
            string resultadoValidacao = registro.Validar();
            string validarRepeticoes = ValidarFuncionarios(registro);
            if (resultadoValidacao == "ESTA_VALIDO" && validarRepeticoes == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirFuncionario, ObtemParametrosFuncionario(registro));
            }

            return resultadoValidacao;
        }

        public override string Editar(int id, Funcionario registro)
        {
            string resultadoValidacao = registro.Validar();

            string validarRepeticoes = ValidarFuncionarios(registro, id);
            if (resultadoValidacao == "ESTA_VALIDO" && validarRepeticoes == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarFuncionario, ObtemParametrosFuncionario(registro));
            }

            return resultadoValidacao;
        }    

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirFuncionario, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteFuncionario, AdicionarParametro("ID", id));
        }

        public override Funcionario SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarFuncionarioPorId, ConverterEmFuncionario, AdicionarParametro("ID", id));
        }

        public override List<Funcionario> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosFuncionarios, ConverterEmFuncionario);
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

        #region Metodos Privados
        private Dictionary<string, object> ObtemParametrosFuncionario(Funcionario funcionario)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", funcionario.Id);
            parametros.Add("NOME", funcionario.Nome);
            parametros.Add("NUMEROCPF", funcionario.NumeroCpf);
            parametros.Add("USUARIO", funcionario.Usuario);
            parametros.Add("SENHA", funcionario.Senha);
            parametros.Add("DATAADMISSAO", funcionario.DataAdmissao);
            parametros.Add("SALARIO", funcionario.Salario);

            return parametros; ;
        }
        private Funcionario ConverterEmFuncionario(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string nome = Convert.ToString(reader["NOME"]);
            string numeroCpf = Convert.ToString(reader["NUMEROCPF"]);
            string usuario = Convert.ToString(reader["USUARIO"]);
            string senha = Convert.ToString(reader["SENHA"]);
            DateTime admissao = Convert.ToDateTime(reader["DATAADMISSAO"]);
            double salario = Convert.ToDouble(reader["SALARIO"]);

            Funcionario funcionarios = new Funcionario(nome,numeroCpf,usuario,senha,admissao,salario);

            funcionarios.Id = id;

            return funcionarios;
        }
       
        #endregion
    }
}
