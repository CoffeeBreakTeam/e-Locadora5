
namespace e_Locadora5.WindowsApp.Features.VeiculoModule
{
    partial class TelaVeiculoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaVeiculoForm));
            this.pictureBoxVeiculo = new System.Windows.Forms.PictureBox();
            this.btnImagem = new System.Windows.Forms.Button();
            this.groupBoxImagemVeiculo = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.txtChassi = new System.Windows.Forms.TextBox();
            this.txtCor = new System.Windows.Forms.TextBox();
            this.txtQtdPortas = new System.Windows.Forms.TextBox();
            this.txtCapacidadeTanque = new System.Windows.Forms.TextBox();
            this.txtFabricante = new System.Windows.Forms.TextBox();
            this.labelPlaca = new System.Windows.Forms.Label();
            this.labelChassi = new System.Windows.Forms.Label();
            this.labelCor = new System.Windows.Forms.Label();
            this.labelFabricante = new System.Windows.Forms.Label();
            this.labelCapacidadeTanque = new System.Windows.Forms.Label();
            this.labelQtdPortas = new System.Windows.Forms.Label();
            this.labelAno = new System.Windows.Forms.Label();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.labelCapacidadePessoas = new System.Windows.Forms.Label();
            this.txtCapacidadePessoas = new System.Windows.Forms.TextBox();
            this.comboBoxCombustivel = new System.Windows.Forms.ComboBox();
            this.labelCombustivel = new System.Windows.Forms.Label();
            this.labelPortaMalas = new System.Windows.Forms.Label();
            this.comboBoxPortaMalas = new System.Windows.Forms.ComboBox();
            this.id = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.labelGrupoVeiculo = new System.Windows.Forms.Label();
            this.comboBoxGrupoVeiculo = new System.Windows.Forms.ComboBox();
            this.labelQuilometragem = new System.Windows.Forms.Label();
            this.labelModelo = new System.Windows.Forms.Label();
            this.txtQuilometragem = new System.Windows.Forms.TextBox();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.groupBoxDadosVeiculo = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVeiculo)).BeginInit();
            this.groupBoxImagemVeiculo.SuspendLayout();
            this.groupBoxDadosVeiculo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxVeiculo
            // 
            this.pictureBoxVeiculo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxVeiculo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxVeiculo.Image = global::e_Locadora5.WindowsApp.Properties.Resources.fundoPictureBoxVeiculo;
            this.pictureBoxVeiculo.Location = new System.Drawing.Point(4, 19);
            this.pictureBoxVeiculo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBoxVeiculo.Name = "pictureBoxVeiculo";
            this.pictureBoxVeiculo.Size = new System.Drawing.Size(459, 365);
            this.pictureBoxVeiculo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxVeiculo.TabIndex = 0;
            this.pictureBoxVeiculo.TabStop = false;
            // 
            // btnImagem
            // 
            this.btnImagem.Location = new System.Drawing.Point(286, 415);
            this.btnImagem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnImagem.Name = "btnImagem";
            this.btnImagem.Size = new System.Drawing.Size(124, 27);
            this.btnImagem.TabIndex = 14;
            this.btnImagem.Text = "Procurar Imagem";
            this.btnImagem.UseVisualStyleBackColor = true;
            this.btnImagem.Click += new System.EventHandler(this.btnImagem_Click);
            // 
            // groupBoxImagemVeiculo
            // 
            this.groupBoxImagemVeiculo.Controls.Add(this.pictureBoxVeiculo);
            this.groupBoxImagemVeiculo.Location = new System.Drawing.Point(282, 22);
            this.groupBoxImagemVeiculo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxImagemVeiculo.Name = "groupBoxImagemVeiculo";
            this.groupBoxImagemVeiculo.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxImagemVeiculo.Size = new System.Drawing.Size(467, 387);
            this.groupBoxImagemVeiculo.TabIndex = 28;
            this.groupBoxImagemVeiculo.TabStop = false;
            this.groupBoxImagemVeiculo.Text = "Imagem do Veículo";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(698, 478);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(88, 27);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.Location = new System.Drawing.Point(603, 478);
            this.btnGravar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(88, 27);
            this.btnGravar.TabIndex = 15;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // txtPlaca
            // 
            this.txtPlaca.Location = new System.Drawing.Point(148, 52);
            this.txtPlaca.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPlaca.MaxLength = 7;
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(116, 23);
            this.txtPlaca.TabIndex = 1;
            // 
            // txtChassi
            // 
            this.txtChassi.Location = new System.Drawing.Point(148, 172);
            this.txtChassi.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtChassi.Name = "txtChassi";
            this.txtChassi.Size = new System.Drawing.Size(116, 23);
            this.txtChassi.TabIndex = 5;
            // 
            // txtCor
            // 
            this.txtCor.Location = new System.Drawing.Point(148, 203);
            this.txtCor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCor.Name = "txtCor";
            this.txtCor.Size = new System.Drawing.Size(116, 23);
            this.txtCor.TabIndex = 6;
            // 
            // txtQtdPortas
            // 
            this.txtQtdPortas.Location = new System.Drawing.Point(148, 263);
            this.txtQtdPortas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtQtdPortas.Name = "txtQtdPortas";
            this.txtQtdPortas.Size = new System.Drawing.Size(116, 23);
            this.txtQtdPortas.TabIndex = 8;
            // 
            // txtCapacidadeTanque
            // 
            this.txtCapacidadeTanque.Location = new System.Drawing.Point(148, 233);
            this.txtCapacidadeTanque.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCapacidadeTanque.Name = "txtCapacidadeTanque";
            this.txtCapacidadeTanque.Size = new System.Drawing.Size(116, 23);
            this.txtCapacidadeTanque.TabIndex = 7;
            // 
            // txtFabricante
            // 
            this.txtFabricante.Location = new System.Drawing.Point(148, 112);
            this.txtFabricante.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtFabricante.Name = "txtFabricante";
            this.txtFabricante.Size = new System.Drawing.Size(116, 23);
            this.txtFabricante.TabIndex = 3;
            // 
            // labelPlaca
            // 
            this.labelPlaca.AutoSize = true;
            this.labelPlaca.Location = new System.Drawing.Point(10, 55);
            this.labelPlaca.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPlaca.Name = "labelPlaca";
            this.labelPlaca.Size = new System.Drawing.Size(35, 15);
            this.labelPlaca.TabIndex = 18;
            this.labelPlaca.Text = "Placa";
            // 
            // labelChassi
            // 
            this.labelChassi.AutoSize = true;
            this.labelChassi.Location = new System.Drawing.Point(10, 175);
            this.labelChassi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelChassi.Name = "labelChassi";
            this.labelChassi.Size = new System.Drawing.Size(41, 15);
            this.labelChassi.TabIndex = 22;
            this.labelChassi.Text = "Chassi";
            // 
            // labelCor
            // 
            this.labelCor.AutoSize = true;
            this.labelCor.Location = new System.Drawing.Point(10, 207);
            this.labelCor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCor.Name = "labelCor";
            this.labelCor.Size = new System.Drawing.Size(26, 15);
            this.labelCor.TabIndex = 23;
            this.labelCor.Text = "Cor";
            // 
            // labelFabricante
            // 
            this.labelFabricante.AutoSize = true;
            this.labelFabricante.Location = new System.Drawing.Point(10, 115);
            this.labelFabricante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFabricante.Name = "labelFabricante";
            this.labelFabricante.Size = new System.Drawing.Size(62, 15);
            this.labelFabricante.TabIndex = 20;
            this.labelFabricante.Text = "Fabricante";
            // 
            // labelCapacidadeTanque
            // 
            this.labelCapacidadeTanque.AutoSize = true;
            this.labelCapacidadeTanque.Location = new System.Drawing.Point(10, 237);
            this.labelCapacidadeTanque.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCapacidadeTanque.Name = "labelCapacidadeTanque";
            this.labelCapacidadeTanque.Size = new System.Drawing.Size(128, 15);
            this.labelCapacidadeTanque.TabIndex = 24;
            this.labelCapacidadeTanque.Text = "Capacidade Tanque (L)";
            // 
            // labelQtdPortas
            // 
            this.labelQtdPortas.AutoSize = true;
            this.labelQtdPortas.Location = new System.Drawing.Point(10, 267);
            this.labelQtdPortas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelQtdPortas.Name = "labelQtdPortas";
            this.labelQtdPortas.Size = new System.Drawing.Size(121, 15);
            this.labelQtdPortas.TabIndex = 25;
            this.labelQtdPortas.Text = "Quantidade de Portas";
            // 
            // labelAno
            // 
            this.labelAno.AutoSize = true;
            this.labelAno.Location = new System.Drawing.Point(10, 297);
            this.labelAno.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAno.Name = "labelAno";
            this.labelAno.Size = new System.Drawing.Size(105, 15);
            this.labelAno.TabIndex = 26;
            this.labelAno.Text = "Ano de Fabricação";
            // 
            // txtAno
            // 
            this.txtAno.Location = new System.Drawing.Point(148, 293);
            this.txtAno.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(116, 23);
            this.txtAno.TabIndex = 9;
            // 
            // labelCapacidadePessoas
            // 
            this.labelCapacidadePessoas.AutoSize = true;
            this.labelCapacidadePessoas.Location = new System.Drawing.Point(10, 327);
            this.labelCapacidadePessoas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCapacidadePessoas.Name = "labelCapacidadePessoas";
            this.labelCapacidadePessoas.Size = new System.Drawing.Size(113, 15);
            this.labelCapacidadePessoas.TabIndex = 27;
            this.labelCapacidadePessoas.Text = "Capacidade Pessoas";
            // 
            // txtCapacidadePessoas
            // 
            this.txtCapacidadePessoas.Location = new System.Drawing.Point(148, 323);
            this.txtCapacidadePessoas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCapacidadePessoas.Name = "txtCapacidadePessoas";
            this.txtCapacidadePessoas.Size = new System.Drawing.Size(116, 23);
            this.txtCapacidadePessoas.TabIndex = 10;
            // 
            // comboBoxCombustivel
            // 
            this.comboBoxCombustivel.FormattingEnabled = true;
            this.comboBoxCombustivel.Items.AddRange(new object[] {
            "Gasolina",
            "Alcool",
            "Diesel",
            "Gas"});
            this.comboBoxCombustivel.Location = new System.Drawing.Point(148, 384);
            this.comboBoxCombustivel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxCombustivel.Name = "comboBoxCombustivel";
            this.comboBoxCombustivel.Size = new System.Drawing.Size(116, 23);
            this.comboBoxCombustivel.TabIndex = 12;
            // 
            // labelCombustivel
            // 
            this.labelCombustivel.AutoSize = true;
            this.labelCombustivel.Location = new System.Drawing.Point(10, 388);
            this.labelCombustivel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCombustivel.Name = "labelCombustivel";
            this.labelCombustivel.Size = new System.Drawing.Size(74, 15);
            this.labelCombustivel.TabIndex = 30;
            this.labelCombustivel.Text = "Combustível";
            // 
            // labelPortaMalas
            // 
            this.labelPortaMalas.AutoSize = true;
            this.labelPortaMalas.Location = new System.Drawing.Point(10, 421);
            this.labelPortaMalas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPortaMalas.Name = "labelPortaMalas";
            this.labelPortaMalas.Size = new System.Drawing.Size(124, 15);
            this.labelPortaMalas.TabIndex = 31;
            this.labelPortaMalas.Text = "Tamanho Porta-Malas";
            // 
            // comboBoxPortaMalas
            // 
            this.comboBoxPortaMalas.FormattingEnabled = true;
            this.comboBoxPortaMalas.Items.AddRange(new object[] {
            "Pequeno",
            "Médio",
            "Grande"});
            this.comboBoxPortaMalas.Location = new System.Drawing.Point(148, 418);
            this.comboBoxPortaMalas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxPortaMalas.Name = "comboBoxPortaMalas";
            this.comboBoxPortaMalas.Size = new System.Drawing.Size(116, 23);
            this.comboBoxPortaMalas.TabIndex = 13;
            // 
            // id
            // 
            this.id.AutoSize = true;
            this.id.Location = new System.Drawing.Point(10, 25);
            this.id.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(18, 15);
            this.id.TabIndex = 17;
            this.id.Text = "ID";
            this.id.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(148, 22);
            this.txtId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(116, 23);
            this.txtId.TabIndex = 26;
            this.txtId.Text = "0";
            // 
            // labelGrupoVeiculo
            // 
            this.labelGrupoVeiculo.AutoSize = true;
            this.labelGrupoVeiculo.Location = new System.Drawing.Point(10, 357);
            this.labelGrupoVeiculo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGrupoVeiculo.Name = "labelGrupoVeiculo";
            this.labelGrupoVeiculo.Size = new System.Drawing.Size(98, 15);
            this.labelGrupoVeiculo.TabIndex = 29;
            this.labelGrupoVeiculo.Text = "Grupo do Veículo";
            // 
            // comboBoxGrupoVeiculo
            // 
            this.comboBoxGrupoVeiculo.FormattingEnabled = true;
            this.comboBoxGrupoVeiculo.Location = new System.Drawing.Point(148, 353);
            this.comboBoxGrupoVeiculo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxGrupoVeiculo.Name = "comboBoxGrupoVeiculo";
            this.comboBoxGrupoVeiculo.Size = new System.Drawing.Size(116, 23);
            this.comboBoxGrupoVeiculo.TabIndex = 11;
            // 
            // labelQuilometragem
            // 
            this.labelQuilometragem.AutoSize = true;
            this.labelQuilometragem.Location = new System.Drawing.Point(10, 145);
            this.labelQuilometragem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelQuilometragem.Name = "labelQuilometragem";
            this.labelQuilometragem.Size = new System.Drawing.Size(91, 15);
            this.labelQuilometragem.TabIndex = 21;
            this.labelQuilometragem.Text = "Quilometragem";
            // 
            // labelModelo
            // 
            this.labelModelo.AutoSize = true;
            this.labelModelo.Location = new System.Drawing.Point(10, 85);
            this.labelModelo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelModelo.Name = "labelModelo";
            this.labelModelo.Size = new System.Drawing.Size(48, 15);
            this.labelModelo.TabIndex = 19;
            this.labelModelo.Text = "Modelo";
            // 
            // txtQuilometragem
            // 
            this.txtQuilometragem.Location = new System.Drawing.Point(148, 142);
            this.txtQuilometragem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtQuilometragem.Name = "txtQuilometragem";
            this.txtQuilometragem.Size = new System.Drawing.Size(116, 23);
            this.txtQuilometragem.TabIndex = 4;
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(148, 82);
            this.txtModelo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtModelo.MaxLength = 7;
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(116, 23);
            this.txtModelo.TabIndex = 2;
            // 
            // groupBoxDadosVeiculo
            // 
            this.groupBoxDadosVeiculo.Controls.Add(this.groupBoxImagemVeiculo);
            this.groupBoxDadosVeiculo.Controls.Add(this.labelQuilometragem);
            this.groupBoxDadosVeiculo.Controls.Add(this.btnImagem);
            this.groupBoxDadosVeiculo.Controls.Add(this.labelModelo);
            this.groupBoxDadosVeiculo.Controls.Add(this.txtId);
            this.groupBoxDadosVeiculo.Controls.Add(this.txtQuilometragem);
            this.groupBoxDadosVeiculo.Controls.Add(this.txtPlaca);
            this.groupBoxDadosVeiculo.Controls.Add(this.txtModelo);
            this.groupBoxDadosVeiculo.Controls.Add(this.txtChassi);
            this.groupBoxDadosVeiculo.Controls.Add(this.labelGrupoVeiculo);
            this.groupBoxDadosVeiculo.Controls.Add(this.txtCor);
            this.groupBoxDadosVeiculo.Controls.Add(this.comboBoxGrupoVeiculo);
            this.groupBoxDadosVeiculo.Controls.Add(this.txtFabricante);
            this.groupBoxDadosVeiculo.Controls.Add(this.txtCapacidadeTanque);
            this.groupBoxDadosVeiculo.Controls.Add(this.id);
            this.groupBoxDadosVeiculo.Controls.Add(this.txtQtdPortas);
            this.groupBoxDadosVeiculo.Controls.Add(this.labelPortaMalas);
            this.groupBoxDadosVeiculo.Controls.Add(this.labelPlaca);
            this.groupBoxDadosVeiculo.Controls.Add(this.comboBoxPortaMalas);
            this.groupBoxDadosVeiculo.Controls.Add(this.labelChassi);
            this.groupBoxDadosVeiculo.Controls.Add(this.labelCombustivel);
            this.groupBoxDadosVeiculo.Controls.Add(this.labelCor);
            this.groupBoxDadosVeiculo.Controls.Add(this.comboBoxCombustivel);
            this.groupBoxDadosVeiculo.Controls.Add(this.labelFabricante);
            this.groupBoxDadosVeiculo.Controls.Add(this.labelCapacidadePessoas);
            this.groupBoxDadosVeiculo.Controls.Add(this.labelCapacidadeTanque);
            this.groupBoxDadosVeiculo.Controls.Add(this.txtCapacidadePessoas);
            this.groupBoxDadosVeiculo.Controls.Add(this.labelQtdPortas);
            this.groupBoxDadosVeiculo.Controls.Add(this.labelAno);
            this.groupBoxDadosVeiculo.Controls.Add(this.txtAno);
            this.groupBoxDadosVeiculo.Location = new System.Drawing.Point(14, 14);
            this.groupBoxDadosVeiculo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxDadosVeiculo.Name = "groupBoxDadosVeiculo";
            this.groupBoxDadosVeiculo.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxDadosVeiculo.Size = new System.Drawing.Size(771, 457);
            this.groupBoxDadosVeiculo.TabIndex = 32;
            this.groupBoxDadosVeiculo.TabStop = false;
            this.groupBoxDadosVeiculo.Text = "Informações do Veículo";
            // 
            // TelaVeiculoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 512);
            this.Controls.Add(this.groupBoxDadosVeiculo);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaVeiculoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Veículo";
            this.Load += new System.EventHandler(this.TelaVeiculoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVeiculo)).EndInit();
            this.groupBoxImagemVeiculo.ResumeLayout(false);
            this.groupBoxDadosVeiculo.ResumeLayout(false);
            this.groupBoxDadosVeiculo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxVeiculo;
        private System.Windows.Forms.Button btnImagem;
        private System.Windows.Forms.GroupBox groupBoxImagemVeiculo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.TextBox txtChassi;
        private System.Windows.Forms.TextBox txtCor;
        private System.Windows.Forms.TextBox txtQtdPortas;
        private System.Windows.Forms.TextBox txtCapacidadeTanque;
        private System.Windows.Forms.TextBox txtFabricante;
        private System.Windows.Forms.Label labelPlaca;
        private System.Windows.Forms.Label labelChassi;
        private System.Windows.Forms.Label labelCor;
        private System.Windows.Forms.Label labelFabricante;
        private System.Windows.Forms.Label labelCapacidadeTanque;
        private System.Windows.Forms.Label labelQtdPortas;
        private System.Windows.Forms.Label labelAno;
        private System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.Label labelCapacidadePessoas;
        private System.Windows.Forms.TextBox txtCapacidadePessoas;
        private System.Windows.Forms.ComboBox comboBoxCombustivel;
        private System.Windows.Forms.Label labelCombustivel;
        private System.Windows.Forms.Label labelPortaMalas;
        private System.Windows.Forms.ComboBox comboBoxPortaMalas;
        private System.Windows.Forms.Label id;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label labelGrupoVeiculo;
        private System.Windows.Forms.ComboBox comboBoxGrupoVeiculo;
        private System.Windows.Forms.Label labelQuilometragem;
        private System.Windows.Forms.Label labelModelo;
        private System.Windows.Forms.TextBox txtQuilometragem;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.GroupBox groupBoxDadosVeiculo;
    }
}