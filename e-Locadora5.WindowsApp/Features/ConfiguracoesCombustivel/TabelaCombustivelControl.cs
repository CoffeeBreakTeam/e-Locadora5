using e_Locadora5.Configuracoes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Locadora5.WindowsApp.Features.ConfiguracoesCombustivel
{
    public partial class TabelaCombustivelControl : UserControl
    {
        public TabelaCombustivelControl()
        {
            InitializeComponent();
        }

        public void CarregarConfiguracoes()
        {
            txtGasolina.Text = Configuracao.PrecoGasolina.ToString();
            txtGas.Text = Configuracao.PrecoGas.ToString();
            txtAlcool.Text = Configuracao.PrecoAlcool.ToString();
            txtDiesel.Text = Configuracao.PrecoDiesel.ToString();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            double? precoGasolina = PegarDoubleComVerificacao(txtGasolina);
            if (precoGasolina == null)
                return;

            double? precoGas = PegarDoubleComVerificacao(txtGas);
            if (precoGas == null)
                return;

            double? precoDiesel = PegarDoubleComVerificacao(txtDiesel);
            if (precoDiesel == null)
                return;

            double? precoAlcool = PegarDoubleComVerificacao(txtAlcool);
            if (precoAlcool == null)
                return;


            if (MessageBox.Show("Tem certeza que deseja gravar as configurações atuais?",
                "Configurações de Combustível",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Configuracao.PrecoGasolina = (double)precoGasolina;
                Configuracao.PrecoGas = (double)precoGas;
                Configuracao.PrecoDiesel = (double)precoDiesel;
                Configuracao.PrecoAlcool = (double)precoAlcool;


                TelaPrincipalForm.Instancia.AtualizarRodape("Alteração nos preços salvadas com sucesso!");
            }
        }
        private double? PegarDoubleComVerificacao(TextBox textBox)
        {
            try
            {
                return Convert.ToDouble(textBox.Text);
            }
            catch (Exception)
            {
                TelaPrincipalForm.Instancia
                    .AtualizarRodape($"O Campo aceita apenas números {textBox.AccessibleName}");
            }

            return null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja cancelar a edição?", "Configurações do Combustível",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                CarregarConfiguracoes();

                TelaPrincipalForm.Instancia.AtualizarRodape("Configurações não foram salvadas");
            }
        }
    }
}
