using e_Locadora5.Controladores.ClientesModule;
using e_Locadora5.Controladores.CondutorModule;
using e_Locadora5.Controladores.CupomModule;
using e_Locadora5.Controladores.FuncionarioModule;
using e_Locadora5.Controladores.Shared;
using e_Locadora5.Controladores.TaxasServicoModule;
using e_Locadora5.Controladores.VeiculoModule;
using e_Locadora5.Dominio;
using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.CondutoresModule;
using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.FuncionarioModule;
using e_Locadora5.Dominio.LocacaoModule;
using e_Locadora5.Dominio.TaxasServicosModule;
using e_Locadora5.Dominio.VeiculosModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Controladores.LocacaoModule
{
    public class ControladorLocacao : Controlador<Locacao>
    {
        ControladorFuncionario controladorFuncionario = new ControladorFuncionario();
        ControladorClientes controladorCliente = new ControladorClientes();
        ControladorCondutor controladorCondutor = new ControladorCondutor();
        ControladorGrupoVeiculo controladorGrupoVeiculo = new ControladorGrupoVeiculo();
        ControladorVeiculos controladorVeiculo = new ControladorVeiculos();
        TaxasServicosAppService controladorTaxasServicos = new TaxasServicosAppService();
        ControladorCupons controladorCupom = new ControladorCupons();

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


        public override string InserirNovo(Locacao registro)
        {
            string resultadoValidacaoDominio = registro.Validar();
            string resultadoValidacaoControlador = ValidarLocacao(registro);


            if (resultadoValidacaoDominio == "ESTA_VALIDO" && resultadoValidacaoControlador == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirLocacao, ObtemParametrosLocacao(registro));
                if (!registro.taxasServicos.IsNullOrEmpty())
                    foreach (TaxasServicos taxaServico in registro.taxasServicos)
                    {
                        LocacaoTaxasServicos locacao_TaxaServico = new LocacaoTaxasServicos(registro, taxaServico);
                        Db.Insert(sqlInserirLocacaoTaxasServicos, ObtemParametrosLocacaoTaxasServicos(locacao_TaxaServico));
                    }
            }

            if (resultadoValidacaoDominio != "ESTA_VALIDO")
                return resultadoValidacaoDominio;
            else
                return resultadoValidacaoControlador;
        }

        public override string Editar(int id, Locacao registro)
        {
            string resultadoValidacaoDominio = registro.Validar();
            string resultadoValidacaoControlador = ValidarLocacao(registro, id);
     
            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarLocacao, ObtemParametrosLocacao(registro));


                //deletando todas taxas relacionadas
                if (!registro.taxasServicos.IsNullOrEmpty()) {
                    foreach (TaxasServicos taxaServico in registro.taxasServicos)
                    {
                        LocacaoTaxasServicos locacao_TaxaServico = new LocacaoTaxasServicos(registro, taxaServico);
                        Db.Delete(sqlExcluirLocacaoTaxasServicos, ObtemParametrosLocacaoTaxasServicos(locacao_TaxaServico));
                    }

                    //inserindo novas taxas relacionadas
                    foreach (TaxasServicos taxaServico in registro.taxasServicos)
                    {
                        LocacaoTaxasServicos locacao_TaxaServico = new LocacaoTaxasServicos(registro, taxaServico);
                        Db.Insert(sqlInserirLocacaoTaxasServicos, ObtemParametrosLocacaoTaxasServicos(locacao_TaxaServico));
                    }
                }

            }

            if (resultadoValidacaoDominio != "ESTA_VALIDO")
                return resultadoValidacaoDominio;
            else
                return resultadoValidacaoControlador;

        }

        public override bool Excluir(int id)
        {
            try
            {
                Locacao locacaoExcluida = SelecionarPorId(id);
                if (!locacaoExcluida.IsNullOrEmpty())
                {
                    if (!locacaoExcluida.taxasServicos.IsNullOrEmpty())
                    {
                        List<TaxasServicos> taxasServicosDaLocacao = SelecionarTaxasServicosPorLocacaoId(id);
                        foreach (TaxasServicos taxaServico in taxasServicosDaLocacao)
                        {
                            LocacaoTaxasServicos locacao_TaxaServico = new LocacaoTaxasServicos(locacaoExcluida, taxaServico);

                            Db.Delete(sqlExcluirLocacaoTaxasServicos, ObtemParametrosLocacaoTaxasServicos(locacao_TaxaServico));
                        }
                    }
                    Db.Delete(sqlExcluirLocacao, AdicionarParametro("ID", id));
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteLocacao, AdicionarParametro("ID", id));
        }

        public override Locacao SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarLocacaoPorId, ConverterEmLocacao, AdicionarParametro("ID", id));
        }

        public override List<Locacao> SelecionarTodos()
        {
            List<Locacao> todasLocacoes = new List<Locacao>();
            todasLocacoes = Db.GetAll(sqlSelecionarTodasLocacoes, ConverterEmLocacao);

            foreach (Locacao locacaoIndividual in todasLocacoes)
            {
                List<TaxasServicos> taxasServicosIndividuais = SelecionarTaxasServicosPorLocacaoId(locacaoIndividual.Id);
                locacaoIndividual.taxasServicos = taxasServicosIndividuais;
            }

            return todasLocacoes;
        }
        public List<Locacao> SelecionarLocacoesPendentes(bool emAberto, DateTime dataDevolucao)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("EMABERTO", emAberto);
            parametros.Add("DATADEVOLUCAO", dataDevolucao);

            List<Locacao> locacoesPendentes = new List<Locacao>();
            locacoesPendentes = Db.GetAll(sqlSelecionarLocacoesPendentes, ConverterEmLocacao,parametros);
            foreach (Locacao locacaoIndividual in locacoesPendentes)
            {
                List<TaxasServicos> taxasServicosIndividuais = SelecionarTaxasServicosPorLocacaoId(locacaoIndividual.Id);
                locacaoIndividual.taxasServicos = taxasServicosIndividuais;
            }
                   
            return locacoesPendentes;
        }

        public List<Locacao> SelecionarLocacoesEmailPendente()
        {

            var parametros = new Dictionary<string, object>();

            parametros.Add("EMAILENVIADO", false);

            List<Locacao> locacoesEmailPendente = new List<Locacao>();
            locacoesEmailPendente = Db.GetAll(sqlSelecionarLocacoesEmailPendente, ConverterEmLocacao, parametros);
            foreach (Locacao locacaoIndividual in locacoesEmailPendente)
            {
                List<TaxasServicos> taxasServicosIndividuais = SelecionarTaxasServicosPorLocacaoId(locacaoIndividual.Id);
                locacaoIndividual.taxasServicos = taxasServicosIndividuais;
            }

            return locacoesEmailPendente;
        }


        public string ValidarLocacao(Locacao novoLocacao, int id = 0)
        {
            //validar carros alugados
            if (novoLocacao != null)
            {
                if (id != 0)
                {//situação de editar
                    int countVeiculoIndisponivel = 0;
                    List<Locacao> todasLocacoes = SelecionarTodos();
                    foreach (Locacao locacao in todasLocacoes)
                    {
                        if (novoLocacao.veiculo.Id == locacao.veiculo.Id && locacao.emAberto == true && locacao.Id != id)
                            countVeiculoIndisponivel++;
                    }
                    if (countVeiculoIndisponivel > 0)
                        return "Veiculo já alugado, tente novamente.";
                }
                else
                {//situação de inserir
                    int countVeiculoIndisponivel = 0;
                    List<Locacao> todosLocacaos = SelecionarTodos();
                    foreach (Locacao locacao in todosLocacaos)
                    {
                        if (novoLocacao.veiculo.Id == locacao.veiculo.Id && locacao.emAberto == true)
                            countVeiculoIndisponivel++;
                    }
                    if (countVeiculoIndisponivel > 0)
                        return "Veiculo já alugado, tente novamente.";
                }
            }
            return "ESTA_VALIDO";
        }

        public string ValidarCNH(Locacao novoLocacao, int id = 0)
        {
            //validar carros alugados
            if (novoLocacao != null)
            {
                if (id != 0)
                {//situação de editar
                    int countCNHVencida = 0;
                    List<Locacao> todasLocacoes = SelecionarTodos();
                    foreach (Locacao locacao in todasLocacoes)
                    {
                        if (novoLocacao.condutor.ValidadeCNH < DateTime.Now && novoLocacao.emAberto == true && locacao.condutor.Id != id)
                            countCNHVencida++;
                    }
                    if (countCNHVencida > 0)
                        return "O Condutor Selecionado está com a CNH vencida!";
                }
                else
                {//situação de inserir
                    int countCNHVencida = 0;
                    List<Locacao> todosLocacaos = SelecionarTodos();
                    foreach (Locacao locacao in todosLocacaos)
                    {
                        if (novoLocacao.condutor.ValidadeCNH < DateTime.Now && novoLocacao.emAberto == true)
                            countCNHVencida++;
                    }
                    if (countCNHVencida > 0)
                        return "O Condutor Selecionado está com a CNH vencida!";
                }
            }
            return "ESTA_VALIDO";
        }

        private Dictionary<string, object> ObtemParametrosLocacao(Locacao locacao)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", locacao.Id);
            parametros.Add("IDFUNCIONARIO", locacao.funcionario.Id);
            parametros.Add("IDCLIENTE", locacao.cliente.Id);
            parametros.Add("IDCONDUTOR", locacao.condutor.Id);
            parametros.Add("IDGRUPOVEICULO", locacao.grupoVeiculo.Id);
            parametros.Add("IDVEICULO", locacao.veiculo.Id);
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

            if (locacao.cupom != null)
                parametros.Add("IDCUPOM", locacao.cupom.Id);
            else
                parametros.Add("IDCUPOM", DBNull.Value);

            return parametros;
        }

        private Locacao ConverterEmLocacao(IDataReader reader)
        {
            var idFuncionario = Convert.ToInt32(reader["IDFUNCIONARIO"]);
            Funcionario funcionario = controladorFuncionario.SelecionarPorId(idFuncionario);

            var idCliente = Convert.ToInt32(reader["IDCLIENTE"]);
            Clientes cliente = controladorCliente.SelecionarPorId(idCliente);

            var idCondutor = Convert.ToInt32(reader["IDCONDUTOR"]);
            Condutor condutor = controladorCondutor.SelecionarPorId(idCondutor);

            var idGrupoVeiculo = Convert.ToInt32(reader["IDGRUPOVEICULO"]);
            GrupoVeiculo grupoVeiculo = controladorGrupoVeiculo.SelecionarPorId(idGrupoVeiculo);

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

            Locacao locacao = new Locacao(funcionario, dataLocacao, dataDevolucao, quilometragemDevolucao, plano, seguroCliente, seguroTerceiro, caucao, grupoVeiculo, veiculo, cliente, condutor, emAberto);

            if (reader["IDCUPOM"] != DBNull.Value)
            {
                var idCupom = Convert.ToInt32(reader["IDCUPOM"]);
                locacao.cupom = controladorCupom.SelecionarPorId(idCupom);
            }

            locacao.emailEnviado = emailEnviado;
            locacao.valorTotal = Convert.ToDouble(reader["VALORTOTAL"]);
            locacao.Id = Convert.ToInt32(reader["ID"]);

            return locacao;
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
            TaxasServicos taxasServicos = controladorTaxasServicos.SelecionarPorId(idTaxasServicos);

            LocacaoTaxasServicos locacaoTaxasServicos = new LocacaoTaxasServicos(locacao, taxasServicos);

            locacaoTaxasServicos.Id = Convert.ToInt32(reader["ID"]);

            return locacaoTaxasServicos;
        }

        public List<LocacaoTaxasServicos> SelecionarTodosLocacaoTaxasServicos()
        {
            return Db.GetAll(sqlSelecionarTodasLocacoesTaxasServicos, ConverterEmLocacaoTaxasServicos);
        }

        public List<TaxasServicos> SelecionarTaxasServicosPorLocacaoId(int idLocacao)
        {
            if (Existe(idLocacao))
            {
                List<TaxasServicos> taxasServicos = new List<TaxasServicos>();
                List<LocacaoTaxasServicos> todasLocacaoTaxaServico = SelecionarTodosLocacaoTaxasServicos();
                foreach (LocacaoTaxasServicos Locacao_TaxaServico in todasLocacaoTaxaServico)
                {
                    if (idLocacao == Locacao_TaxaServico.locacao.Id)
                        taxasServicos.Add(Locacao_TaxaServico.taxasServicos);
                }
                return taxasServicos;
            }
            return null;
        }
    }
}
