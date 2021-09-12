using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Locadora5.WindowsApp.Features.LocacaoModule
{
    public partial class TelaFiltroLocacaoForm : Form
    {
        public TelaFiltroLocacaoForm()
        {
            InitializeComponent();
        }

        public FlitroLocacoesEnum TipoFiltro
        {
            get
            {
                if (rbLocacoePendentes.Checked)
                    return FlitroLocacoesEnum.LocacoesChegadaPendente;

                else
                    return FlitroLocacoesEnum.TodasLocacoes;
            }
        }

        private void TelaFiltroLocacaoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }
    }
}
