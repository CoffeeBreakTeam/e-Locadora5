
namespace e_Locadora5.WindowsApp.Features.CondutorModule
{
    partial class TabelaCondutorControl
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
            this.gridCondutores = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridCondutores)).BeginInit();
            this.SuspendLayout();
            // 
            // gridCondutores
            // 
            this.gridCondutores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCondutores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCondutores.Location = new System.Drawing.Point(0, 0);
            this.gridCondutores.Name = "gridCondutores";
            this.gridCondutores.Size = new System.Drawing.Size(414, 315);
            this.gridCondutores.TabIndex = 2;
            // 
            // TabelaCondutorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridCondutores);
            this.Name = "TabelaCondutorControl";
            this.Size = new System.Drawing.Size(414, 315);
            ((System.ComponentModel.ISupportInitialize)(this.gridCondutores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridCondutores;
    }
}
