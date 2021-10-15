using e_Locadora5.Aplicacao.ClienteModule;
using e_Locadora5.Aplicacao.CondutorModule;
using e_Locadora5.Aplicacao.CupomModule;
using e_Locadora5.Aplicacao.FuncionarioModule;
using e_Locadora5.Aplicacao.GrupoVeiculoModule;
using e_Locadora5.Aplicacao.LocacaoModule;
using e_Locadora5.Aplicacao.ParceiroModule;
using e_Locadora5.Aplicacao.TaxasServicosModule;
using e_Locadora5.Aplicacao.VeiculoModule;
using e_Locadora5.Dominio.LocacaoModule;
using e_Locadora5.Email;
using e_Locadora5.Infra.SQL.LocacaoModule;
using e_Locadora5.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Locadora5.WindowsApp.Features.LocacaoModule
{
    public partial class TelaEmailsPendentesForm : Form
    {
        private LocacaoAppService locacaoAppService = new LocacaoAppService(new LocacaoDAO());
        private OperacoesLocacao operacaoLocacao;
        private TabelaLocacaoControl tabelaLocacao;
        public TelaEmailsPendentesForm(FuncionarioAppService funcionarioAppService, GrupoVeiculoAppService grupoVeiculoAppService, VeiculoAppService veiculoAppService, ClienteAppService clienteAppService, CondutorAppService condutorAppService, TaxasServicosAppService taxasServicosAppService, ParceiroAppService parceiroAppService, CupomAppService cupomAppService, LocacaoAppService locacaoAppService)
        {
            InitializeComponent();
            operacaoLocacao = new OperacoesLocacao(funcionarioAppService,grupoVeiculoAppService,veiculoAppService,clienteAppService,condutorAppService,taxasServicosAppService,parceiroAppService,cupomAppService,locacaoAppService);
            ConfigurarPainelRegistros();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            int id = tabelaLocacao.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione uma locação para enviar o resumo financeiro por email!", "Email pendente de Locação",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Locacao locacaoSelecionado = locacaoAppService.SelecionarPorId(id);

            TelaPrincipalForm.Instancia.AtualizarRodape("Gerando PDF do Resumo Financeiro...");
            PDF pdf = new PDF(locacaoSelecionado);
            string localPDF = pdf.GerarPDF();
            do
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("Tentando se conectar a internet...");
                SMTP email = new SMTP();
                if (email.estaConectadoInternet())
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape("Enviando email para " + locacaoSelecionado.Cliente.Email);
                    email.enviarEmail(locacaoSelecionado.Cliente.Email, "Resumo Financeiro de Locação", "", localPDF);
                    TelaPrincipalForm.Instancia.AtualizarRodape("Email com resumo financeiro enviado para " + locacaoSelecionado.Cliente.Email);
                    locacaoSelecionado.emailEnviado = true;
                    locacaoAppService.Editar(id, locacaoSelecionado);
                    tabelaLocacao.AtualizarLocacoesEmailsPendentes();
                    break;
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape("Não foi possível se conectar a internet para enviar o resumo financeiro");
                    if (MessageBox.Show($"Não foi possível conectar-se a internet. Deseja tentar novamente?",
                        "Envio de email", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        TelaPrincipalForm.Instancia.AtualizarRodape("Cancelado envio da segunda via do email");
                        break;
                    }
                }
            } while (true);



            
            
            
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("Cancelado envio da segunda via do email");
        }

        private void ConfigurarPainelRegistros()
        {
            tabelaLocacao = (TabelaLocacaoControl)operacaoLocacao.ObterTabelaEmailsPendentes();
            tabelaLocacao.Dock = DockStyle.Fill;

            panelLocacoes.Controls.Clear();

            panelLocacoes.Controls.Add(tabelaLocacao);
        }
    }
}
