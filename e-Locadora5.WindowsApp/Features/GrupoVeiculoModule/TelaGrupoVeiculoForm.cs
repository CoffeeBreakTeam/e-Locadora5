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


        public string ValidarCampos() 
        {
            if (string.IsNullOrEmpty(txtCategoria.Text))
                return "Categoria inválida, tente novamente";

            if (!ValidarTipoDouble(txtPlanoDiarioValorDiario.Text))
                return "Plano Diário: Valor Diário inválido, tente novamente";

            if (!ValidarTipoDouble(txtPlanoDiarioValorKm.Text))
                return "Plano Diário: Valor KM inválido, tente novamente";

            if (!ValidarTipoDouble(txtPlanoControladoValorDiario.Text))
                return "Plano KM Controlado: Valor Diário inválido, tente novamente";

            if (!ValidarTipoDouble(txtPlanoControladoValorKm.Text))
                return "Plano KM Controlado: Valor por KM inválido, tente novamente";

            if (!ValidarTipoDouble(txtPlanoControladoQtdKm.Text))
                return "Plano KM Controlado: Quantidade de KM inválido, tente novamente";

            if (!ValidarTipoDouble(txtPlanoLivreValorDiario.Text))
                return "Plano KM Livre: Valor Diário inválido, tente novamente";

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
        private void btnGravar_Click(object sender, EventArgs e)
        {
            string resultadoValidacao = ValidarCampos();
            if (resultadoValidacao.Equals("CAMPOS_VALIDOS"))
            {
                DialogResult = DialogResult.OK;
                string categoria = txtCategoria.Text;
                double planoDiarioValorDiario = Convert.ToDouble(txtPlanoDiarioValorDiario.Text);
                double planoDiarioValorKm = Convert.ToDouble(txtPlanoDiarioValorKm.Text);
                double planoControladoValorDiario = Convert.ToDouble(txtPlanoControladoValorDiario.Text);
                double planoControladoValorKm = Convert.ToDouble(txtPlanoControladoValorKm.Text);
                double planoControladoQuantidadeKm = Convert.ToDouble(txtPlanoControladoQtdKm.Text);
                double planoLivreValorDiario = Convert.ToDouble(txtPlanoLivreValorDiario.Text);

                grupoVeiculo = new GrupoVeiculo(categoria, planoDiarioValorKm, planoDiarioValorDiario, planoControladoValorKm, planoControladoQuantidadeKm, planoControladoValorDiario, planoLivreValorDiario);

                resultadoValidacao = grupoVeiculo.Validar();

                if (resultadoValidacao != "ESTA_VALIDO")
                {
                    string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                    TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                    DialogResult = DialogResult.None;
                }
                
            }
            else
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);
            }
        }

        private void txtPlanoDiarioValorDiario_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }


    }
}
