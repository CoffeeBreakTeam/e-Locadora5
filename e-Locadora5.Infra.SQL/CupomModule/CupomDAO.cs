using e_Locadora5.Aplicacao.ParceiroModule;
using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Infra.SQL.ParceiroModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.SQL.CupomModule
{
    public class CupomDAO : ICupomRepository
    {
        ParceiroAppService parceiroAppService = new ParceiroAppService(new ParceiroDAO());

        #region sqls
        private const string sqlInserirCupom =
        @"INSERT INTO TBCUPONS
	                (	
		                [NOME], 
		                [VALOR_PERCENTUAL], 
		                [VALOR_FIXO],
                        [DATA_VALIDADE],
                        [IDPARCEIRO],
                        [VALOR_MINIMO]
	                )
	                VALUES
	                (
                        @NOME, 
		                @VALOR_PERCENTUAL, 
		                @VALOR_FIXO,
                        @DATA_VALIDADE,
                        @IDPARCEIRO,
                        @VALOR_MINIMO
	                )";

        private const string sqlEditarCupom =
       @"UPDATE TBCUPONS
                    SET
                        [NOME] = @NOME, 
		                [VALOR_PERCENTUAL] = @VALOR_PERCENTUAL, 
		                [VALOR_FIXO] = @VALOR_FIXO,
                        [DATA_VALIDADE] = @DATA_VALIDADE,
                        [IDPARCEIRO] = @IDPARCEIRO,
                        [VALOR_MINIMO] = @VALOR_MINIMO
                     
                    WHERE 
                        ID = @ID";

        private const string sqlExcluirCupom =
        @"DELETE 
	                FROM
                        TBCUPONS
                    WHERE 
                        ID = @ID";

        private const string sqlExisteCupom =
         @"SELECT 
                    COUNT(*) 
                FROM 
                    [TBCUPONS]
                WHERE 
                    [ID] = @ID";

        private const string sqlExisteCupomComEsseNome =
         @"SELECT 
                    COUNT(*) 
                FROM 
                    [TBCUPONS]
                WHERE 
                    [NOME] = @NOME";

        private const string sqlSelecionarTodosCupons =
        @"SELECT
                        [ID],
                        [NOME], 
		                [VALOR_PERCENTUAL], 
		                [VALOR_FIXO],
                        [DATA_VALIDADE],
                        [IDPARCEIRO],
                        [VALOR_MINIMO]

                        FROM TBCUPONS";

        private const string sqlSelecionarCupomPorId =
         @"SELECT
                        [ID],
                        [NOME], 
		                [VALOR_PERCENTUAL], 
		                [VALOR_FIXO],
                        [DATA_VALIDADE],
                        [IDPARCEIRO],
                        [VALOR_MINIMO]

	                FROM
                        TBCUPONS
                    WHERE 
                        ID = @ID";
        #endregion

        public bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirCupom, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private Dictionary<string, object> ObtemParametrosCupons(Cupons cupons)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", cupons.Id);
            parametros.Add("NOME", cupons.Nome);
            parametros.Add("VALOR_PERCENTUAL", cupons.ValorPercentual);
            parametros.Add("VALOR_FIXO", cupons.ValorFixo);
            parametros.Add("DATA_VALIDADE", cupons.DataValidade);
            parametros.Add("IDPARCEIRO", cupons.Parceiro.Id);
            parametros.Add("VALOR_MINIMO", cupons.ValorMinimo);
            return parametros;
        }

        public List<Cupons> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosCupons, ConverterEmCupom);
        }

        private Cupons ConverterEmCupom(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string nome = ((string)reader["NOME"]);
            int valor_Percentual = Convert.ToInt32(reader["VALOR_PERCENTUAL"]);
            double valor_Fixo = Convert.ToDouble(reader["VALOR_FIXO"]);
            DateTime data = Convert.ToDateTime(reader["DATA_VALIDADE"]);
            int idParceiro = Convert.ToInt32(reader["IDPARCEIRO"]);
            Parceiro parceiro = parceiroAppService.SelecionarPorId(idParceiro);
            double valorMinimo = Convert.ToDouble(reader["VALOR_MINIMO"]);

            Cupons cupons = new Cupons(nome, valor_Percentual, valor_Fixo, data, parceiro, valorMinimo);

            cupons.Id = id;

            return cupons;
        }

        public void Editar(int id, Cupons cupons)
        {
            cupons.Id = id;
            Db.Update(sqlEditarCupom, ObtemParametrosCupons(cupons));
        }

        public Cupons SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarCupomPorId, ConverterEmCupom, AdicionarParametro("ID", id));
        }

        private Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }

        public bool Existe(int id)
        {
            return Db.Exists(sqlExisteCupom, AdicionarParametro("ID", id));
        }

        public void InserirNovo(Cupons cupons)
        {
            cupons.Id = Db.Insert(sqlInserirCupom, ObtemParametrosCupons(cupons));
        }

        public bool ExisteCupomMesmoNome(string nome)
        {
            return Db.Exists(sqlExisteCupomComEsseNome, AdicionarParametro("NOME", nome));
        }
    }
}
