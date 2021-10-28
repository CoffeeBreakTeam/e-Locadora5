using e_Locadora5.Aplicacao.FuncionarioModule;
using e_Locadora5.Dominio.FuncionarioModule;
using e_Locadora5.Infra.ORM.FuncionarioModule;
using e_Locadora5.Infra.ORM.ParceiroModule;
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
        FuncionarioAppService funcionarioAppService = null;
        bool loginValido = false;
        public TelaLogin()
        {
            LocadoraDbContext locadoraDbContext = new LocadoraDbContext();

            funcionarioAppService = new FuncionarioAppService(new FuncionarioOrmDAO(locadoraDbContext));
            InitializeComponent();
            txtSenha.PasswordChar = '*';
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {           
           
            if (txtUsuario.Text == "admin" && txtSenha.Text == "admin")
            {
                TelaPrincipalForm telaPrincipalForm = new TelaPrincipalForm();
                telaPrincipalForm.funcionario = new Funcionario("admin", "0000000000", "admin", "admin", DateTime.Now, 0000000000);
                loginValido = true;
                this.Visible = false;
                this.Hide();
                telaPrincipalForm.ShowDialog();

            }
            else
            {
                foreach (Funcionario funcionario in funcionarioAppService.SelecionarTodos())
                {
                    if (txtUsuario.Text == funcionario.Usuario && txtSenha.Text == funcionario.Senha)
                    {
                        TelaPrincipalForm telaPrincipalForm = new TelaPrincipalForm();
                        telaPrincipalForm.funcionario = funcionario;
                        loginValido = true;
                        this.Visible = false;
                        this.Hide();
                        telaPrincipalForm.ShowDialog();

                    }
                }
            }
            
            if (loginValido == false)
                labelRodape.Text = "Login ou Senha Inválidos, tente novamente!";
        }
        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnGravar_Click(sender, e);
            }
        }   

        private void btnGravar_MouseLeave(object sender, EventArgs e)
        {

            btnGravar.BackColor = Color.White;
            btnGravar.ForeColor = Color.Black;

        }

        private void btnGravar_MouseEnter(object sender, EventArgs e)
        {
            btnGravar.BackColor = Color.FromArgb(78, 168, 222);
            btnGravar.ForeColor = Color.White;
        }
      
    }
}
