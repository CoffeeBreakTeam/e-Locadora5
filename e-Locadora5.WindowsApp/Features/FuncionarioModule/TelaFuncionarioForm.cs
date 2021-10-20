using e_Locadora5.Aplicacao.FuncionarioModule;
using e_Locadora5.Dominio.FuncionarioModule;
using e_Locadora5.Infra.SQL.FuncionarioModule;
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

namespace e_Locadora5.WindowsApp.Features.FuncionarioModule
{
    public partial class TelaFuncionarioForm : Form
    {
        private Funcionario funcionario;
        FuncionarioAppService funcionarioAppService = new FuncionarioAppService(new FuncionarioDAO());
        public TelaFuncionarioForm()
        {
            InitializeComponent();
        }

        public Funcionario Funcionario
        {
            get { return funcionario; }

            set
            {
                funcionario = value;

                txtId.Text = funcionario.Id.ToString();
                txtNome.Text = funcionario.Nome;
                txtCPF.Text = funcionario.NumeroCpf;
                txtUsuario.Text = funcionario.Usuario;
                txtSenha.Text = funcionario.Senha;
                dateAdmissao.Value = funcionario.DataAdmissao;
                txtSalario.Text = funcionario.Salario.ToString();
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string numerocpf = txtCPF.Text;
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;
            DateTime admissao = dateAdmissao.Value;
            double SALARIO = Convert.ToDouble(txtSalario.Text);

            funcionario = new Funcionario(nome, numerocpf, usuario, senha, admissao, SALARIO);

            funcionario.Id = Convert.ToInt32(txtId.Text);
        }

        private void txtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
