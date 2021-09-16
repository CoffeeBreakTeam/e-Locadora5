using e_Locadora5.Aplicacao.ParceiroModule;
using e_Locadora5.Dominio.ParceirosModule;
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

namespace e_Locadora5.WindowsApp.Features.ParceirosModule
{
    public partial class TelaParceiroForm : Form
    {
        private Parceiro parceiro;
        ParceiroAppService controlador = new ParceiroAppService(new ParceiroDAO());
        public TelaParceiroForm()
        {
            InitializeComponent();
        }

        public Parceiro Parceiro
        {
            get { return parceiro; }

            set
            {
                parceiro = value;

                txtId.Text = parceiro.Id.ToString();
                txtNome.Text = parceiro.nome;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;

            parceiro = new Parceiro(nome);

            int id = Convert.ToInt32(txtId.Text);

            string resultadoValidacaoDominio = parceiro.Validar();
            string resultadoValidacaoControlador = controlador.ValidarParceiros(parceiro, id);

            if (resultadoValidacaoDominio != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacaoDominio).ReadLine();

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

    }
}
  
