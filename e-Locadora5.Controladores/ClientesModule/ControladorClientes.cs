using e_Locadora5.Controladores.Shared;
using e_Locadora5.Dominio.ClientesModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Controladores.ClientesModule
{
    public class ControladorClientes : Controlador<Clientes>
    {
        #region Queris
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
        public override string InserirNovo(Clientes registro)
        {
            string resultadoValidacao = registro.Validar();
            string validarRepeticoes = ValidarClientes(registro);
            if (resultadoValidacao == "ESTA_VALIDO" && validarRepeticoes == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirCliente, ObtemParametrosClientes(registro));
            }

            return resultadoValidacao;
        }


        public override string Editar(int id, Clientes registro)
        {
            string resultadoValidacao = registro.Validar();

            string validarRepeticoes = ValidarClientes(registro, id);
            if (resultadoValidacao == "ESTA_VALIDO" && validarRepeticoes == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarCliente, ObtemParametrosClientes(registro));
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirCliente, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteCliente, AdicionarParametro("ID", id));
        }

        public override Clientes SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarClientePorId, ConverterEmCliente, AdicionarParametro("ID", id));
        }

        public override List<Clientes> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosClientes, ConverterEmCliente);
        }

        public string ValidarClientes(Clientes novoClientes, int id = 0)
        {
            //validar placas iguais
            if (novoClientes != null)
            {
                if (id != 0)
                {//situação de editar
                    int countCPFsIguais = 0;
                    int countRGsIguais = 0;
                    int countCNPJsIguais = 0;
                    List<Clientes> todosClientes = SelecionarTodos();
                    foreach (Clientes cliente in todosClientes)
                    {
                        if (novoClientes.CPF.Equals(cliente.CPF) && cliente.Id != id && novoClientes.CPF!="")
                            countCPFsIguais++;
                        if (novoClientes.RG.Equals(cliente.RG) && cliente.Id != id && novoClientes.RG != "")
                            countRGsIguais++;
                        if (novoClientes.CNPJ.Equals(cliente.CNPJ) && cliente.Id != id && novoClientes.CNPJ != "")
                            countCNPJsIguais++;
                    }
                    if (countCPFsIguais > 0)
                        return "CPF já cadastrado, tente novamente.";
                    if (countRGsIguais > 0)
                        return "RG já cadastrado, tente novamente.";
                    if (countCNPJsIguais > 0)
                        return "CNPJ já cadastrado, tente novamente.";
                }
                else
                {//situação de inserir
                    int countCPFsIguais = 0;
                    int countRGsIguais = 0;
                    int countCNPJsIguais = 0;
                    List<Clientes> todosClientess = SelecionarTodos();
                    foreach (Clientes cliente in todosClientess)
                    {
                        if (novoClientes.CPF.Equals(cliente.CPF) && novoClientes.CPF != "")
                            countCPFsIguais++;
                        if (novoClientes.RG.Equals(cliente.RG) && novoClientes.RG != "")
                            countRGsIguais++;
                        if (novoClientes.CNPJ.Equals(cliente.CNPJ) && novoClientes.CNPJ != "")
                            countCNPJsIguais++;
                    }
                    if (countCPFsIguais > 0)
                        return "CPF já cadastrado, tente novamente.";
                    if (countRGsIguais > 0)
                        return "RG já cadastrado, tente novamente.";
                    if (countCNPJsIguais > 0)
                        return "CNPJ já cadastrado, tente novamente.";
                }
            }
            return "ESTA_VALIDO";
        }

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

            Clientes clientes = new Clientes(nome, endereco, telefone, rg, cpf, cnpj,email);

            clientes.Id = id;

            return clientes;
        }

    }
}
