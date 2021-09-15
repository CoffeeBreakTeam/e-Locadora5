using e_Locadora5.Controladores.Shared;
using e_Locadora5.Dominio.TaxasServicosModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Controladores.TaxasServicoModule
{
    public class TaxasServicosAppService : Controlador<TaxasServicos>
    {
        #region Queries

        private const string sqlInserirTaxasServicos =
        @"INSERT INTO TBTAXASSERVICOS
	                (	
		                [DESCRICAO], 
		                [TAXA_FIXA], 
		                [TAXA_VARIAVEL]
	                )
	                VALUES
	                (
                        @DESCRICAO, 
		                @TAXA_FIXA, 
		                @TAXA_VARIAVEL
	                )";

        private const string sqlEditarTaxasServicos =
        @"UPDATE TBTAXASSERVICOS
                    SET
                        [DESCRICAO] = @DESCRICAO, 
		                [TAXA_FIXA] = @TAXA_FIXA, 
		                [TAXA_VARIAVEL] = @TAXA_VARIAVEL
                    WHERE 
                        ID = @ID";

        private const string sqlExcluirTaxasServicos =
         @"DELETE 
	                FROM
                        TBTAXASSERVICOS
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarTaxasServicosPorId =
         @"SELECT
                        [ID],
                        [DESCRICAO], 
		                [TAXA_FIXA], 
		                [TAXA_VARIAVEL]
	                FROM
                        TBTAXASSERVICOS
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarTodosTaxasServicos =
        @"SELECT
                        [ID],
                        [DESCRICAO], 
		                [TAXA_FIXA], 
		                [TAXA_VARIAVEL]

                        FROM TBTAXASSERVICOS";


        private const string sqlExisteTaxasServicos =
         @"SELECT 
                COUNT(*) 
            FROM 
                [TBTAXASSERVICOS]
            WHERE 
                [ID] = @ID";
        #endregion

        public override string Editar(int id, TaxasServicos registro)
        {
            string resultadoValidacao = registro.Validar();
            string resultadoValidacaoControlador = ValidarTaxasServicos(registro, id);

            if (resultadoValidacao == "ESTA_VALIDO" && resultadoValidacaoControlador == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarTaxasServicos, ObtemParametrosTaxasServicos(registro));
            }

            if(resultadoValidacao != "ESTA_VALIDO")
            {
                return resultadoValidacao;
            }
            else
            {
                return resultadoValidacaoControlador;
            }
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirTaxasServicos, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteTaxasServicos, AdicionarParametro("ID", id));
        }

        public override string InserirNovo(TaxasServicos registro)
        {
            string resultadoValidacao = registro.Validar();
            string resultadoValidacaoControlador = ValidarTaxasServicos(registro);

            if (resultadoValidacao == "ESTA_VALIDO" && resultadoValidacaoControlador == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirTaxasServicos, ObtemParametrosTaxasServicos(registro));
            }

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                return resultadoValidacao;
            }
            else
            {
                return resultadoValidacaoControlador;
            }
        }

        private Dictionary<string, object> ObtemParametrosTaxasServicos(TaxasServicos taxasServicos)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", taxasServicos.Id);
            parametros.Add("DESCRICAO", taxasServicos.Descricao);
            parametros.Add("TAXA_FIXA", taxasServicos.TaxaFixa);
            parametros.Add("TAXA_VARIAVEL", taxasServicos.TaxaDiaria);

            return parametros;
        }

        public override TaxasServicos SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarTaxasServicosPorId, ConverterEmTaxasServicos, AdicionarParametro("ID", id));
        }

        private TaxasServicos ConverterEmTaxasServicos(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string descricao = Convert.ToString(reader["DESCRICAO"]);
            double taxa_fixa = Convert.ToDouble(reader["TAXA_FIXA"]);
            double taxa_variavel = Convert.ToDouble(reader["TAXA_VARIAVEL"]);

            TaxasServicos taxasServicos = new TaxasServicos(descricao, taxa_fixa, taxa_variavel);

            taxasServicos.Id = id;

            return taxasServicos;
        }

        public override List<TaxasServicos> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosTaxasServicos, ConverterEmTaxasServicos);
        }

        public string ValidarTaxasServicos(TaxasServicos novoTaxasServicos, int id = 0)
        {
            //validar placas iguais
            if (novoTaxasServicos != null)
            {
                if (id != 0)
                {//situação de editar
                    int countTaxasIguais = 0;
                    List<TaxasServicos> todosTaxasServicos = SelecionarTodos();
                    foreach (TaxasServicos taxasServicos in todosTaxasServicos)
                    {
                        if (novoTaxasServicos.Descricao.Equals(taxasServicos.Descricao) && taxasServicos.Id != id)
                            countTaxasIguais++;
                    }
                    if (countTaxasIguais > 0)
                        return "Taxa ou serviço já cadastrada, tente novamente.";
                }
                else
                {//situação de inserir
                    int countTaxasIguais = 0;
                    List<TaxasServicos> todosTaxasServicos = SelecionarTodos();
                    foreach (TaxasServicos taxasServicos in todosTaxasServicos)
                    {
                        if (novoTaxasServicos.Descricao.Equals(taxasServicos.Descricao))
                            countTaxasIguais++;
                    }
                    if (countTaxasIguais > 0)
                        return "Taxa ou serviço já cadastrada, tente novamente.";
                }
            }
            return "ESTA_VALIDO";
        }
    }
}
