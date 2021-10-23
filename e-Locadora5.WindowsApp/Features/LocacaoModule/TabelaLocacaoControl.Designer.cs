
namespace e_Locadora5.WindowsApp.Features.LocacaoModule
{
    partial class TabelaLocacaoControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridLocacao = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridLocacao)).BeginInit();
            this.SuspendLayout();
            // 
            // gridLocacao
            // 
            this.gridLocacao.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(75)))), ((int)(((byte)(125)))));
            this.gridLocacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLocacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLocacao.Location = new System.Drawing.Point(0, 0);
            this.gridLocacao.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridLocacao.Name = "gridLocacao";
            this.gridLocacao.RowHeadersWidth = 51;
            this.gridLocacao.Size = new System.Drawing.Size(200, 231);
            this.gridLocacao.TabIndex = 1;
            // 
            // TabelaLocacaoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridLocacao);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TabelaLocacaoControl";
            this.Size = new System.Drawing.Size(200, 231);
            ((System.ComponentModel.ISupportInitialize)(this.gridLocacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridLocacao;
    }
}
