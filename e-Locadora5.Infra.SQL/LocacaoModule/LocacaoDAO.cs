using e_Locadora5.Dominio.LocacaoModule;
using e_Locadora5.Dominio.TaxasServicosModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.SQL.LocacaoModule
{
    public class LocacaoDAO: ILocacaoRepository
    {
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

        public void InserirLocacao(Locacao locacao)
        {
            locacao.Id = Db.Insert(sqlInserirLocacao, ObtemParametrosLocacao(locacao));
            if (!locacao.taxasServicos.IsNullOrEmpty())
                foreach (TaxasServicos taxaServico in locacao.taxasServicos)
                {
                    var parametrosTaxasServicos = new Dictionary<string, object>
                    {
                        {"IDLOCACAO",locacao.Id },
                        {"IDTAXASSERVICOS",taxaServico.Id }
                    };
                    
                    Db.Insert(sqlInserirLocacaoTaxasServicos, parametrosTaxasServicos);
                }
        }

        public Locacao SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Locacao> SelecionarTodasLocacoes()
        {
            throw new NotImplementedException();
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
        private Dictionary<string, object> ObtemParametrosLocacaoTaxasServicos(LocacaoTaxasServicos locacaoTaxasServicos)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", locacaoTaxasServicos.Id);
            parametros.Add("IDLOCACAO", locacaoTaxasServicos.locacao.Id);
            parametros.Add("IDTAXASSERVICOS", locacaoTaxasServicos.taxasServicos.Id);

            return parametros;
        }
    }
}
