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
        ParceiroAppService controlador =null;
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
                txtNome.Text = parceiro.Nome;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;

            parceiro = new Parceiro(nome);

            int id = Convert.ToInt32(txtId.Text);

            string resultadoValidacaoDominio = parceiro.Validar();          

            if (resultadoValidacaoDominio != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacaoDominio).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
           

    
        }

    }
}
  
