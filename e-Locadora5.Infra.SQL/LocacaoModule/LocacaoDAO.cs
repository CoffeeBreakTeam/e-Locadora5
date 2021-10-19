using e_Locadora5.Aplicacao.ClienteModule;
using e_Locadora5.Aplicacao.CondutorModule;
using e_Locadora5.Aplicacao.CupomModule;
using e_Locadora5.Aplicacao.FuncionarioModule;
using e_Locadora5.Aplicacao.GrupoVeiculoModule;
using e_Locadora5.Aplicacao.TaxasServicosModule;
using e_Locadora5.Aplicacao.VeiculoModule;
using e_Locadora5.Dominio;
using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.CondutoresModule;
using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.FuncionarioModule;
using e_Locadora5.Dominio.LocacaoModule;
using e_Locadora5.Dominio.TaxasServicosModule;
using e_Locadora5.Dominio.VeiculosModule;
using e_Locadora5.Infra.GeradorLogs;
using e_Locadora5.Infra.SQL.ClienteModule;
using e_Locadora5.Infra.SQL.CondutorModule;
using e_Locadora5.Infra.SQL.CupomModule;
using e_Locadora5.Infra.SQL.FuncionarioModule;
using e_Locadora5.Infra.SQL.GrupoVeiculoModule;
using e_Locadora5.Infra.SQL.TaxasServicosModule;
using e_Locadora5.Infra.SQL.VeiculoModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.SQL.LocacaoModule
{
    public class LocacaoDAO: ILocacaoRepository
    {
        FuncionarioAppService funcionarioAppService = new FuncionarioAppService(new FuncionarioDAO());
        ClienteAppService clienteAppService = new ClienteAppService(new ClienteDAO());
        CondutorAppService condutorAppService = new CondutorAppService(new CondutorDAO());
        GrupoVeiculoAppService grupoVeiculoAppService = new GrupoVeiculoAppService(new GrupoVeiculoDAO());
        VeiculoAppService controladorVeiculo = new VeiculoAppService(new VeiculoDAO());
        TaxasServicosAppService taxasServicosAppService = new TaxasServicosAppService(new TaxasServicosDAO());
        CupomAppService cupomAppService = new CupomAppService(new CupomDAO());

        #region Queries Locacao
        private const string sqlInserirLocacao =
         @"INSERT INTO TBLOCACAO
	                (
		                [IDFUNCIONARIO], 
		                [IDCLIENTE], 
		                [IDCONDUTOR],
                        [IDGRUPOVEICULO], 
                        [IDVEICULO],
                        [IDCUPOM],
		                [EMABERTO],
                        [DATALOCACAO],
                        [DATADEVOLUCAO],
                        [QUILOMETRAGEMDEVOLUCAO],
                        [PLANO],
                        [SEGUROCLIENTE],
                        [SEGUROTERCEIRO],
                        [CAUCAO],
                        [VALORTOTAL],
                        [EMAILENVIADO]
	                ) 
	                VALUES
	                (
		                @IDFUNCIONARIO, 
		                @IDCLIENTE, 
		                @IDCONDUTOR,
                        @IDGRUPOVEICULO, 
                        @IDVEICULO,
                        @IDCUPOM,
		                @EMABERTO,
                        @DATALOCACAO,
                        @DATADEVOLUCAO,
                        @QUILOMETRAGEMDEVOLUCAO,
                        @PLANO,
                        @SEGUROCLIENTE,
                        @SEGUROTERCEIRO,
                        @CAUCAO,
                        @VALORTOTAL,
                        @EMAILENVIADO
	                )";

        private const string sqlEditarLocacao =
                    @"UPDATE TBLOCACAO
                    SET
		                [IDFUNCIONARIO] = @IDFUNCIONARIO, 
		                [IDCLIENTE] = @IDCLIENTE, 
		                [IDCONDUTOR] = @IDCONDUTOR,
                        [IDGRUPOVEICULO] = @IDGRUPOVEICULO, 
                        [IDVEICULO] = @IDVEICULO,
                        [IDCUPOM] = @IDCUPOM,
		                [EMABERTO] = @EMABERTO,
                        [DATALOCACAO] = @DATALOCACAO,
                        [DATADEVOLUCAO] = @DATADEVOLUCAO,
                        [QUILOMETRAGEMDEVOLUCAO] = @QUILOMETRAGEMDEVOLUCAO,
                        [PLANO] = @PLANO,
                        [SEGUROCLIENTE] = @SEGUROCLIENTE,
                        [SEGUROTERCEIRO] = @SEGUROTERCEIRO,
                        [CAUCAO] = @CAUCAO,
                        [VALORTOTAL] = @VALORTOTAL,
                        [EMAILENVIADO] = @EMAILENVIADO
                    WHERE 
                        ID = @ID";

        private const string sqlExcluirLocacao =
         @"DELETE 
	              FROM
                        TBLOCACAO
                    WHERE 
                        ID = @ID";

        private const string sqlExisteLocacao =
        @"SELECT 
                COUNT(*) 
            FROM 
                [TBLOCACAO]
            WHERE 
                [ID] = @ID";

        private const string sqlExisteLocacaoVeiculoRepetidoInserir =
        @"SELECT 
                COUNT(*) 
            FROM 
                [TBLOCACAO]
            WHERE 
                [EMABERTO] = @EMABERTO
            AND [IDVEICULO] = @IDVEICULO";

        private const string sqlExisteLocacaoVeiculoRepetidoEditar =
        @"SELECT 
                COUNT(*) 
            FROM 
                [TBLOCACAO]
            WHERE 
                [EMABERTO] = @EMABERTO
            AND [IDVEICULO] = @IDVEICULO
            AND [ID] != @ID";

        private const string sqlSelecionarLocacaoPorId =
            @"SELECT 
                [ID],
		        [IDFUNCIONARIO], 
		        [IDCLIENTE], 
		        [IDCONDUTOR],
                [IDGRUPOVEICULO], 
                [IDVEICULO],
                [IDCUPOM],
		        [EMABERTO],
                [DATALOCACAO],
                [DATADEVOLUCAO],
                [QUILOMETRAGEMDEVOLUCAO],
                [PLANO],
                [SEGUROCLIENTE],
                [SEGUROTERCEIRO],
                [CAUCAO],
                [VALORTOTAL],
                [EMAILENVIADO]
            FROM
                [TBLOCACAO]
            WHERE
                [ID] = @ID";

        private const string sqlSelecionarTodasLocacoes =
            @"SELECT 
                [ID],
		        [IDFUNCIONARIO], 
		        [IDCLIENTE], 
		        [IDCONDUTOR],
                [IDGRUPOVEICULO], 
                [IDVEICULO],
                [IDCUPOM],
		        [EMABERTO],
                [DATALOCACAO],
                [DATADEVOLUCAO],
                [QUILOMETRAGEMDEVOLUCAO],
                [PLANO],
                [SEGUROCLIENTE],
                [SEGUROTERCEIRO],
                [CAUCAO],
                [VALORTOTAL],
                [EMAILENVIADO]
            FROM
                [TBLOCACAO]";
        private const string sqlSelecionarLocacoesPendentes =
            @"SELECT 
                [ID],
		        [IDFUNCIONARIO], 
		        [IDCLIENTE], 
		        [IDCONDUTOR],
                [IDGRUPOVEICULO], 
                [IDVEICULO],
                [IDCUPOM],
		        [EMABERTO],
                [DATALOCACAO],
                [DATADEVOLUCAO],
                [QUILOMETRAGEMDEVOLUCAO],
                [PLANO],
                [SEGUROCLIENTE],
                [SEGUROTERCEIRO],
                [CAUCAO],
                [VALORTOTAL],
                [EMAILENVIADO]
            FROM
                [TBLOCACAO]
           WHERE 
                [EMABERTO] = @EMABERTO
            AND
                [DATADEVOLUCAO] < @DATADEVOLUCAO";
        private const string sqlSelecionarLocacoesEmailPendente =
            @"SELECT 
                [ID],
		        [IDFUNCIONARIO], 
		        [IDCLIENTE], 
		        [IDCONDUTOR],
                [IDGRUPOVEICULO], 
                [IDVEICULO],
                [IDCUPOM],
		        [EMABERTO],
                [DATALOCACAO],
                [DATADEVOLUCAO],
                [QUILOMETRAGEMDEVOLUCAO],
                [PLANO],
                [SEGUROCLIENTE],
                [SEGUROTERCEIRO],
                [CAUCAO],
                [VALORTOTAL],
                [EMAILENVIADO]
            FROM
                [TBLOCACAO]
           WHERE
                [EMAILENVIADO] = @EMAILENVIADO";

        private const string sqlSelecionarLocacoesPorVeiculoId =
        @"SELECT
                [ID],
		        [IDFUNCIONARIO], 
		        [IDCLIENTE], 
		        [IDCONDUTOR],
                [IDGRUPOVEICULO], 
                [IDVEICULO],
                [IDCUPOM],
		        [EMABERTO],
                [DATALOCACAO],
                [DATADEVOLUCAO],
                [QUILOMETRAGEMDEVOLUCAO],
                [PLANO],
                [SEGUROCLIENTE],
                [SEGUROTERCEIRO],
                [CAUCAO],
                [VALORTOTAL],
                [EMAILENVIADO]
	        FROM
                [TBLOCACAO]
           WHERE
                [IDVEICULO] = @IDVEICULO";


        #endregion


        #region Queries LocacaoTaxaServico
        private const string sqlInserirLocacaoTaxasServicos =
         @"INSERT INTO TBLOCACAO_TBTAXASSERVICOS
	                (
		                [IDLOCACAO], 
		                [IDTAXASSERVICOS]
	                ) 
	                VALUES
	                (
		                @IDLOCACAO, 
		                @IDTAXASSERVICOS
	                )";

        private const string sqlEditarLocacaoTaxasServicos =
                    @"UPDATE TBLOCACAO_TBTAXASSERVICOS
                    SET
		                [IDLOCACAO] = @IDLOCACAO, 
		                [IDTAXASSERVICOS] = @IDTAXASSERVICOS
                    WHERE 
                        ID = @ID";

        private const string sqlExcluirLocacaoTaxasServicos =
         @"DELETE 
	              FROM
                        TBLOCACAO_TBTAXASSERVICOS
                    WHERE 
                        IDLOCACAO = @IDLOCACAO AND IDTAXASSERVICOS = @IDTAXASSERVICOS";

        private const string sqlExisteLocacaoTaxasServicos =
        @"SELECT 
                COUNT(*) 
            FROM 
                [TBLOCACAO_TBTAXASSERVICOS]
            WHERE 
                [ID] = @ID";

        private const string sqlSelecionarLocacaoTaxasServicosPorId =
            @"SELECT 
                [ID],
		        [IDLOCACAO], 
		        [IDTAXASSERVICOS]
            FROM
                [TBLOCACAO_TBTAXASSERVICOS]
            WHERE
                [ID] = @ID";

        private const string sqlSelecionarTodasLocacoesTaxasServicos =
            @"SELECT 
                [ID],
		        [IDLOCACAO], 
		        [IDTAXASSERVICOS]
            FROM
                [TBLOCACAO_TBTAXASSERVICOS]";

        
        #endregion


        public bool InserirNovo(Locacao registro)
        {
            try
            {
                Serilog.Log.Logger.Contexto().Information("Tentando inserir locação {registro} no banco de dados...", registro);
                registro.Id = Db.Insert(sqlInserirLocacao, ObtemParametrosLocacao(registro));

                if (!registro.TaxasServicos.IsNullOrEmpty())
                {
                    Serilog.Log.Logger.Contexto().Information("Tentando inserir as relações das taxas e serviços dessa locação no banco de dados...", registro);
                    foreach (TaxasServicos taxaServico in registro.TaxasServicos)
                    {
                        LocacaoTaxasServicos locacao_TaxaServico = new LocacaoTaxasServicos(registro, taxaServico);
                        Db.Insert(sqlInserirLocacaoTaxasServicos, ObtemParametrosLocacaoTaxasServicos(locacao_TaxaServico));
                    }
                }
                
                Serilog.Log.Logger.Contexto().Information("Tentando registrar a locação no histórico de locações do veículo...", registro);
                registro.Veiculo.RegistrarLocacao(registro);
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public bool Editar(int id, Locacao registro)
        {
            try
            {
                Serilog.Log.Logger.Contexto().Information("Tentando editar a locação de id {id} para {registro} no banco de dados...", id, registro);
                registro.Id = id;
                Db.Update(sqlEditarLocacao, ObtemParametrosLocacao(registro));
                Serilog.Log.Logger.Contexto().Information("Edição da locação {registro} foi executada com sucesso no banco de dados...", id, registro);


                if (!registro.TaxasServicos.IsNullOrEmpty())
                {
                    //deletando todas taxas relacionadas
                    Serilog.Log.Logger.Contexto().Information("(Processo de edição) Tentando excluir a relação das taxas e serviços dessa locação no banco de dados...", registro);
                    foreach (TaxasServicos taxaServico in registro.TaxasServicos)
                    {
                        LocacaoTaxasServicos locacao_TaxaServico = new LocacaoTaxasServicos(registro, taxaServico);
                        Db.Delete(sqlExcluirLocacaoTaxasServicos, ObtemParametrosLocacaoTaxasServicos(locacao_TaxaServico));
                        Serilog.Log.Logger.Contexto().Information("Excluido a relação da taxaServico {taxaServico} e a locação {registro} no banco de dados...", id, registro);
                    }

                    //inserindo novas taxas relacionadas
                    Serilog.Log.Logger.Contexto().Information("(Processo de edição) Tentando inserir a relação das taxas e serviços dessa locação no banco de dados...", registro);
                    foreach (TaxasServicos taxaServico in registro.TaxasServicos)
                    {
                        LocacaoTaxasServicos locacao_TaxaServico = new LocacaoTaxasServicos(registro, taxaServico);
                        Db.Insert(sqlInserirLocacaoTaxasServicos, ObtemParametrosLocacaoTaxasServicos(locacao_TaxaServico));
                        Serilog.Log.Logger.Contexto().Information("Inserido a relação da taxaServico {taxaServico} e a locação {registro} no banco de dados...", id, registro);
                    }
                }
                return true;
            }
            catch (Exception ex) 
            {
                ex.Data.Add("sqlEditarLocacao", sqlEditarLocacao);
                ex.Data.Add("sqlExcluirLocacaoTaxasServicos", sqlExcluirLocacaoTaxasServicos);
                ex.Data.Add("sqlInserirLocacaoTaxasServicos", sqlInserirLocacaoTaxasServicos);
                ex.Data.Add("locacao", registro);
                ex.Data.Add("veiculo", registro.Veiculo);
                throw ex;
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                Serilog.Log.Logger.Contexto().Information("Tentando selecionar a locação por id {id} no banco de dados...", id);
                Locacao locacaoSelecionada = SelecionarPorId(id);
                if (!locacaoSelecionada.IsNullOrEmpty())
                {
                    if (!locacaoSelecionada.TaxasServicos.IsNullOrEmpty())
                    {
                        Serilog.Log.Logger.Contexto().Information("Tentando excluir as relações das taxas e serviços dessa locação {locacaoSelecionada} no banco de dados...", locacaoSelecionada);
                        List<TaxasServicos> taxasServicosDaLocacao = SelecionarTaxasServicosPorLocacaoId(id);
                        foreach (TaxasServicos taxaServico in taxasServicosDaLocacao)
                        {
                            LocacaoTaxasServicos locacao_TaxaServico = new LocacaoTaxasServicos(locacaoSelecionada, taxaServico);

                            Db.Delete(sqlExcluirLocacaoTaxasServicos, ObtemParametrosLocacaoTaxasServicos(locacao_TaxaServico));
                        }
                    }
                    Serilog.Log.Logger.Contexto().Information("Tentando excluir a locação {registro} no banco de dados...", locacaoSelecionada);
                    Db.Delete(sqlExcluirLocacao, AdicionarParametro("ID", id));
                }
                else
                    Serilog.Log.Logger.Contexto().Warning("Não foi encontrado uma locação válida através do id {id} no banco de dados...", id);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Existe(int id)
        {
            try
            {
                Serilog.Log.Logger.Contexto().Information("Tentando verificar se existe uma locação com id {id} no banco de dados...", id);
                return Db.Exists(sqlExisteLocacao, AdicionarParametro("ID", id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExisteLocacaoComVeiculoRepetido(int id, int idVeiculo)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("ID", id);
            parametros.Add("IDVEICULO", idVeiculo);
            parametros.Add("EMABERTO", true);

            Serilog.Log.Logger.Contexto().Information("Tentando verificar se existe veiculo repetido uma locação com id {id} no banco de dados...", id);
            if (id == 0) //situação de inserir
                return Db.Exists(sqlExisteLocacaoVeiculoRepetidoInserir, parametros);
            else //situação de editar
                return Db.Exists(sqlExisteLocacaoVeiculoRepetidoEditar, parametros);
        }

        public Locacao SelecionarPorId(int id)
        {
            try
            { 
                Serilog.Log.Logger.Contexto().Information("Tentando selecionar o cliente com id {idCliente} no banco de dados...", id);
                return Db.Get(sqlSelecionarLocacaoPorId, ConverterEmLocacao, AdicionarParametro("ID", id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Locacao> SelecionarTodos()
        {
            try
            {
                Serilog.Log.Logger.Contexto().Information("Tentando selecionar todas locações no banco de dados...");
                List<Locacao> todasLocacoes = new List<Locacao>();
                todasLocacoes = Db.GetAll(sqlSelecionarTodasLocacoes, ConverterEmLocacao);

                Serilog.Log.Logger.Contexto().Information("Tentando atribuir individualmente as taxas e serviços de cada locação...");
                foreach (Locacao locacaoIndividual in todasLocacoes)
                {
                    List<TaxasServicos> taxasServicosIndividuais = SelecionarTaxasServicosPorLocacaoId(locacaoIndividual.Id);
                    locacaoIndividual.TaxasServicos = taxasServicosIndividuais;
                }

                return todasLocacoes;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }

        public List<Locacao> SelecionarLocacoesPendentes(int idVeiculo)
        {
            try
            {
                var parametros = new Dictionary<string, object>();
                parametros.Add("IDVEICULO", idVeiculo);
                List<Locacao> locacoesDoVeiculo = new List<Locacao>();

                Serilog.Log.Logger.Contexto().Information("Tentando selecionar todas locações pendentes no banco de dados...");
                locacoesDoVeiculo = Db.GetAll(sqlSelecionarLocacoesPorVeiculoId, ConverterEmLocacao, parametros);

                Serilog.Log.Logger.Contexto().Information("Tentando atribuir individualmente as taxas e serviços de cada locação pendente...");
                foreach (Locacao locacaoIndividual in locacoesDoVeiculo)
                {
                    List<TaxasServicos> taxasServicosIndividuais = SelecionarTaxasServicosPorLocacaoId(locacaoIndividual.Id);
                    locacaoIndividual.TaxasServicos = taxasServicosIndividuais;
                }

                return locacoesDoVeiculo;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Locacao> SelecionarLocacoesPendentes(bool emAberto, DateTime dataDevolucao)
        {
            try
            {
                var parametros = new Dictionary<string, object>();
                parametros.Add("EMABERTO", emAberto);
                parametros.Add("DATADEVOLUCAO", dataDevolucao);
                List<Locacao> locacoesPendentes = new List<Locacao>();

                Serilog.Log.Logger.Contexto().Information("Tentando selecionar todas locações pendentes no banco de dados...");
                locacoesPendentes = Db.GetAll(sqlSelecionarLocacoesPendentes, ConverterEmLocacao, parametros);

                Serilog.Log.Logger.Contexto().Information("Tentando atribuir individualmente as taxas e serviços de cada locação pendente...");
                foreach (Locacao locacaoIndividual in locacoesPendentes)
                {
                    List<TaxasServicos> taxasServicosIndividuais = SelecionarTaxasServicosPorLocacaoId(locacaoIndividual.Id);
                    locacaoIndividual.TaxasServicos = taxasServicosIndividuais;
                }

                return locacoesPendentes;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Locacao> SelecionarLocacoesEmailPendente()
        {
            try
            {
                var parametros = new Dictionary<string, object>();
                parametros.Add("EMAILENVIADO", false);
                List<Locacao> locacoesEmailPendente = new List<Locacao>();

                Serilog.Log.Logger.Contexto().Information("Tentando selecionar todas locações com email pendente no banco de dados...");
                locacoesEmailPendente = Db.GetAll(sqlSelecionarLocacoesEmailPendente, ConverterEmLocacao, parametros);

                Serilog.Log.Logger.Contexto().Information("Tentando atribuir individualmente as taxas e serviços de cada locação com email pendente...");
                foreach (Locacao locacaoIndividual in locacoesEmailPendente)
                {
                    List<TaxasServicos> taxasServicosIndividuais = SelecionarTaxasServicosPorLocacaoId(locacaoIndividual.Id);
                    locacaoIndividual.TaxasServicos = taxasServicosIndividuais;
                }

                return locacoesEmailPendente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Locacao> SelecionarLocacoesPorVeiculoId(int id)
        {
            try
            {
                var parametros = new Dictionary<string, object>();
                parametros.Add("IDVEICULO", id);
                List<Locacao> locacoesDoVeiculo = new List<Locacao>();

                Serilog.Log.Logger.Contexto().Information("Tentando selecionar todas locações do veiculo com id {@id} no banco de dados...", id);
                locacoesDoVeiculo = Db.GetAll(sqlSelecionarLocacoesPorVeiculoId, ConverterEmLocacao, parametros);

                return locacoesDoVeiculo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Dictionary<string, object> ObtemParametrosLocacao(Locacao locacao)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", locacao.Id);
            parametros.Add("IDFUNCIONARIO", locacao.Funcionario.Id);
            parametros.Add("IDCLIENTE", locacao.Cliente.Id);
            parametros.Add("IDCONDUTOR", locacao.Condutor.Id);
            parametros.Add("IDGRUPOVEICULO", locacao.GrupoVeiculo.Id);
            parametros.Add("IDVEICULO", locacao.Veiculo.Id);
            parametros.Add("EMABERTO", locacao.emAberto);
            parametros.Add("DATALOCACAO", locacao.dataLocacao);
            parametros.Add("DATADEVOLUCAO", locacao.dataDevolucao);
            parametros.Add("QUILOMETRAGEMDEVOLUCAO", locacao.quilometragemDevolucao);
            parametros.Add("PLANO", locacao.plano);
            parametros.Add("SEGUROCLIENTE", locacao.seguroCliente);
            parametros.Add("SEGUROTERCEIRO", locacao.seguroTerceiro);
            parametros.Add("CAUCAO", locacao.caucao);
            parametros.Add("VALORTOTAL", locacao.valorTotal);
            parametros.Add("EMAILENVIADO", locacao.emailEnviado);

            if (locacao.Cupom != null)
                parametros.Add("IDCUPOM", locacao.Cupom.Id);
            else
                parametros.Add("IDCUPOM", DBNull.Value);

            return parametros;
        }

        private Locacao ConverterEmLocacao(IDataReader reader)
        {
            var idFuncionario = Convert.ToInt32(reader["IDFUNCIONARIO"]);
            Funcionario funcionario = funcionarioAppService.SelecionarPorId(idFuncionario);

            var idCliente = Convert.ToInt32(reader["IDCLIENTE"]);
            Cliente cliente = clienteAppService.SelecionarPorId(idCliente);

            var idCondutor = Convert.ToInt32(reader["IDCONDUTOR"]);
            Condutor condutor = condutorAppService.SelecionarPorId(idCondutor);

            var idGrupoVeiculo = Convert.ToInt32(reader["IDGRUPOVEICULO"]);
            GrupoVeiculo grupoVeiculo = grupoVeiculoAppService.SelecionarPorId(idGrupoVeiculo);

            var idVeiculo = Convert.ToInt32(reader["IDVEICULO"]);
            Veiculo veiculo = controladorVeiculo.SelecionarPorId(idVeiculo);                 

            var emAberto = Convert.ToBoolean(reader["EMABERTO"]);
            var dataLocacao = Convert.ToDateTime(reader["DATALOCACAO"]);
            var dataDevolucao = Convert.ToDateTime(reader["DATADEVOLUCAO"]);
            var quilometragemDevolucao = Convert.ToDouble(reader["QUILOMETRAGEMDEVOLUCAO"]);
            var plano = Convert.ToString(reader["PLANO"]);
            var seguroCliente = Convert.ToDouble(reader["SEGUROCLIENTE"]);
            var seguroTerceiro = Convert.ToDouble(reader["SEGUROTERCEIRO"]);
            var caucao = Convert.ToDouble(reader["CAUCAO"]);
            var emailEnviado = Convert.ToBoolean(reader["EMAILENVIADO"]);

            Cupom cupom = null;

            if (reader["IDCUPOM"] != DBNull.Value)
            {
                var idCupom = Convert.ToInt32(reader["IDCUPOM"]);
                cupom = cupomAppService.SelecionarPorId(idCupom);
            }

            Locacao locacao = new Locacao(funcionario, dataLocacao, dataDevolucao, quilometragemDevolucao, plano, seguroCliente, seguroTerceiro, caucao, grupoVeiculo, veiculo, cliente, condutor, emAberto,cupom);

            

            locacao.emailEnviado = emailEnviado;
            locacao.valorTotal = Convert.ToDouble(reader["VALORTOTAL"]);
            locacao.Id = Convert.ToInt32(reader["ID"]);

            return locacao;
        }

        protected Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }

        //LocacaoTaxaServico

        private Dictionary<string, object> ObtemParametrosLocacaoTaxasServicos(LocacaoTaxasServicos locacaoTaxasServicos)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", locacaoTaxasServicos.Id);
            parametros.Add("IDLOCACAO", locacaoTaxasServicos.locacao.Id);
            parametros.Add("IDTAXASSERVICOS", locacaoTaxasServicos.taxasServicos.Id);

            return parametros;
        }

        private LocacaoTaxasServicos ConverterEmLocacaoTaxasServicos(IDataReader reader)
        {
            var idLocacao = Convert.ToInt32(reader["IDLOCACAO"]);
            Locacao locacao = SelecionarPorId(idLocacao);
            //adicionar TaxasServicosSeparadamente

            var idTaxasServicos = Convert.ToInt32(reader["IDTAXASSERVICOS"]);
            TaxasServicos taxasServicos = taxasServicosAppService.SelecionarPorId(idTaxasServicos);

            LocacaoTaxasServicos locacaoTaxasServicos = new LocacaoTaxasServicos(locacao, taxasServicos);

            locacaoTaxasServicos.Id = Convert.ToInt32(reader["ID"]);

            return locacaoTaxasServicos;
        }

        public List<LocacaoTaxasServicos> SelecionarTodosLocacaoTaxasServicos()
        {
            try
            {
                Serilog.Log.Logger.Contexto().Information("Tentando selecionar todas relaçoes das locações e suas taxas e serviços no banco de dados...");
                return Db.GetAll(sqlSelecionarTodasLocacoesTaxasServicos, ConverterEmLocacaoTaxasServicos);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<TaxasServicos> SelecionarTaxasServicosPorLocacaoId(int idLocacao)
        {
            try
            {
                if (Existe(idLocacao))
                {
                    List<TaxasServicos> taxasServicos = new List<TaxasServicos>();

                    Serilog.Log.Logger.Contexto().Information("Tentando selecionar todas relaçoes das locações e suas taxas e serviços no banco de dados...");
                    List<LocacaoTaxasServicos> todasLocacaoTaxaServico = SelecionarTodosLocacaoTaxasServicos();

                    Serilog.Log.Logger.Contexto().Information("Tentando atribuir individualmente as relações das taxas e serviços de cada locação...");
                    foreach (LocacaoTaxasServicos Locacao_TaxaServico in todasLocacaoTaxaServico)
                    {
                        if (idLocacao == Locacao_TaxaServico.locacao.Id)
                            taxasServicos.Add(Locacao_TaxaServico.taxasServicos);
                    }
                    return taxasServicos;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Locacao> SelecionarLocacoesCompleta(int id)
        {
            throw new NotImplementedException();
        }

        Locacao ILocacaoRepository.SelecionarLocacoesCompleta(int id)
        {
            throw new NotImplementedException();
        }
    }
}
