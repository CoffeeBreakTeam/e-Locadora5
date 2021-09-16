using e_Locadora5.Aplicacao.GrupoVeiculoModule;
using e_Locadora5.Dominio;
using e_Locadora5.Infra.SQL.GrupoVeiculoModule;
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

namespace e_Locadora5.WindowsApp.GrupoVeiculoModule
{
    public partial class TabelaGrupoVeiculoControl : UserControl
    {
        public GrupoVeiculoAppService grupoVeiculoAppService = new GrupoVeiculoAppService(new GrupoVeiculoDAO());

        public TabelaGrupoVeiculoControl()
        {
            InitializeComponent();
            gridGrupoVeiculo.ConfigurarGridZebrado();
            gridGrupoVeiculo.ConfigurarGridSomenteLeitura();
            gridGrupoVeiculo.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Categoria", HeaderText = "Categoria"},

                new DataGridViewTextBoxColumn { DataPropertyName = "planoDiarioValorKm", HeaderText = "PD: Valor Diário"},

                new DataGridViewTextBoxColumn { DataPropertyName = "planoDiarioValorDiario", HeaderText = "PD: Valor Km"},

                new DataGridViewTextBoxColumn { DataPropertyName = "planoKmControladoValorDiario", HeaderText = "PC: Valor Diário"},

                new DataGridViewTextBoxColumn { DataPropertyName = "planoKmControladoValorKm", HeaderText = "PC: Valor Km"},

                new DataGridViewTextBoxColumn { DataPropertyName = "planoKmControladoQuantidadeKm", HeaderText = "PC: Quantidade de Km"},

                new DataGridViewTextBoxColumn { DataPropertyName = "planoKmLivreValorDiario", HeaderText = "PL: Valor Diário"}
            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridGrupoVeiculo.SelecionarId<int>();
        }

        public void AtualizarRegistros()
        {
            var grupoVeiculos = grupoVeiculoAppService.SelecionarTodos();

            CarregarTabela(grupoVeiculos);
        }

        public void CarregarTabela(List<GrupoVeiculo> grupoVeiculos)
        {
            gridGrupoVeiculo.DataSource = grupoVeiculos;
        }
    }
}
