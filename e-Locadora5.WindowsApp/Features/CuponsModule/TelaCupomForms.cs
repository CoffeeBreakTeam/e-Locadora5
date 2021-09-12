using e_Locadora5.Controladores.CupomModule;
using e_Locadora5.Controladores.ParceiroModule;
using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.ParceirosModule;
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
        private Cupons cupons;
        ControladorCupons controladorCupons = new ControladorCupons();
        ControladorParceiro controladorParceiro = new ControladorParceiro();

        public TelaCupomForms()
        {
            InitializeComponent();
            CarregarParceiro();
        }

        public Cupons Cupons
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

        public string ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtNome.Text))
                return "Nome Inválido, tente novamente";

            if (valorPercentual.Checked == true && !ValidarTipoInt(txtValorPercentual.Text))
                return "Valor Percentual está inválido, tente novamente";

            if (Convert.ToInt32(txtValorPercentual.Text) > 100)
                return "Valor Perncentual não pode ser Maior que cem";

            if (valorFixo.Checked == true && !ValidarTipoDouble(txtValorFixo.Text))
                return "Valor Fixo está inválido, tente novamente";

            if (!ValidarTipoDateTime(maskedTextBoxDataValidade.Text))
                return "Data de Validade invalida, tente novamente";

            if (Convert.ToDateTime(maskedTextBoxDataValidade.Text) < DateTime.Now.Date)
                return "Data de Validade não pode ser Menor que a data Atual";

            if (string.IsNullOrEmpty(cboxParceiro.Text))
                return "Parceiro Inválida, tente novamente";

            if (!ValidarTipoDouble(txtValorMinimo.Text))
                return "Valor Minimo inválido, tente novamente";

            if (Convert.ToDouble(txtValorMinimo.Text) <= 0)
                return "Valor Minimo não pode ser menor ou igual a Zero, tente novamente";

            return "CAMPOS_VALIDOS";
        }
        private bool ValidarTipoDouble(string texto)
        {
            try
            {
                double numeroConvertido = Convert.ToDouble(texto);
                return true;
            }
            catch
            {
                return false;

            }
        }
        private bool ValidarTipoInt(string texto)
        {
            try
            {
                double numeroConvertido = Convert.ToInt32(texto);
                return true;
            }
            catch
            {
                return false;

            }
        }

        private bool ValidarTipoDateTime(string texto)
        {
            try
            {
                DateTime dataConvertido = Convert.ToDateTime(texto);
                return true;
            }
            catch
            {
                return false;

            }
        }


        private void btnGravar_Click(object sender, EventArgs e)
        {
            string resultadoValidacao = ValidarCampos();
            if (resultadoValidacao.Equals("CAMPOS_VALIDOS"))
            {
                DialogResult = DialogResult.OK;
                string nome = txtNome.Text;
                int valorPercentual = Convert.ToInt32(txtValorPercentual.Text);
                double valorFixo = Convert.ToDouble(txtValorFixo.Text);
                DateTime dataValidade = Convert.ToDateTime(maskedTextBoxDataValidade.Text);
                double valorMinimo = Convert.ToDouble(txtValorMinimo.Text);

                Parceiro parceiro = (Parceiro)cboxParceiro.SelectedItem;

                cupons = new Cupons(nome, valorPercentual, valorFixo, dataValidade, parceiro, valorMinimo);

                int id = Convert.ToInt32(txtId.Text);
                resultadoValidacao = cupons.Validar();
                string resultadoValidacaoControlador = controladorCupons.ValidarCupons(Cupons, id);

                if (resultadoValidacao != "ESTA_VALIDO")
                {
                    string primeiroErro = new StringReader(resultadoValidacao).ReadLine();
                    TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                    DialogResult = DialogResult.None;
                }
                else if (resultadoValidacaoControlador != "ESTA_VALIDO")
                {
                    string primeiroErroControlador = new StringReader(resultadoValidacaoControlador).ReadLine();

                    TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErroControlador);

                    DialogResult = DialogResult.None;
                }
            }
            else
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();
                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }

        private void CarregarParceiro()
        {
            cboxParceiro.Items.Clear();
            foreach (Parceiro parceiro in controladorParceiro.SelecionarTodos())
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
    }
}
