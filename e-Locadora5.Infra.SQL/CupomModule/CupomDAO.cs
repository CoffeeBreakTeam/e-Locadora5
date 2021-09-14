using e_Locadora5.Dominio.CupomModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.SQL.CupomModule
{
    public class CupomDAO : ICupomRepository
    {
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

        public void InserirCupom(Cupons cupons)
        {
            cupons.Id = Db.Insert(sqlInserirCupom, ObtemParametrosCupons(cupons));
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
    }
}
