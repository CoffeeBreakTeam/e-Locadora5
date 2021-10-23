using e_Locadora5.Aplicacao.CupomModule;
using e_Locadora5.Aplicacao.ParceiroModule;
using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Infra.SQL.CupomModule;
using e_Locadora5.Infra.SQL.ParceiroModule;
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

namespace e_Locadora5.WindowsApp.Features.CuponsModule
{
    public partial class TelaCupomForms : Form
    {
        private Cupom cupons;  
       ParceiroAppService parceiroAppService = null;

        public TelaCupomForms(ParceiroAppService parceiroAppService)
        {      
            this.parceiroAppService = parceiroAppService;

            InitializeComponent();
            CarregarComboBoxParceiro();
        }

        public Cupom Cupons
        {
            get { return cupons; }

            set
            {
                cupons = value;
                txtId.Text = cupons.Id.ToString();
                txtNome.Text = cupons.Nome.ToString();
                if (cupons.ValorPercentual != 0)
                {
                    valorPercentual.Checked = true;
                    txtValorPercentual.Text = cupons.ValorPercentual.ToString();
                }
                if (cupons.ValorFixo != 0)
                {
                    valorFixo.Checked = true;
                    txtValorFixo.Text = cupons.ValorFixo.ToString();
                }
                maskedTextBoxDataValidade.Text = cupons.DataValidade.ToString();
                cboxParceiro.SelectedItem = cupons.Parceiro;
                txtValorMinimo.Text = cupons.ValorMinimo.ToString();

            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            int valorPercentual = Convert.ToInt32(txtValorPercentual.Text);
            double valorFixo = Convert.ToDouble(txtValorFixo.Text);
            DateTime dataValidade = Convert.ToDateTime(maskedTextBoxDataValidade.Text);
            double valorMinimo = Convert.ToDouble(txtValorMinimo.Text);

            Parceiro parceiro = (Parceiro)cboxParceiro.SelectedItem;

            cupons = new Cupom(nome, valorPercentual, valorFixo, dataValidade, parceiro, valorMinimo);

            cupons.Id = Convert.ToInt32(txtId.Text);
        }
        private void CarregarComboBoxParceiro()
        {
            cboxParceiro.Items.Clear();
            foreach (Parceiro parceiro in parceiroAppService.SelecionarTodos())
                cboxParceiro.Items.Add(parceiro);
        }
        private void valorPercentual_CheckedChanged(object sender, EventArgs e)
        {
            if (valorPercentual.Checked == true)
            {
                txtValorFixo.Enabled = false;
                txtValorPercentual.Enabled = true;
                txtValorFixo.Text = "0";
            }
        }
        private void valorFixo_CheckedChanged(object sender, EventArgs e)
        {
            if (valorFixo.Checked == true)
            {
                txtValorPercentual.Enabled = false;
                txtValorFixo.Enabled = true;
                txtValorPercentual.Text = "0";
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        #region MetodosLerSomenteInt

        private void txtValorPercentual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtValorFixo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtValorMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        #endregion
    }
}
