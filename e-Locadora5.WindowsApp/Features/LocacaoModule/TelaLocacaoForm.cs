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
using e_Locadora5.Aplicacao.FuncionarioModule;
using e_Locadora5.Aplicacao.GrupoVeiculoModule;
using e_Locadora5.Aplicacao.VeiculoModule;
using e_Locadora5.Aplicacao.ClienteModule;
using e_Locadora5.Aplicacao.CondutorModule;
using e_Locadora5.Aplicacao.TaxasServicosModule;
using e_Locadora5.Aplicacao.ParceiroModule;
using e_Locadora5.Aplicacao.CupomModule;
using e_Locadora5.Aplicacao.LocacaoModule;
using e_Locadora5.Infra.SQL.LocacaoModule;
using e_Locadora5.Infra.SQL.CupomModule;
using e_Locadora5.Infra.SQL.ParceiroModule;
using e_Locadora5.Infra.SQL.TaxasServicosModule;
using e_Locadora5.Infra.SQL.CondutorModule;
using e_Locadora5.Infra.SQL.ClienteModule;
using e_Locadora5.Infra.SQL.VeiculoModule;
using e_Locadora5.Infra.SQL.GrupoVeiculoModule;
using e_Locadora5.Infra.SQL.FuncionarioModule;

namespace e_Locadora5.WindowsApp.Features.LocacaoModule
{
    public partial class TelaLocacaoForm : Form
    {
        FuncionarioAppService funcionarioAppService = null;
        GrupoVeiculoAppService grupoVeiculoAppService = null;
        VeiculoAppService veiculoAppService = null;
        ClienteAppService clienteAppService = null;
        CondutorAppService condutorAppService = null;
        TaxasServicosAppService taxasServicosAppService = null;
        ParceiroAppService parceiroAppService = null;
        CupomAppService cupomAppService = null;
        LocacaoAppService locacaoAppService = null;

        private double custoPlanoLocacao = 0;
        private Locacao locacao;

        public TelaLocacaoForm(FuncionarioAppService funcionarioAppService, GrupoVeiculoAppService grupoVeiculoAppService, VeiculoAppService veiculoAppService, ClienteAppService clienteAppService, CondutorAppService condutorAppService, TaxasServicosAppService taxasServicosAppService, ParceiroAppService parceiroAppService, CupomAppService cupomAppService, LocacaoAppService locacaoAppService)
        {
            this.funcionarioAppService = funcionarioAppService;
            this.grupoVeiculoAppService = grupoVeiculoAppService;
            this.veiculoAppService = veiculoAppService;
            this.clienteAppService = clienteAppService;
            this.condutorAppService = condutorAppService;
            this.taxasServicosAppService = taxasServicosAppService;
            this.parceiroAppService = parceiroAppService;
            this.cupomAppService = cupomAppService;
            this.locacaoAppService = locacaoAppService;
            InitializeComponent();
            CarregarCliente();
            CarregarFuncionario();
            CarregarGrupoVeiculos();
            CarregarTaxasServicos();
            cboxPlano.SelectedIndex = 0;
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
                cboxCliente.SelectedItem = locacao.Cliente;

                //CONDUTOR
                cboxCondutor.SelectedItem = locacao.Condutor;

                //VEICULO
                cboxGrupoVeiculo.SelectedItem = locacao.GrupoVeiculo;
                cboxVeiculo.SelectedItem = locacao.Veiculo;
                txtQuilometragemLocacao.Text = locacao.quilometragemDevolucao.ToString();
                txtCaucao.Text = locacao.caucao.ToString();

                if (locacao.Cupom != null)
                {
                    radioButtonCupomSim.Checked = true;
                    comboBoxParceiro.SelectedItem = locacao.Cupom.Parceiro;
                    CarregarCupons();
                    comboBoxCupom.SelectedItem = locacao.Cupom;
                }
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            MostrarResumoFinanceiro();
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
            Cliente cliente = (Cliente)cboxCliente.SelectedItem;
            Condutor condutor = (Condutor)cboxCondutor.SelectedItem;
            bool emAberto = true;
            Cupom cupom = null;
            if (radioButtonCupomSim.Checked == true)
            {
                cupom = (Cupom)comboBoxCupom.SelectedItem;

            }

            List<TaxasServicos> taxasServicos = new List<TaxasServicos>();
      
            for (int i = 0; i <= (cListBoxTaxasServicos.Items.Count - 1); i++)
            {
                if (cListBoxTaxasServicos.GetItemChecked(i))
                {
                    taxasServicos.Add((TaxasServicos)cListBoxTaxasServicos.Items[i]);
                }
            }

            locacao = new Locacao(funcionario, dataLocacao, dataDevolucao, quilometragemDevolucao, plano, seguroCliente, seguroTerceiro, caucao, grupoVeiculo, veiculo, cliente, condutor, emAberto, cupom, taxasServicos);

            locacao.Id = Convert.ToInt32(txtIdLocacao.Text);
        }

        private void CarregarCliente()
        {
            cboxCliente.Items.Clear();

            List<Cliente> contatos = clienteAppService.SelecionarTodos();

            foreach (var contato in contatos)
            {
                cboxCliente.Items.Add(contato);
            }
            if (contatos.Count > 0)
                cboxCliente.SelectedIndex = 0;
        }

        private void CarregarVeiculo()
        {
            cboxVeiculo.Items.Clear();

            List<Veiculo> veiculos = veiculoAppService.SelecionarTodos();

            foreach (var veiculo in veiculos)
            {
                if (veiculo.GrupoVeiculo.Equals((GrupoVeiculo)cboxGrupoVeiculo.SelectedItem))
                    cboxVeiculo.Items.Add(veiculo);
            }
            if (cboxVeiculo.Items.Count > 0)
                cboxVeiculo.SelectedIndex = 0;
        }

        private void CarregarGrupoVeiculos()
        {
            cboxGrupoVeiculo.Items.Clear();

            List<GrupoVeiculo> grupoVeiculos = grupoVeiculoAppService.SelecionarTodos();

            foreach (var grupoVeiculo in grupoVeiculos)
            {
                cboxGrupoVeiculo.Items.Add(grupoVeiculo);
            }
            if (grupoVeiculos.Count > 0)
                cboxGrupoVeiculo.SelectedIndex = 0;
        }

        private void CarregarCondutor()
        {
            cboxCondutor.Items.Clear();
            List<Condutor> condutores = condutorAppService.SelecionarTodos();

            foreach (var condutor in condutores)
            {
                if (condutor.Cliente.Equals((Cliente)cboxCliente.SelectedItem))
                    cboxCondutor.Items.Add(condutor);
            }
            if (cboxCondutor.Items.Count > 0)
                cboxCondutor.SelectedIndex = 0;
        }

        private void CarregarFuncionario()
        {
            txtFuncionario.Text = TelaPrincipalForm.Instancia.funcionario.ToString();
        }

        private void CarregarTaxasServicos()
        {
            cListBoxTaxasServicos.Items.Clear();

            List<TaxasServicos> taxasServicos = taxasServicosAppService.SelecionarTodos();

            foreach (var taxaServico in taxasServicos)
            {
                cListBoxTaxasServicos.Items.Add(taxaServico);
            }
        }

        private void CarregarParceiros()
        {
            comboBoxParceiro.Items.Clear();

            List<Parceiro> parceiros = parceiroAppService.SelecionarTodos();

            foreach (var parceiro in parceiros)
            {
                comboBoxParceiro.Items.Add(parceiro);
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
            catch
            {
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
            catch
            {
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
            catch
            {
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
            //var taxa = cListBoxTaxasServicos.Items[e.Index] as TaxasServicos;

            //if (taxa == null)
            //{
            //    return;
            //}

            //if (e.NewValue == CheckState.Checked)
            //{
            //    locacao.TaxasServicos.Add(taxa);
            //}
            //else if (e.NewValue == CheckState.Unchecked)
            //{
            //    locacao.TaxasServicos.Remove(taxa);
            //}


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
                    foreach (TaxasServicos taxaServicoLocacao in locacaoAppService.SelecionarTaxasServicosPorLocacaoId(locacao.Id))
                    {
                        if (taxaServicoLocacao.Equals((TaxasServicos)cListBoxTaxasServicos.Items[i]))
                            cListBoxTaxasServicos.SetItemChecked(i, true);
                    }
                }

            var Cupons = cupomAppService.SelecionarTodos();

            if (Cupons.Count == 0)
                radioButtonCupomSim.Enabled = false;

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
            foreach (Cupom cupom in cupomAppService.SelecionarTodos())
            {
                if (cupom.Parceiro.Equals(comboBoxParceiro.SelectedItem))
                {
                    comboBoxCupom.Items.Add(cupom);
                }
            }
            if (comboBoxCupom.Items.Count > 0)
                comboBoxCupom.SelectedIndex = 0;
        }

        private void radioButtonCupomSim_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCupomSim.Checked == true)
            {
                comboBoxParceiro.Enabled = true;
                comboBoxCupom.Enabled = true;
                CarregarParceiros();
                //comboBoxParceiro.SelectedIndex = 0;
                //comboBoxCupom.SelectedIndex = 0;
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

        #region MetodosLerSomenteInt

        private void txtCaucao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtSeguroCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtSeguroTerceiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtQuilometragemLocacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        #endregion
    }
}
