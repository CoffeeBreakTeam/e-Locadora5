using e_Locadora5.Dominio;
using e_Locadora5.Dominio.GrupoVeiculoModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.SQL.GrupoVeiculoModule
{
    public class GrupoVeiculoDAO : IGrupoVeiculoRepository
    {
        #region Queries
        private const string sqlInserirGrupoVeiculo =
            @"INSERT INTO CATEGORIAS 
	                (
		                [CATEGORIA], 
		                [VALORDIARIOKM], 
		                [VALORDIARIO],
                        [VALORCONTROLADODIARIOKM], 
		                [VALORCONTROLADODIARIO],
                        [VALORCONTROLADOQTDKM],
                        [VALORLIVRE]
	                ) 
	                VALUES
	                (
                        @CATEGORIA, 
		                @VALORDIARIOKM, 
		                @VALORDIARIO,
                        @VALORCONTROLADODIARIOKM, 
		                @VALORCONTROLADODIARIO,
                        @VALORCONTROLADOQTDKM,
                        @VALORLIVRE
	                )";

        private const string sqlEditarGrupoVeiculo =
            @"UPDATE CATEGORIAS
                    SET
                        [CATEGORIA] = @CATEGORIA, 
		                [VALORDIARIOKM] = @VALORDIARIOKM, 
		                [VALORDIARIO] = @VALORDIARIO,
                        [VALORCONTROLADODIARIOKM] = @VALORCONTROLADODIARIOKM, 
		                [VALORCONTROLADODIARIO] = @VALORCONTROLADODIARIO,
                        [VALORCONTROLADOQTDKM] = @VALORCONTROLADOQTDKM,
                        [VALORLIVRE] = @VALORLIVRE
                    WHERE 
                        ID = @ID";

        private const string sqlExcluirGrupoVeiculo =
            @"DELETE 
	                FROM
                        CATEGORIAS
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarGrupoVeiculoPorId =
            @"SELECT
                        [ID],
                        [CATEGORIA], 
		                [VALORDIARIOKM], 
		                [VALORDIARIO],
                        [VALORCONTROLADODIARIOKM], 
		                [VALORCONTROLADODIARIO],
                        [VALORCONTROLADOQTDKM],
                        [VALORLIVRE]
	                FROM
                        CATEGORIAS
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarTodosGrupoVeiculos =
            @"SELECT
                        [ID],
                        [CATEGORIA], 
		                [VALORDIARIOKM], 
		                [VALORDIARIO],
                        [VALORCONTROLADODIARIOKM], 
		                [VALORCONTROLADODIARIO],
                        [VALORCONTROLADOQTDKM],
                        [VALORLIVRE] FROM CATEGORIAS";

        private const string sqlExisteGrupoVeiculo =
            @"SELECT 
                COUNT(*) 
            FROM 
                [CATEGORIAS]
            WHERE 
                [ID] = @ID";
        #endregion
        public bool InserirNovo(GrupoVeiculo registro)
        {
            registro.Id = Db.Insert(sqlInserirGrupoVeiculo, ObtemParametrosGrupoVeiculo(registro));
            return true;
        }

        public bool Editar(int id, GrupoVeiculo registro)
        {
            registro.Id = id;
            Db.Update(sqlEditarGrupoVeiculo, ObtemParametrosGrupoVeiculo(registro));
            return true;
        }

        public bool Excluir(int id)
        {
            Db.Delete(sqlExcluirGrupoVeiculo, AdicionarParametro("ID", id));
            return true;
        }

        public bool Existe(int id)
        {
            return Db.Exists(sqlExisteGrupoVeiculo, AdicionarParametro("ID", id));
        }

        public GrupoVeiculo SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarGrupoVeiculoPorId, ConverterEmGrupoVeiculo, AdicionarParametro("ID", id));
        }

        public List<GrupoVeiculo> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosGrupoVeiculos, ConverterEmGrupoVeiculo);
        }

        private GrupoVeiculo ConverterEmGrupoVeiculo(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string categoria = Convert.ToString(reader["CATEGORIA"]);
            double planoDiarioValorKm = Convert.ToDouble(reader["VALORDIARIOKM"]);
            double planoDiarioValorDiario = Convert.ToDouble(reader["VALORDIARIO"]);
            double planoKmControladoValorKm = Convert.ToDouble(reader["VALORCONTROLADODIARIOKM"]);
            double planoKmControladoValorDiario = Convert.ToDouble(reader["VALORCONTROLADODIARIO"]);
            double planoKmControladoQuantidadeKm = Convert.ToDouble(reader["VALORCONTROLADOQTDKM"]);
            double planoKmLivreValorDiario = Convert.ToDouble(reader["VALORLIVRE"]);

            GrupoVeiculo grupoVeiculo = new GrupoVeiculo(categoria, planoDiarioValorKm, planoDiarioValorDiario, planoKmControladoValorKm, planoKmControladoQuantidadeKm, planoKmControladoValorDiario, planoKmLivreValorDiario);

            grupoVeiculo.Id = id;

            return grupoVeiculo;
        }

        private Dictionary<string, object> ObtemParametrosGrupoVeiculo(GrupoVeiculo grupoVeiculo)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", grupoVeiculo.Id);
            parametros.Add("CATEGORIA", grupoVeiculo.categoria);
            parametros.Add("VALORDIARIOKM", grupoVeiculo.planoDiarioValorKm);
            parametros.Add("VALORDIARIO", grupoVeiculo.planoDiarioValorDiario);
            parametros.Add("VALORCONTROLADODIARIOKM", grupoVeiculo.planoKmControladoValorKm);
            parametros.Add("VALORCONTROLADOQTDKM", grupoVeiculo.planoKmControladoQuantidadeKm);
            parametros.Add("VALORCONTROLADODIARIO", grupoVeiculo.planoKmControladoValorDiario);
            parametros.Add("VALORLIVRE", grupoVeiculo.planoKmLivreValorDiario);

            return parametros;
        }

        protected Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }

    }
}
