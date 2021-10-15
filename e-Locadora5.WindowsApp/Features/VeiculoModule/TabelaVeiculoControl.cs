using e_Locadora5.Aplicacao.VeiculoModule;
using e_Locadora5.Dominio.VeiculosModule;
using e_Locadora5.Infra.SQL.VeiculoModule;
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

namespace e_Locadora5.WindowsApp.VeiculoModule
{
    public partial class TabelaVeiculoControl : UserControl
    {
        public VeiculoAppService veiculoAppService = null;
        public TabelaVeiculoControl(VeiculoAppService veiculoAppService)
        {
            this.veiculoAppService = veiculoAppService;
            InitializeComponent();
            gridVeiculo.ConfigurarGridZebrado();
            gridVeiculo.ConfigurarGridSomenteLeitura();
            gridVeiculo.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
          {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Placa", HeaderText = "Placa"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Modelo", HeaderText = "Modelo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Fabricante", HeaderText = "Fabricante"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Quilometragem", HeaderText = "Quilometragem"},

                new DataGridViewTextBoxColumn { DataPropertyName = "QtdLitrosTanque", HeaderText = "Capacidade Litros"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Combustivel", HeaderText = "Combustivel" },

                new DataGridViewTextBoxColumn { DataPropertyName = "GrupoVeiculo", HeaderText = "Grupo Veiculo" }

          };
           
            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridVeiculo.SelecionarId<int>();
        }

        public void AtualizarRegistros()
        {
            var veiculo = veiculoAppService.SelecionarTodos();

            CarregarTabela(veiculo);

        }

        private void CarregarTabela(List<Veiculo> veiculos)
        {
            gridVeiculo.DataSource = veiculos;
        }
    }
}
