using e_Locadora5.Dominio.FuncionarioModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.SQL.FuncionarioModule
{
    public class FuncionarioDAO : IFuncionarioRepository 
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

        public void InserirNovo(Funcionario registro)
        {
            registro.Id = Db.Insert(sqlInserirFuncionario, ObtemParametrosFuncionario(registro));
        }

        public void Editar(int id, Funcionario registro)
        {
            registro.Id = id;
            Db.Update(sqlEditarFuncionario, ObtemParametrosFuncionario(registro));
        }

        public void Excluir(int id)
        {
             Db.Delete(sqlExcluirFuncionario, AdicionarParametro("ID", id));
        }

        public bool Existe(int id)
        {
            return Db.Exists(sqlExisteFuncionario, AdicionarParametro("ID", id));
        }

        public Funcionario SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarFuncionarioPorId, ConverterEmFuncionario, AdicionarParametro("ID", id));
        }

        public List<Funcionario> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosFuncionarios, ConverterEmFuncionario);
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

            Funcionario funcionarios = new Funcionario(nome, numeroCpf, usuario, senha, admissao, salario);

            funcionarios.Id = id;

            return funcionarios;
        }

        #endregion

        protected Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }

        public void InserirFuncionario(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

    }
}
