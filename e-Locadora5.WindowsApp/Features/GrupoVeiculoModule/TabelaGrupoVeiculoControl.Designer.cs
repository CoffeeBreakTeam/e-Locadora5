
namespace e_Locadora5.WindowsApp.GrupoVeiculoModule
{
    partial class TabelaGrupoVeiculoControl
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
            this.gridGrupoVeiculo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridGrupoVeiculo)).BeginInit();
            this.SuspendLayout();
            // 
            // gridGrupoVeiculo
            // 
            this.gridGrupoVeiculo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(75)))), ((int)(((byte)(125)))));
            this.gridGrupoVeiculo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridGrupoVeiculo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridGrupoVeiculo.Location = new System.Drawing.Point(0, 0);
            this.gridGrupoVeiculo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridGrupoVeiculo.Name = "gridGrupoVeiculo";
            this.gridGrupoVeiculo.RowHeadersWidth = 51;
            this.gridGrupoVeiculo.Size = new System.Drawing.Size(645, 551);
            this.gridGrupoVeiculo.TabIndex = 0;
            // 
            // TabelaGrupoVeiculoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridGrupoVeiculo);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TabelaGrupoVeiculoControl";
            this.Size = new System.Drawing.Size(645, 551);
            ((System.ComponentModel.ISupportInitialize)(this.gridGrupoVeiculo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridGrupoVeiculo;
    }
}
