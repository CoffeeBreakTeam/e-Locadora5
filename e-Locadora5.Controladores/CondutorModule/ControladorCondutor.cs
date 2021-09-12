using e_Locadora5.Controladores.ClientesModule;
using e_Locadora5.Controladores.Shared;
using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.CondutoresModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Controladores.CondutorModule
{
    public class ControladorCondutor : Controlador<Condutor>
    {
        ControladorClientes controlador = new ControladorClientes();
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
        public override string InserirNovo(Condutor registro)
        {
            string resultadoValidacao = registro.Validar();
            string resultadoValidacaoRepeticoes = ValidarCondutor(registro);

            if (resultadoValidacao == "ESTA_VALIDO" && resultadoValidacaoRepeticoes == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirCondutor, ObtemParametrosCondutor(registro));
            }

            return resultadoValidacao;
        }

        public override string Editar(int id, Condutor registro)
        {
            string resultadoValidacao = registro.Validar();
            string resultadoValidacaoRepeticoes = ValidarCondutor(registro, id);

            if (resultadoValidacao == "ESTA_VALIDO" && resultadoValidacaoRepeticoes == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarCondutor, ObtemParametrosCondutor(registro));
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
        {

            try
            {
                Db.Delete(sqlExcluirCondutor, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteCondutor, AdicionarParametro("ID", id));
        }

        public override Condutor SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarCondutorPorId, ConverterEmCondutor, AdicionarParametro("ID", id));
        }
  
        public override List<Condutor> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosCondutores, ConverterEmCondutor);
        }
        public List<Condutor> SelecionarCondutoresComCnhVencida(DateTime data)
        {
            return Db.GetAll(sqlSelecionarCondutoresComCNHVencida, ConverterEmCondutor, AdicionarParametro("VALIDADECNH", data));
        }

        public string ValidarCondutor(Condutor novoCondutores, int id = 0)
        {
            //validar placas iguais
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
            Clientes clientes = controlador.SelecionarPorId(idCliente);

            Condutor condutor = new Condutor(nome, endereco, telefone, numeroRg, numeroCpf, numeroCnh, dataValidade, clientes);

            condutor.Id = Convert.ToInt32(reader["ID"]);

            return condutor;
        }



    }
}
