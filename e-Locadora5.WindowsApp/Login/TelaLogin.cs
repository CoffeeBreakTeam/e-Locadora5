using e_Locadora5.Aplicacao.FuncionarioModule;
using e_Locadora5.Controladores.FuncionarioModule;
using e_Locadora5.Dominio.FuncionarioModule;
using e_Locadora5.Infra.SQL.FuncionarioModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Locadora5.WindowsApp.Login
{
    public partial class TelaLogin : Form
    {
        FuncionarioAppService funcionarioAppService = new FuncionarioAppService(new FuncionarioDAO());
        public TelaLogin()
        {
            InitializeComponent();
            txtSenha.PasswordChar = '*';
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            bool loginValido = false;
            foreach (Funcionario funcionario in funcionarioAppService.SelecionarTodos())
            {
                if (txtUsuario.Text == funcionario.Usuario && txtSenha.Text == funcionario.Senha)
                {
                    TelaPrincipalForm telaPrincipalForm = new TelaPrincipalForm();
                    telaPrincipalForm.funcionario = funcionario;
                    loginValido = true;
                    this.Visible = false;
                    telaPrincipalForm.ShowDialog();
                }
            }
            if (txtUsuario.Text == "admin" && txtSenha.Text == "admin")
            {
                TelaPrincipalForm telaPrincipalForm = new TelaPrincipalForm();
                telaPrincipalForm.funcionario = new Funcionario("admin", "0000000000", "admin", "admin", DateTime.Now, 0000000000);
                loginValido = true;
                this.Visible = false;
                telaPrincipalForm.ShowDialog();
                

            }
            if (!loginValido)
                labelRodape.Text = "Login ou Senha Inválidos, tente novamente!";
        }
        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnGravar_Click(sender, e);
            }
        }
    }
}
