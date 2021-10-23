
namespace e_Locadora5.WindowsApp.Features.CondutorModule
{
    partial class TelaCondutorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaCondutorForm));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.txtCPF = new System.Windows.Forms.MaskedTextBox();
            this.txtRG = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelEndereco = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.TxtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.txtCnh = new System.Windows.Forms.MaskedTextBox();
            this.dateValidade = new System.Windows.Forms.DateTimePicker();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBoxDadosCondutor = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxDadosCondutor.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(567, 329);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.Location = new System.Drawing.Point(459, 329);
            this.btnGravar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(100, 35);
            this.btnGravar.TabIndex = 28;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(491, 69);
            this.txtCPF.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCPF.Mask = "000.000.000-00";
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(132, 27);
            this.txtCPF.TabIndex = 42;
            // 
            // txtRG
            // 
            this.txtRG.Location = new System.Drawing.Point(491, 29);
            this.txtRG.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRG.Mask = "000000000";
            this.txtRG.Name = "txtRG";
            this.txtRG.Size = new System.Drawing.Size(132, 27);
            this.txtRG.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(364, 69);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 20);
            this.label6.TabIndex = 40;
            this.label6.Text = "Número do CPF";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(364, 34);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 20);
            this.label5.TabIndex = 39;
            this.label5.Text = "Número do RG";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 154);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 38;
            this.label4.Text = "Telefone";
            // 
            // labelEndereco
            // 
            this.labelEndereco.AutoSize = true;
            this.labelEndereco.Location = new System.Drawing.Point(12, 114);
            this.labelEndereco.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEndereco.Name = "labelEndereco";
            this.labelEndereco.Size = new System.Drawing.Size(71, 20);
            this.labelEndereco.TabIndex = 37;
            this.labelEndereco.Text = "Endereço";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "Nome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 20);
            this.label1.TabIndex = 35;
            this.label1.Text = "Id";
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(95, 109);
            this.txtEndereco.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(219, 27);
            this.txtEndereco.TabIndex = 34;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(95, 69);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(219, 27);
            this.txtNome.TabIndex = 33;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.SteelBlue;
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(95, 29);
            this.txtId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(63, 27);
            this.txtId.TabIndex = 32;
            this.txtId.Text = "0";
            // 
            // TxtTelefone
            // 
            this.TxtTelefone.Location = new System.Drawing.Point(95, 149);
            this.TxtTelefone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TxtTelefone.Mask = "(99) 00000-0000";
            this.TxtTelefone.Name = "TxtTelefone";
            this.TxtTelefone.Size = new System.Drawing.Size(132, 27);
            this.TxtTelefone.TabIndex = 31;
            // 
            // txtCnh
            // 
            this.txtCnh.Location = new System.Drawing.Point(491, 109);
            this.txtCnh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCnh.Mask = "00000000000";
            this.txtCnh.Name = "txtCnh";
            this.txtCnh.Size = new System.Drawing.Size(132, 27);
            this.txtCnh.TabIndex = 43;
            // 
            // dateValidade
            // 
            this.dateValidade.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateValidade.Location = new System.Drawing.Point(491, 149);
            this.dateValidade.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateValidade.Name = "dateValidade";
            this.dateValidade.Size = new System.Drawing.Size(132, 27);
            this.dateValidade.TabIndex = 44;
            // 
            // cbCliente
            // 
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(95, 29);
            this.cbCliente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(219, 28);
            this.cbCliente.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(364, 114);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 20);
            this.label7.TabIndex = 46;
            this.label7.Text = "Número da CNH";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(364, 154);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 20);
            this.label8.TabIndex = 47;
            this.label8.Text = "Validade da CNH";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 34);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 20);
            this.label9.TabIndex = 48;
            this.label9.Text = "Cliente";
            // 
            // groupBoxDadosCondutor
            // 
            this.groupBoxDadosCondutor.Controls.Add(this.txtId);
            this.groupBoxDadosCondutor.Controls.Add(this.TxtTelefone);
            this.groupBoxDadosCondutor.Controls.Add(this.label8);
            this.groupBoxDadosCondutor.Controls.Add(this.txtNome);
            this.groupBoxDadosCondutor.Controls.Add(this.label7);
            this.groupBoxDadosCondutor.Controls.Add(this.txtEndereco);
            this.groupBoxDadosCondutor.Controls.Add(this.label1);
            this.groupBoxDadosCondutor.Controls.Add(this.dateValidade);
            this.groupBoxDadosCondutor.Controls.Add(this.label2);
            this.groupBoxDadosCondutor.Controls.Add(this.txtCnh);
            this.groupBoxDadosCondutor.Controls.Add(this.labelEndereco);
            this.groupBoxDadosCondutor.Controls.Add(this.txtCPF);
            this.groupBoxDadosCondutor.Controls.Add(this.label4);
            this.groupBoxDadosCondutor.Controls.Add(this.txtRG);
            this.groupBoxDadosCondutor.Controls.Add(this.label5);
            this.groupBoxDadosCondutor.Controls.Add(this.label6);
            this.groupBoxDadosCondutor.Location = new System.Drawing.Point(16, 118);
            this.groupBoxDadosCondutor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxDadosCondutor.Name = "groupBoxDadosCondutor";
            this.groupBoxDadosCondutor.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxDadosCondutor.Size = new System.Drawing.Size(651, 202);
            this.groupBoxDadosCondutor.TabIndex = 49;
            this.groupBoxDadosCondutor.TabStop = false;
            this.groupBoxDadosCondutor.Text = "Informações do Condutor";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbCliente);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(16, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(335, 80);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente do Condutor";
            // 
            // TelaCondutorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 377);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxDadosCondutor);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(702, 424);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(702, 424);
            this.Name = "TelaCondutorForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Condutor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelaCondutorForm_FormClosing);
            this.groupBoxDadosCondutor.ResumeLayout(false);
            this.groupBoxDadosCondutor.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.MaskedTextBox txtCPF;
        private System.Windows.Forms.MaskedTextBox txtRG;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelEndereco;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.MaskedTextBox TxtTelefone;
        private System.Windows.Forms.MaskedTextBox txtCnh;
        private System.Windows.Forms.DateTimePicker dateValidade;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBoxDadosCondutor;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}