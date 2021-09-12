using e_Locadora5.Dominio;
using e_Locadora5.Controladores.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace e_Locadora5.Controladores.VeiculoModule
{
    public class ControladorGrupoVeiculo : Controlador<GrupoVeiculo>
    {
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

        public override string InserirNovo(GrupoVeiculo registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirGrupoVeiculo, ObtemParametrosGrupoVeiculo(registro));
            }

            return resultadoValidacao;
        }

        public override string Editar(int id, GrupoVeiculo registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarGrupoVeiculo, ObtemParametrosGrupoVeiculo(registro));
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirGrupoVeiculo, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteGrupoVeiculo, AdicionarParametro("ID", id));
        }

        public override GrupoVeiculo SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarGrupoVeiculoPorId, ConverterEmGrupoVeiculo, AdicionarParametro("ID", id));
        }

        public override List<GrupoVeiculo> SelecionarTodos()
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
    }
}
