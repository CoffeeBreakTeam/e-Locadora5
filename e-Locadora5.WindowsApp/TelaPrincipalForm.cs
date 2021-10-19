﻿using Autofac;
using e_Locadora5.Aplicacao.ClienteModule;
using e_Locadora5.Aplicacao.CondutorModule;
using e_Locadora5.Aplicacao.CupomModule;
using e_Locadora5.Aplicacao.FuncionarioModule;
using e_Locadora5.Aplicacao.GrupoVeiculoModule;
using e_Locadora5.Aplicacao.LocacaoModule;
using e_Locadora5.Aplicacao.ParceiroModule;
using e_Locadora5.Aplicacao.TaxasServicosModule;
using e_Locadora5.Aplicacao.VeiculoModule;
using e_Locadora5.Dominio.FuncionarioModule;
using e_Locadora5.Dominio.GrupoVeiculoModule;
using e_Locadora5.Infra.ORM.ClienteModule;
using e_Locadora5.Infra.ORM.CondutorModule;
using e_Locadora5.Infra.ORM.CupomModule;
using e_Locadora5.Infra.ORM.FuncionarioModule;
using e_Locadora5.Infra.ORM.GrupoVeiculoModule;
using e_Locadora5.Infra.ORM.LocacaoModule;
using e_Locadora5.Infra.ORM.ParceiroModule;
using e_Locadora5.Infra.ORM.TaxasServicosModule;
using e_Locadora5.Infra.ORM.VeiculoModule;
using e_Locadora5.Infra.SQL.ClienteModule;
using e_Locadora5.Infra.SQL.CondutorModule;
using e_Locadora5.Infra.SQL.CupomModule;
using e_Locadora5.Infra.SQL.FuncionarioModule;
using e_Locadora5.Infra.SQL.GrupoVeiculoModule;
using e_Locadora5.Infra.SQL.LocacaoModule;
using e_Locadora5.Infra.SQL.ParceiroModule;
using e_Locadora5.Infra.SQL.TaxasServicosModule;
using e_Locadora5.Infra.SQL.VeiculoModule;
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

        public TelaPrincipalForm()
        {
            InitializeComponent();
            Instancia = this;        

        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }

        private void ConfigurarPainelRegistros(ICadastravel operacoes)
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

            operacoes = AutoFacBuilder.Container.Resolve<OperacoesGrupoVeiculo>();

            ConfigurarPainelRegistros(operacoes);
        }     

        private void menuItemClientes_Click(object sender, EventArgs e)
        {
            ConfiguracaoClientesToolBox configuracao = new ConfiguracaoClientesToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = AutoFacBuilder.Container.Resolve<OperacoesClientes>();

            ConfigurarPainelRegistros(operacoes);
        }

        private ICadastravel ObtemOperacaoCliente()
        {
            var context = new LocadoraDbContext();
            var repository = new ClienteOrmDAO(context);
            var clienteSer = new ClienteAppService(repository);
            operacoes = new OperacoesClientes(clienteSer);
            return operacoes;
        }

        private void menuItemCondutor_Click(object sender, EventArgs e)
        {
            ConfiguracaoCondutoresToolBox configuracao = new ConfiguracaoCondutoresToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = AutoFacBuilder.Container.Resolve<OperacoesCondutores>();

            ConfigurarPainelRegistros(operacoes);
        }

        private ICadastravel ObtemOperacoesCondutores()
        {
            var context = new LocadoraDbContext();

            var clienteRepository = new ClienteOrmDAO(context);
            var clienteAppService = new ClienteAppService(clienteRepository);

            var condutorRepository = new CondutorOrmDAO(context);
            var condutorAppService = new CondutorAppService(condutorRepository);           

            operacoes = new OperacoesCondutores(condutorAppService, clienteAppService);
            return operacoes;
        }

        private void MenuItemTaxasEServicos_Click(object sender, EventArgs e)
        {
            ConfiguracaoTaxaServicosToolBox configuracao = new ConfiguracaoTaxaServicosToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = ObtemOperacoesTaxaServicos();

            ConfigurarPainelRegistros(operacoes);
        }

        private ICadastravel ObtemOperacoesTaxaServicos()
        {
            var context = new LocadoraDbContext();


            var TaxasRepository = new TaxasServicosOrmDAO(context);
            var taxasServicosAppService = new TaxasServicosAppService(TaxasRepository);

            operacoes = new OperacoesTaxaServicos(taxasServicosAppService);
            return operacoes;
        }

        private void locaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoLocacaoToolBox configuracao = new ConfiguracaoLocacaoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = ObtemOperacoesLocacao();

            ConfigurarPainelRegistros(operacoes);
        }

        private ICadastravel ObtemOperacoesLocacao()
        {
            var context = new LocadoraDbContext();

            var clienteRepository = new ClienteOrmDAO(context);
            var clienteAppService = new ClienteAppService(clienteRepository);

            var condutorRepository = new CondutorOrmDAO(context);
            var condutorAppService = new CondutorAppService(condutorRepository);

            var veiculoRepository = new VeiculoOrmDAO(context);
            var grupoVeiculoRepository = new GrupoVeiculoOrmDAO(context);

            var veiculoAppService = new VeiculoAppService(veiculoRepository);
            var grupoVeiculoAppService = new GrupoVeiculoAppService(grupoVeiculoRepository);

            var locacaoRepository = new LocacaoOrmDAO(context);
            var locacaoAppService = new LocacaoAppService(locacaoRepository);

            var TaxasRepository = new TaxasServicosOrmDAO(context);
            var taxasServicosAppService = new TaxasServicosAppService(TaxasRepository);

            var FuncionarioRepository = new FuncionarioOrmDAO(context);
            var funcionarioAppService = new FuncionarioAppService(FuncionarioRepository);

            var cupomRepository = new CupomOrmDAO(context);
            var cupomAppService = new CupomAppService(cupomRepository);

            var parceiroRepository = new ParceiroOrmDAO(context);
            var parceiroAppService = new ParceiroAppService(parceiroRepository);

            operacoes = new OperacoesLocacao(funcionarioAppService,grupoVeiculoAppService,veiculoAppService, clienteAppService,condutorAppService, taxasServicosAppService,parceiroAppService,cupomAppService,locacaoAppService);
            return operacoes;
        }

        private void devoluçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void funcionariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoFuncionarioToolBox configuracao = new ConfiguracaoFuncionarioToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = ObtemOperacoesFuncionario();

            ConfigurarPainelRegistros(operacoes);
        }

        private ICadastravel ObtemOperacoesFuncionario()
        {
            var context = new LocadoraDbContext();
            var repository = new FuncionarioOrmDAO(context);
            var funcionarioSer = new FuncionarioAppService(repository);
            operacoes = new OperacoesFuncionario(funcionarioSer);
            return operacoes;
        }

        private void combustivelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConfiguracaoCombustivelToolBox configuracao = new ConfiguracaoCombustivelToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesCombustivel();

            ConfigurarPainelRegistros(operacoes);
        }

        private void menuItemVeiculo_Click(object sender, EventArgs e)
        {
            ConfiguracaoVeiculoToolBox configuracao = new ConfiguracaoVeiculoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = ObtemOperacoesVeiculo();

            ConfigurarPainelRegistros(operacoes);
        }

        private ICadastravel ObtemOperacoesVeiculo()
        {
            var context = new LocadoraDbContext();

            var veiculoRepository = new VeiculoOrmDAO(context);
            var grupoVeiculoRepository = new GrupoVeiculoOrmDAO(context);

            var veiculoAppService = new VeiculoAppService(veiculoRepository);
            var grupoVeiculoAppService = new GrupoVeiculoAppService(grupoVeiculoRepository);

            operacoes = new OperacoesVeiculo(veiculoAppService, grupoVeiculoAppService);
            return operacoes;
        }

        private void perceirosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoParceiroToolBox configuracao = new ConfiguracaoParceiroToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = AutoFacBuilder.Container.Resolve<OperacoesParceiros>();

            ConfigurarPainelRegistros(operacoes);
        }      

        private void cuponsDeDescontosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoCuponsToolBox configuracao = new ConfiguracaoCuponsToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = AutoFacBuilder.Container.Resolve<OperacoesCupons>();

            ConfigurarPainelRegistros(operacoes);
        }

        private ICadastravel ObtemOperacoesCupons()
        {
            var context = new LocadoraDbContext();

            var cupomRepository = new CupomOrmDAO(context);
            var cupomAppService = new CupomAppService(cupomRepository);

            var parceiroRepository = new ParceiroOrmDAO(context);
            var parceiroAppService = new ParceiroAppService(parceiroRepository);

            operacoes = new OperacoesCupons(cupomAppService,parceiroAppService);
            return operacoes;
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
            if (funcionario.Usuario != "admin")
            {
                funcionariosToolStripMenuItem.Enabled = false;
                combustivelToolStripMenuItem1.Enabled = false;
            }
            if (funcionario.Usuario == "admin")
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
