using e_Locadora5.Dominio.ClientesModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.SQL.ClienteModule
{
    public class ClienteDAO : IClienteRepository
    {
        #region Queries
        private const string sqlInserirCliente =
            @"INSERT INTO TBCLIENTES 
	                (
		                [NOME], 
		                [ENDERECO], 
		                [TELEFONE],
                        [RG], 
		                [CPF],
                        [CNPJ],
                        [EMAIL]
	                ) 
	                VALUES
	                (
                        @NOME, 
		                @ENDERECO, 
		                @TELEFONE,
                        @RG, 
		                @CPF,
                        @CNPJ,
                        @EMAIL
	                )";

        private const string sqlEditarCliente =
            @"UPDATE TBCLIENTES
                    SET
                        [NOME] = @NOME, 
		                [ENDERECO] = @ENDERECO, 
		                [TELEFONE] = @TELEFONE,
                        [RG] = @RG, 
		                [CPF] = @CPF,
                        [CNPJ] = @CNPJ,
                        [EMAIL] = @EMAIL
                    WHERE 
                        ID = @ID";

        private const string sqlExcluirCliente =
            @"DELETE 
	                FROM
                        TBCLIENTES
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarClientePorId =
            @"SELECT
                        [ID],
                        [NOME], 
		                [ENDERECO], 
		                [TELEFONE],
                        [RG], 
		                [CPF],
                        [CNPJ],
                        [EMAIL]
	                FROM
                        TBCLIENTES
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarTodosClientes =
            @"SELECT
                        [ID],
                        [NOME], 
		                [ENDERECO], 
		                [TELEFONE],
                        [RG], 
		                [CPF],
                        [CNPJ],
                        [EMAIL] FROM TBCLIENTES";

        private const string sqlExisteCliente =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBCLIENTES]
            WHERE 
                [ID] = @ID";
        #endregion

        public void InserirCliente(Clientes cliente)
        {
            cliente.Id = Db.Insert(sqlInserirCliente, ObtemParametrosClientes(cliente));
        }

        public void EditarCliente(int id, Clientes cliente)
        {
            Db.Update(sqlEditarCliente, ObtemParametrosClientes(cliente));
        }

        public void ExcluirCliente(int id)
        {
            Db.Delete(sqlExcluirCliente, AdicionarParametro("ID", id));
        }

        public bool Existe(int id)
        {
            return Db.Exists(sqlExisteCliente, AdicionarParametro("ID", id));
        }    

        public Clientes SelecionarClientePorId(int id)
        {
            return Db.Get(sqlSelecionarClientePorId, ConverterEmCliente, AdicionarParametro("ID", id));
        }

        public List<Clientes> SelecionarTodosClientes()
        {
            return Db.GetAll(sqlSelecionarTodosClientes, ConverterEmCliente);
        }

        #region metodos privados
        private Dictionary<string, object> ObtemParametrosClientes(Clientes clientes)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", clientes.Id);
            parametros.Add("NOME", clientes.Nome);
            parametros.Add("ENDERECO", clientes.Endereco);
            parametros.Add("TELEFONE", clientes.Telefone);
            parametros.Add("RG", clientes.RG);
            parametros.Add("CPF", clientes.CPF);
            parametros.Add("CNPJ", clientes.CNPJ);
            parametros.Add("EMAIL", clientes.Email);

            return parametros;
        }

        private Clientes ConverterEmCliente(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string nome = Convert.ToString(reader["NOME"]);
            string endereco = Convert.ToString(reader["ENDERECO"]);
            string telefone = Convert.ToString(reader["TELEFONE"]);
            string rg = Convert.ToString(reader["RG"]);
            string cpf = Convert.ToString(reader["CPF"]);
            string cnpj = Convert.ToString(reader["CNPJ"]);
            string email = Convert.ToString(reader["EMAIL"]);

            Clientes clientes = new Clientes(nome, endereco, telefone, rg, cpf, cnpj, email);

            clientes.Id = id;

            return clientes;
        }

        protected Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }

        #endregion


    }
}
