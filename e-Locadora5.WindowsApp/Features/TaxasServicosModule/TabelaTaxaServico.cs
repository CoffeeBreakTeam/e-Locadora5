using e_Locadora5.Aplicacao.TaxasServicosModule;
using e_Locadora5.Dominio.TaxasServicosModule;
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

namespace e_Locadora5.WindowsApp.Features.TaxasServicosModule
{
    public partial class TabelaTaxaServico : UserControl
    {
        private readonly TaxasServicosAppService controladorTaxasServicos;

        public TabelaTaxaServico(TaxasServicosAppService ctrlTaxasServicos)
        {
            InitializeComponent();
            gridTaxasServicos.ConfigurarGridZebrado();
            gridTaxasServicos.ConfigurarGridSomenteLeitura();
            gridTaxasServicos.Columns.AddRange(ObterColunas());
            this.controladorTaxasServicos = ctrlTaxasServicos;
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Descricao", HeaderText = "Descricão"},

                new DataGridViewTextBoxColumn { DataPropertyName = "TaxaFixa", HeaderText = "Taxa Fixa"},

                new DataGridViewTextBoxColumn { DataPropertyName = "TaxaDiaria", HeaderText = "Taxa Diaria"},

            };

            return colunas;
        }
        public int ObtemIdSelecionado()
        {
            return gridTaxasServicos.SelecionarId<int>();
        }
        public void AtualizarRegistros()
        {

            var taxasServicos = controladorTaxasServicos.SelecionarTodos();

            CarregarTbela(taxasServicos);

        }
        private void CarregarTbela(List<TaxasServicos> taxasServicos)
        {
            gridTaxasServicos.DataSource = taxasServicos;
        }
    }
}
