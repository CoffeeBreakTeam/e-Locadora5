using e_Locadora5.Dominio.ClientesModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using e_Locadora5.Infra.GeradorLogs;

namespace e_Locadora5.Infra.SQL.ClienteModule
{
    public class ClienteDAO : IClienteRepository
    {
        //GeradorDeLog geradorDeLog = new GeradorDeLog();

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

        private const string sqlExisteClienteComCPFRepetidoInserir =
        @"SELECT 
                COUNT(*) 
            FROM 
                [TBCLIENTES]
            WHERE 
                [CPF] = @CPF";


        private const string sqlExisteClienteComCPFRepetidoEditar =
        @"SELECT 
                COUNT(*) 
            FROM 
                [TBCLIENTES]
            WHERE 
                [CPF] = @CPF
            AND
                [ID] != @ID";

        private const string sqlExisteClienteComRGRepetidoInserir =
       @"SELECT 
                COUNT(*) 
            FROM 
                [TBCLIENTES]
            WHERE 
                [RG] = @RG";

        private const string sqlExisteClienteComRGRepetidoEditar =
      @"SELECT 
                COUNT(*) 
            FROM 
                [TBCLIENTES]
            WHERE 
                [RG] = @RG
            AND
                [ID] != @ID";
        #endregion

        public bool InserirNovo(Cliente cliente)
        {
            try
            {
                Log.Logger.Contexto().Information("Tentando inserir {cliente} no banco de dados...", cliente);
                cliente.Id = Db.Insert(sqlInserirCliente, ObtemParametrosClientes(cliente));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public bool Editar(int id, Cliente cliente)
        {
            try
            {
                Log.Logger.Contexto().Information("Tentando editar o cliente com id {@idCliente} para {cliente} no banco de dados...", id, cliente);
                Db.Update(sqlEditarCliente, ObtemParametrosClientes(cliente));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                Log.Logger.Contexto().Information("Tentando excluir cliente com id {@idCliente} no banco de dados...", id);
                Db.Delete(sqlExcluirCliente, AdicionarParametro("ID", id));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Existe(int id)
        {
            try
            {
                Log.Logger.Contexto().Information("Tentando verificar se existe um cliente com id {@idCliente} no banco de dados...", id);
                return Db.Exists(sqlExisteCliente, AdicionarParametro("ID", id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cliente SelecionarPorId(int id)
        {
            try
            {
                Log.Logger.Contexto().Information("Tentando selecionar o cliente com id {@idCliente} no banco de dados...", id);
                return Db.Get(sqlSelecionarClientePorId, ConverterEmCliente, AdicionarParametro("ID", id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cliente> SelecionarTodos()
        {
            try
            {
                Log.Logger.Contexto().Information("Tentando selecionar todos os clientes no banco de dados...");
                return Db.GetAll(sqlSelecionarTodosClientes, ConverterEmCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #region metodos privados
        private Dictionary<string, object> ObtemParametrosClientes(Cliente clientes)
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

        private Cliente ConverterEmCliente(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string nome = Convert.ToString(reader["NOME"]);
            string endereco = Convert.ToString(reader["ENDERECO"]);
            string telefone = Convert.ToString(reader["TELEFONE"]);
            string rg = Convert.ToString(reader["RG"]);
            string cpf = Convert.ToString(reader["CPF"]);
            string cnpj = Convert.ToString(reader["CNPJ"]);
            string email = Convert.ToString(reader["EMAIL"]);

            Cliente clientes = new Cliente(nome, endereco, telefone, rg, cpf, cnpj, email);

            clientes.Id = id;

            return clientes;
        }

        protected Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }

        public bool ExisteClienteComEsteCPF(int id, string cpf)
        {
            bool novoCliente = id == 0;

            try 
            {
                Serilog.Log.Logger.Contexto().Information("Verificando se existe cliente com cpf {@cpf} no bancos de dados...", cpf);
                if (novoCliente)
                {
                    return Db.Exists(sqlExisteClienteComCPFRepetidoInserir, AdicionarParametro("CPF", cpf));
                }
                else
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("ID", id);
                    parametros.Add("CPF", cpf);
                    return Db.Exists(sqlExisteClienteComCPFRepetidoEditar, parametros);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExisteClienteComEsteRG(int id, string rg)
        {
            bool novoCliente = id == 0;

            try
            {
                Serilog.Log.Logger.Contexto().Information("Verificando se existe cliente com rg {@rg} no bancos de dados...", rg);
                if (novoCliente)
                {
                    return Db.Exists(sqlExisteClienteComRGRepetidoInserir, AdicionarParametro("RG", rg));
                }
                else
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("ID", id);
                    parametros.Add("RG", rg);
                    return Db.Exists(sqlExisteClienteComRGRepetidoEditar, parametros);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


    }
}
