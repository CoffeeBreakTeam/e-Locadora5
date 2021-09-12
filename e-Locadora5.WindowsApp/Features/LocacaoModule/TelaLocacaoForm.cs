using e_Locadora5.Controladores.ClientesModule;
using e_Locadora5.Controladores.CondutorModule;
using e_Locadora5.Controladores.CupomModule;
using e_Locadora5.Controladores.FuncionarioModule;
using e_Locadora5.Controladores.LocacaoModule;
using e_Locadora5.Controladores.ParceiroModule;
using e_Locadora5.Controladores.TaxasServicoModule;
using e_Locadora5.Controladores.VeiculoModule;
using e_Locadora5.Dominio;
using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.CondutoresModule;
using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.FuncionarioModule;
using e_Locadora5.Dominio.LocacaoModule;
using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Dominio.TaxasServicosModule;
using e_Locadora5.Dominio.VeiculosModule;
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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using e_Locadora5.Email;

namespace e_Locadora5.WindowsApp.Features.LocacaoModule
{
    public partial class TelaLocacaoForm : Form
    {
        ControladorClientes controladorCliente = new ControladorClientes();
        ControladorCondutor controladorCondutor = new ControladorCondutor();
        ControladorGrupoVeiculo controladorGrupoVeiculo = new ControladorGrupoVeiculo();
        ControladorVeiculos controladorVeiculo = new ControladorVeiculos();
        ControladorLocacao controladorLocacao = new ControladorLocacao();
        ControladorFuncionario controladorFuncionario = new ControladorFuncionario();
        ControladorTaxasServicos controladorTaxasServicos = new ControladorTaxasServicos();
        ControladorParceiro controladorParceiro = new ControladorParceiro();
        ControladorCupons controladorCupom = new ControladorCupons();
        
        private double custoPlanoLocacao = 0;
        private Locacao locacao;
        private PDF pdf;

        public TelaLocacaoForm()
        {
            InitializeComponent();
            CarregarCliente();
            CarregarFuncionario();
            CarregarGrupoVeiculos();
            CarregarTaxasServicos();
            CarregarParceiros();
        }

        public Locacao Locacao
        {
            get
            {
                return locacao;
            }

            set
            {
                locacao = value;

                //LOCAÇÃO
                txtIdLocacao.Text = locacao.Id.ToString();
                cboxPlano.SelectedItem = locacao.plano;
                txtFuncionario.Text = TelaPrincipalForm.Instancia.funcionario.ToString();


                if (locacao.seguroCliente != 0)
                {
                    checkBoxSeguroCliente.Checked = true;
                    txtSeguroCliente.Text = locacao.seguroCliente.ToString();
                }

                if (locacao.seguroTerceiro != 0)
                {
                    checkBoxSeguroTerceiro.Checked = true;
                    txtSeguroTerceiro.Text = locacao.seguroTerceiro.ToString();
                }

                maskedTextBoxLocacao.Text = locacao.dataLocacao.ToString();
                maskedTextBoxDevolucao.Text = locacao.dataDevolucao.ToString();

                //CLIENTE
                cboxCliente.SelectedItem = locacao.cliente;

                //CONDUTOR
                cboxCondutor.SelectedItem = locacao.condutor;

                //VEICULO
                cboxGrupoVeiculo.SelectedItem = locacao.grupoVeiculo;
                cboxVeiculo.SelectedItem = locacao.veiculo;
                txtQuilometragemLocacao.Text = locacao.quilometragemDevolucao.ToString();
                txtCaucao.Text = locacao.caucao.ToString();

                if (locacao.cupom != null)
                {
                    radioButtonCupomSim.Checked = true;
                    comboBoxParceiro.SelectedItem = locacao.cupom.Parceiro;
                    CarregarCupons();
                    comboBoxCupom.SelectedItem = locacao.cupom;
                }
            }
        }

        public string ValidarCampos()
        {
            if (cboxPlano.SelectedItem == null)
            {
                return "Plano é obrigatorio";
            }

            if (string.IsNullOrEmpty(txtFuncionario.Text))
            {
                return "Funcionario é obrigatório";
            }

            if (!ValidarTipoInt(txtSeguroCliente.Text))
            {
                return "Digite um valor valido para Seguro Cliente";
            }
            if (!ValidarTipoInt(txtSeguroTerceiro.Text))
            {
                return "Digite um valor valido para Seguro Terceiro";
            }
            if (maskedTextBoxLocacao.Text.Length != 10)
            {
                return "Digite uma data valida para Data de Locação";
            }
            if (maskedTextBoxDevolucao.Text.Length != 10)
            {
                return "Digite uma data valida para Data de Devolução";
            }
            if (!ValidarTipoDouble(txtCaucao.Text))
            {
                return "Digite um valor valido para Caução";
            }
            if (cboxCliente.SelectedItem == null)
            {
                return "Cliente é obrigatótio";
            }
            if (cboxCondutor.SelectedItem == null)
            {
                return "Condutor é obrigatório";
            }
            if (cboxGrupoVeiculo.SelectedItem == null)
            {
                return "Grupo de Veículo é obrigatório";
            }
            if (cboxVeiculo.SelectedItem == null)
            {
                return "Veiculo é obrigatório";
            }
            if (!ValidarTipoInt(txtQuilometragemLocacao.Text))
            {
                return "Quilometragem Devolução inválido";
            }
            if (radioButtonCupomSim.Checked == true && !ValidarCupom())
                return "Cupom de Desconto inválido!";

            return "ESTA_VALIDO";
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            MostrarResumoFinanceiro();
            string validacaoCampos = ValidarCampos();

            if (ValidarCampos().Equals("ESTA_VALIDO"))
            {
                DialogResult = DialogResult.OK;
                Funcionario funcionario = TelaPrincipalForm.Instancia.funcionario;
                DateTime dataLocacao = Convert.ToDateTime(maskedTextBoxLocacao.Text);
                DateTime dataDevolucao = Convert.ToDateTime(maskedTextBoxDevolucao.Text);
                double quilometragemDevolucao = Convert.ToDouble(txtQuilometragemLocacao.Text);
                string plano = cboxPlano.SelectedItem.ToString();
                double seguroCliente = Convert.ToDouble(txtSeguroCliente.Text);
                double seguroTerceiro = Convert.ToDouble(txtSeguroTerceiro.Text);
                double caucao = Convert.ToDouble(txtCaucao.Text);
                GrupoVeiculo grupoVeiculo = (GrupoVeiculo)cboxGrupoVeiculo.SelectedItem;
                Veiculo veiculo = (Veiculo)cboxVeiculo.SelectedItem;
                Clientes cliente = (Clientes)cboxCliente.SelectedItem;
                Condutor condutor = (Condutor)cboxCondutor.SelectedItem;
                bool emAberto = true;

                

                locacao = new Locacao(funcionario, dataLocacao, dataDevolucao, quilometragemDevolucao, plano, seguroCliente, seguroTerceiro, caucao, grupoVeiculo, veiculo, cliente, condutor, emAberto);

                if (radioButtonCupomSim.Checked == true)
                    locacao.cupom = (Cupons)comboBoxCupom.SelectedItem;

                locacao.taxasServicos.Clear();

                for (int i = 0; i <= (cListBoxTaxasServicos.Items.Count - 1); i++)
                {
                    if (cListBoxTaxasServicos.GetItemChecked(i))
                    {
                        TaxasServicos taxaServico = (TaxasServicos)cListBoxTaxasServicos.Items[i];
                        locacao.taxasServicos.Add(taxaServico);
                    }
                }

                int id = Convert.ToInt32(txtIdLocacao.Text);
                string resultadoValidacaoDominio = veiculo.Validar();

                string resultadoValidacaoControlador = controladorLocacao.ValidarLocacao(locacao, id);

                string resultadoValidacaoCNH = controladorLocacao.ValidarCNH(locacao, id);

                if (resultadoValidacaoDominio != "ESTA_VALIDO")
                {
                    string primeiroErroDominio = new StringReader(resultadoValidacaoDominio).ReadLine();

                    TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErroDominio);

                    DialogResult = DialogResult.None;
                }
                else if (resultadoValidacaoControlador != "ESTA_VALIDO")
                {
                    string primeiroErroControlador = new StringReader(resultadoValidacaoControlador).ReadLine();

                    TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErroControlador);

                    DialogResult = DialogResult.None;
                }
                else if (resultadoValidacaoCNH != "ESTA_VALIDO")
                {
                    string primeiroErroCNH = new StringReader(resultadoValidacaoCNH).ReadLine();

                    TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErroCNH);

                    DialogResult = DialogResult.None;
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape("Gerando PDF do Resumo Financeiro...");
                    PDF pdf = new PDF(locacao);
                    string localPDF = pdf.GerarPDF();
                    do
                    {
                        TelaPrincipalForm.Instancia.AtualizarRodape("Tentando se conectar a internet...");
                        SMTP email = new SMTP();
                        if (email.estaConectadoInternet())
                        {
                            TelaPrincipalForm.Instancia.AtualizarRodape("Enviando email para " + locacao.cliente.Email);
                            email.enviarEmail(locacao.cliente.Email, "Resumo Financeiro de Locação", "", localPDF);
                            TelaPrincipalForm.Instancia.AtualizarRodape("Email com resumo financeiro enviado para " + locacao.cliente.Email);
                            locacao.emailEnviado = true;
                            break;
                        }
                        else
                        {
                            TelaPrincipalForm.Instancia.AtualizarRodape("Não foi possível se conectar a internet para enviar o resumo financeiro");
                            if (MessageBox.Show($"Não foi possível conectar-se a internet. Deseja tentar novamente?",
                                "Envio de email", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                TelaPrincipalForm.Instancia.AtualizarRodape("Cancelado envio de email");
                                break;
                            }
                        }
                    } while (true);


                }

            }
            else
            {
                string primeiroErro = new StringReader(validacaoCampos).ReadLine();
                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);
            }
        }

        private void CarregarCliente()
        {
            cboxCliente.Items.Clear();

            List<Clientes> contatos = controladorCliente.SelecionarTodos();

            foreach (var contato in contatos)
            {
                cboxCliente.Items.Add(contato);
            }
        }

        private void CarregarVeiculo()
        {
            cboxVeiculo.Items.Clear();

            List<Veiculo> veiculos = controladorVeiculo.SelecionarTodos();

            foreach (var veiculo in veiculos)
            {
                if (veiculo.GrupoVeiculo.Equals((GrupoVeiculo)cboxGrupoVeiculo.SelectedItem))
                    cboxVeiculo.Items.Add(veiculo);
            }
        }

        private void CarregarGrupoVeiculos()
        {
            cboxGrupoVeiculo.Items.Clear();

            List<GrupoVeiculo> grupoVeiculos = controladorGrupoVeiculo.SelecionarTodos();

            foreach (var grupoVeiculo in grupoVeiculos)
            {
                cboxGrupoVeiculo.Items.Add(grupoVeiculo);
            }
        }

        private void CarregarCondutor()
        {
            cboxCondutor.Items.Clear();
            List<Condutor> condutores = controladorCondutor.SelecionarTodos();

            foreach (var condutor in condutores)
            {
                if (condutor.Cliente.Equals((Clientes)cboxCliente.SelectedItem))
                    cboxCondutor.Items.Add(condutor);
            }
        }

        private void CarregarFuncionario()
        {
            txtFuncionario.Text = TelaPrincipalForm.Instancia.funcionario.ToString();       
        }

        private void CarregarTaxasServicos()
        {
            cListBoxTaxasServicos.Items.Clear();

            List<TaxasServicos> taxasServicos = controladorTaxasServicos.SelecionarTodos();

            foreach (var taxaServico in taxasServicos)
            {
                cListBoxTaxasServicos.Items.Add(taxaServico);
            }
        }

        private void CarregarParceiros()
        {
            comboBoxParceiro.Items.Clear();

            List<Parceiro> parceiros = controladorParceiro.SelecionarTodos();

            foreach (var parceiro in parceiros)
            {
                comboBoxParceiro.Items.Add(parceiro);
            }
        }

        private bool ValidarTipoInt(string texto)
        {
            try
            {
                double numeroConvertido = Convert.ToInt32(texto);
                return true;
            }
            catch
            {
                return false;
            }
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

        private void checkBoxCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSeguroCliente.Checked == true)
            {
                txtSeguroCliente.Enabled = true;
            }

            else
            {
                txtSeguroCliente.Enabled = false;
                txtSeguroCliente.Text = "0";
            }
        }

        private void checkBoxSeguroTerceiro_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSeguroTerceiro.Checked == true)
            {
                txtSeguroTerceiro.Enabled = true;
            }

            else
            {
                txtSeguroTerceiro.Enabled = false;
                txtSeguroTerceiro.Text = "0";
            }
        }

        private void cboxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarCondutor();
        }

        private void cboxGrupoVeiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarVeiculo();
            MostrarResumoFinanceiro();
        }

        private void maskedTextBoxDevolucao_TextChanged(object sender, EventArgs e)
        {
            MostrarResumoFinanceiro();
        }

        private void maskedTextBoxLocacao_TextChanged(object sender, EventArgs e)
        {
            MostrarResumoFinanceiro();
        }

        private void MostrarDiasPrevistos()
        {
            try
            {
                if (maskedTextBoxLocacao.Text.Length == 10 && maskedTextBoxDevolucao.Text.Length == 10)
                {
                    DateTime dataLocacao = Convert.ToDateTime(maskedTextBoxLocacao.Text);
                    DateTime dataDevolucao = Convert.ToDateTime(maskedTextBoxDevolucao.Text);
                    double numeroDias = (dataDevolucao - dataLocacao).TotalDays;
                    if (numeroDias > 0)
                        labelVariavelDiasPrevistos.Text = numeroDias.ToString();
                    else
                        labelVariavelDiasPrevistos.Text = "0";
                }
            }
            catch { }
        }

        private void cboxPlano_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarResumoFinanceiro();
        }

        private void MostrarValorTotal()
        {
            try
            {
                double valorTotal = custoPlanoLocacao + Convert.ToDouble(labelVariavelSeguros.Text) + Convert.ToDouble(labelVariavelCustosTaxasServicos.Text);
                labelVariavelValorTotal.Text = valorTotal.ToString();
            }
            catch { }

        }

        private void MostrarValorPlano()
        {
            try
            {
                custoPlanoLocacao = 0;
                GrupoVeiculo grupoVeiculoSelecionado = (GrupoVeiculo)cboxGrupoVeiculo.SelectedItem;
                string planoSelecionado = cboxPlano.Text;

                if (grupoVeiculoSelecionado != null && planoSelecionado != "")
                {
                    if (planoSelecionado == "Diário")
                    {
                        double valorDiario = grupoVeiculoSelecionado.planoDiarioValorDiario * Convert.ToDouble(labelVariavelDiasPrevistos.Text);
                        labelVariavelCustosPlano.Text = valorDiario.ToString() + " + " + grupoVeiculoSelecionado.planoDiarioValorKm + " por Km";
                        custoPlanoLocacao = valorDiario;
                    }
                    else if (planoSelecionado == "Km Controlado")
                    {
                        double valorDiario = grupoVeiculoSelecionado.planoKmControladoValorDiario * Convert.ToDouble(labelVariavelDiasPrevistos.Text);
                        double valorKm = grupoVeiculoSelecionado.planoKmControladoValorKm * grupoVeiculoSelecionado.planoKmControladoQuantidadeKm;
                        labelVariavelCustosPlano.Text = valorDiario.ToString() + " + " + grupoVeiculoSelecionado.planoKmControladoValorKm + " por Km extra";
                        custoPlanoLocacao = valorDiario;
                    }
                    else if (planoSelecionado == "Km Livre")
                    {
                        double valorDiario = grupoVeiculoSelecionado.planoKmLivreValorDiario * Convert.ToDouble(labelVariavelDiasPrevistos.Text);
                        labelVariavelCustosPlano.Text = valorDiario.ToString();
                        custoPlanoLocacao = valorDiario;
                    }
                }
            }
            catch {
                labelVariavelCustosPlano.Text = "0";
            }
        }

        private void MostrarValorTaxasServicos()
        {
            try
            {
                List<TaxasServicos> taxasServicosSelecionadas = new List<TaxasServicos>();
                double valorTaxasServicos = 0;

                foreach (object itemChecked in cListBoxTaxasServicos.CheckedItems)
                {  
                    TaxasServicos taxaServico = (TaxasServicos)itemChecked;
                    valorTaxasServicos += (taxaServico.TaxaDiaria * Convert.ToDouble(labelVariavelDiasPrevistos.Text)) + taxaServico.TaxaFixa;
                }
                    
                labelVariavelCustosTaxasServicos.Text = valorTaxasServicos.ToString();
            }
            catch {
                labelVariavelCustosTaxasServicos.Text = "0";
            }
        }

        private void MostrarValorSeguros()
        {
            try
            {
                double valorSeguros = 0;
                valorSeguros += Convert.ToDouble(txtSeguroCliente.Text) + Convert.ToDouble(txtSeguroTerceiro.Text);
                labelVariavelSeguros.Text = valorSeguros.ToString();
            }
            catch {
                labelVariavelSeguros.Text = "0";
            }
        }

        private void txtSeguroCliente_TextChanged(object sender, EventArgs e)
        {
            MostrarResumoFinanceiro();
        }

        private void txtSeguroTerceiro_TextChanged(object sender, EventArgs e)
        {
            MostrarResumoFinanceiro();
        }

        private void MostrarResumoFinanceiro()
        {
            MostrarDiasPrevistos();
            MostrarValorPlano();
            MostrarValorTaxasServicos();
            MostrarValorSeguros();
            MostrarValorTotal();
        }

        private void cListBoxTaxasServicos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)(() => MostrarResumoFinanceiro()));
        }

        private void cboxVeiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Veiculo veiculo = (Veiculo)cboxVeiculo.SelectedItem;
            txtQuilometragemLocacao.Text = veiculo.Quilometragem.ToString();
        }

        private void TelaLocacaoForm_Load(object sender, EventArgs e)
        {
            if (locacao != null)
                for (int i = 0; i <= (cListBoxTaxasServicos.Items.Count - 1); i++)
                {
                    foreach (TaxasServicos taxaServicoLocacao in controladorLocacao.SelecionarTaxasServicosPorLocacaoId(locacao.Id))
                    {
                        if (taxaServicoLocacao.Equals((TaxasServicos)cListBoxTaxasServicos.Items[i]))
                            cListBoxTaxasServicos.SetItemChecked(i, true);
                    }
                }
        }

        private void labelParceiros_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxParceiro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarCupons();
        }

        private void CarregarCupons()
        {
            comboBoxCupom.Items.Clear();
            comboBoxCupom.Text = "";
            foreach (Cupons cupom in controladorCupom.SelecionarTodos())
            {
                if (cupom.Parceiro.Equals(comboBoxParceiro.SelectedItem))
                {
                    comboBoxCupom.Items.Add(cupom);
                }
            }
        }

        private bool ValidarCupom()
        {
            foreach (Cupons cupom in controladorCupom.SelecionarTodos())
            {
                if (cupom.Parceiro.nome == comboBoxParceiro.SelectedItem.ToString())
                {
                    if (cupom.Nome == comboBoxCupom.Text && cupom.Validar() == "ESTA_VALIDO")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void radioButtonCupomSim_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCupomSim.Checked == true)
            {
                comboBoxParceiro.Enabled = true;
                comboBoxCupom.Enabled = true;
            }
        }

        private void radioButtonCupomNao_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCupomNao.Checked == true)
            {
                comboBoxParceiro.Enabled = false;
                comboBoxParceiro.SelectedIndex = -1;
                comboBoxCupom.Enabled = false;
                comboBoxCupom.SelectedIndex = -1;
            }
        }
    }
}
