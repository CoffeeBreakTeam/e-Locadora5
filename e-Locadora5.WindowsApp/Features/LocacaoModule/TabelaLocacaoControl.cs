using Autofac;
using e_Locadora5.Aplicacao.LocacaoModule;
using e_Locadora5.Dominio.LocacaoModule;
using e_Locadora5.Infra.SQL.LocacaoModule;
using e_Locadora5.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Locadora5.WindowsApp.Features.LocacaoModule
{
    public partial class TabelaLocacaoControl : UserControl
    {

        public LocacaoAppService locacaoAppService = null;


        public TabelaLocacaoControl(LocacaoAppService locacaoAppService)
        {
            InitializeComponent();
            this.locacaoAppService = locacaoAppService;
            gridLocacao.ConfigurarGridZebrado();
            gridLocacao.ConfigurarGridSomenteLeitura();
            gridLocacao.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
{
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "funcionario", HeaderText = "Funcionário"},

                new DataGridViewTextBoxColumn { DataPropertyName = "cliente", HeaderText = "Cliente"},

                new DataGridViewTextBoxColumn { DataPropertyName = "veiculo", HeaderText = "Veículo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "condutor", HeaderText = "Condutor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "dataLocacao", HeaderText = "Data de Locação"},

                new DataGridViewTextBoxColumn { DataPropertyName = "dataDevolucao", HeaderText = "Data de Devolução"},

                new DataGridViewTextBoxColumn { DataPropertyName = "emAberto", HeaderText = "Em Aberto"},

};

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridLocacao.SelecionarId<int>();
        }

        public void AtualizarRegistros()
        {
            LocacaoAppService locacaoAppServiceParaMetodo =  AutoFacBuilder.Container.Resolve<LocacaoAppService>();

            var locacao = locacaoAppServiceParaMetodo.SelecionarTodos();

            CarregarTabela(locacao);
        }

        public void AtualizarLocacoesEmailsPendentes()
        {
            var locacao = locacaoAppService.SelecionarLocacoesEmailPendente();

            CarregarTabela(locacao);
        }

        public void CarregarTabela(List<Locacao> locacaos)
        {
            gridLocacao.DataSource = locacaos;
        }
    }
}
