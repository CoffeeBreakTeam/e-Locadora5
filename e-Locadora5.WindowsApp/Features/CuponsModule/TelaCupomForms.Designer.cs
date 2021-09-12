
namespace e_Locadora5.WindowsApp.Features.CuponsModule
{
    partial class TelaCupomForms
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.txtValorFixo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtValorPercentual = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.valorPercentual = new System.Windows.Forms.RadioButton();
            this.valorFixo = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.maskedTextBoxDataValidade = new System.Windows.Forms.MaskedTextBox();
            this.Parceiro = new System.Windows.Forms.Label();
            this.cboxParceiro = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtValorMinimo = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(166, 312);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(73, 23);
            this.btnCancelar.TabIndex = 57;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(85, 312);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(73, 23);
            this.btnGravar.TabIndex = 56;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // txtValorFixo
            // 
            this.txtValorFixo.Enabled = false;
            this.txtValorFixo.Location = new System.Drawing.Point(98, 162);
            this.txtValorFixo.Name = "txtValorFixo";
            this.txtValorFixo.Size = new System.Drawing.Size(141, 20);
            this.txtValorFixo.TabIndex = 55;
            this.txtValorFixo.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "Valor Fixo";
            // 
            // txtValorPercentual
            // 
            this.txtValorPercentual.Location = new System.Drawing.Point(98, 136);
            this.txtValorPercentual.Name = "txtValorPercentual";
            this.txtValorPercentual.Size = new System.Drawing.Size(141, 20);
            this.txtValorPercentual.TabIndex = 53;
            this.txtValorPercentual.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "Valor Percentual";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "Nome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Id";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(98, 110);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(141, 20);
            this.txtNome.TabIndex = 49;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(98, 84);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(48, 20);
            this.txtId.TabIndex = 48;
            this.txtId.Text = "0";
            // 
            // valorPercentual
            // 
            this.valorPercentual.AutoSize = true;
            this.valorPercentual.Checked = true;
            this.valorPercentual.Location = new System.Drawing.Point(6, 19);
            this.valorPercentual.Name = "valorPercentual";
            this.valorPercentual.Size = new System.Drawing.Size(103, 17);
            this.valorPercentual.TabIndex = 37;
            this.valorPercentual.TabStop = true;
            this.valorPercentual.Text = "Valor Percentual";
            this.valorPercentual.UseVisualStyleBackColor = true;
            this.valorPercentual.CheckedChanged += new System.EventHandler(this.valorPercentual_CheckedChanged);
            // 
            // valorFixo
            // 
            this.valorFixo.AutoSize = true;
            this.valorFixo.Location = new System.Drawing.Point(126, 19);
            this.valorFixo.Name = "valorFixo";
            this.valorFixo.Size = new System.Drawing.Size(71, 17);
            this.valorFixo.TabIndex = 38;
            this.valorFixo.Text = "Valor Fixo";
            this.valorFixo.UseVisualStyleBackColor = true;
            this.valorFixo.CheckedChanged += new System.EventHandler(this.valorFixo_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.valorPercentual);
            this.groupBox1.Controls.Add(this.valorFixo);
            this.groupBox1.Location = new System.Drawing.Point(12, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 44);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Cupom";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Data de Validade";
            // 
            // maskedTextBoxDataValidade
            // 
            this.maskedTextBoxDataValidade.Location = new System.Drawing.Point(139, 191);
            this.maskedTextBoxDataValidade.Mask = "00/00/0000";
            this.maskedTextBoxDataValidade.Name = "maskedTextBoxDataValidade";
            this.maskedTextBoxDataValidade.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxDataValidade.TabIndex = 60;
            this.maskedTextBoxDataValidade.ValidatingType = typeof(System.DateTime);
            // 
            // Parceiro
            // 
            this.Parceiro.AutoSize = true;
            this.Parceiro.Location = new System.Drawing.Point(7, 220);
            this.Parceiro.Name = "Parceiro";
            this.Parceiro.Size = new System.Drawing.Size(46, 13);
            this.Parceiro.TabIndex = 62;
            this.Parceiro.Text = "Parceiro";
            // 
            // cboxParceiro
            // 
            this.cboxParceiro.FormattingEnabled = true;
            this.cboxParceiro.Location = new System.Drawing.Point(98, 220);
            this.cboxParceiro.Name = "cboxParceiro";
            this.cboxParceiro.Size = new System.Drawing.Size(141, 21);
            this.cboxParceiro.TabIndex = 63;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 64;
            this.label6.Text = "Valor Minimo";
            // 
            // txtValorMinimo
            // 
            this.txtValorMinimo.Location = new System.Drawing.Point(98, 251);
            this.txtValorMinimo.Name = "txtValorMinimo";
            this.txtValorMinimo.Size = new System.Drawing.Size(141, 20);
            this.txtValorMinimo.TabIndex = 65;
            this.txtValorMinimo.Text = "0";
            // 
            // TelaCupomForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 347);
            this.Controls.Add(this.txtValorMinimo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboxParceiro);
            this.Controls.Add(this.Parceiro);
            this.Controls.Add(this.maskedTextBoxDataValidade);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.txtValorFixo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtValorPercentual);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCupomForms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cupom de Desconto";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.TextBox txtValorFixo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtValorPercentual;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.RadioButton valorPercentual;
        private System.Windows.Forms.RadioButton valorFixo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDataValidade;
        private System.Windows.Forms.Label Parceiro;
        private System.Windows.Forms.ComboBox cboxParceiro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtValorMinimo;
    }
}