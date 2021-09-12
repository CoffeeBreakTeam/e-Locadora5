
namespace e_Locadora5.WindowsApp.VeiculoModule
{
    partial class TabelaVeiculoControl
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
            this.gridVeiculo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridVeiculo)).BeginInit();
            this.SuspendLayout();
            // 
            // gridVeiculo
            // 
            this.gridVeiculo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridVeiculo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridVeiculo.Location = new System.Drawing.Point(0, 0);
            this.gridVeiculo.Name = "gridVeiculo";
            this.gridVeiculo.Size = new System.Drawing.Size(150, 150);
            this.gridVeiculo.TabIndex = 1;
            // 
            // TabelaVeiculoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridVeiculo);
            this.Name = "TabelaVeiculoControl";
            ((System.ComponentModel.ISupportInitialize)(this.gridVeiculo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridVeiculo;
    }
}
