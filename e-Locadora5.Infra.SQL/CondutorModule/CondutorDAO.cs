using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.CondutoresModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        [NUMERORG], 
		                [NUMEROCPF],
                        [NUMEROCNH],
                        [VALIDADECNH],
                        [ID_CLIENTE]
	                ) 
	                VALUES
	                (
                        @NOME, 
		                @ENDERECO, 
		                @TELEFONE,
                        @NUMERORG,
                        @NUMEROCPF, 
		                @NUMEROCNH,
                        @VALIDADECNH,
                        @ID_CLIENTE
	                )";

        private const string sqlEditarCondutor =
         @"UPDATE TBCONDUTOR
                    SET
                        [NOME] = @NOME,
		                [ENDERECO] = @ENDERECO, 
		                [TELEFONE] = @TELEFONE,
                        [NUMERORG] = @NUMERORG, 
		                [NUMEROCPF] = @NUMEROCPF,
                        [NUMEROCNH] = @NUMEROCNH,
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

        private const string sqlSelecionarCondutorPorId =
            @"SELECT 
                CP.[ID],       
                CP.[NOME],
                CP.[ENDERECO],
                CP.[TELEFONE],             
                CP.[NUMERORG],                    
                CP.[NUMEROCPF],                                
                CP.[NUMEROCNH],
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
                CP.[NUMERORG],                    
                CP.[NUMEROCPF],                                
                CP.[NUMEROCNH],
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
                CP.[NUMERORG],                    
                CP.[NUMEROCPF],                                
                CP.[NUMEROCNH],
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

        public void InserirNovo(Condutor registro)
        {
            registro.Id = Db.Insert(sqlInserirCondutor, ObtemParametrosCondutor(registro));
        }

        public void Editar(int id, Condutor registro)
        {
            registro.Id = id;
            Db.Update(sqlEditarCondutor, ObtemParametrosCondutor(registro));
        }

        public void Excluir(int id)
        {
            Db.Delete(sqlExcluirCondutor, AdicionarParametro("ID", id));
        }

        public bool Existe(int id)
        {
            return Db.Exists(sqlExisteCondutor, AdicionarParametro("ID", id));
        }

        public Condutor SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarCondutorPorId, ConverterEmCondutor, AdicionarParametro("ID", id));
        }

        public List<Condutor> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosCondutores, ConverterEmCondutor);
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
            parametros.Add("NUMERORG", condutor.Rg);
            parametros.Add("NUMEROCPF", condutor.Cpf);
            parametros.Add("NUMEROCNH", condutor.NumeroCNH);
            parametros.Add("VALIDADECNH", condutor.ValidadeCNH);
            parametros.Add("ID_CLIENTE", condutor.Cliente?.Id);

            return parametros;
        }

        private Condutor ConverterEmCondutor(IDataReader reader)
        {
            var nome = Convert.ToString(reader["NOME"]);
            var endereco = Convert.ToString(reader["ENDERECO"]);
            var telefone = Convert.ToString(reader["TELEFONE"]);
            var numeroRg = Convert.ToString(reader["NUMERORG"]);
            var numeroCpf = Convert.ToString(reader["NUMEROCPF"]);
            var numeroCnh = Convert.ToString(reader["NUMEROCNH"]);
            var dataValidade = Convert.ToDateTime(reader["VALIDADECNH"]);


            var idCliente = Convert.ToInt32(reader["ID_CLIENTE"]);
            Clientes clientes = clienteAppService.SelecionarPorId(idCliente);

            Condutor condutor = new Condutor(nome, endereco, telefone, numeroRg, numeroCpf, numeroCnh, dataValidade, clientes);

            condutor.Id = Convert.ToInt32(reader["ID"]);

            return condutor;
        }

        protected Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }
    }
}
