
namespace e_Locadora5.WindowsApp.Features.LocacaoModule
{
    partial class TelaEmailsPendentesForm
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
            this.btnEnviar = new System.Windows.Forms.Button();
            this.groupBoxLocacoes = new System.Windows.Forms.GroupBox();
            this.panelLocacoes = new System.Windows.Forms.Panel();
            this.groupBoxLocacoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(670, 237);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(589, 237);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 13;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // groupBoxLocacoes
            // 
            this.groupBoxLocacoes.Controls.Add(this.panelLocacoes);
            this.groupBoxLocacoes.Location = new System.Drawing.Point(12, 12);
            this.groupBoxLocacoes.Name = "groupBoxLocacoes";
            this.groupBoxLocacoes.Size = new System.Drawing.Size(733, 219);
            this.groupBoxLocacoes.TabIndex = 14;
            this.groupBoxLocacoes.TabStop = false;
            this.groupBoxLocacoes.Text = "Locações com Emails Pendentes";
            // 
            // panelLocacoes
            // 
            this.panelLocacoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLocacoes.Location = new System.Drawing.Point(3, 16);
            this.panelLocacoes.Name = "panelLocacoes";
            this.panelLocacoes.Size = new System.Drawing.Size(727, 200);
            this.panelLocacoes.TabIndex = 15;
            // 
            // TelaEmailsPendentesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 272);
            this.Controls.Add(this.groupBoxLocacoes);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaEmailsPendentesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emails Pendentes";
            this.groupBoxLocacoes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.GroupBox groupBoxLocacoes;
        private System.Windows.Forms.Panel panelLocacoes;
    }
}