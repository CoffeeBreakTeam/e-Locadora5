using e_Locadora5.Dominio.TaxasServicosModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.SQL.TaxasServicosModule
{
    public class TaxasServicosDAO : ITaxasServicosRepository
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

        public void Editar(int id, TaxasServicos registro)
        {
            registro.Id = id;
            Db.Update(sqlEditarTaxasServicos, ObtemParametrosTaxasServicos(registro));
        }

        public void Excluir(int id)
        {
             Db.Delete(sqlExcluirTaxasServicos, AdicionarParametro("ID", id));
        }

        public bool Existe(int id)
        {
            return Db.Exists(sqlExisteTaxasServicos, AdicionarParametro("ID", id));
        }

        public void InserirNovo(TaxasServicos registro)
        {
            registro.Id = Db.Insert(sqlInserirTaxasServicos, ObtemParametrosTaxasServicos(registro));
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

        public TaxasServicos SelecionarPorId(int id)
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

        public List<TaxasServicos> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosTaxasServicos, ConverterEmTaxasServicos);
        }

        protected Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }
    }
}
