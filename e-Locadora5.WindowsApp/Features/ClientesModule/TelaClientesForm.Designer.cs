
namespace e_Locadora5.WindowsApp.ClientesModule
{
    partial class TelaClientesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaClientesForm));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.TxtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRG = new System.Windows.Forms.MaskedTextBox();
            this.txtCPF = new System.Windows.Forms.MaskedTextBox();
            this.txtCnpj = new System.Windows.Forms.MaskedTextBox();
            this.rbCPF = new System.Windows.Forms.RadioButton();
            this.rbCNPJ = new System.Windows.Forms.RadioButton();
            this.groupBoxTipoPessoa = new System.Windows.Forms.GroupBox();
            this.groupBoxDadosPessoa = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBoxTipoPessoa.SuspendLayout();
            this.groupBoxDadosPessoa.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(527, 357);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(419, 357);
            this.btnGravar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(100, 35);
            this.btnGravar.TabIndex = 7;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(339, 155);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "Número do CPF";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(344, 115);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "Número do RG";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(383, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Telefone";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 122);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Endereço";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Nome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Id";
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(88, 117);
            this.txtEndereco.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(219, 27);
            this.txtEndereco.TabIndex = 2;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(88, 77);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(219, 27);
            this.txtNome.TabIndex = 1;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.SteelBlue;
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(88, 37);
            this.txtId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtId.MaximumSize = new System.Drawing.Size(63, 27);
            this.txtId.MinimumSize = new System.Drawing.Size(63, 27);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(63, 27);
            this.txtId.TabIndex = 15;
            this.txtId.Text = "0";
            // 
            // TxtTelefone
            // 
            this.TxtTelefone.Location = new System.Drawing.Point(453, 71);
            this.TxtTelefone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TxtTelefone.Mask = "(99) 00000-0000";
            this.TxtTelefone.Name = "TxtTelefone";
            this.TxtTelefone.Size = new System.Drawing.Size(132, 27);
            this.TxtTelefone.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(329, 197);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 20);
            this.label7.TabIndex = 28;
            this.label7.Text = "Número do CNPJ";
            // 
            // txtRG
            // 
            this.txtRG.Location = new System.Drawing.Point(453, 111);
            this.txtRG.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRG.Mask = "000000000";
            this.txtRG.Name = "txtRG";
            this.txtRG.Size = new System.Drawing.Size(132, 27);
            this.txtRG.TabIndex = 5;
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(453, 151);
            this.txtCPF.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCPF.Mask = "000.000.000-00";
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(132, 27);
            this.txtCPF.TabIndex = 6;
            // 
            // txtCnpj
            // 
            this.txtCnpj.Location = new System.Drawing.Point(453, 192);
            this.txtCnpj.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCnpj.Mask = "00000000/0000-00";
            this.txtCnpj.Name = "txtCnpj";
            this.txtCnpj.Size = new System.Drawing.Size(132, 27);
            this.txtCnpj.TabIndex = 7;
            // 
            // rbCPF
            // 
            this.rbCPF.AutoSize = true;
            this.rbCPF.Location = new System.Drawing.Point(8, 29);
            this.rbCPF.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbCPF.Name = "rbCPF";
            this.rbCPF.Size = new System.Drawing.Size(198, 24);
            this.rbCPF.TabIndex = 9;
            this.rbCPF.Text = "Cadastro de Pessoa Física";
            this.rbCPF.UseVisualStyleBackColor = true;
            this.rbCPF.CheckedChanged += new System.EventHandler(this.rbCPF_CheckedChanged);
            // 
            // rbCNPJ
            // 
            this.rbCNPJ.AutoSize = true;
            this.rbCNPJ.Location = new System.Drawing.Point(219, 29);
            this.rbCNPJ.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbCNPJ.Name = "rbCNPJ";
            this.rbCNPJ.Size = new System.Drawing.Size(212, 24);
            this.rbCNPJ.TabIndex = 10;
            this.rbCNPJ.Text = "Cadastro de Pessoa Jurídica";
            this.rbCNPJ.UseVisualStyleBackColor = true;
            this.rbCNPJ.CheckedChanged += new System.EventHandler(this.rbCNPJ_CheckedChanged);
            // 
            // groupBoxTipoPessoa
            // 
            this.groupBoxTipoPessoa.Controls.Add(this.rbCPF);
            this.groupBoxTipoPessoa.Controls.Add(this.rbCNPJ);
            this.groupBoxTipoPessoa.Location = new System.Drawing.Point(16, 18);
            this.groupBoxTipoPessoa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxTipoPessoa.Name = "groupBoxTipoPessoa";
            this.groupBoxTipoPessoa.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxTipoPessoa.Size = new System.Drawing.Size(441, 80);
            this.groupBoxTipoPessoa.TabIndex = 29;
            this.groupBoxTipoPessoa.TabStop = false;
            this.groupBoxTipoPessoa.Text = "Tipo de Pessoa";
            // 
            // groupBoxDadosPessoa
            // 
            this.groupBoxDadosPessoa.Controls.Add(this.txtEmail);
            this.groupBoxDadosPessoa.Controls.Add(this.label8);
            this.groupBoxDadosPessoa.Controls.Add(this.txtId);
            this.groupBoxDadosPessoa.Controls.Add(this.TxtTelefone);
            this.groupBoxDadosPessoa.Controls.Add(this.txtCnpj);
            this.groupBoxDadosPessoa.Controls.Add(this.txtNome);
            this.groupBoxDadosPessoa.Controls.Add(this.txtCPF);
            this.groupBoxDadosPessoa.Controls.Add(this.txtEndereco);
            this.groupBoxDadosPessoa.Controls.Add(this.txtRG);
            this.groupBoxDadosPessoa.Controls.Add(this.label1);
            this.groupBoxDadosPessoa.Controls.Add(this.label7);
            this.groupBoxDadosPessoa.Controls.Add(this.label2);
            this.groupBoxDadosPessoa.Controls.Add(this.label3);
            this.groupBoxDadosPessoa.Controls.Add(this.label4);
            this.groupBoxDadosPessoa.Controls.Add(this.label6);
            this.groupBoxDadosPessoa.Controls.Add(this.label5);
            this.groupBoxDadosPessoa.Location = new System.Drawing.Point(16, 108);
            this.groupBoxDadosPessoa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxDadosPessoa.Name = "groupBoxDadosPessoa";
            this.groupBoxDadosPessoa.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxDadosPessoa.Size = new System.Drawing.Size(611, 240);
            this.groupBoxDadosPessoa.TabIndex = 30;
            this.groupBoxDadosPessoa.TabStop = false;
            this.groupBoxDadosPessoa.Text = "Informações do Cliente";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(88, 157);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(219, 27);
            this.txtEmail.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 162);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 20);
            this.label8.TabIndex = 30;
            this.label8.Text = "Email";
            // 
            // TelaClientesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 400);
            this.Controls.Add(this.groupBoxDadosPessoa);
            this.Controls.Add(this.groupBoxTipoPessoa);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(659, 447);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(659, 447);
            this.Name = "TelaClientesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Cliente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelaClientesForm_FormClosing);
            this.Load += new System.EventHandler(this.TelaClientesForm_Load);
            this.groupBoxTipoPessoa.ResumeLayout(false);
            this.groupBoxTipoPessoa.PerformLayout();
            this.groupBoxDadosPessoa.ResumeLayout(false);
            this.groupBoxDadosPessoa.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.MaskedTextBox TxtTelefone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox txtRG;
        private System.Windows.Forms.MaskedTextBox txtCPF;
        private System.Windows.Forms.MaskedTextBox txtCnpj;
        private System.Windows.Forms.RadioButton rbCPF;
        private System.Windows.Forms.RadioButton rbCNPJ;
        private System.Windows.Forms.GroupBox groupBoxTipoPessoa;
        private System.Windows.Forms.GroupBox groupBoxDadosPessoa;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label8;
    }
}