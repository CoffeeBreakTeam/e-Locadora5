using e_Locadora5.Aplicacao.TaxasServicosModule;
using e_Locadora5.Dominio.TaxasServicosModule;
using e_Locadora5.Infra.SQL.TaxasServicosModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Locadora5.WindowsApp.Features.TaxasServicosModule
{
    public partial class TelaTaxaServicosForm : Form
    {
        private TaxasServicos taxasServicos;

        public TelaTaxaServicosForm()
        {
            InitializeComponent();
        }

        public TaxasServicos TaxasServicos
        {
            get { return taxasServicos; }

            set
            {
                taxasServicos = value;

                txtId.Text = taxasServicos.Id.ToString();
                txtDescricao.Text = taxasServicos.Descricao;
                if (taxasServicos.TaxaFixa != 0)
                {
                    taxaFixa.Checked = true;
                    textTaxaFixa.Text = taxasServicos.TaxaFixa.ToString();
                }
                else
                {
                    taxaDiaria.Checked = true;
                    textTaxaDiaria.Text = taxasServicos.TaxaDiaria.ToString();
                }
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string descricao = txtDescricao.Text;
            double taxaFixa = Convert.ToDouble(textTaxaFixa.Text);
            double taxaDiaria = Convert.ToDouble(textTaxaDiaria.Text);

            taxasServicos = new TaxasServicos(descricao, taxaFixa, taxaDiaria);

            taxasServicos.Id = Convert.ToInt32(txtId.Text);
        }

        private void taxaFixa_CheckedChanged(object sender, EventArgs e)
        {
            if (taxaFixa.Checked == true)
            {
                textTaxaDiaria.Enabled = false;
                textTaxaFixa.Enabled = true;
                textTaxaDiaria.Text = "0";
            }
        }

        private void taxaDiaria_CheckedChanged(object sender, EventArgs e)
        {
            if (taxaDiaria.Checked == true)
            {
                textTaxaFixa.Enabled = false;
                textTaxaDiaria.Enabled = true;
                textTaxaFixa.Text = "0";
            }
        }

        private void TelaTaxaServicosForm_Load(object sender, EventArgs e)
        {
            if (taxasServicos == null)
            {
                taxaFixa.Checked = true;
                taxaDiaria.Checked = false;
            }
        }

        #region MetodosLerSomenteint

        private void textTaxaFixa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void textTaxaDiaria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        #endregion
    }
}
