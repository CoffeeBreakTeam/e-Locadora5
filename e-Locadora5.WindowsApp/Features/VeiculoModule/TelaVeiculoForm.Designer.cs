
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
            this.pictureBoxVeiculo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxVeiculo.Location = new System.Drawing.Point(3, 16);
            this.pictureBoxVeiculo.Name = "pictureBoxVeiculo";
            this.pictureBoxVeiculo.Size = new System.Drawing.Size(394, 316);
            this.pictureBoxVeiculo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxVeiculo.TabIndex = 0;
            this.pictureBoxVeiculo.TabStop = false;
            // 
            // btnImagem
            // 
            this.btnImagem.Location = new System.Drawing.Point(245, 360);
            this.btnImagem.Name = "btnImagem";
            this.btnImagem.Size = new System.Drawing.Size(106, 23);
            this.btnImagem.TabIndex = 14;
            this.btnImagem.Text = "Procurar Imagem";
            this.btnImagem.UseVisualStyleBackColor = true;
            this.btnImagem.Click += new System.EventHandler(this.btnImagem_Click);
            // 
            // groupBoxImagemVeiculo
            // 
            this.groupBoxImagemVeiculo.Controls.Add(this.pictureBoxVeiculo);
            this.groupBoxImagemVeiculo.Location = new System.Drawing.Point(242, 19);
            this.groupBoxImagemVeiculo.Name = "groupBoxImagemVeiculo";
            this.groupBoxImagemVeiculo.Size = new System.Drawing.Size(400, 335);
            this.groupBoxImagemVeiculo.TabIndex = 28;
            this.groupBoxImagemVeiculo.TabStop = false;
            this.groupBoxImagemVeiculo.Text = "Imagem do Veículo";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(598, 414);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.Location = new System.Drawing.Point(517, 414);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 23);
            this.btnGravar.TabIndex = 15;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // txtPlaca
            // 
            this.txtPlaca.Location = new System.Drawing.Point(127, 45);
            this.txtPlaca.MaxLength = 7;
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(100, 20);
            this.txtPlaca.TabIndex = 1;
            // 
            // txtChassi
            // 
            this.txtChassi.Location = new System.Drawing.Point(127, 149);
            this.txtChassi.Name = "txtChassi";
            this.txtChassi.Size = new System.Drawing.Size(100, 20);
            this.txtChassi.TabIndex = 5;
            // 
            // txtCor
            // 
            this.txtCor.Location = new System.Drawing.Point(127, 176);
            this.txtCor.Name = "txtCor";
            this.txtCor.Size = new System.Drawing.Size(100, 20);
            this.txtCor.TabIndex = 6;
            // 
            // txtQtdPortas
            // 
            this.txtQtdPortas.Location = new System.Drawing.Point(127, 228);
            this.txtQtdPortas.Name = "txtQtdPortas";
            this.txtQtdPortas.Size = new System.Drawing.Size(100, 20);
            this.txtQtdPortas.TabIndex = 8;
            // 
            // txtCapacidadeTanque
            // 
            this.txtCapacidadeTanque.Location = new System.Drawing.Point(127, 202);
            this.txtCapacidadeTanque.Name = "txtCapacidadeTanque";
            this.txtCapacidadeTanque.Size = new System.Drawing.Size(100, 20);
            this.txtCapacidadeTanque.TabIndex = 7;
            // 
            // txtFabricante
            // 
            this.txtFabricante.Location = new System.Drawing.Point(127, 97);
            this.txtFabricante.Name = "txtFabricante";
            this.txtFabricante.Size = new System.Drawing.Size(100, 20);
            this.txtFabricante.TabIndex = 3;
            // 
            // labelPlaca
            // 
            this.labelPlaca.AutoSize = true;
            this.labelPlaca.Location = new System.Drawing.Point(9, 48);
            this.labelPlaca.Name = "labelPlaca";
            this.labelPlaca.Size = new System.Drawing.Size(34, 13);
            this.labelPlaca.TabIndex = 18;
            this.labelPlaca.Text = "Placa";
            // 
            // labelChassi
            // 
            this.labelChassi.AutoSize = true;
            this.labelChassi.Location = new System.Drawing.Point(9, 152);
            this.labelChassi.Name = "labelChassi";
            this.labelChassi.Size = new System.Drawing.Size(38, 13);
            this.labelChassi.TabIndex = 22;
            this.labelChassi.Text = "Chassi";
            // 
            // labelCor
            // 
            this.labelCor.AutoSize = true;
            this.labelCor.Location = new System.Drawing.Point(9, 179);
            this.labelCor.Name = "labelCor";
            this.labelCor.Size = new System.Drawing.Size(23, 13);
            this.labelCor.TabIndex = 23;
            this.labelCor.Text = "Cor";
            // 
            // labelFabricante
            // 
            this.labelFabricante.AutoSize = true;
            this.labelFabricante.Location = new System.Drawing.Point(9, 100);
            this.labelFabricante.Name = "labelFabricante";
            this.labelFabricante.Size = new System.Drawing.Size(57, 13);
            this.labelFabricante.TabIndex = 20;
            this.labelFabricante.Text = "Fabricante";
            // 
            // labelCapacidadeTanque
            // 
            this.labelCapacidadeTanque.AutoSize = true;
            this.labelCapacidadeTanque.Location = new System.Drawing.Point(9, 205);
            this.labelCapacidadeTanque.Name = "labelCapacidadeTanque";
            this.labelCapacidadeTanque.Size = new System.Drawing.Size(119, 13);
            this.labelCapacidadeTanque.TabIndex = 24;
            this.labelCapacidadeTanque.Text = "Capacidade Tanque (L)";
            // 
            // labelQtdPortas
            // 
            this.labelQtdPortas.AutoSize = true;
            this.labelQtdPortas.Location = new System.Drawing.Point(9, 231);
            this.labelQtdPortas.Name = "labelQtdPortas";
            this.labelQtdPortas.Size = new System.Drawing.Size(110, 13);
            this.labelQtdPortas.TabIndex = 25;
            this.labelQtdPortas.Text = "Quantidade de Portas";
            // 
            // labelAno
            // 
            this.labelAno.AutoSize = true;
            this.labelAno.Location = new System.Drawing.Point(9, 257);
            this.labelAno.Name = "labelAno";
            this.labelAno.Size = new System.Drawing.Size(97, 13);
            this.labelAno.TabIndex = 26;
            this.labelAno.Text = "Ano de Fabricação";
            // 
            // txtAno
            // 
            this.txtAno.Location = new System.Drawing.Point(127, 254);
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(100, 20);
            this.txtAno.TabIndex = 9;
            // 
            // labelCapacidadePessoas
            // 
            this.labelCapacidadePessoas.AutoSize = true;
            this.labelCapacidadePessoas.Location = new System.Drawing.Point(9, 283);
            this.labelCapacidadePessoas.Name = "labelCapacidadePessoas";
            this.labelCapacidadePessoas.Size = new System.Drawing.Size(107, 13);
            this.labelCapacidadePessoas.TabIndex = 27;
            this.labelCapacidadePessoas.Text = "Capacidade Pessoas";
            // 
            // txtCapacidadePessoas
            // 
            this.txtCapacidadePessoas.Location = new System.Drawing.Point(127, 280);
            this.txtCapacidadePessoas.Name = "txtCapacidadePessoas";
            this.txtCapacidadePessoas.Size = new System.Drawing.Size(100, 20);
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
            this.comboBoxCombustivel.Location = new System.Drawing.Point(127, 333);
            this.comboBoxCombustivel.Name = "comboBoxCombustivel";
            this.comboBoxCombustivel.Size = new System.Drawing.Size(100, 21);
            this.comboBoxCombustivel.TabIndex = 12;
            // 
            // labelCombustivel
            // 
            this.labelCombustivel.AutoSize = true;
            this.labelCombustivel.Location = new System.Drawing.Point(9, 336);
            this.labelCombustivel.Name = "labelCombustivel";
            this.labelCombustivel.Size = new System.Drawing.Size(66, 13);
            this.labelCombustivel.TabIndex = 30;
            this.labelCombustivel.Text = "Combustível";
            // 
            // labelPortaMalas
            // 
            this.labelPortaMalas.AutoSize = true;
            this.labelPortaMalas.Location = new System.Drawing.Point(9, 365);
            this.labelPortaMalas.Name = "labelPortaMalas";
            this.labelPortaMalas.Size = new System.Drawing.Size(111, 13);
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
            this.comboBoxPortaMalas.Location = new System.Drawing.Point(127, 362);
            this.comboBoxPortaMalas.Name = "comboBoxPortaMalas";
            this.comboBoxPortaMalas.Size = new System.Drawing.Size(100, 21);
            this.comboBoxPortaMalas.TabIndex = 13;
            // 
            // id
            // 
            this.id.AutoSize = true;
            this.id.Location = new System.Drawing.Point(9, 22);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(18, 13);
            this.id.TabIndex = 17;
            this.id.Text = "ID";
            this.id.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(127, 19);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 26;
            this.txtId.Text = "0";
            // 
            // labelGrupoVeiculo
            // 
            this.labelGrupoVeiculo.AutoSize = true;
            this.labelGrupoVeiculo.Location = new System.Drawing.Point(9, 309);
            this.labelGrupoVeiculo.Name = "labelGrupoVeiculo";
            this.labelGrupoVeiculo.Size = new System.Drawing.Size(91, 13);
            this.labelGrupoVeiculo.TabIndex = 29;
            this.labelGrupoVeiculo.Text = "Grupo do Veículo";
            // 
            // comboBoxGrupoVeiculo
            // 
            this.comboBoxGrupoVeiculo.FormattingEnabled = true;
            this.comboBoxGrupoVeiculo.Location = new System.Drawing.Point(127, 306);
            this.comboBoxGrupoVeiculo.Name = "comboBoxGrupoVeiculo";
            this.comboBoxGrupoVeiculo.Size = new System.Drawing.Size(100, 21);
            this.comboBoxGrupoVeiculo.TabIndex = 11;
            // 
            // labelQuilometragem
            // 
            this.labelQuilometragem.AutoSize = true;
            this.labelQuilometragem.Location = new System.Drawing.Point(9, 126);
            this.labelQuilometragem.Name = "labelQuilometragem";
            this.labelQuilometragem.Size = new System.Drawing.Size(77, 13);
            this.labelQuilometragem.TabIndex = 21;
            this.labelQuilometragem.Text = "Quilometragem";
            // 
            // labelModelo
            // 
            this.labelModelo.AutoSize = true;
            this.labelModelo.Location = new System.Drawing.Point(9, 74);
            this.labelModelo.Name = "labelModelo";
            this.labelModelo.Size = new System.Drawing.Size(42, 13);
            this.labelModelo.TabIndex = 19;
            this.labelModelo.Text = "Modelo";
            // 
            // txtQuilometragem
            // 
            this.txtQuilometragem.Location = new System.Drawing.Point(127, 123);
            this.txtQuilometragem.Name = "txtQuilometragem";
            this.txtQuilometragem.Size = new System.Drawing.Size(100, 20);
            this.txtQuilometragem.TabIndex = 4;
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(127, 71);
            this.txtModelo.MaxLength = 7;
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(100, 20);
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
            this.groupBoxDadosVeiculo.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDadosVeiculo.Name = "groupBoxDadosVeiculo";
            this.groupBoxDadosVeiculo.Size = new System.Drawing.Size(661, 396);
            this.groupBoxDadosVeiculo.TabIndex = 32;
            this.groupBoxDadosVeiculo.TabStop = false;
            this.groupBoxDadosVeiculo.Text = "Informações do Veículo";
            // 
            // TelaVeiculoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 444);
            this.Controls.Add(this.groupBoxDadosVeiculo);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
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