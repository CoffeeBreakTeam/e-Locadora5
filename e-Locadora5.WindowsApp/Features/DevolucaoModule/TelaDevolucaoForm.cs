using e_Locadora5.Aplicacao.ClienteModule;
using e_Locadora5.Aplicacao.CondutorModule;
using e_Locadora5.Aplicacao.CupomModule;
using e_Locadora5.Aplicacao.FuncionarioModule;
using e_Locadora5.Aplicacao.GrupoVeiculoModule;
using e_Locadora5.Aplicacao.LocacaoModule;
using e_Locadora5.Aplicacao.ParceiroModule;
using e_Locadora5.Aplicacao.TaxasServicosModule;
using e_Locadora5.Aplicacao.VeiculoModule;
using e_Locadora5.Configuracoes;
using e_Locadora5.Dominio;
using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.CondutoresModule;
using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.FuncionarioModule;
using e_Locadora5.Dominio.LocacaoModule;
using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Dominio.TaxasServicosModule;
using e_Locadora5.Dominio.VeiculosModule;
using e_Locadora5.Infra.SQL.ClienteModule;
using e_Locadora5.Infra.SQL.CondutorModule;
using e_Locadora5.Infra.SQL.CupomModule;
using e_Locadora5.Infra.SQL.FuncionarioModule;
using e_Locadora5.Infra.SQL.GrupoVeiculoModule;
using e_Locadora5.Infra.SQL.LocacaoModule;
using e_Locadora5.Infra.SQL.ParceiroModule;
using e_Locadora5.Infra.SQL.TaxasServicosModule;
using e_Locadora5.Infra.SQL.VeiculoModule;
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

namespace e_Locadora5.WindowsApp.Features.DevolucaoModule
{
    public partial class TelaDevolucaoForm : Form
    {
        private Locacao devolucao;
        private double valorCombustivelSelecionado;
        private double porcentagemCombustivelReposto = 1;

        FuncionarioAppService funcionarioAppService = new FuncionarioAppService(new FuncionarioDAO());
        GrupoVeiculoAppService grupoVeiculoAppService = new GrupoVeiculoAppService(new GrupoVeiculoDAO());
        VeiculoAppService veiculoAppService = new VeiculoAppService(new VeiculoDAO());
        ClienteAppService clienteAppService = new ClienteAppService(new ClienteDAO());
        CondutorAppService condutorAppService = new CondutorAppService(new CondutorDAO());
        TaxasServicosAppService taxasServicosAppService = new TaxasServicosAppService(new TaxasServicosDAO());
        ParceiroAppService parceiroAppService = new ParceiroAppService(new ParceiroDAO());
        CupomAppService cupomAppService = new CupomAppService(new CupomDAO());
        LocacaoAppService locacaoAppService = new LocacaoAppService(new LocacaoDAO());

        public TelaDevolucaoForm()
        {
            InitializeComponent();
            CarregarTaxasServicos();
            CarregarParceiros();
        }


        public Locacao Locacao
        {
            get
            {
                return devolucao;
            } 
            set
            {
                devolucao = value;

                //LOCAÇÃO
                txtIdLocacao.Text = devolucao.Id.ToString();
                txtFuncionario.Text = TelaPrincipalForm.Instancia.funcionario.ToString();
                txtPlano.Text = devolucao.plano;
                txtCaucao.Text = devolucao.caucao.ToString();
                txtCategoria.Text = devolucao.Veiculo.GrupoVeiculo.ToString();
                txtVeiculo.Text = devolucao.Veiculo.ToString();
                txtCliente.Text = devolucao.Cliente.ToString();
                txtCondutor.Text = devolucao.Condutor.ToString();
                maskedTextBoxDataLocacao.Text = devolucao.dataLocacao.ToString();
                maskedTextBoxDataRetornoPrevisto.Text = devolucao.dataDevolucao.ToString();
                maskedTextBoxDataRetornoAtual.Text = Convert.ToDateTime(DateTime.Now).ToString();
                txtTipoCombustivel.Text = devolucao.Veiculo.Combustivel.ToString();
                txtQuilometragemInicial.Text = devolucao.Veiculo.Quilometragem.ToString();

                if (devolucao.Cupom != null)
                {
                    groupBoxCupom.Enabled = false;
                    radioButtonCupomSim.Checked = true;
                    comboBoxParceiro.SelectedItem = devolucao.Cupom.Parceiro;
                    comboBoxCupom.SelectedItem = devolucao.Cupom;
                }

                if (devolucao.seguroCliente != 0)
                {
                    checkBoxSeguroCliente.Checked = true;
                    txtSeguroCliente.Text = devolucao.seguroCliente.ToString();
                }

                if (devolucao.seguroTerceiro != 0)
                {
                    checkBoxSeguroTerceiro.Checked = true;
                    txtSeguroTerceiro.Text = devolucao.seguroTerceiro.ToString();
                }

            }
        }

        public string ValidarCampos()
        {
            if(maskedTextBoxDataRetornoAtual.Text.Length != 10)
            {
                return "Data de Retorno Atual inválido";
            }
            
            if (!ValidarTipoInt(txtQuilometragemAtual.Text))
            {
                return "Quilometragem Atual inválido";
            }
            if (radioButtonCupomSim.Checked == true)
            {
                if (!ValidarCupom())
                    return "Cupom de Desconto inválido!";
                else
                {
                    Cupom cupom = (Cupom)comboBoxCupom.SelectedItem;
                    if (cupom.ValorMinimo > Convert.ToDouble(labelVariavelValorTotal.Text))
                        return "Valor total não cumpre os requisitos para utilizar este cupom. Valor minimo: " + cupom.ValorMinimo.ToString();
                }
            }
            
            return "ESTA_VALIDO";
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

        private void btnGravar_Click(object sender, EventArgs e)
        {
            MostrarResumoFinanceiro();
            string validacaoCampos = ValidarCampos();

            if (ValidarCampos().Equals("ESTA_VALIDO"))
            {
                DialogResult = DialogResult.OK;

                devolucao.emAberto = false;
                devolucao.Funcionario = TelaPrincipalForm.Instancia.funcionario;
                devolucao.dataDevolucao = Convert.ToDateTime(maskedTextBoxDataRetornoAtual.Text);
                devolucao.quilometragemDevolucao = Convert.ToDouble(txtQuilometragemAtual.Text);
                
                devolucao.Veiculo.Quilometragem = devolucao.quilometragemDevolucao;
                devolucao.valorTotal = Convert.ToDouble(labelVariavelValorFinal.Text);

                if (radioButtonCupomSim.Checked == true)
                   devolucao.Cupom = (Cupom)comboBoxCupom.SelectedItem;

                int id = Convert.ToInt32(txtIdLocacao.Text);
                string resultadoValidacaoDominio = devolucao.ValidarDevolucao();

                if (resultadoValidacaoDominio != "ESTA_VALIDO")
                {
                    string primeiroErroDominio = new StringReader(resultadoValidacaoDominio).ReadLine();

                    TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErroDominio);

                    DialogResult = DialogResult.None;
                }

            }
            else
            {
                string primeiroErro = new StringReader(validacaoCampos).ReadLine();
                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);
            }
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


        private void TelaDevolucaoForm_Load(object sender, EventArgs e)
        {
            if (devolucao != null)
                for (int i = 0; i <= (cListBoxTaxasServicos.Items.Count - 1); i++)
                {
                    foreach (TaxasServicos taxaServicoLocacao in locacaoAppService.SelecionarTaxasServicosPorLocacaoId(devolucao.Id))
                    {
                        if (taxaServicoLocacao.Equals((TaxasServicos)cListBoxTaxasServicos.Items[i]))
                            cListBoxTaxasServicos.SetItemChecked(i, true);
                    }
                }

            ObterValorCombustivel();
            MostrarResumoFinanceiro();
        }

        private void MostrarResumoFinanceiro()
        {
            MostrarDiasPrevistos();
            MostrarValorPlano();
            MostrarValorTaxasServicos();
            MostrarValorCombustivel();
            MostrarValorSeguros();
            MostrarValorTotal();
            MostrarValorDesconto();
            MostrarValorFinal();
        }

        private void MostrarDiasPrevistos()
        {
            try
            {
                DateTime dataLocacao = Convert.ToDateTime(maskedTextBoxDataLocacao.Text);
                DateTime dataDevolucao = Convert.ToDateTime(maskedTextBoxDataRetornoAtual.Text);
                double numeroDias = (dataDevolucao - dataLocacao).TotalDays;
                if (numeroDias > 0)
                    labelVariavelDiasPrevistos.Text = numeroDias.ToString();
                else
                    labelVariavelDiasPrevistos.Text = "0";
                
            }
            catch { }
        }

        private void MostrarValorPlano()
        {
            try
            {
                double custoPlanoLocacao = 0;
                GrupoVeiculo grupoVeiculoSelecionado = devolucao.GrupoVeiculo;
                string planoSelecionado = devolucao.plano;

                if (grupoVeiculoSelecionado != null && planoSelecionado != "")
                {
                    if (planoSelecionado == "Diário")
                    {
                        double valorDiario = grupoVeiculoSelecionado.planoDiarioValorDiario * Convert.ToDouble(labelVariavelDiasPrevistos.Text);
                        double valorKm = grupoVeiculoSelecionado.planoDiarioValorKm * (Convert.ToDouble(txtQuilometragemAtual.Text) - Convert.ToDouble(txtQuilometragemInicial.Text));
                        custoPlanoLocacao = valorDiario + valorKm;
                        labelVariavelCustosPlano.Text = custoPlanoLocacao.ToString();
                    }
                    else if (planoSelecionado == "Km Controlado")
                    {
                        double valorDiario = grupoVeiculoSelecionado.planoKmControladoValorDiario * Convert.ToDouble(labelVariavelDiasPrevistos.Text);
                        double valorKm = 0;
                        if (Convert.ToDouble(txtQuilometragemAtual.Text) - Convert.ToDouble(txtQuilometragemInicial.Text) > grupoVeiculoSelecionado.planoKmControladoQuantidadeKm)
                             valorKm = grupoVeiculoSelecionado.planoKmControladoValorKm * (Convert.ToDouble(txtQuilometragemAtual.Text) - Convert.ToDouble(txtQuilometragemInicial.Text) - grupoVeiculoSelecionado.planoKmControladoQuantidadeKm);
                        
                        custoPlanoLocacao = valorDiario + valorKm;
                        labelVariavelCustosPlano.Text = custoPlanoLocacao.ToString();
                    }
                    else if (planoSelecionado == "Km Livre")
                    {
                        double valorDiario = grupoVeiculoSelecionado.planoKmLivreValorDiario * Convert.ToDouble(labelVariavelDiasPrevistos.Text);
                        custoPlanoLocacao = valorDiario;
                        labelVariavelCustosPlano.Text = custoPlanoLocacao.ToString();
                    }

                    if (custoPlanoLocacao < 0)
                        labelVariavelCustosPlano.Text = "0";
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

        private void MostrarValorCombustivel()
        {
            try
            {
                double valorCombustivel = 0;
                valorCombustivel = valorCombustivelSelecionado * devolucao.Veiculo.QtdLitrosTanque * porcentagemCombustivelReposto;
                labelVariavelCombustivel.Text = valorCombustivel.ToString();
            }
            catch
            {
                labelVariavelCombustivel.Text = "0";
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

        private void MostrarValorTotal()
        {
            try
            {
                double valorTotal = Convert.ToDouble(labelVariavelCustosPlano.Text) + Convert.ToDouble(labelVariavelCombustivel.Text) + Convert.ToDouble(labelVariavelCustosTaxasServicos.Text) + Convert.ToDouble(labelVariavelSeguros.Text);
                labelVariavelValorTotal.Text = valorTotal.ToString();
            }
            catch { }

        }

        private void MostrarValorDesconto()
        {
            try
            {
                Cupom cupom = (Cupom)comboBoxCupom.SelectedItem;
                if (cupom != null)
                {
                    if (cupom.ValorFixo != 0)
                        labelVariavelDesconto.Text = cupom.ValorFixo.ToString();
                    else
                        labelVariavelDesconto.Text = cupom.ValorPercentual.ToString() + "%";
                }
            }
            catch
            {
                labelVariavelSeguros.Text = "0";
            }
        }

        private void MostrarValorFinal()
        {
            try
            {
                Cupom cupom = devolucao.Cupom;
                if (comboBoxCupom.SelectedItem != null)
                    cupom = (Cupom)comboBoxCupom.SelectedItem;
                double valorFinal = 0;

                if (cupom != null)
                {
                    if (cupom.ValorFixo != 0)
                    {
                        double valorTotal = Convert.ToDouble(labelVariavelValorTotal.Text);
                        valorFinal = valorTotal - cupom.ValorFixo;
                    }
                    else
                    {
                        double valorTotal = Convert.ToDouble(labelVariavelValorTotal.Text);
                        double percentualFinal = 100 - cupom.ValorPercentual;
                        valorFinal =  (valorTotal * percentualFinal) / 100;
                    }
                }
                else
                {
                    valorFinal = Convert.ToDouble(labelVariavelValorTotal.Text);
                }
                labelVariavelValorFinal.Text = valorFinal.ToString();
            }
            catch { }
        }


        private void ObterValorCombustivel() {

            if (devolucao.Veiculo.Combustivel == "Alcool")
                valorCombustivelSelecionado = Configuracao.PrecoAlcool;
            if (devolucao.Veiculo.Combustivel == "Diesel")
                valorCombustivelSelecionado = Configuracao.PrecoDiesel;
            if (devolucao.Veiculo.Combustivel == "Gasolina")
                valorCombustivelSelecionado = Configuracao.PrecoGasolina;
            if (devolucao.Veiculo.Combustivel == "Gas")
                valorCombustivelSelecionado = Configuracao.PrecoGas;
        }

        private void txtQuilometragemAtual_TextChanged(object sender, EventArgs e)
        {
            MostrarResumoFinanceiro();
        }

        private void maskedTextBoxDataRetornoAtual_TextChanged(object sender, EventArgs e)
        {
            MostrarResumoFinanceiro();
        }

        private void groupBoxLocacao_Enter(object sender, EventArgs e)
        {

        }

        private void rb100_CheckedChanged(object sender, EventArgs e)
        {
            if (rb100.Checked == true)
            {
                porcentagemCombustivelReposto = 1;
                MostrarResumoFinanceiro();
            }
        }

        private void rb75_CheckedChanged(object sender, EventArgs e)
        {
            if (rb75.Checked == true)
            { 
                porcentagemCombustivelReposto = 0.75;
                MostrarResumoFinanceiro();
            }
        }

        private void rb50_CheckedChanged(object sender, EventArgs e)
        {
            if (rb50.Checked == true)
            {
                porcentagemCombustivelReposto = 0.50;
                MostrarResumoFinanceiro();
            }
                
        }

        private void rb25_CheckedChanged(object sender, EventArgs e)
        {
            if (rb25.Checked == true)
            {
                porcentagemCombustivelReposto = 0.25;
                MostrarResumoFinanceiro();
            }
        }

        private void rbZero_CheckedChanged(object sender, EventArgs e)
        {
            if (rbZero.Checked == true)
            {
                porcentagemCombustivelReposto = 0;
                MostrarResumoFinanceiro();
            }
        }

        private bool ValidarCupom()
        {
            foreach (Cupom cupom in cupomAppService.SelecionarTodos())
            {
                if (cupom.Parceiro.Equals(comboBoxParceiro.SelectedItem))
                {
                    if (cupom.Equals(comboBoxCupom.SelectedItem) && cupom.Validar() == "ESTA_VALIDO")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void comboBoxParceiro_SelectedIndexChanged(object sender, EventArgs e)
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

        private void comboBoxCupom_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarResumoFinanceiro();
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

        private void txtQuilometragemAtual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtQuilometragemInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        #endregion
    }
}
