
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
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(416, 384);
            this.btnGravar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(88, 26);
            this.btnGravar.TabIndex = 83;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(510, 384);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(88, 26);
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
            this.groupBoxResumoFinanceiro.Location = new System.Drawing.Point(316, 14);
            this.groupBoxResumoFinanceiro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxResumoFinanceiro.Name = "groupBoxResumoFinanceiro";
            this.groupBoxResumoFinanceiro.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxResumoFinanceiro.Size = new System.Drawing.Size(281, 364);
            this.groupBoxResumoFinanceiro.TabIndex = 87;
            this.groupBoxResumoFinanceiro.TabStop = false;
            this.groupBoxResumoFinanceiro.Text = "Resumo Financeiro";
            // 
            // labelVariavelSeguros
            // 
            this.labelVariavelSeguros.AutoSize = true;
            this.labelVariavelSeguros.Location = new System.Drawing.Point(78, 154);
            this.labelVariavelSeguros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelVariavelSeguros.Name = "labelVariavelSeguros";
            this.labelVariavelSeguros.Size = new System.Drawing.Size(13, 15);
            this.labelVariavelSeguros.TabIndex = 9;
            this.labelVariavelSeguros.Text = "0";
            // 
            // labelSeguros
            // 
            this.labelSeguros.AutoSize = true;
            this.labelSeguros.Location = new System.Drawing.Point(7, 154);
            this.labelSeguros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSeguros.Name = "labelSeguros";
            this.labelSeguros.Size = new System.Drawing.Size(60, 15);
            this.labelSeguros.TabIndex = 8;
            this.labelSeguros.Text = "Seguro(s):";
            // 
            // labelVariavelValorTotal
            // 
            this.labelVariavelValorTotal.AutoSize = true;
            this.labelVariavelValorTotal.Location = new System.Drawing.Point(85, 201);
            this.labelVariavelValorTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelVariavelValorTotal.Name = "labelVariavelValorTotal";
            this.labelVariavelValorTotal.Size = new System.Drawing.Size(13, 15);
            this.labelVariavelValorTotal.TabIndex = 7;
            this.labelVariavelValorTotal.Text = "0";
            // 
            // labelVariavelCustosTaxasServicos
            // 
            this.labelVariavelCustosTaxasServicos.AutoSize = true;
            this.labelVariavelCustosTaxasServicos.Location = new System.Drawing.Point(122, 109);
            this.labelVariavelCustosTaxasServicos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelVariavelCustosTaxasServicos.Name = "labelVariavelCustosTaxasServicos";
            this.labelVariavelCustosTaxasServicos.Size = new System.Drawing.Size(13, 15);
            this.labelVariavelCustosTaxasServicos.TabIndex = 6;
            this.labelVariavelCustosTaxasServicos.Text = "0";
            // 
            // labelVariavelCustosPlano
            // 
            this.labelVariavelCustosPlano.AutoSize = true;
            this.labelVariavelCustosPlano.Location = new System.Drawing.Point(144, 67);
            this.labelVariavelCustosPlano.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelVariavelCustosPlano.Name = "labelVariavelCustosPlano";
            this.labelVariavelCustosPlano.Size = new System.Drawing.Size(13, 15);
            this.labelVariavelCustosPlano.TabIndex = 5;
            this.labelVariavelCustosPlano.Text = "0";
            // 
            // labelVariavelDiasPrevistos
            // 
            this.labelVariavelDiasPrevistos.AutoSize = true;
            this.labelVariavelDiasPrevistos.Location = new System.Drawing.Point(81, 26);
            this.labelVariavelDiasPrevistos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelVariavelDiasPrevistos.Name = "labelVariavelDiasPrevistos";
            this.labelVariavelDiasPrevistos.Size = new System.Drawing.Size(13, 15);
            this.labelVariavelDiasPrevistos.TabIndex = 4;
            this.labelVariavelDiasPrevistos.Text = "0";
            // 
            // labelCustosTaxasServicos
            // 
            this.labelCustosTaxasServicos.AutoSize = true;
            this.labelCustosTaxasServicos.Location = new System.Drawing.Point(7, 109);
            this.labelCustosTaxasServicos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCustosTaxasServicos.Name = "labelCustosTaxasServicos";
            this.labelCustosTaxasServicos.Size = new System.Drawing.Size(93, 15);
            this.labelCustosTaxasServicos.TabIndex = 3;
            this.labelCustosTaxasServicos.Text = "Taxas e Serviços:";
            // 
            // labelValorTotal
            // 
            this.labelValorTotal.AutoSize = true;
            this.labelValorTotal.Location = new System.Drawing.Point(7, 201);
            this.labelValorTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelValorTotal.Name = "labelValorTotal";
            this.labelValorTotal.Size = new System.Drawing.Size(65, 15);
            this.labelValorTotal.TabIndex = 2;
            this.labelValorTotal.Text = "Valor Total:";
            // 
            // labelCustosPlano
            // 
            this.labelCustosPlano.AutoSize = true;
            this.labelCustosPlano.Location = new System.Drawing.Point(7, 67);
            this.labelCustosPlano.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCustosPlano.Name = "labelCustosPlano";
            this.labelCustosPlano.Size = new System.Drawing.Size(124, 15);
            this.labelCustosPlano.TabIndex = 1;
            this.labelCustosPlano.Text = "Custos Final do Plano:";
            // 
            // labelDiasPrevistos
            // 
            this.labelDiasPrevistos.AutoSize = true;
            this.labelDiasPrevistos.Location = new System.Drawing.Point(7, 26);
            this.labelDiasPrevistos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDiasPrevistos.Name = "labelDiasPrevistos";
            this.labelDiasPrevistos.Size = new System.Drawing.Size(61, 15);
            this.labelDiasPrevistos.TabIndex = 0;
            this.labelDiasPrevistos.Text = "Total Dias:";
            // 
            // tabPageTaxasServicos
            // 
            this.tabPageTaxasServicos.Controls.Add(this.groupBoxTaxasServicos);
            this.tabPageTaxasServicos.Controls.Add(this.groupBox1);
            this.tabPageTaxasServicos.Location = new System.Drawing.Point(4, 24);
            this.tabPageTaxasServicos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageTaxasServicos.Name = "tabPageTaxasServicos";
            this.tabPageTaxasServicos.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageTaxasServicos.Size = new System.Drawing.Size(303, 336);
            this.tabPageTaxasServicos.TabIndex = 4;
            this.tabPageTaxasServicos.Text = "Taxas e Serviços";
            this.tabPageTaxasServicos.UseVisualStyleBackColor = true;
            // 
            // groupBoxTaxasServicos
            // 
            this.groupBoxTaxasServicos.Controls.Add(this.cListBoxTaxasServicos);
            this.groupBoxTaxasServicos.Location = new System.Drawing.Point(6, 7);
            this.groupBoxTaxasServicos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxTaxasServicos.Name = "groupBoxTaxasServicos";
            this.groupBoxTaxasServicos.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxTaxasServicos.Size = new System.Drawing.Size(286, 92);
            this.groupBoxTaxasServicos.TabIndex = 97;
            this.groupBoxTaxasServicos.TabStop = false;
            this.groupBoxTaxasServicos.Text = "Taxas e Serviços";
            // 
            // cListBoxTaxasServicos
            // 
            this.cListBoxTaxasServicos.FormattingEnabled = true;
            this.cListBoxTaxasServicos.Location = new System.Drawing.Point(7, 22);
            this.cListBoxTaxasServicos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cListBoxTaxasServicos.Name = "cListBoxTaxasServicos";
            this.cListBoxTaxasServicos.Size = new System.Drawing.Size(256, 40);
            this.cListBoxTaxasServicos.TabIndex = 95;
            this.cListBoxTaxasServicos.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cListBoxTaxasServicos_ItemCheck);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSeguroTerceiro);
            this.groupBox1.Controls.Add(this.checkBoxSeguroTerceiro);
            this.groupBox1.Controls.Add(this.txtSeguroCliente);
            this.groupBox1.Controls.Add(this.checkBoxSeguroCliente);
            this.groupBox1.Location = new System.Drawing.Point(7, 105);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(284, 86);
            this.groupBox1.TabIndex = 96;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seguros";
            // 
            // txtSeguroTerceiro
            // 
            this.txtSeguroTerceiro.Enabled = false;
            this.txtSeguroTerceiro.Location = new System.Drawing.Point(141, 53);
            this.txtSeguroTerceiro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSeguroTerceiro.Mask = "000000000000000";
            this.txtSeguroTerceiro.Name = "txtSeguroTerceiro";
            this.txtSeguroTerceiro.Size = new System.Drawing.Size(120, 23);
            this.txtSeguroTerceiro.TabIndex = 10;
            this.txtSeguroTerceiro.Text = "0";
            this.txtSeguroTerceiro.TextChanged += new System.EventHandler(this.txtSeguroTerceiro_TextChanged);
            this.txtSeguroTerceiro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSeguroTerceiro_KeyPress);
            // 
            // checkBoxSeguroTerceiro
            // 
            this.checkBoxSeguroTerceiro.AutoSize = true;
            this.checkBoxSeguroTerceiro.Location = new System.Drawing.Point(15, 54);
            this.checkBoxSeguroTerceiro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxSeguroTerceiro.Name = "checkBoxSeguroTerceiro";
            this.checkBoxSeguroTerceiro.Size = new System.Drawing.Size(108, 19);
            this.checkBoxSeguroTerceiro.TabIndex = 1;
            this.checkBoxSeguroTerceiro.Text = "Seguro Terceiro";
            this.checkBoxSeguroTerceiro.UseVisualStyleBackColor = true;
            this.checkBoxSeguroTerceiro.CheckedChanged += new System.EventHandler(this.checkBoxSeguroTerceiro_CheckedChanged);
            // 
            // txtSeguroCliente
            // 
            this.txtSeguroCliente.Enabled = false;
            this.txtSeguroCliente.Location = new System.Drawing.Point(141, 23);
            this.txtSeguroCliente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSeguroCliente.Mask = "000000000000000";
            this.txtSeguroCliente.Name = "txtSeguroCliente";
            this.txtSeguroCliente.Size = new System.Drawing.Size(120, 23);
            this.txtSeguroCliente.TabIndex = 4;
            this.txtSeguroCliente.Text = "0";
            this.txtSeguroCliente.ValidatingType = typeof(int);
            this.txtSeguroCliente.TextChanged += new System.EventHandler(this.txtSeguroCliente_TextChanged);
            this.txtSeguroCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSeguroCliente_KeyPress);
            // 
            // checkBoxSeguroCliente
            // 
            this.checkBoxSeguroCliente.AutoSize = true;
            this.checkBoxSeguroCliente.Location = new System.Drawing.Point(15, 26);
            this.checkBoxSeguroCliente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxSeguroCliente.Name = "checkBoxSeguroCliente";
            this.checkBoxSeguroCliente.Size = new System.Drawing.Size(103, 19);
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
            this.tabPageClienteVeiculo.Location = new System.Drawing.Point(4, 24);
            this.tabPageClienteVeiculo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageClienteVeiculo.Name = "tabPageClienteVeiculo";
            this.tabPageClienteVeiculo.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageClienteVeiculo.Size = new System.Drawing.Size(303, 336);
            this.tabPageClienteVeiculo.TabIndex = 1;
            this.tabPageClienteVeiculo.Text = "Cliente e Veículo";
            this.tabPageClienteVeiculo.UseVisualStyleBackColor = true;
            // 
            // cboxGrupoVeiculo
            // 
            this.cboxGrupoVeiculo.FormattingEnabled = true;
            this.cboxGrupoVeiculo.Location = new System.Drawing.Point(132, 90);
            this.cboxGrupoVeiculo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboxGrupoVeiculo.Name = "cboxGrupoVeiculo";
            this.cboxGrupoVeiculo.Size = new System.Drawing.Size(120, 23);
            this.cboxGrupoVeiculo.TabIndex = 32;
            this.cboxGrupoVeiculo.SelectedIndexChanged += new System.EventHandler(this.cboxGrupoVeiculo_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(64, 94);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 15);
            this.label13.TabIndex = 31;
            this.label13.Text = "Categoria";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 126);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 30;
            this.label1.Text = "Veiculo";
            // 
            // txtQuilometragemLocacao
            // 
            this.txtQuilometragemLocacao.Enabled = false;
            this.txtQuilometragemLocacao.Location = new System.Drawing.Point(132, 154);
            this.txtQuilometragemLocacao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtQuilometragemLocacao.Name = "txtQuilometragemLocacao";
            this.txtQuilometragemLocacao.Size = new System.Drawing.Size(120, 23);
            this.txtQuilometragemLocacao.TabIndex = 29;
            this.txtQuilometragemLocacao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuilometragemLocacao_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 157);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 15);
            this.label5.TabIndex = 28;
            this.label5.Text = "Quilometragem Atual";
            // 
            // cboxVeiculo
            // 
            this.cboxVeiculo.FormattingEnabled = true;
            this.cboxVeiculo.Location = new System.Drawing.Point(132, 122);
            this.cboxVeiculo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboxVeiculo.Name = "cboxVeiculo";
            this.cboxVeiculo.Size = new System.Drawing.Size(120, 23);
            this.cboxVeiculo.TabIndex = 27;
            this.cboxVeiculo.SelectedIndexChanged += new System.EventHandler(this.cboxVeiculo_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(66, 60);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 15);
            this.label12.TabIndex = 20;
            this.label12.Text = "Condutor";
            // 
            // cboxCondutor
            // 
            this.cboxCondutor.FormattingEnabled = true;
            this.cboxCondutor.Location = new System.Drawing.Point(132, 56);
            this.cboxCondutor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboxCondutor.Name = "cboxCondutor";
            this.cboxCondutor.Size = new System.Drawing.Size(120, 23);
            this.cboxCondutor.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(80, 28);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Cliente";
            // 
            // cboxCliente
            // 
            this.cboxCliente.FormattingEnabled = true;
            this.cboxCliente.Location = new System.Drawing.Point(132, 26);
            this.cboxCliente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboxCliente.Name = "cboxCliente";
            this.cboxCliente.Size = new System.Drawing.Size(120, 23);
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
            this.tabPageLocacao.Location = new System.Drawing.Point(4, 24);
            this.tabPageLocacao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageLocacao.Name = "tabPageLocacao";
            this.tabPageLocacao.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageLocacao.Size = new System.Drawing.Size(303, 336);
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
            this.groupBoxCupom.Location = new System.Drawing.Point(7, 189);
            this.groupBoxCupom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxCupom.Name = "groupBoxCupom";
            this.groupBoxCupom.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxCupom.Size = new System.Drawing.Size(287, 137);
            this.groupBoxCupom.TabIndex = 88;
            this.groupBoxCupom.TabStop = false;
            this.groupBoxCupom.Text = "Cupom de Desconto";
            // 
            // comboBoxCupom
            // 
            this.comboBoxCupom.Enabled = false;
            this.comboBoxCupom.FormattingEnabled = true;
            this.comboBoxCupom.Location = new System.Drawing.Point(116, 94);
            this.comboBoxCupom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxCupom.Name = "comboBoxCupom";
            this.comboBoxCupom.Size = new System.Drawing.Size(131, 23);
            this.comboBoxCupom.TabIndex = 35;
            // 
            // radioButtonCupomNao
            // 
            this.radioButtonCupomNao.AutoSize = true;
            this.radioButtonCupomNao.Checked = true;
            this.radioButtonCupomNao.Location = new System.Drawing.Point(73, 22);
            this.radioButtonCupomNao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonCupomNao.Name = "radioButtonCupomNao";
            this.radioButtonCupomNao.Size = new System.Drawing.Size(47, 19);
            this.radioButtonCupomNao.TabIndex = 34;
            this.radioButtonCupomNao.TabStop = true;
            this.radioButtonCupomNao.Text = "Não";
            this.radioButtonCupomNao.UseVisualStyleBackColor = true;
            this.radioButtonCupomNao.CheckedChanged += new System.EventHandler(this.radioButtonCupomNao_CheckedChanged);
            // 
            // radioButtonCupomSim
            // 
            this.radioButtonCupomSim.AutoSize = true;
            this.radioButtonCupomSim.Location = new System.Drawing.Point(13, 23);
            this.radioButtonCupomSim.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonCupomSim.Name = "radioButtonCupomSim";
            this.radioButtonCupomSim.Size = new System.Drawing.Size(45, 19);
            this.radioButtonCupomSim.TabIndex = 33;
            this.radioButtonCupomSim.TabStop = true;
            this.radioButtonCupomSim.Text = "Sim";
            this.radioButtonCupomSim.UseVisualStyleBackColor = true;
            this.radioButtonCupomSim.CheckedChanged += new System.EventHandler(this.radioButtonCupomSim_CheckedChanged);
            // 
            // labelCupom
            // 
            this.labelCupom.AutoSize = true;
            this.labelCupom.Location = new System.Drawing.Point(63, 98);
            this.labelCupom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCupom.Name = "labelCupom";
            this.labelCupom.Size = new System.Drawing.Size(47, 15);
            this.labelCupom.TabIndex = 32;
            this.labelCupom.Text = "Cupom";
            // 
            // comboBoxParceiro
            // 
            this.comboBoxParceiro.Enabled = false;
            this.comboBoxParceiro.FormattingEnabled = true;
            this.comboBoxParceiro.Location = new System.Drawing.Point(116, 62);
            this.comboBoxParceiro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxParceiro.Name = "comboBoxParceiro";
            this.comboBoxParceiro.Size = new System.Drawing.Size(131, 23);
            this.comboBoxParceiro.TabIndex = 29;
            this.comboBoxParceiro.SelectedIndexChanged += new System.EventHandler(this.comboBoxParceiro_SelectedIndexChanged);
            // 
            // labelParceiros
            // 
            this.labelParceiros.AutoSize = true;
            this.labelParceiros.Location = new System.Drawing.Point(56, 66);
            this.labelParceiros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelParceiros.Name = "labelParceiros";
            this.labelParceiros.Size = new System.Drawing.Size(50, 15);
            this.labelParceiros.TabIndex = 30;
            this.labelParceiros.Text = "Parceiro";
            this.labelParceiros.Click += new System.EventHandler(this.labelParceiros_Click);
            // 
            // txtCaucao
            // 
            this.txtCaucao.Location = new System.Drawing.Point(122, 159);
            this.txtCaucao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCaucao.Name = "txtCaucao";
            this.txtCaucao.Size = new System.Drawing.Size(89, 23);
            this.txtCaucao.TabIndex = 28;
            this.txtCaucao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCaucao_KeyPress);
            // 
            // labelCaucao
            // 
            this.labelCaucao.AutoSize = true;
            this.labelCaucao.Location = new System.Drawing.Point(64, 163);
            this.labelCaucao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCaucao.Name = "labelCaucao";
            this.labelCaucao.Size = new System.Drawing.Size(47, 15);
            this.labelCaucao.TabIndex = 27;
            this.labelCaucao.Text = "Caução";
            // 
            // txtFuncionario
            // 
            this.txtFuncionario.Enabled = false;
            this.txtFuncionario.Location = new System.Drawing.Point(123, 69);
            this.txtFuncionario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFuncionario.Name = "txtFuncionario";
            this.txtFuncionario.Size = new System.Drawing.Size(131, 23);
            this.txtFuncionario.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 71);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 15);
            this.label8.TabIndex = 25;
            this.label8.Text = "Funcionário";
            // 
            // maskedTextBoxDevolucao
            // 
            this.maskedTextBoxDevolucao.Location = new System.Drawing.Point(122, 129);
            this.maskedTextBoxDevolucao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.maskedTextBoxDevolucao.Mask = "00/00/0000";
            this.maskedTextBoxDevolucao.Name = "maskedTextBoxDevolucao";
            this.maskedTextBoxDevolucao.Size = new System.Drawing.Size(89, 23);
            this.maskedTextBoxDevolucao.TabIndex = 24;
            this.maskedTextBoxDevolucao.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxDevolucao.TextChanged += new System.EventHandler(this.maskedTextBoxDevolucao_TextChanged);
            // 
            // maskedTextBoxLocacao
            // 
            this.maskedTextBoxLocacao.Location = new System.Drawing.Point(122, 99);
            this.maskedTextBoxLocacao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.maskedTextBoxLocacao.Mask = "00/00/0000";
            this.maskedTextBoxLocacao.Name = "maskedTextBoxLocacao";
            this.maskedTextBoxLocacao.Size = new System.Drawing.Size(89, 23);
            this.maskedTextBoxLocacao.TabIndex = 23;
            this.maskedTextBoxLocacao.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxLocacao.TextChanged += new System.EventHandler(this.maskedTextBoxLocacao_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 133);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "Data Devolução";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 15);
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
            this.cboxPlano.Location = new System.Drawing.Point(122, 37);
            this.cboxPlano.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboxPlano.Name = "cboxPlano";
            this.cboxPlano.Size = new System.Drawing.Size(133, 23);
            this.cboxPlano.TabIndex = 14;
            this.cboxPlano.SelectedIndexChanged += new System.EventHandler(this.cboxPlano_SelectedIndexChanged);
            // 
            // labelDataLocacao
            // 
            this.labelDataLocacao.AutoSize = true;
            this.labelDataLocacao.Location = new System.Drawing.Point(28, 103);
            this.labelDataLocacao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDataLocacao.Name = "labelDataLocacao";
            this.labelDataLocacao.Size = new System.Drawing.Size(78, 15);
            this.labelDataLocacao.TabIndex = 19;
            this.labelDataLocacao.Text = "Data Locação";
            // 
            // txtIdLocacao
            // 
            this.txtIdLocacao.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtIdLocacao.Enabled = false;
            this.txtIdLocacao.Location = new System.Drawing.Point(122, 7);
            this.txtIdLocacao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIdLocacao.Name = "txtIdLocacao";
            this.txtIdLocacao.Size = new System.Drawing.Size(89, 23);
            this.txtIdLocacao.TabIndex = 1;
            this.txtIdLocacao.Text = "0";
            // 
            // labelPlano
            // 
            this.labelPlano.AutoSize = true;
            this.labelPlano.Location = new System.Drawing.Point(76, 40);
            this.labelPlano.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPlano.Name = "labelPlano";
            this.labelPlano.Size = new System.Drawing.Size(37, 15);
            this.labelPlano.TabIndex = 15;
            this.labelPlano.Text = "Plano";
            // 
            // tabControlLocacao
            // 
            this.tabControlLocacao.Controls.Add(this.tabPageLocacao);
            this.tabControlLocacao.Controls.Add(this.tabPageClienteVeiculo);
            this.tabControlLocacao.Controls.Add(this.tabPageTaxasServicos);
            this.tabControlLocacao.Location = new System.Drawing.Point(6, 14);
            this.tabControlLocacao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControlLocacao.Name = "tabControlLocacao";
            this.tabControlLocacao.SelectedIndex = 0;
            this.tabControlLocacao.Size = new System.Drawing.Size(311, 364);
            this.tabControlLocacao.TabIndex = 86;
            // 
            // TelaLocacaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 424);
            this.Controls.Add(this.groupBoxResumoFinanceiro);
            this.Controls.Add(this.tabControlLocacao);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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