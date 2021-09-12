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
    public partial class FiltroCondutoresForm : Form
    {
        public FiltroCondutoresForm()
        {
            InitializeComponent();
        }

        public FlitroCondutoresEnum TipoFiltro
        {
            get
            {
                if (rbCnhVencida.Checked)
                    return FlitroCondutoresEnum.CondutoresCnhVencida;

                else 
                    return FlitroCondutoresEnum.TodosCondutores;
            }
        }

        private void FiltroCondutoresForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }
    }
}
