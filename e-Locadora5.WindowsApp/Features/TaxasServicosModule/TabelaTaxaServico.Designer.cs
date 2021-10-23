
namespace e_Locadora5.WindowsApp.Features.TaxasServicosModule
{
    partial class TabelaTaxaServico
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
            this.gridTaxasServicos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridTaxasServicos)).BeginInit();
            this.SuspendLayout();
            // 
            // gridTaxasServicos
            // 
            this.gridTaxasServicos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(75)))), ((int)(((byte)(125)))));
            this.gridTaxasServicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTaxasServicos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTaxasServicos.Location = new System.Drawing.Point(0, 0);
            this.gridTaxasServicos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridTaxasServicos.Name = "gridTaxasServicos";
            this.gridTaxasServicos.RowHeadersWidth = 51;
            this.gridTaxasServicos.Size = new System.Drawing.Size(200, 231);
            this.gridTaxasServicos.TabIndex = 2;
            // 
            // TabelaTaxaServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridTaxasServicos);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TabelaTaxaServico";
            this.Size = new System.Drawing.Size(200, 231);
            ((System.ComponentModel.ISupportInitialize)(this.gridTaxasServicos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridTaxasServicos;
    }
}
