using e_Locadora5.Aplicacao.GrupoVeiculoModule;
using e_Locadora5.Dominio;
using e_Locadora5.Dominio.GrupoVeiculoModule;
using e_Locadora5.Dominio.VeiculosModule;
using e_Locadora5.Infra.GeradorLogs;
using e_Locadora5.Infra.SQL.GrupoVeiculoModule;
using e_Locadora5.Infra.SQL.LocacaoModule;
using Serilog;
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
        private const string sqlExisteVeiculoComEssaPlaca =
        @"SELECT 
                COUNT(*) 
            FROM 
                [TBVEICULOS]
            WHERE 
                [PLACA] = @PLACA";

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

        public bool InserirNovo(Veiculo registro)
        {
            Log.Logger.Contexto().Information("Tentando inserir {veiculo} no banco de dados...", registro);
            registro.Id = Db.Insert(sqlInserirVeiculo, ObtemParametrosVeiculo(registro));
            return true;
        }

        public bool Editar(int id, Veiculo registro)
        {
            Log.Logger.Contexto().Information("Tentando editar o veiculo com id {@idVeiculo} para {veiculo} no banco de dados...", id, registro);
            registro.Id = id;
            Db.Update(sqlEditarVeiculo, ObtemParametrosVeiculo(registro));
            return true;
        }

        public bool Excluir(int id)
        {
            try
            {
                Log.Logger.Contexto().Information("Tentando excluir veiculo com id {@idVeiculo} no banco de dados...", id);
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
            Log.Logger.Contexto().Information("Tentando verificar se existe um veiculo com id {@idVeiculo} no banco de dados...", id);
            return Db.Exists(sqlExisteVeiculo, AdicionarParametro("ID", id));
        }      

        public Veiculo SelecionarPorIdCarregandoLocacoes(int id)
        {
            if (Existe(id))
            {
                Log.Logger.Contexto().Information("Tentando selecionar o veiculo com id {@idVeiculo} no banco de dados...", id);
                Veiculo veiculoSelecionado = Db.Get(sqlSelecionarVeiculoPorId, ConverterEmVeiculo, AdicionarParametro("ID", id));

                LocacaoDAO locacaoDAO = new LocacaoDAO();
                veiculoSelecionado.Locacoes = locacaoDAO.SelecionarLocacoesPorVeiculoId(veiculoSelecionado.Id);

                return veiculoSelecionado;
            }

            return null;
        }

        public Veiculo SelecionarPorId(int id)
        {
            if (Existe(id))
            {
                Log.Logger.Contexto().Information("Tentando selecionar o veiculo com id {@idVeiculo} no banco de dados...", id);
                Veiculo veiculoSelecionado = Db.Get(sqlSelecionarVeiculoPorId, ConverterEmVeiculo, AdicionarParametro("ID", id));              

                return veiculoSelecionado;
            }

            return null;
        }

        public List<Veiculo> SelecionarTodos()
        {
            Log.Logger.Contexto().Information("Tentando selecionar todos os veiculos no banco de dados...");
            return Db.GetAll(sqlSelecionarTodosVeiculos, ConverterEmVeiculo); ;
        }

        public bool ExisteVeiculoComEssaPlaca(string placa)
        {
            Log.Logger.Contexto().Information("Tentando verificar se existe veiculo com a placa {placa} no banco de dados...", placa);
            return Db.Exists(sqlExisteVeiculoComEssaPlaca, AdicionarParametro("PLACA", placa));
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

            //LocacaoAppService locacaoService = new LocacaoAppService(new LocacaoDAO());
            //List < Locacao > = locacaoService.SelecionarTodasLocacoesVeiculo(idVeiculo);


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
