using e_Locadora5.Controladores.Shared;
using e_Locadora5.Dominio;
using e_Locadora5.Dominio.VeiculosModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Controladores.VeiculoModule
{
    public class ControladorVeiculos : Controlador<Veiculo>
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
        public override string InserirNovo(Veiculo registro)
        {
            string resultadoValidacaoDominio = registro.Validar();
            string resultadoValidacaoControlador = ValidarVeiculo(registro);
            if (resultadoValidacaoDominio == "ESTA_VALIDO" && resultadoValidacaoControlador == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirVeiculo, ObtemParametrosVeiculo(registro));
            }
            
            return resultadoValidacaoDominio + resultadoValidacaoControlador;
        }

        public override string Editar(int id, Veiculo registro)
        {
            string resultadoValidacao = registro.Validar();
            string resultadoValidacaoControlador = ValidarVeiculo(registro, id);
            if (resultadoValidacao == "ESTA_VALIDO" && resultadoValidacaoControlador == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarVeiculo, ObtemParametrosVeiculo(registro));
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
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

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteVeiculo, AdicionarParametro("ID", id));
        }

        public override Veiculo SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarVeiculoPorId, ConverterEmVeiculo, AdicionarParametro("ID", id));
        }

        public override List<Veiculo> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosVeiculos, ConverterEmVeiculo);
        }

        public string ValidarVeiculo(Veiculo novoVeiculo, int id = 0)
        {
            //validar placas iguais
            if (novoVeiculo != null)
            {
                if (id != 0)
                {//situação de editar
                    int countPlacasIguais = 0;
                    List<Veiculo> todosVeiculos = SelecionarTodos();
                    foreach (Veiculo veiculo in todosVeiculos)
                    {
                        if (novoVeiculo.Placa.Equals(veiculo.Placa) && veiculo.Id != id)
                            countPlacasIguais++;
                    }
                    if (countPlacasIguais > 0)
                        return "Placa já cadastrada, tente novamente.";
                }
                else 
                {//situação de inserir
                    int countPlacasIguais = 0;
                    List<Veiculo> todosVeiculos = SelecionarTodos();
                    foreach (Veiculo veiculo in todosVeiculos)
                    {
                        if (novoVeiculo.Placa.Equals(veiculo.Placa))
                            countPlacasIguais++;
                    }
                    if (countPlacasIguais > 0)
                        return "Placa já cadastrada, tente novamente.";
                }
            }
                return "ESTA_VALIDO";
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
            string combustivel  = Convert.ToString(reader["TIPOCOMBUSTIVEL"]);
            int idGrupoVeiculo = Convert.ToInt32(reader["IDGRUPOVEICULO"]);
            //if (reader["IMAGEM"] != null)
                byte[] imagem = (byte[])reader["IMAGEM"];
            
            ControladorGrupoVeiculo controladorGrupoVeiculo = new ControladorGrupoVeiculo();
            GrupoVeiculo grupoVeiculo = controladorGrupoVeiculo.SelecionarPorId(idGrupoVeiculo);

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

        

        #endregion
    }
}
