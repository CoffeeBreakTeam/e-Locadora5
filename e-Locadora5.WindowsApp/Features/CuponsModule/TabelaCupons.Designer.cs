
namespace e_Locadora5.WindowsApp.Features.CuponsModule
{
    partial class TabelaCupons
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
            this.gridCupons = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridCupons)).BeginInit();
            this.SuspendLayout();
            // 
            // gridCupons
            // 
            this.gridCupons.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(75)))), ((int)(((byte)(125)))));
            this.gridCupons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCupons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCupons.Location = new System.Drawing.Point(0, 0);
            this.gridCupons.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridCupons.Name = "gridCupons";
            this.gridCupons.RowHeadersWidth = 51;
            this.gridCupons.Size = new System.Drawing.Size(200, 231);
            this.gridCupons.TabIndex = 3;
            // 
            // TabelaCupons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridCupons);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TabelaCupons";
            this.Size = new System.Drawing.Size(200, 231);
            ((System.ComponentModel.ISupportInitialize)(this.gridCupons)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridCupons;
    }
}
