using e_Locadora5.Configuracoes;
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

namespace e_Locadora5.WindowsApp.Features.DevolucaoModule
{
    public partial class TelaDevolucaoForm : Form
    {
        private Locacao devolucao;
        private double valorCombustivelSelecionado;
        private double porcentagemCombustivelReposto = 1;

        ControladorClientes controladorCliente = new ControladorClientes();
        ControladorCondutor controladorCondutor = new ControladorCondutor();
        ControladorGrupoVeiculo controladorGrupoVeiculo = new ControladorGrupoVeiculo();
        ControladorVeiculos controladorVeiculo = new ControladorVeiculos();
        ControladorLocacao controladorLocacao = new ControladorLocacao();
        ControladorFuncionario controladorFuncionario = new ControladorFuncionario();
        ControladorTaxasServicos controladorTaxasServicos = new ControladorTaxasServicos();
        ControladorParceiro controladorParceiro = new ControladorParceiro();
        ControladorCupons controladorCupom = new ControladorCupons();

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
                txtCategoria.Text = devolucao.veiculo.GrupoVeiculo.ToString();
                txtVeiculo.Text = devolucao.veiculo.ToString();
                txtCliente.Text = devolucao.cliente.ToString();
                txtCondutor.Text = devolucao.condutor.ToString();
                maskedTextBoxDataLocacao.Text = devolucao.dataLocacao.ToString();
                maskedTextBoxDataRetornoPrevisto.Text = devolucao.dataDevolucao.ToString();
                maskedTextBoxDataRetornoAtual.Text = Convert.ToDateTime(DateTime.Now).ToString();
                txtTipoCombustivel.Text = devolucao.veiculo.Combustivel.ToString();
                txtQuilometragemInicial.Text = devolucao.veiculo.Quilometragem.ToString();

                if (devolucao.cupom != null)
                {
                    radioButtonCupomSim.Checked = true;
                    comboBoxParceiro.SelectedItem = devolucao.cupom.Parceiro;
                    comboBoxCupom.SelectedItem = devolucao.cupom;
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
            
            if (!ValidarCupom())
                return "Cupom de Desconto inválido!";
            else 
            {
                Cupons cupom = (Cupons)comboBoxCupom.SelectedItem;
                if (cupom.ValorMinimo > Convert.ToDouble(labelVariavelValorTotal.Text))
                    return "Valor total não cumpre os requisitos para utilizar este cupom. Valor minimo: "+cupom.ValorMinimo.ToString();
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
                devolucao.funcionario = TelaPrincipalForm.Instancia.funcionario;
                devolucao.dataDevolucao = Convert.ToDateTime(maskedTextBoxDataRetornoAtual.Text);
                devolucao.quilometragemDevolucao = Convert.ToDouble(txtQuilometragemAtual.Text);
                
                devolucao.veiculo.Quilometragem = devolucao.quilometragemDevolucao;
                devolucao.valorTotal = Convert.ToDouble(labelVariavelValorFinal.Text);

                if (radioButtonCupomSim.Checked == true)
                   devolucao.cupom = (Cupons)comboBoxCupom.SelectedItem;

                int id = Convert.ToInt32(txtIdLocacao.Text);
                string resultadoValidacaoDominio = devolucao.ValidarDevolucao();

                string resultadoValidacaoControlador = controladorLocacao.ValidarLocacao(devolucao, id);

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


        private void TelaDevolucaoForm_Load(object sender, EventArgs e)
        {
            if (devolucao != null)
                for (int i = 0; i <= (cListBoxTaxasServicos.Items.Count - 1); i++)
                {
                    foreach (TaxasServicos taxaServicoLocacao in controladorLocacao.SelecionarTaxasServicosPorLocacaoId(devolucao.Id))
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
                GrupoVeiculo grupoVeiculoSelecionado = devolucao.grupoVeiculo;
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
                valorCombustivel = valorCombustivelSelecionado * devolucao.veiculo.QtdLitrosTanque * porcentagemCombustivelReposto;
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
                Cupons cupom = (Cupons)comboBoxCupom.SelectedItem;
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
                Cupons cupom = devolucao.cupom;
                if (comboBoxCupom.SelectedItem != null)
                    cupom = (Cupons)comboBoxCupom.SelectedItem;
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

            if (devolucao.veiculo.Combustivel == "Alcool")
                valorCombustivelSelecionado = Configuracao.PrecoAlcool;
            if (devolucao.veiculo.Combustivel == "Diesel")
                valorCombustivelSelecionado = Configuracao.PrecoDiesel;
            if (devolucao.veiculo.Combustivel == "Gasolina")
                valorCombustivelSelecionado = Configuracao.PrecoGasolina;
            if (devolucao.veiculo.Combustivel == "Gas")
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
            foreach (Cupons cupom in controladorCupom.SelecionarTodos())
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
            foreach (Cupons cupom in controladorCupom.SelecionarTodos())
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
    }   
}
