using e_Locadora5.Aplicacao.CondutorModule;
using e_Locadora5.Dominio.CondutoresModule;
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

namespace e_Locadora5.WindowsApp.Features.CondutorModule
{
    public partial class TabelaCondutorControl : UserControl
    {
        private CondutorAppService controladorCondutor;
        public TabelaCondutorControl(CondutorAppService controladorCondutor)
        {
            InitializeComponent();
            gridCondutores.ConfigurarGridZebrado();
            gridCondutores.ConfigurarGridSomenteLeitura();
            gridCondutores.Columns.AddRange(ObterColunas());
            this.controladorCondutor = controladorCondutor;
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Endereco", HeaderText = "Endereço"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Rg", HeaderText = "Numero RG"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Cpf", HeaderText = "Numero CPF"},

                 new DataGridViewTextBoxColumn {DataPropertyName = "NumeroCnh", HeaderText = "Numero CNH"},

                 new DataGridViewTextBoxColumn {DataPropertyName = "ValidadeCnh", HeaderText = "Data Validade Cnh"},

                 new DataGridViewTextBoxColumn {DataPropertyName = "Cliente", HeaderText = "Cliente"}
            };

            return colunas;
        }
        public int ObtemIdSelecionado()
        {
            return gridCondutores.SelecionarId<int>();
        }
        public void AtualizarRegistrosCnhVencida()
        {
            var condutores = controladorCondutor.SelecionarCondutoresComCnhVencida(DateTime.Now);

            CarregarTabela(condutores);

        }
        public void CarregarTabela(List<Condutor> condutores)
        {
            gridCondutores.DataSource = condutores;
        }

    }
}
