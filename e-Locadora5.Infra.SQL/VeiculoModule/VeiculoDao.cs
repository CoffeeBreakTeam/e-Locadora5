using e_Locadora5.Aplicacao.GrupoVeiculoModule;
using e_Locadora5.Dominio;
using e_Locadora5.Dominio.GrupoVeiculoModule;
using e_Locadora5.Dominio.VeiculosModule;
using e_Locadora5.Infra.SQL.GrupoVeiculoModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.SQL.VeiculoModule
{
    public class VeiculoDAO : IVeiculoRepository
    {
        #region Queries
        private const string sqlInserirVeiculo =
         @"INSERT INTO TBVEICULOS
	                (
		                [PLACA],
                        [MODELO],
		                [FABRICANTE],
                        [QUILOMETRAGEM],
		                [QTDLITROSTANQUE],
                        [QTDPORTAS],
                        [NUMEROCHASSI], 
		                [COR],
                        [CAPACIDADEOCUPANTES],
                        [ANOFABRICACAO],
                        [TAMANHOPORTAMALAS],
                        [TIPOCOMBUSTIVEL],
                        [IDGRUPOVEICULO],
                        [IMAGEM]
	                ) 
	                VALUES
	                (
                        @PLACA,
                        @MODELO,
		                @FABRICANTE,
                        @QUILOMETRAGEM,
		                @QTDLITROSTANQUE,
                        @QTDPORTAS,
                        @NUMEROCHASSI,
                        @COR, 
		                @CAPACIDADEOCUPANTES,
                        @ANOFABRICACAO,
                        @TAMANHOPORTAMALAS,
                        @TIPOCOMBUSTIVEL,
                        @IDGRUPOVEICULO,
                        @IMAGEM
	                )";

        private const string sqlEditarVeiculo =
         @"UPDATE TBVEICULOS
                    SET
                        [PLACA] = @PLACA,
                        [MODELO] = @MODELO,
		                [FABRICANTE] = @FABRICANTE,
                        [QUILOMETRAGEM] = @QUILOMETRAGEM,
		                [QTDLITROSTANQUE] = @QTDLITROSTANQUE,
                        [QTDPORTAS] = @QTDPORTAS,
                        [NUMEROCHASSI] = @NUMEROCHASSI, 
		                [COR] = @COR,
                        [CAPACIDADEOCUPANTES] = @CAPACIDADEOCUPANTES,
                        [ANOFABRICACAO] = @ANOFABRICACAO,
                        [TAMANHOPORTAMALAS] = @TAMANHOPORTAMALAS,
                        [TIPOCOMBUSTIVEL] = @TIPOCOMBUSTIVEL,
                        [IDGRUPOVEICULO] = @IDGRUPOVEICULO,
                        [IMAGEM] = @IMAGEM
                    WHERE 
                        ID = @ID";

        private const string sqlExcluirVeiculo =
         @"DELETE 
	              FROM
                        TBVEICULOS
                    WHERE 
                        ID = @ID";

        private const string sqlExisteVeiculo =
        @"SELECT 
                COUNT(*) 
            FROM 
                [TBVEICULOS]
            WHERE 
                [ID] = @ID";

        private const string sqlSelecionarVeiculoPorId =
        @"SELECT
                        [ID],
                        [PLACA],
                        [MODELO],
		                [FABRICANTE],
                        [QUILOMETRAGEM],
		                [QTDLITROSTANQUE],
                        [QTDPORTAS],
                        [NUMEROCHASSI], 
		                [COR],
                        [CAPACIDADEOCUPANTES],
                        [ANOFABRICACAO],
                        [TAMANHOPORTAMALAS],
                        [TIPOCOMBUSTIVEL],
                        [IDGRUPOVEICULO],
                        [IMAGEM]
	                FROM
                        TBVEICULOS
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarTodosVeiculos =
        @"SELECT
                        [ID],
                        [PLACA],
                        [MODELO],
		                [FABRICANTE],
                        [QUILOMETRAGEM],
		                [QTDLITROSTANQUE],
                        [QTDPORTAS],
                        [NUMEROCHASSI], 
		                [COR],
                        [CAPACIDADEOCUPANTES],
                        [ANOFABRICACAO],
                        [TAMANHOPORTAMALAS],
                        [TIPOCOMBUSTIVEL],
                        [IDGRUPOVEICULO],
                        [IMAGEM]
                        FROM TBVEICULOS";

        #endregion

        public void Editar(int id, Veiculo registro)
        {
            registro.Id = id;
            Db.Update(sqlEditarVeiculo, ObtemParametrosVeiculo(registro));
        }

        public bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirVeiculo, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Existe(int id)
        {
            return Db.Exists(sqlExisteVeiculo, AdicionarParametro("ID", id));
        }

        public void InserirNovo(Veiculo registro)
        {
            registro.Id = Db.Insert(sqlInserirVeiculo, ObtemParametrosVeiculo(registro));
        }

        public Veiculo SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarVeiculoPorId, ConverterEmVeiculo, AdicionarParametro("ID", id));
        }

        public List<Veiculo> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosVeiculos, ConverterEmVeiculo);
        }

        public bool ExisteVeiculoComEssaPlaca(string placa)
        {
            throw new NotImplementedException();
        }

        #region Metodos Privados

        private Veiculo ConverterEmVeiculo(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string placa = Convert.ToString(reader["PLACA"]);
            string modelo = Convert.ToString(reader["MODELO"]);
            string fabricante = Convert.ToString(reader["FABRICANTE"]);
            double quilometragem = Convert.ToDouble(reader["QUILOMETRAGEM"]);
            int qtdLitrosTanque = Convert.ToInt32(reader["QTDLITROSTANQUE"]);
            int qtdPortas = Convert.ToInt32(reader["QTDPORTAS"]);
            string numeroChassi = Convert.ToString(reader["NUMEROCHASSI"]);
            string cor = Convert.ToString(reader["COR"]);
            int capacidadeDeOcupantes = Convert.ToInt32(reader["CAPACIDADEOCUPANTES"]);
            int anoFabricacao = Convert.ToInt32(reader["ANOFABRICACAO"]);
            string tamanhoPortaMalas = Convert.ToString(reader["TAMANHOPORTAMALAS"]);
            string combustivel = Convert.ToString(reader["TIPOCOMBUSTIVEL"]);
            int idGrupoVeiculo = Convert.ToInt32(reader["IDGRUPOVEICULO"]);
            //if (reader["IMAGEM"] != null)
            byte[] imagem = (byte[])reader["IMAGEM"];

            GrupoVeiculoAppService grupoVeiculoService = new GrupoVeiculoAppService(new GrupoVeiculoDAO());
            GrupoVeiculo grupoVeiculo = grupoVeiculoService.SelecionarPorId(idGrupoVeiculo);

            Veiculo veiculo = new Veiculo(placa, modelo, fabricante, quilometragem, qtdLitrosTanque, qtdPortas, numeroChassi, cor, capacidadeDeOcupantes, anoFabricacao, tamanhoPortaMalas, combustivel, grupoVeiculo, imagem);

            veiculo.Id = id;

            return veiculo;
        }

        private Dictionary<string, object> ObtemParametrosVeiculo(Veiculo veiculo)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", veiculo.Id);
            parametros.Add("PLACA", veiculo.Placa);
            parametros.Add("MODELO", veiculo.Modelo);
            parametros.Add("FABRICANTE", veiculo.Fabricante);
            parametros.Add("QUILOMETRAGEM", veiculo.Quilometragem);
            parametros.Add("QTDLITROSTANQUE", veiculo.QtdLitrosTanque);
            parametros.Add("QTDPORTAS", veiculo.QtdPortas);
            parametros.Add("NUMEROCHASSI", veiculo.NumeroChassi);
            parametros.Add("COR", veiculo.Cor);
            parametros.Add("CAPACIDADEOCUPANTES", veiculo.CapacidadeOcupantes);
            parametros.Add("ANOFABRICACAO", veiculo.AnoFabricacao);
            parametros.Add("TAMANHOPORTAMALAS", veiculo.TamanhoPortaMalas);
            parametros.Add("TIPOCOMBUSTIVEL", veiculo.Combustivel);
            parametros.Add("IDGRUPOVEICULO", veiculo.GrupoVeiculo.Id);
            parametros.Add("IMAGEM", veiculo.Imagem);


            return parametros;
        }

        protected Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }




        #endregion
    }
}
