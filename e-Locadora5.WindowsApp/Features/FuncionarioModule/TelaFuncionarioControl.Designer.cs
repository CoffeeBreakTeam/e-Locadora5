
namespace e_Locadora5.WindowsApp.Features.FuncionarioModule
{
    partial class TelaFuncionarioControl
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
            this.gridFuncionario = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridFuncionario)).BeginInit();
            this.SuspendLayout();
            // 
            // gridFuncionario
            // 
            this.gridFuncionario.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(75)))), ((int)(((byte)(125)))));
            this.gridFuncionario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFuncionario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFuncionario.Location = new System.Drawing.Point(0, 0);
            this.gridFuncionario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridFuncionario.Name = "gridFuncionario";
            this.gridFuncionario.RowHeadersWidth = 51;
            this.gridFuncionario.Size = new System.Drawing.Size(636, 575);
            this.gridFuncionario.TabIndex = 2;
            // 
            // TelaFuncionarioControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridFuncionario);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TelaFuncionarioControl";
            this.Size = new System.Drawing.Size(636, 575);
            ((System.ComponentModel.ISupportInitialize)(this.gridFuncionario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridFuncionario;
    }
}
