using e_Locadora5.Aplicacao.ClienteModule;
using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.CondutoresModule;
using e_Locadora5.Infra.GeradorLogs;
using e_Locadora5.Infra.SQL.ClienteModule;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;


namespace e_Locadora5.Infra.SQL.CondutorModule
{
    public class CondutorDAO : ICondutorRepository
    {
        ClienteAppService clienteAppService = new ClienteAppService(new ClienteDAO());

        #region Queries
        private const string sqlInserirCondutor =
         @"INSERT INTO TBCONDUTOR
	                (
		                [NOME], 
		                [ENDERECO], 
		                [TELEFONE],
                        [RG], 
		                [CPF],
                        [CNH],
                        [VALIDADECNH],
                        [ID_CLIENTE]
	                ) 
	                VALUES
	                (
                        @NOME, 
		                @ENDERECO, 
		                @TELEFONE,
                        @RG,
                        @CPF, 
		                @CNH,
                        @VALIDADECNH,
                        @ID_CLIENTE
	                )";

        private const string sqlEditarCondutor =
         @"UPDATE TBCONDUTOR
                    SET
                        [NOME] = @NOME,
		                [ENDERECO] = @ENDERECO, 
		                [TELEFONE] = @TELEFONE,
                        [RG] = @RG, 
		                [CPF] = @CPF,
                        [CNH] = @CNH,
                        [VALIDADECNH] = @VALIDADECNH,
                        [ID_CLIENTE] = @ID_CLIENTE
                    WHERE 
                        ID = @ID";

        private const string sqlExcluirCondutor =
         @"DELETE 
	              FROM
                        TBCONDUTOR
                    WHERE 
                        ID = @ID";

        private const string sqlExisteCondutor =
        @"SELECT 
                COUNT(*) 
            FROM 
                [TBCONDUTOR]
            WHERE 
                [ID] = @ID";

        private const string sqlExisteCondutorComCPFRepetidoInserir =
        @"SELECT 
                COUNT(*) 
            FROM 
                [TBCONDUTOR]
            WHERE 
                [CPF] = @CPF";

        private const string sqlExisteCondutorComCPFRepetidoEditar =
        @"SELECT 
                COUNT(*) 
            FROM 
                [TBCONDUTOR]
            WHERE 
                [CPF] = @CPF
            AND
                [ID] != @ID";

        private const string sqlExisteCondutorComRGRepetidoInserir =
        @"SELECT 
                COUNT(*) 
            FROM 
                [TBCONDUTOR]
            WHERE 
                [RG] = @RG";

        private const string sqlExisteCondutorComRGRepetidoEditar =
        @"SELECT 
                COUNT(*) 
            FROM 
                [TBCONDUTOR]
            WHERE 
                [RG] = @RG
            AND
                [ID] != @ID";

        private const string sqlSelecionarCondutorPorId =
            @"SELECT 
                CP.[ID],       
                CP.[NOME],
                CP.[ENDERECO],
                CP.[TELEFONE],             
                CP.[RG],                    
                CP.[CPF],                                
                CP.[CNH],
                CP.[VALIDADECNH],
                CP.[ID_CLIENTE],
                CT.[NOME],       
                CT.[ENDERECO],             
                CT.[TELEFONE],                    
                CT.[RG], 
                CT.[CPF],
                CT.[CNPJ],
                CT.[EMAIL]
            FROM
                [TBCONDUTOR] AS CP LEFT JOIN 
                [TBCLIENTES] AS CT
            ON
                CT.ID = CP.ID_CLIENTE
            WHERE
                 CP.[ID] = @ID";

        private const string sqlSelecionarTodosCondutores =
            @"SELECT 
                CP.[ID],       
                CP.[NOME],
                CP.[ENDERECO],
                CP.[TELEFONE],             
                CP.[RG],                    
                CP.[CPF],                                
                CP.[CNH],
                CP.[VALIDADECNH],
                CP.[ID_CLIENTE],
                CT.[NOME],       
                CT.[ENDERECO],             
                CT.[TELEFONE],                    
                CT.[RG], 
                CT.[CPF],
                CT.[CNPJ],
                CT.[EMAIL]
            FROM
                [TBCONDUTOR] AS CP LEFT JOIN 
                [TBCLIENTES] AS CT
            ON
                CT.ID = CP.ID_CLIENTE";
        private const string sqlSelecionarCondutoresComCNHVencida =
            @"SELECT 
                CP.[ID],       
                CP.[NOME],
                CP.[ENDERECO],
                CP.[TELEFONE],             
                CP.[RG],                    
                CP.[CPF],                                
                CP.[CNH],
                CP.[VALIDADECNH],
                CP.[ID_CLIENTE],
                CT.[NOME],       
                CT.[ENDERECO],             
                CT.[TELEFONE],                    
                CT.[RG], 
                CT.[CPF],
                CT.[CNPJ],
                CT.[EMAIL]
            FROM
                [TBCONDUTOR] AS CP LEFT JOIN 
                [TBCLIENTES] AS CT
            ON
                CT.ID = CP.ID_CLIENTE
           WHERE 
                CP.[VALIDADECNH] <= @VALIDADECNH";


        #endregion

        public bool InserirNovo(Condutor registro)
        {
            Log.Logger.Contexto().Information("Tentando inserir {@Condutor} no banco de dados...", registro);
            registro.Id = Db.Insert(sqlInserirCondutor, ObtemParametrosCondutor(registro));
            return true;
        }

        public bool Editar(int id, Condutor registro)
        {
            try
            {
                Log.Logger.Contexto().Information("Tentando editar o condutor com id {idcondutor} no banco de dados...", id);
                registro.Id = id;
                Db.Update(sqlEditarCondutor, ObtemParametrosCondutor(registro));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }

        }

        public bool Excluir(int id)
        {
            try
            {
                Log.Logger.Contexto().Information("Excluindo condutor com id {idcondutor} no banco de dados...", id);
                Db.Delete(sqlExcluirCondutor, AdicionarParametro("ID", id));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }

        }

        public bool Existe(int id)
        {
            try
            {
                Log.Logger.Contexto().Information("Tentando verificar se existe um condutor com id {idcondutor} no banco de dados...", id);
                return Db.Exists(sqlExisteCondutor, AdicionarParametro("ID", id));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Condutor SelecionarPorId(int id)
        {
            try
            {
                Log.Logger.Contexto().Information("Tentando selecionar o condutor com id {idcondutor} no banco de dados...", id);
                return Db.Get(sqlSelecionarCondutorPorId, ConverterEmCondutor, AdicionarParametro("ID", id));
            }
            catch (Exception ex)
            {
                ex.Data.Add("sql", sqlSelecionarCondutorPorId);
                ex.Data.Add("condutorId", id);
                throw ex;
            }

        }

        public List<Condutor> SelecionarTodos()
        {
            try
            {
                Log.Logger.Contexto().Information("Tentando selecionar todos os condutores no banco de dados...");
                return Db.GetAll(sqlSelecionarTodosCondutores, ConverterEmCondutor);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Condutor> SelecionarCondutoresComCnhVencida(DateTime data)
        {
            return Db.GetAll(sqlSelecionarCondutoresComCNHVencida, ConverterEmCondutor, AdicionarParametro("VALIDADECNH", data));
        }

        private Dictionary<string, object> ObtemParametrosCondutor(Condutor condutor)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", condutor.Id);
            parametros.Add("NOME", condutor.Nome);
            parametros.Add("ENDERECO", condutor.Endereco);
            parametros.Add("TELEFONE", condutor.Telefone);
            parametros.Add("RG", condutor.Rg);
            parametros.Add("CPF", condutor.Cpf);
            parametros.Add("CNH", condutor.NumeroCNH);
            parametros.Add("VALIDADECNH", condutor.ValidadeCNH);
            parametros.Add("ID_CLIENTE", condutor.Cliente?.Id);

            return parametros;
        }

        private Condutor ConverterEmCondutor(IDataReader reader)
        {
            var nome = Convert.ToString(reader["NOME"]);
            var endereco = Convert.ToString(reader["ENDERECO"]);
            var telefone = Convert.ToString(reader["TELEFONE"]);
            var Rg = Convert.ToString(reader["RG"]);
            var Cpf = Convert.ToString(reader["CPF"]);
            var Cnh = Convert.ToString(reader["CNH"]);
            var dataValidade = Convert.ToDateTime(reader["VALIDADECNH"]);


            var idCliente = Convert.ToInt32(reader["ID_CLIENTE"]);
            Cliente clientes = clienteAppService.SelecionarPorId(idCliente);

            Condutor condutor = new Condutor(nome, endereco, telefone, Rg, Cpf, Cnh, dataValidade, clientes);

            condutor.Id = Convert.ToInt32(reader["ID"]);

            return condutor;
        }

        protected Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }

        public bool ExisteCondutorComEsteCPF(int id, string cpf)
        {
            bool novoCondutor = id == 0;
            try
            {
                Log.Logger.Contexto().Information("Verificando se existe condutor com cpf {cpf} no bancos de dados...", cpf);
                if (novoCondutor)
                {
                    return Db.Exists(sqlExisteCondutorComCPFRepetidoInserir, AdicionarParametro("CPF", cpf));
                }
                else
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("ID", id);
                    parametros.Add("CPF", cpf);
                    return Db.Exists(sqlExisteCondutorComCPFRepetidoEditar, parametros);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool ExisteCondutorComEsteRG(int id, string rg)
        {
            bool novoCondutor = id == 0;
            try
            {
                Log.Logger.Contexto().Information("Verificando se existe condutor com rg {rg} no bancos de dados...", rg);
                if (novoCondutor)
                {
                    return Db.Exists(sqlExisteCondutorComRGRepetidoInserir, AdicionarParametro("RG", rg));
                }
                else
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("ID", id);
                    parametros.Add("RG", rg);
                    return Db.Exists(sqlExisteCondutorComRGRepetidoEditar, parametros);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
