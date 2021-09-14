using e_Locadora5.Aplicacao.FuncionarioModule;
using e_Locadora5.Controladores.FuncionarioModule;
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

        public string ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtNome.Text))
                return "Nome inválido, tente novamente";

            if (RemoverPontosETracos(txtCPF.Text) == "")
                return "CPF é obrigatório, tente novamente";

            if (string.IsNullOrEmpty(txtUsuario.Text))
                return "Nome de usuário inválido, tente novamente";

            if (string.IsNullOrEmpty(txtSenha.Text))
                return "Senha inválida, tente novamente";

            if (!ValidarTipoDouble(txtSalario.Text))
                return "Sálario inválido, tente novamente";

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
        private string RemoverPontosETracos(string palavra)
        {
            palavra = palavra.Replace(".", "");
            palavra = palavra.Replace(",", "");
            palavra = palavra.Replace("-", "");
            palavra = palavra.Replace("/", "");
            palavra = palavra.Trim();
            return palavra;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos() == "CAMPOS_VALIDOS")
            {
                string nome = txtNome.Text;
                string numerocpf = txtCPF.Text;
                string usuario = txtUsuario.Text;
                string senha = txtSenha.Text;
                DateTime admissao = dateAdmissao.Value;
                double SALARIO = Convert.ToDouble(txtSalario.Text);

             
                funcionario = new Funcionario(nome, numerocpf, usuario, senha, admissao, SALARIO);

                int id = Convert.ToInt32(txtId.Text);

                string resultadoValidacaoDominio = funcionario.Validar();
                string resultadoValidacaoControlador = funcionarioAppService.ValidarFuncionarios(funcionario, id);

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
            else
            {
                string primeiroErroControlador = new StringReader(ValidarCampos()).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErroControlador);

                DialogResult = DialogResult.None;
            }
        }
    }
}
