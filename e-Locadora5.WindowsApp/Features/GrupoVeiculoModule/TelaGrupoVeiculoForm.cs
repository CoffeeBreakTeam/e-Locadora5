using e_Locadora5.Dominio;
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

namespace e_Locadora5.WindowsApp.GrupoVeiculoModule
{
    public partial class TelaGrupoVeiculoForm : Form
    {
        private GrupoVeiculo grupoVeiculo;

        public TelaGrupoVeiculoForm()
        {
            InitializeComponent();
        }

        public GrupoVeiculo GrupoVeiculo
        {
            get { return grupoVeiculo; }

            set
            {
                grupoVeiculo = value;

                txtId.Text = grupoVeiculo.Id.ToString();
                txtCategoria.Text = grupoVeiculo.categoria;
                txtPlanoDiarioValorDiario.Text = grupoVeiculo.planoDiarioValorDiario.ToString();
                txtPlanoDiarioValorKm.Text = grupoVeiculo.planoDiarioValorKm.ToString();
                txtPlanoControladoValorDiario.Text = grupoVeiculo.planoKmControladoValorDiario.ToString();
                txtPlanoControladoValorKm.Text = grupoVeiculo.planoKmControladoValorKm.ToString();
                txtPlanoControladoQtdKm.Text = grupoVeiculo.planoKmControladoValorKm.ToString();
                txtPlanoLivreValorDiario.Text = grupoVeiculo.planoKmLivreValorDiario.ToString();
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

            string categoria = txtCategoria.Text;
            double planoDiarioValorDiario = Convert.ToDouble(txtPlanoDiarioValorDiario.Text);
            double planoDiarioValorKm = Convert.ToDouble(txtPlanoDiarioValorKm.Text);
            double planoControladoValorDiario = Convert.ToDouble(txtPlanoControladoValorDiario.Text);
            double planoControladoValorKm = Convert.ToDouble(txtPlanoControladoValorKm.Text);
            double planoControladoQuantidadeKm = Convert.ToDouble(txtPlanoControladoQtdKm.Text);
            double planoLivreValorDiario = Convert.ToDouble(txtPlanoLivreValorDiario.Text);

            grupoVeiculo = new GrupoVeiculo(categoria, planoDiarioValorKm, planoDiarioValorDiario, planoControladoValorKm, planoControladoQuantidadeKm, planoControladoValorDiario, planoLivreValorDiario);

            grupoVeiculo.Id = Convert.ToInt32(txtId.Text);
        }

        private void txtPlanoDiarioValorDiario_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        #region MetodosLerSomenteInt


        private void txtPlanoDiarioValorDiario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtPlanoDiarioValorKm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtPlanoControladoValorDiario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtPlanoControladoValorKm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtPlanoControladoQtdKm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtPlanoLivreValorDiario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        #endregion


    }
}
