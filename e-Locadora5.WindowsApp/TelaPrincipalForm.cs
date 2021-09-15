using e_Locadora5.Aplicacao.FuncionarioModule;
using e_Locadora5.Controladores.ClientesModule;
using e_Locadora5.Controladores.CondutorModule;
using e_Locadora5.Controladores.CupomModule;
using e_Locadora5.Controladores.FuncionarioModule;
using e_Locadora5.Controladores.LocacaoModule;
using e_Locadora5.Controladores.ParceiroModule;
using e_Locadora5.Controladores.TaxasServicoModule;
using e_Locadora5.Controladores.VeiculoModule;
using e_Locadora5.Dominio.FuncionarioModule;
using e_Locadora5.Infra.SQL.FuncionarioModule;
using e_Locadora5.WindowsApp.ClientesModule;
using e_Locadora5.WindowsApp.Features.CondutorModule;
using e_Locadora5.WindowsApp.Features.ConfiguracoesCombustivel;
using e_Locadora5.WindowsApp.Features.CuponsModule;
using e_Locadora5.WindowsApp.Features.FuncionarioModule;
using e_Locadora5.WindowsApp.Features.LocacaoModule;
using e_Locadora5.WindowsApp.Features.ParceirosModule;
using e_Locadora5.WindowsApp.Features.TaxasServicosModule;
using e_Locadora5.WindowsApp.GrupoVeiculoModule;
using e_Locadora5.WindowsApp.Login;
using e_Locadora5.WindowsApp.Shared;
using e_Locadora5.WindowsApp.VeiculoModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Locadora5.WindowsApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ICadastravel operacoes;

        public static TelaPrincipalForm Instancia;

        public Funcionario funcionario;

        private OperacoesClientes operacoesClientes;
        private OperacoesCondutores operacoesCondutores;
        private OperacoesFuncionario operacoesFuncionario;
        private OperacoesGrupoVeiculo operacoesGrupoVeiculo;
        private OperacoesLocacao operacoesLocacao;
        private OperacoesVeiculo operacoesVeiculo;
        private OperacoesTaxaServicos operacoesTaxaServicos;
        private OperacoesCupons operacoesCupons;
        private OperacoesParceiros operacoesParceiros;


        public TelaPrincipalForm()
        {
            InitializeComponent();
            Instancia = this;

            operacoesClientes = new OperacoesClientes(new ControladorClientes());
            operacoesGrupoVeiculo = new OperacoesGrupoVeiculo(new ControladorGrupoVeiculo());
            operacoesCondutores = new OperacoesCondutores(new ControladorCondutor());
            operacoesTaxaServicos = new OperacoesTaxaServicos(new ControladorTaxasServicos());
            operacoesLocacao = new OperacoesLocacao(new ControladorLocacao());
            operacoesFuncionario = new OperacoesFuncionario(new FuncionarioAppService(new FuncionarioDAO()));
            operacoesVeiculo = new OperacoesVeiculo(new ControladorVeiculos());
            operacoesCupons = new OperacoesCupons(new ControladorCupons());
            operacoesParceiros = new OperacoesParceiros(new ControladorParceiro());
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }

        private void ConfigurarPainelRegistros()
        {
            UserControl tabela = operacoes.ObterTabela();
            tabela.Dock = DockStyle.Fill;
            
            panelRegistros.Controls.Clear();

            panelRegistros.Controls.Add(tabela);

        }

        private void ConfigurarToolBox(IConfiguracaoToolBox configuracao)
        {
            toolboxAcoes.Enabled = true;
            labelTipoCadastro.Text = configuracao.TipoCadastro;

            btnAdicionar.ToolTipText = configuracao.ObterToolTips().Adicionar;
            btnEditar.ToolTipText = configuracao.ObterToolTips().Editar;
            btnExcluir.ToolTipText = configuracao.ObterToolTips().Excluir;

            btnAgrupar.ToolTipText = configuracao.ObterToolTips().Agrupar;
            btnDesagrupar.ToolTipText = configuracao.ObterToolTips().Desagrupar;
            btnFiltrar.ToolTipText = configuracao.ObterToolTips().Filtrar;
            btnDevolucao.ToolTipText = configuracao.ObterToolTips().Devolucao;
            btnClassificacao.ToolTipText = configuracao.ObterToolTips().Classificacao;
            btnEmail.ToolTipText = configuracao.ObterToolTips().Email;

            btnAdicionar.Enabled = configuracao.ObterEstadoBotoes().Adicionar;
            btnEditar.Enabled = configuracao.ObterEstadoBotoes().Editar;
            btnExcluir.Enabled = configuracao.ObterEstadoBotoes().Excluir;

            btnAgrupar.Enabled = configuracao.ObterEstadoBotoes().Agrupar;
            btnDesagrupar.Enabled = configuracao.ObterEstadoBotoes().Desagrupar;
            btnFiltrar.Enabled = configuracao.ObterEstadoBotoes().Filtrar;
            btnDevolucao.Enabled = configuracao.ObterEstadoBotoes().Devolucao;
            btnClassificacao.Enabled = configuracao.ObterEstadoBotoes().Classificacao;
            btnEmail.Enabled = configuracao.ObterEstadoBotoes().Email;
        }

        private void menuItemGrupoVeiculos_Click(object sender, EventArgs e)
        {
            ConfiguracaoGrupoVeiculoToolBox configuracao = new ConfiguracaoGrupoVeiculoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = operacoesGrupoVeiculo;

            ConfigurarPainelRegistros();
        }
        private void menuItemClientes_Click(object sender, EventArgs e)
        {
            ConfiguracaoClientesToolBox configuracao = new ConfiguracaoClientesToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = operacoesClientes;

            ConfigurarPainelRegistros();
        }
        private void menuItemCondutor_Click(object sender, EventArgs e)
        {
            ConfiguracaoCondutoresToolBox configuracao = new ConfiguracaoCondutoresToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = operacoesCondutores;

            ConfigurarPainelRegistros();
        }
        private void MenuItemTaxasEServicos_Click(object sender, EventArgs e)
        {
            ConfiguracaoTaxaServicosToolBox configuracao = new ConfiguracaoTaxaServicosToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = operacoesTaxaServicos;

            ConfigurarPainelRegistros();
        }
        private void locaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoLocacaoToolBox configuracao = new ConfiguracaoLocacaoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = operacoesLocacao;

            ConfigurarPainelRegistros();
        }

        private void devoluçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void funcionariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoFuncionarioToolBox configuracao = new ConfiguracaoFuncionarioToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = operacoesFuncionario;

            ConfigurarPainelRegistros();
        }

 
        private void combustivelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConfiguracaoCombustivelToolBox configuracao = new ConfiguracaoCombustivelToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesCombustivel();

            ConfigurarPainelRegistros();
        }

        private void menuItemVeiculo_Click(object sender, EventArgs e)
        {
            ConfiguracaoVeiculoToolBox configuracao = new ConfiguracaoVeiculoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = operacoesVeiculo;

            ConfigurarPainelRegistros();
        }
        private void perceirosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoParceiroToolBox configuracao = new ConfiguracaoParceiroToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = operacoesParceiros;

            ConfigurarPainelRegistros();
        }

        private void cuponsDeDescontosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoCuponsToolBox configuracao = new ConfiguracaoCuponsToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = operacoesCupons;

            ConfigurarPainelRegistros();
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            operacoes.InserirNovoRegistro();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            operacoes.EditarRegistro();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            operacoes.ExcluirRegistro();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            operacoes.FiltrarRegistros();
        }

        private void btnAgrupar_Click(object sender, EventArgs e)
        {
            operacoes.AgruparRegistros();
        }

        private void btnDesagrupar_Click(object sender, EventArgs e)
        {
            operacoes.DesagruparRegistros();
        }

        private void btnDevolucao_Click(object sender, EventArgs e)
        {
            OperacoesLocacao operacaoDevolucao = (OperacoesLocacao)operacoes;
            operacaoDevolucao.RegistrarDevolucao();
        }

        private void TelaPrincipalForm_Load(object sender, EventArgs e)
        {
            if(funcionario.Usuario != "admin")
            {
                funcionariosToolStripMenuItem.Enabled = false;
                combustivelToolStripMenuItem1.Enabled = false;
            }
            if(funcionario.Usuario == "admin")
            {
                menuItemClientes.Enabled = false;
                menuItemCondutor.Enabled = false;
                menuItemVeiculo.Enabled = false;
                menuItemGrupoVeiculos.Enabled = false;
                MenuItemTaxasEServicos.Enabled = false;
                locaçãoToolStripMenuItem.Enabled = false;
                cuponsDeDescontosToolStripMenuItem.Enabled = false;
                perceirosToolStripMenuItem.Enabled = false;
                
            }

            labelRodape.Text = "Seja bem vindo " + funcionario.Nome;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            funcionario = null;
            this.Hide();
            TelaPrincipalForm telaPrincipalForm = new TelaPrincipalForm();
            telaPrincipalForm.Close();
            
            TelaLogin telaLogin = new TelaLogin();
            telaLogin.ShowDialog();
        }

        private void btnQuantidadeCupons_Click(object sender, EventArgs e)
        {
            OperacoesCupons operacaoCupom = (OperacoesCupons)operacoes;
            operacaoCupom.MostrarClassificacao();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            OperacoesLocacao operacaoDevolucao = (OperacoesLocacao)operacoes;
            operacaoDevolucao.VisualizarEmailsPendentes();
        }
    }
}
