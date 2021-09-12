using e_Locadora5.Controladores.ClientesModule;
using e_Locadora5.Controladores.CondutorModule;
using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.CondutoresModule;
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

namespace e_Locadora5.WindowsApp.Features.CondutorModule
{
    public partial class TelaCondutorForm : Form
    {
        private Condutor condutor;
        private ControladorClientes controladorCliente = new ControladorClientes();
        private ControladorCondutor controladorCondutor = new ControladorCondutor();

        public TelaCondutorForm()
        {
            InitializeComponent();
            InicializarComboBoxClientes();
        }

        public Condutor Condutor
        {
            get { return condutor; }

            set
            {
                condutor = value;

                txtId.Text = condutor.Id.ToString();
                txtNome.Text = condutor.Nome;
                txtEndereco.Text = condutor.Endereco;

                TxtTelefone.Text = condutor.Telefone;
                txtRG.Text = condutor.Rg;
                txtCPF.Text = condutor.Cpf;
                txtCnh.Text = condutor.NumeroCNH;
                dateValidade.Value = condutor.ValidadeCNH;
                cbCliente.SelectedItem = condutor.Cliente;
                
            }
        }

        private void InicializarComboBoxClientes()
        {
            cbCliente.Items.Clear();

            List<Clientes> contatos = controladorCliente.SelecionarTodos();

            foreach (var contato in contatos)
            {
                cbCliente.Items.Add(contato);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos() == "ESTA_VALIDO")
            {
                DialogResult = DialogResult.OK;
                string nome = txtNome.Text;
                string endereco = txtEndereco.Text;
                string telefone = TxtTelefone.Text;
                string rg = txtRG.Text;
                string cpf = txtCPF.Text;
                string cnh = txtCnh.Text;
                DateTime validade = dateValidade.Value;
                int id = Convert.ToInt32(txtId.Text);

                cpf = RemoverPontosETracos(cpf);
                cnh = RemoverPontosETracos(cnh);

                Clientes cliente = (Clientes)cbCliente.SelectedItem;

                condutor = new Condutor(nome, endereco, telefone, rg, cpf, cnh, validade, cliente);

                string resultadoValidacao = condutor.Validar();
                string resultadoValidacaoControlador = controladorCondutor.ValidarCondutor(condutor, id);

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
                string primeiroErroControlador = new StringReader(ValidarCampos()).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErroControlador);
            }
        }

        private void TelaCondutorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
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

        public string ValidarCampos()
        {

            if (cbCliente.SelectedItem == null)
            {
                return "Cliente é obrigatório";
            }

            return "ESTA_VALIDO";
        }
    }
}
