
namespace e_Locadora5.WindowsApp
{
    partial class TelaPrincipalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaPrincipalForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemGrupoVeiculos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVeiculo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCondutor = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemTaxasEServicos = new System.Windows.Forms.ToolStripMenuItem();
            this.locaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.perceirosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuponsDeDescontosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.combustivelToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolboxAcoes = new System.Windows.Forms.ToolStrip();
            this.btnAdicionar = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFiltrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAgrupar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDesagrupar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDevolucao = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClassificacao = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEmail = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.labelTipoCadastro = new System.Windows.Forms.ToolStripLabel();
            this.panelRegistros = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelRodape = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSair = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.toolboxAcoes.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSair)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem,
            this.configuraçõesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(928, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemGrupoVeiculos,
            this.menuItemVeiculo,
            this.menuItemClientes,
            this.menuItemCondutor,
            this.MenuItemTaxasEServicos,
            this.locaçãoToolStripMenuItem,
            this.funcionariosToolStripMenuItem,
            this.perceirosToolStripMenuItem,
            this.cuponsDeDescontosToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // menuItemGrupoVeiculos
            // 
            this.menuItemGrupoVeiculos.Name = "menuItemGrupoVeiculos";
            this.menuItemGrupoVeiculos.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.menuItemGrupoVeiculos.Size = new System.Drawing.Size(253, 26);
            this.menuItemGrupoVeiculos.Text = "Grupo de Veiculos";
            this.menuItemGrupoVeiculos.Click += new System.EventHandler(this.menuItemGrupoVeiculos_Click);
            // 
            // menuItemVeiculo
            // 
            this.menuItemVeiculo.Name = "menuItemVeiculo";
            this.menuItemVeiculo.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.menuItemVeiculo.Size = new System.Drawing.Size(253, 26);
            this.menuItemVeiculo.Text = "Veiculos";
            this.menuItemVeiculo.Click += new System.EventHandler(this.menuItemVeiculo_Click);
            // 
            // menuItemClientes
            // 
            this.menuItemClientes.Name = "menuItemClientes";
            this.menuItemClientes.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.menuItemClientes.Size = new System.Drawing.Size(253, 26);
            this.menuItemClientes.Text = "Clientes";
            this.menuItemClientes.Click += new System.EventHandler(this.menuItemClientes_Click);
            // 
            // menuItemCondutor
            // 
            this.menuItemCondutor.Name = "menuItemCondutor";
            this.menuItemCondutor.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.menuItemCondutor.Size = new System.Drawing.Size(253, 26);
            this.menuItemCondutor.Text = "Condutores";
            this.menuItemCondutor.Click += new System.EventHandler(this.menuItemCondutor_Click);
            // 
            // MenuItemTaxasEServicos
            // 
            this.MenuItemTaxasEServicos.Name = "MenuItemTaxasEServicos";
            this.MenuItemTaxasEServicos.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.MenuItemTaxasEServicos.Size = new System.Drawing.Size(253, 26);
            this.MenuItemTaxasEServicos.Text = "Taxas e Servicos";
            this.MenuItemTaxasEServicos.Click += new System.EventHandler(this.MenuItemTaxasEServicos_Click);
            // 
            // locaçãoToolStripMenuItem
            // 
            this.locaçãoToolStripMenuItem.Name = "locaçãoToolStripMenuItem";
            this.locaçãoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.locaçãoToolStripMenuItem.Size = new System.Drawing.Size(253, 26);
            this.locaçãoToolStripMenuItem.Text = "Locação";
            this.locaçãoToolStripMenuItem.Click += new System.EventHandler(this.locaçãoToolStripMenuItem_Click);
            // 
            // funcionariosToolStripMenuItem
            // 
            this.funcionariosToolStripMenuItem.Name = "funcionariosToolStripMenuItem";
            this.funcionariosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.funcionariosToolStripMenuItem.Size = new System.Drawing.Size(253, 26);
            this.funcionariosToolStripMenuItem.Text = "Funcionário";
            this.funcionariosToolStripMenuItem.Click += new System.EventHandler(this.funcionariosToolStripMenuItem_Click);
            // 
            // perceirosToolStripMenuItem
            // 
            this.perceirosToolStripMenuItem.Name = "perceirosToolStripMenuItem";
            this.perceirosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.perceirosToolStripMenuItem.Size = new System.Drawing.Size(253, 26);
            this.perceirosToolStripMenuItem.Text = "Parceiros";
            this.perceirosToolStripMenuItem.Click += new System.EventHandler(this.perceirosToolStripMenuItem_Click);
            // 
            // cuponsDeDescontosToolStripMenuItem
            // 
            this.cuponsDeDescontosToolStripMenuItem.Name = "cuponsDeDescontosToolStripMenuItem";
            this.cuponsDeDescontosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.cuponsDeDescontosToolStripMenuItem.Size = new System.Drawing.Size(253, 26);
            this.cuponsDeDescontosToolStripMenuItem.Text = "Cupons de Desconto";
            this.cuponsDeDescontosToolStripMenuItem.Click += new System.EventHandler(this.cuponsDeDescontosToolStripMenuItem_Click);
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.combustivelToolStripMenuItem1});
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.configuraçõesToolStripMenuItem.Text = "Configurações";
            // 
            // combustivelToolStripMenuItem1
            // 
            this.combustivelToolStripMenuItem1.Name = "combustivelToolStripMenuItem1";
            this.combustivelToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.combustivelToolStripMenuItem1.Size = new System.Drawing.Size(198, 26);
            this.combustivelToolStripMenuItem1.Text = "Combustível";
            this.combustivelToolStripMenuItem1.Click += new System.EventHandler(this.combustivelToolStripMenuItem1_Click);
            // 
            // toolboxAcoes
            // 
            this.toolboxAcoes.Enabled = false;
            this.toolboxAcoes.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolboxAcoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdicionar,
            this.btnEditar,
            this.btnExcluir,
            this.toolStripSeparator1,
            this.btnFiltrar,
            this.toolStripSeparator3,
            this.btnAgrupar,
            this.toolStripSeparator4,
            this.btnDesagrupar,
            this.toolStripSeparator2,
            this.btnDevolucao,
            this.toolStripSeparator6,
            this.btnClassificacao,
            this.toolStripSeparator7,
            this.btnEmail,
            this.toolStripSeparator5,
            this.labelTipoCadastro});
            this.toolboxAcoes.Location = new System.Drawing.Point(0, 30);
            this.toolboxAcoes.Name = "toolboxAcoes";
            this.toolboxAcoes.Size = new System.Drawing.Size(928, 41);
            this.toolboxAcoes.TabIndex = 3;
            this.toolboxAcoes.Text = "toolStrip1";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdicionar.Image = global::e_Locadora5.WindowsApp.Properties.Resources.outline_add_circle_outline_black_24dp;
            this.btnAdicionar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Padding = new System.Windows.Forms.Padding(5);
            this.btnAdicionar.Size = new System.Drawing.Size(38, 38);
            this.btnAdicionar.Text = "toolStripButton1";
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditar.Image = global::e_Locadora5.WindowsApp.Properties.Resources.outline_mode_edit_black_24dp;
            this.btnEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Padding = new System.Windows.Forms.Padding(5);
            this.btnEditar.Size = new System.Drawing.Size(38, 38);
            this.btnEditar.Text = "toolStripButton1";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExcluir.Image = global::e_Locadora5.WindowsApp.Properties.Resources.outline_delete_black_24dp;
            this.btnExcluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Padding = new System.Windows.Forms.Padding(5);
            this.btnExcluir.Size = new System.Drawing.Size(38, 38);
            this.btnExcluir.Text = "toolStripButton1";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 41);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFiltrar.Image = global::e_Locadora5.WindowsApp.Properties.Resources.outline_filter_alt_black_24dp;
            this.btnFiltrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Padding = new System.Windows.Forms.Padding(5);
            this.btnFiltrar.Size = new System.Drawing.Size(38, 38);
            this.btnFiltrar.Text = "toolStripButton1";
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 41);
            // 
            // btnAgrupar
            // 
            this.btnAgrupar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAgrupar.Image = global::e_Locadora5.WindowsApp.Properties.Resources.outline_list_alt_black_24dp;
            this.btnAgrupar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAgrupar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgrupar.Name = "btnAgrupar";
            this.btnAgrupar.Padding = new System.Windows.Forms.Padding(5);
            this.btnAgrupar.Size = new System.Drawing.Size(38, 38);
            this.btnAgrupar.Text = "toolStripButton1";
            this.btnAgrupar.Click += new System.EventHandler(this.btnAgrupar_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 41);
            // 
            // btnDesagrupar
            // 
            this.btnDesagrupar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDesagrupar.Image = global::e_Locadora5.WindowsApp.Properties.Resources.outline_expand_black_24dp1;
            this.btnDesagrupar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDesagrupar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDesagrupar.Name = "btnDesagrupar";
            this.btnDesagrupar.Padding = new System.Windows.Forms.Padding(5);
            this.btnDesagrupar.Size = new System.Drawing.Size(38, 38);
            this.btnDesagrupar.Text = "toolStripButton1";
            this.btnDesagrupar.Click += new System.EventHandler(this.btnDesagrupar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 41);
            // 
            // btnDevolucao
            // 
            this.btnDevolucao.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDevolucao.Image = global::e_Locadora5.WindowsApp.Properties.Resources.outline_directions_car_black_24dp;
            this.btnDevolucao.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDevolucao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDevolucao.Name = "btnDevolucao";
            this.btnDevolucao.Padding = new System.Windows.Forms.Padding(5);
            this.btnDevolucao.Size = new System.Drawing.Size(38, 38);
            this.btnDevolucao.Text = "Devolução de Veículos";
            this.btnDevolucao.Click += new System.EventHandler(this.btnDevolucao_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 41);
            // 
            // btnClassificacao
            // 
            this.btnClassificacao.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClassificacao.Image = global::e_Locadora5.WindowsApp.Properties.Resources.outline_insert_chart_outlined_black_24dp1;
            this.btnClassificacao.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClassificacao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClassificacao.Name = "btnClassificacao";
            this.btnClassificacao.Size = new System.Drawing.Size(29, 38);
            this.btnClassificacao.Click += new System.EventHandler(this.btnQuantidadeCupons_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 41);
            // 
            // btnEmail
            // 
            this.btnEmail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEmail.Image = global::e_Locadora5.WindowsApp.Properties.Resources.outline_mail_black_24dp;
            this.btnEmail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEmail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(29, 38);
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 41);
            // 
            // labelTipoCadastro
            // 
            this.labelTipoCadastro.Name = "labelTipoCadastro";
            this.labelTipoCadastro.Size = new System.Drawing.Size(217, 38);
            this.labelTipoCadastro.Text = "Cadastro Selecionado: Nenhum";
            // 
            // panelRegistros
            // 
            this.panelRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRegistros.BackgroundImage = global::e_Locadora5.WindowsApp.Properties.Resources.New_Screen_Vetores;
            this.panelRegistros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelRegistros.Location = new System.Drawing.Point(16, 100);
            this.panelRegistros.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelRegistros.Name = "panelRegistros";
            this.panelRegistros.Size = new System.Drawing.Size(896, 554);
            this.panelRegistros.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelRodape});
            this.statusStrip1.Location = new System.Drawing.Point(0, 665);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(928, 26);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelRodape
            // 
            this.labelRodape.Name = "labelRodape";
            this.labelRodape.Size = new System.Drawing.Size(83, 20);
            this.labelRodape.Text = "Tudo Ok ;-)";
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.Transparent;
            this.btnSair.Image = global::e_Locadora5.WindowsApp.Properties.Resources.outline_exit_to_app_black_24dp;
            this.btnSair.Location = new System.Drawing.Point(861, 37);
            this.btnSair.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(51, 58);
            this.btnSair.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnSair.TabIndex = 6;
            this.btnSair.TabStop = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // TelaPrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 691);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panelRegistros);
            this.Controls.Add(this.toolboxAcoes);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TelaPrincipalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.Load += new System.EventHandler(this.TelaPrincipalForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolboxAcoes.ResumeLayout(false);
            this.toolboxAcoes.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSair)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemGrupoVeiculos;
        private System.Windows.Forms.ToolStripMenuItem menuItemVeiculo;
        private System.Windows.Forms.ToolStripMenuItem menuItemClientes;
        private System.Windows.Forms.ToolStrip toolboxAcoes;
        private System.Windows.Forms.ToolStripButton btnAdicionar;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnExcluir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFiltrar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnAgrupar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnDesagrupar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel labelTipoCadastro;
        private System.Windows.Forms.Panel panelRegistros;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelRodape;
        private System.Windows.Forms.ToolStripMenuItem menuItemCondutor;
        private System.Windows.Forms.ToolStripMenuItem MenuItemTaxasEServicos;
        private System.Windows.Forms.ToolStripMenuItem locaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funcionariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnDevolucao;
        private System.Windows.Forms.PictureBox btnSair;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem combustivelToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem perceirosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuponsDeDescontosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnClassificacao;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btnEmail;
    }
}

