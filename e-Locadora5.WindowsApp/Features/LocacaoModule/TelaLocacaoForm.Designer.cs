
namespace e_Locadora5.WindowsApp.Features.LocacaoModule
{
    partial class TelaLocacaoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBoxResumoFinanceiro = new System.Windows.Forms.GroupBox();
            this.labelVariavelSeguros = new System.Windows.Forms.Label();
            this.labelSeguros = new System.Windows.Forms.Label();
            this.labelVariavelValorTotal = new System.Windows.Forms.Label();
            this.labelVariavelCustosTaxasServicos = new System.Windows.Forms.Label();
            this.labelVariavelCustosPlano = new System.Windows.Forms.Label();
            this.labelVariavelDiasPrevistos = new System.Windows.Forms.Label();
            this.labelCustosTaxasServicos = new System.Windows.Forms.Label();
            this.labelValorTotal = new System.Windows.Forms.Label();
            this.labelCustosPlano = new System.Windows.Forms.Label();
            this.labelDiasPrevistos = new System.Windows.Forms.Label();
            this.tabPageTaxasServicos = new System.Windows.Forms.TabPage();
            this.groupBoxTaxasServicos = new System.Windows.Forms.GroupBox();
            this.cListBoxTaxasServicos = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSeguroTerceiro = new System.Windows.Forms.MaskedTextBox();
            this.checkBoxSeguroTerceiro = new System.Windows.Forms.CheckBox();
            this.txtSeguroCliente = new System.Windows.Forms.MaskedTextBox();
            this.checkBoxSeguroCliente = new System.Windows.Forms.CheckBox();
            this.tabPageClienteVeiculo = new System.Windows.Forms.TabPage();
            this.cboxGrupoVeiculo = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuilometragemLocacao = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboxVeiculo = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboxCondutor = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboxCliente = new System.Windows.Forms.ComboBox();
            this.tabPageLocacao = new System.Windows.Forms.TabPage();
            this.groupBoxCupom = new System.Windows.Forms.GroupBox();
            this.comboBoxCupom = new System.Windows.Forms.ComboBox();
            this.radioButtonCupomNao = new System.Windows.Forms.RadioButton();
            this.radioButtonCupomSim = new System.Windows.Forms.RadioButton();
            this.labelCupom = new System.Windows.Forms.Label();
            this.comboBoxParceiro = new System.Windows.Forms.ComboBox();
            this.labelParceiros = new System.Windows.Forms.Label();
            this.txtCaucao = new System.Windows.Forms.TextBox();
            this.labelCaucao = new System.Windows.Forms.Label();
            this.txtFuncionario = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.maskedTextBoxDevolucao = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxLocacao = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxPlano = new System.Windows.Forms.ComboBox();
            this.labelDataLocacao = new System.Windows.Forms.Label();
            this.txtIdLocacao = new System.Windows.Forms.TextBox();
            this.labelPlano = new System.Windows.Forms.Label();
            this.tabControlLocacao = new System.Windows.Forms.TabControl();
            this.groupBoxResumoFinanceiro.SuspendLayout();
            this.tabPageTaxasServicos.SuspendLayout();
            this.groupBoxTaxasServicos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageClienteVeiculo.SuspendLayout();
            this.tabPageLocacao.SuspendLayout();
            this.groupBoxCupom.SuspendLayout();
            this.tabControlLocacao.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGravar
            // 
            this.btnGravar.Location = new System.Drawing.Point(356, 333);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 23);
            this.btnGravar.TabIndex = 83;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(437, 333);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 84;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // groupBoxResumoFinanceiro
            // 
            this.groupBoxResumoFinanceiro.Controls.Add(this.labelVariavelSeguros);
            this.groupBoxResumoFinanceiro.Controls.Add(this.labelSeguros);
            this.groupBoxResumoFinanceiro.Controls.Add(this.labelVariavelValorTotal);
            this.groupBoxResumoFinanceiro.Controls.Add(this.labelVariavelCustosTaxasServicos);
            this.groupBoxResumoFinanceiro.Controls.Add(this.labelVariavelCustosPlano);
            this.groupBoxResumoFinanceiro.Controls.Add(this.labelVariavelDiasPrevistos);
            this.groupBoxResumoFinanceiro.Controls.Add(this.labelCustosTaxasServicos);
            this.groupBoxResumoFinanceiro.Controls.Add(this.labelValorTotal);
            this.groupBoxResumoFinanceiro.Controls.Add(this.labelCustosPlano);
            this.groupBoxResumoFinanceiro.Controls.Add(this.labelDiasPrevistos);
            this.groupBoxResumoFinanceiro.Location = new System.Drawing.Point(271, 12);
            this.groupBoxResumoFinanceiro.Name = "groupBoxResumoFinanceiro";
            this.groupBoxResumoFinanceiro.Size = new System.Drawing.Size(241, 315);
            this.groupBoxResumoFinanceiro.TabIndex = 87;
            this.groupBoxResumoFinanceiro.TabStop = false;
            this.groupBoxResumoFinanceiro.Text = "Resumo Financeiro";
            // 
            // labelVariavelSeguros
            // 
            this.labelVariavelSeguros.AutoSize = true;
            this.labelVariavelSeguros.Location = new System.Drawing.Point(67, 133);
            this.labelVariavelSeguros.Name = "labelVariavelSeguros";
            this.labelVariavelSeguros.Size = new System.Drawing.Size(13, 13);
            this.labelVariavelSeguros.TabIndex = 9;
            this.labelVariavelSeguros.Text = "0";
            // 
            // labelSeguros
            // 
            this.labelSeguros.AutoSize = true;
            this.labelSeguros.Location = new System.Drawing.Point(6, 133);
            this.labelSeguros.Name = "labelSeguros";
            this.labelSeguros.Size = new System.Drawing.Size(55, 13);
            this.labelSeguros.TabIndex = 8;
            this.labelSeguros.Text = "Seguro(s):";
            // 
            // labelVariavelValorTotal
            // 
            this.labelVariavelValorTotal.AutoSize = true;
            this.labelVariavelValorTotal.Location = new System.Drawing.Point(73, 174);
            this.labelVariavelValorTotal.Name = "labelVariavelValorTotal";
            this.labelVariavelValorTotal.Size = new System.Drawing.Size(13, 13);
            this.labelVariavelValorTotal.TabIndex = 7;
            this.labelVariavelValorTotal.Text = "0";
            // 
            // labelVariavelCustosTaxasServicos
            // 
            this.labelVariavelCustosTaxasServicos.AutoSize = true;
            this.labelVariavelCustosTaxasServicos.Location = new System.Drawing.Point(104, 94);
            this.labelVariavelCustosTaxasServicos.Name = "labelVariavelCustosTaxasServicos";
            this.labelVariavelCustosTaxasServicos.Size = new System.Drawing.Size(13, 13);
            this.labelVariavelCustosTaxasServicos.TabIndex = 6;
            this.labelVariavelCustosTaxasServicos.Text = "0";
            // 
            // labelVariavelCustosPlano
            // 
            this.labelVariavelCustosPlano.AutoSize = true;
            this.labelVariavelCustosPlano.Location = new System.Drawing.Point(124, 58);
            this.labelVariavelCustosPlano.Name = "labelVariavelCustosPlano";
            this.labelVariavelCustosPlano.Size = new System.Drawing.Size(13, 13);
            this.labelVariavelCustosPlano.TabIndex = 5;
            this.labelVariavelCustosPlano.Text = "0";
            // 
            // labelVariavelDiasPrevistos
            // 
            this.labelVariavelDiasPrevistos.AutoSize = true;
            this.labelVariavelDiasPrevistos.Location = new System.Drawing.Point(70, 22);
            this.labelVariavelDiasPrevistos.Name = "labelVariavelDiasPrevistos";
            this.labelVariavelDiasPrevistos.Size = new System.Drawing.Size(13, 13);
            this.labelVariavelDiasPrevistos.TabIndex = 4;
            this.labelVariavelDiasPrevistos.Text = "0";
            // 
            // labelCustosTaxasServicos
            // 
            this.labelCustosTaxasServicos.AutoSize = true;
            this.labelCustosTaxasServicos.Location = new System.Drawing.Point(6, 94);
            this.labelCustosTaxasServicos.Name = "labelCustosTaxasServicos";
            this.labelCustosTaxasServicos.Size = new System.Drawing.Size(92, 13);
            this.labelCustosTaxasServicos.TabIndex = 3;
            this.labelCustosTaxasServicos.Text = "Taxas e Serviços:";
            // 
            // labelValorTotal
            // 
            this.labelValorTotal.AutoSize = true;
            this.labelValorTotal.Location = new System.Drawing.Point(6, 174);
            this.labelValorTotal.Name = "labelValorTotal";
            this.labelValorTotal.Size = new System.Drawing.Size(61, 13);
            this.labelValorTotal.TabIndex = 2;
            this.labelValorTotal.Text = "Valor Total:";
            // 
            // labelCustosPlano
            // 
            this.labelCustosPlano.AutoSize = true;
            this.labelCustosPlano.Location = new System.Drawing.Point(6, 58);
            this.labelCustosPlano.Name = "labelCustosPlano";
            this.labelCustosPlano.Size = new System.Drawing.Size(112, 13);
            this.labelCustosPlano.TabIndex = 1;
            this.labelCustosPlano.Text = "Custos Final do Plano:";
            // 
            // labelDiasPrevistos
            // 
            this.labelDiasPrevistos.AutoSize = true;
            this.labelDiasPrevistos.Location = new System.Drawing.Point(6, 22);
            this.labelDiasPrevistos.Name = "labelDiasPrevistos";
            this.labelDiasPrevistos.Size = new System.Drawing.Size(58, 13);
            this.labelDiasPrevistos.TabIndex = 0;
            this.labelDiasPrevistos.Text = "Total Dias:";
            // 
            // tabPageTaxasServicos
            // 
            this.tabPageTaxasServicos.Controls.Add(this.groupBoxTaxasServicos);
            this.tabPageTaxasServicos.Controls.Add(this.groupBox1);
            this.tabPageTaxasServicos.Location = new System.Drawing.Point(4, 22);
            this.tabPageTaxasServicos.Name = "tabPageTaxasServicos";
            this.tabPageTaxasServicos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTaxasServicos.Size = new System.Drawing.Size(258, 289);
            this.tabPageTaxasServicos.TabIndex = 4;
            this.tabPageTaxasServicos.Text = "Taxas e Serviços";
            this.tabPageTaxasServicos.UseVisualStyleBackColor = true;
            // 
            // groupBoxTaxasServicos
            // 
            this.groupBoxTaxasServicos.Controls.Add(this.cListBoxTaxasServicos);
            this.groupBoxTaxasServicos.Location = new System.Drawing.Point(5, 6);
            this.groupBoxTaxasServicos.Name = "groupBoxTaxasServicos";
            this.groupBoxTaxasServicos.Size = new System.Drawing.Size(245, 79);
            this.groupBoxTaxasServicos.TabIndex = 97;
            this.groupBoxTaxasServicos.TabStop = false;
            this.groupBoxTaxasServicos.Text = "Taxas e Serviços";
            // 
            // cListBoxTaxasServicos
            // 
            this.cListBoxTaxasServicos.FormattingEnabled = true;
            this.cListBoxTaxasServicos.Location = new System.Drawing.Point(6, 19);
            this.cListBoxTaxasServicos.Name = "cListBoxTaxasServicos";
            this.cListBoxTaxasServicos.Size = new System.Drawing.Size(220, 49);
            this.cListBoxTaxasServicos.TabIndex = 95;
            this.cListBoxTaxasServicos.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cListBoxTaxasServicos_ItemCheck);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSeguroTerceiro);
            this.groupBox1.Controls.Add(this.checkBoxSeguroTerceiro);
            this.groupBox1.Controls.Add(this.txtSeguroCliente);
            this.groupBox1.Controls.Add(this.checkBoxSeguroCliente);
            this.groupBox1.Location = new System.Drawing.Point(6, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 74);
            this.groupBox1.TabIndex = 96;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seguros";
            // 
            // txtSeguroTerceiro
            // 
            this.txtSeguroTerceiro.Enabled = false;
            this.txtSeguroTerceiro.Location = new System.Drawing.Point(121, 46);
            this.txtSeguroTerceiro.Mask = "000000000000000";
            this.txtSeguroTerceiro.Name = "txtSeguroTerceiro";
            this.txtSeguroTerceiro.Size = new System.Drawing.Size(104, 20);
            this.txtSeguroTerceiro.TabIndex = 10;
            this.txtSeguroTerceiro.Text = "0";
            this.txtSeguroTerceiro.TextChanged += new System.EventHandler(this.txtSeguroTerceiro_TextChanged);
            // 
            // checkBoxSeguroTerceiro
            // 
            this.checkBoxSeguroTerceiro.AutoSize = true;
            this.checkBoxSeguroTerceiro.Location = new System.Drawing.Point(13, 47);
            this.checkBoxSeguroTerceiro.Name = "checkBoxSeguroTerceiro";
            this.checkBoxSeguroTerceiro.Size = new System.Drawing.Size(102, 17);
            this.checkBoxSeguroTerceiro.TabIndex = 1;
            this.checkBoxSeguroTerceiro.Text = "Seguro Terceiro";
            this.checkBoxSeguroTerceiro.UseVisualStyleBackColor = true;
            this.checkBoxSeguroTerceiro.CheckedChanged += new System.EventHandler(this.checkBoxSeguroTerceiro_CheckedChanged);
            // 
            // txtSeguroCliente
            // 
            this.txtSeguroCliente.Enabled = false;
            this.txtSeguroCliente.Location = new System.Drawing.Point(121, 20);
            this.txtSeguroCliente.Mask = "000000000000000";
            this.txtSeguroCliente.Name = "txtSeguroCliente";
            this.txtSeguroCliente.Size = new System.Drawing.Size(104, 20);
            this.txtSeguroCliente.TabIndex = 4;
            this.txtSeguroCliente.Text = "0";
            this.txtSeguroCliente.ValidatingType = typeof(int);
            this.txtSeguroCliente.TextChanged += new System.EventHandler(this.txtSeguroCliente_TextChanged);
            // 
            // checkBoxSeguroCliente
            // 
            this.checkBoxSeguroCliente.AutoSize = true;
            this.checkBoxSeguroCliente.Location = new System.Drawing.Point(13, 22);
            this.checkBoxSeguroCliente.Name = "checkBoxSeguroCliente";
            this.checkBoxSeguroCliente.Size = new System.Drawing.Size(95, 17);
            this.checkBoxSeguroCliente.TabIndex = 0;
            this.checkBoxSeguroCliente.Text = "Seguro Cliente";
            this.checkBoxSeguroCliente.UseVisualStyleBackColor = true;
            this.checkBoxSeguroCliente.CheckedChanged += new System.EventHandler(this.checkBoxCliente_CheckedChanged);
            // 
            // tabPageClienteVeiculo
            // 
            this.tabPageClienteVeiculo.Controls.Add(this.cboxGrupoVeiculo);
            this.tabPageClienteVeiculo.Controls.Add(this.label13);
            this.tabPageClienteVeiculo.Controls.Add(this.label1);
            this.tabPageClienteVeiculo.Controls.Add(this.txtQuilometragemLocacao);
            this.tabPageClienteVeiculo.Controls.Add(this.label5);
            this.tabPageClienteVeiculo.Controls.Add(this.cboxVeiculo);
            this.tabPageClienteVeiculo.Controls.Add(this.label12);
            this.tabPageClienteVeiculo.Controls.Add(this.cboxCondutor);
            this.tabPageClienteVeiculo.Controls.Add(this.label6);
            this.tabPageClienteVeiculo.Controls.Add(this.cboxCliente);
            this.tabPageClienteVeiculo.Location = new System.Drawing.Point(4, 22);
            this.tabPageClienteVeiculo.Name = "tabPageClienteVeiculo";
            this.tabPageClienteVeiculo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClienteVeiculo.Size = new System.Drawing.Size(258, 289);
            this.tabPageClienteVeiculo.TabIndex = 1;
            this.tabPageClienteVeiculo.Text = "Cliente e Veículo";
            this.tabPageClienteVeiculo.UseVisualStyleBackColor = true;
            // 
            // cboxGrupoVeiculo
            // 
            this.cboxGrupoVeiculo.FormattingEnabled = true;
            this.cboxGrupoVeiculo.Location = new System.Drawing.Point(113, 78);
            this.cboxGrupoVeiculo.Name = "cboxGrupoVeiculo";
            this.cboxGrupoVeiculo.Size = new System.Drawing.Size(104, 21);
            this.cboxGrupoVeiculo.TabIndex = 32;
            this.cboxGrupoVeiculo.SelectedIndexChanged += new System.EventHandler(this.cboxGrupoVeiculo_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(55, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "Categoria";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Veiculo";
            // 
            // txtQuilometragemLocacao
            // 
            this.txtQuilometragemLocacao.Enabled = false;
            this.txtQuilometragemLocacao.Location = new System.Drawing.Point(113, 133);
            this.txtQuilometragemLocacao.Name = "txtQuilometragemLocacao";
            this.txtQuilometragemLocacao.Size = new System.Drawing.Size(104, 20);
            this.txtQuilometragemLocacao.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Quilometragem Atual";
            // 
            // cboxVeiculo
            // 
            this.cboxVeiculo.FormattingEnabled = true;
            this.cboxVeiculo.Location = new System.Drawing.Point(113, 106);
            this.cboxVeiculo.Name = "cboxVeiculo";
            this.cboxVeiculo.Size = new System.Drawing.Size(104, 21);
            this.cboxVeiculo.TabIndex = 27;
            this.cboxVeiculo.SelectedIndexChanged += new System.EventHandler(this.cboxVeiculo_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(57, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Condutor";
            // 
            // cboxCondutor
            // 
            this.cboxCondutor.FormattingEnabled = true;
            this.cboxCondutor.Location = new System.Drawing.Point(113, 49);
            this.cboxCondutor.Name = "cboxCondutor";
            this.cboxCondutor.Size = new System.Drawing.Size(104, 21);
            this.cboxCondutor.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Cliente";
            // 
            // cboxCliente
            // 
            this.cboxCliente.FormattingEnabled = true;
            this.cboxCliente.Location = new System.Drawing.Point(113, 22);
            this.cboxCliente.Name = "cboxCliente";
            this.cboxCliente.Size = new System.Drawing.Size(104, 21);
            this.cboxCliente.TabIndex = 15;
            this.cboxCliente.SelectedIndexChanged += new System.EventHandler(this.cboxCliente_SelectedIndexChanged);
            // 
            // tabPageLocacao
            // 
            this.tabPageLocacao.Controls.Add(this.groupBoxCupom);
            this.tabPageLocacao.Controls.Add(this.txtCaucao);
            this.tabPageLocacao.Controls.Add(this.labelCaucao);
            this.tabPageLocacao.Controls.Add(this.txtFuncionario);
            this.tabPageLocacao.Controls.Add(this.label8);
            this.tabPageLocacao.Controls.Add(this.maskedTextBoxDevolucao);
            this.tabPageLocacao.Controls.Add(this.maskedTextBoxLocacao);
            this.tabPageLocacao.Controls.Add(this.label4);
            this.tabPageLocacao.Controls.Add(this.label2);
            this.tabPageLocacao.Controls.Add(this.cboxPlano);
            this.tabPageLocacao.Controls.Add(this.labelDataLocacao);
            this.tabPageLocacao.Controls.Add(this.txtIdLocacao);
            this.tabPageLocacao.Controls.Add(this.labelPlano);
            this.tabPageLocacao.Location = new System.Drawing.Point(4, 22);
            this.tabPageLocacao.Name = "tabPageLocacao";
            this.tabPageLocacao.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLocacao.Size = new System.Drawing.Size(258, 289);
            this.tabPageLocacao.TabIndex = 0;
            this.tabPageLocacao.Text = "Locação";
            this.tabPageLocacao.UseVisualStyleBackColor = true;
            // 
            // groupBoxCupom
            // 
            this.groupBoxCupom.Controls.Add(this.comboBoxCupom);
            this.groupBoxCupom.Controls.Add(this.radioButtonCupomNao);
            this.groupBoxCupom.Controls.Add(this.radioButtonCupomSim);
            this.groupBoxCupom.Controls.Add(this.labelCupom);
            this.groupBoxCupom.Controls.Add(this.comboBoxParceiro);
            this.groupBoxCupom.Controls.Add(this.labelParceiros);
            this.groupBoxCupom.Location = new System.Drawing.Point(6, 164);
            this.groupBoxCupom.Name = "groupBoxCupom";
            this.groupBoxCupom.Size = new System.Drawing.Size(246, 119);
            this.groupBoxCupom.TabIndex = 88;
            this.groupBoxCupom.TabStop = false;
            this.groupBoxCupom.Text = "Cupom de Desconto";
            // 
            // comboBoxCupom
            // 
            this.comboBoxCupom.Enabled = false;
            this.comboBoxCupom.FormattingEnabled = true;
            this.comboBoxCupom.Location = new System.Drawing.Point(99, 81);
            this.comboBoxCupom.Name = "comboBoxCupom";
            this.comboBoxCupom.Size = new System.Drawing.Size(113, 21);
            this.comboBoxCupom.TabIndex = 35;
            // 
            // radioButtonCupomNao
            // 
            this.radioButtonCupomNao.AutoSize = true;
            this.radioButtonCupomNao.Checked = true;
            this.radioButtonCupomNao.Location = new System.Drawing.Point(62, 19);
            this.radioButtonCupomNao.Name = "radioButtonCupomNao";
            this.radioButtonCupomNao.Size = new System.Drawing.Size(45, 17);
            this.radioButtonCupomNao.TabIndex = 34;
            this.radioButtonCupomNao.TabStop = true;
            this.radioButtonCupomNao.Text = "Não";
            this.radioButtonCupomNao.UseVisualStyleBackColor = true;
            this.radioButtonCupomNao.CheckedChanged += new System.EventHandler(this.radioButtonCupomNao_CheckedChanged);
            // 
            // radioButtonCupomSim
            // 
            this.radioButtonCupomSim.AutoSize = true;
            this.radioButtonCupomSim.Location = new System.Drawing.Point(11, 20);
            this.radioButtonCupomSim.Name = "radioButtonCupomSim";
            this.radioButtonCupomSim.Size = new System.Drawing.Size(42, 17);
            this.radioButtonCupomSim.TabIndex = 33;
            this.radioButtonCupomSim.TabStop = true;
            this.radioButtonCupomSim.Text = "Sim";
            this.radioButtonCupomSim.UseVisualStyleBackColor = true;
            this.radioButtonCupomSim.CheckedChanged += new System.EventHandler(this.radioButtonCupomSim_CheckedChanged);
            // 
            // labelCupom
            // 
            this.labelCupom.AutoSize = true;
            this.labelCupom.Location = new System.Drawing.Point(54, 85);
            this.labelCupom.Name = "labelCupom";
            this.labelCupom.Size = new System.Drawing.Size(40, 13);
            this.labelCupom.TabIndex = 32;
            this.labelCupom.Text = "Cupom";
            // 
            // comboBoxParceiro
            // 
            this.comboBoxParceiro.Enabled = false;
            this.comboBoxParceiro.FormattingEnabled = true;
            this.comboBoxParceiro.Location = new System.Drawing.Point(100, 54);
            this.comboBoxParceiro.Name = "comboBoxParceiro";
            this.comboBoxParceiro.Size = new System.Drawing.Size(113, 21);
            this.comboBoxParceiro.TabIndex = 29;
            this.comboBoxParceiro.SelectedIndexChanged += new System.EventHandler(this.comboBoxParceiro_SelectedIndexChanged);
            // 
            // labelParceiros
            // 
            this.labelParceiros.AutoSize = true;
            this.labelParceiros.Location = new System.Drawing.Point(48, 57);
            this.labelParceiros.Name = "labelParceiros";
            this.labelParceiros.Size = new System.Drawing.Size(46, 13);
            this.labelParceiros.TabIndex = 30;
            this.labelParceiros.Text = "Parceiro";
            this.labelParceiros.Click += new System.EventHandler(this.labelParceiros_Click);
            // 
            // txtCaucao
            // 
            this.txtCaucao.Location = new System.Drawing.Point(105, 138);
            this.txtCaucao.Name = "txtCaucao";
            this.txtCaucao.Size = new System.Drawing.Size(77, 20);
            this.txtCaucao.TabIndex = 28;
            // 
            // labelCaucao
            // 
            this.labelCaucao.AutoSize = true;
            this.labelCaucao.Location = new System.Drawing.Point(55, 141);
            this.labelCaucao.Name = "labelCaucao";
            this.labelCaucao.Size = new System.Drawing.Size(44, 13);
            this.labelCaucao.TabIndex = 27;
            this.labelCaucao.Text = "Caução";
            // 
            // txtFuncionario
            // 
            this.txtFuncionario.Enabled = false;
            this.txtFuncionario.Location = new System.Drawing.Point(106, 60);
            this.txtFuncionario.Name = "txtFuncionario";
            this.txtFuncionario.Size = new System.Drawing.Size(113, 20);
            this.txtFuncionario.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Funcionário";
            // 
            // maskedTextBoxDevolucao
            // 
            this.maskedTextBoxDevolucao.Location = new System.Drawing.Point(105, 112);
            this.maskedTextBoxDevolucao.Mask = "00/00/0000";
            this.maskedTextBoxDevolucao.Name = "maskedTextBoxDevolucao";
            this.maskedTextBoxDevolucao.Size = new System.Drawing.Size(77, 20);
            this.maskedTextBoxDevolucao.TabIndex = 24;
            this.maskedTextBoxDevolucao.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxDevolucao.TextChanged += new System.EventHandler(this.maskedTextBoxDevolucao_TextChanged);
            // 
            // maskedTextBoxLocacao
            // 
            this.maskedTextBoxLocacao.Location = new System.Drawing.Point(105, 86);
            this.maskedTextBoxLocacao.Mask = "00/00/0000";
            this.maskedTextBoxLocacao.Name = "maskedTextBoxLocacao";
            this.maskedTextBoxLocacao.Size = new System.Drawing.Size(77, 20);
            this.maskedTextBoxLocacao.TabIndex = 23;
            this.maskedTextBoxLocacao.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxLocacao.TextChanged += new System.EventHandler(this.maskedTextBoxLocacao_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Data Devolução";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "ID";
            // 
            // cboxPlano
            // 
            this.cboxPlano.FormattingEnabled = true;
            this.cboxPlano.Items.AddRange(new object[] {
            "Diário",
            "Km Controlado",
            "Km Livre"});
            this.cboxPlano.Location = new System.Drawing.Point(105, 32);
            this.cboxPlano.Name = "cboxPlano";
            this.cboxPlano.Size = new System.Drawing.Size(114, 21);
            this.cboxPlano.TabIndex = 14;
            this.cboxPlano.SelectedIndexChanged += new System.EventHandler(this.cboxPlano_SelectedIndexChanged);
            // 
            // labelDataLocacao
            // 
            this.labelDataLocacao.AutoSize = true;
            this.labelDataLocacao.Location = new System.Drawing.Point(24, 89);
            this.labelDataLocacao.Name = "labelDataLocacao";
            this.labelDataLocacao.Size = new System.Drawing.Size(75, 13);
            this.labelDataLocacao.TabIndex = 19;
            this.labelDataLocacao.Text = "Data Locação";
            // 
            // txtIdLocacao
            // 
            this.txtIdLocacao.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtIdLocacao.Enabled = false;
            this.txtIdLocacao.Location = new System.Drawing.Point(105, 6);
            this.txtIdLocacao.Name = "txtIdLocacao";
            this.txtIdLocacao.Size = new System.Drawing.Size(77, 20);
            this.txtIdLocacao.TabIndex = 1;
            this.txtIdLocacao.Text = "0";
            // 
            // labelPlano
            // 
            this.labelPlano.AutoSize = true;
            this.labelPlano.Location = new System.Drawing.Point(65, 35);
            this.labelPlano.Name = "labelPlano";
            this.labelPlano.Size = new System.Drawing.Size(34, 13);
            this.labelPlano.TabIndex = 15;
            this.labelPlano.Text = "Plano";
            // 
            // tabControlLocacao
            // 
            this.tabControlLocacao.Controls.Add(this.tabPageLocacao);
            this.tabControlLocacao.Controls.Add(this.tabPageClienteVeiculo);
            this.tabControlLocacao.Controls.Add(this.tabPageTaxasServicos);
            this.tabControlLocacao.Location = new System.Drawing.Point(5, 12);
            this.tabControlLocacao.Name = "tabControlLocacao";
            this.tabControlLocacao.SelectedIndex = 0;
            this.tabControlLocacao.Size = new System.Drawing.Size(266, 315);
            this.tabControlLocacao.TabIndex = 86;
            // 
            // TelaLocacaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 368);
            this.Controls.Add(this.groupBoxResumoFinanceiro);
            this.Controls.Add(this.tabControlLocacao);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaLocacaoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de Locações";
            this.Load += new System.EventHandler(this.TelaLocacaoForm_Load);
            this.groupBoxResumoFinanceiro.ResumeLayout(false);
            this.groupBoxResumoFinanceiro.PerformLayout();
            this.tabPageTaxasServicos.ResumeLayout(false);
            this.groupBoxTaxasServicos.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageClienteVeiculo.ResumeLayout(false);
            this.tabPageClienteVeiculo.PerformLayout();
            this.tabPageLocacao.ResumeLayout(false);
            this.tabPageLocacao.PerformLayout();
            this.groupBoxCupom.ResumeLayout(false);
            this.groupBoxCupom.PerformLayout();
            this.tabControlLocacao.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBoxResumoFinanceiro;
        private System.Windows.Forms.Label labelCustosTaxasServicos;
        private System.Windows.Forms.Label labelValorTotal;
        private System.Windows.Forms.Label labelCustosPlano;
        private System.Windows.Forms.Label labelDiasPrevistos;
        private System.Windows.Forms.TabPage tabPageTaxasServicos;
        private System.Windows.Forms.GroupBox groupBoxTaxasServicos;
        private System.Windows.Forms.CheckedListBox cListBoxTaxasServicos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxSeguroTerceiro;
        private System.Windows.Forms.CheckBox checkBoxSeguroCliente;
        private System.Windows.Forms.TabPage tabPageClienteVeiculo;
        private System.Windows.Forms.ComboBox cboxGrupoVeiculo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuilometragemLocacao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboxVeiculo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboxCondutor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboxCliente;
        private System.Windows.Forms.TabPage tabPageLocacao;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDevolucao;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxLocacao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboxPlano;
        private System.Windows.Forms.Label labelDataLocacao;
        private System.Windows.Forms.TextBox txtIdLocacao;
        private System.Windows.Forms.Label labelPlano;
        private System.Windows.Forms.TabControl tabControlLocacao;
        private System.Windows.Forms.Label labelVariavelDiasPrevistos;
        private System.Windows.Forms.Label labelVariavelCustosPlano;
        private System.Windows.Forms.Label labelVariavelCustosTaxasServicos;
        private System.Windows.Forms.Label labelVariavelValorTotal;
        private System.Windows.Forms.Label labelVariavelSeguros;
        private System.Windows.Forms.Label labelSeguros;
        private System.Windows.Forms.MaskedTextBox txtSeguroTerceiro;
        private System.Windows.Forms.MaskedTextBox txtSeguroCliente;
        private System.Windows.Forms.TextBox txtFuncionario;
        private System.Windows.Forms.TextBox txtCaucao;
        private System.Windows.Forms.Label labelCaucao;
        private System.Windows.Forms.GroupBox groupBoxCupom;
        private System.Windows.Forms.Label labelParceiros;
        private System.Windows.Forms.ComboBox comboBoxParceiro;
        private System.Windows.Forms.Label labelCupom;
        private System.Windows.Forms.RadioButton radioButtonCupomNao;
        private System.Windows.Forms.RadioButton radioButtonCupomSim;
        private System.Windows.Forms.ComboBox comboBoxCupom;
    }
}