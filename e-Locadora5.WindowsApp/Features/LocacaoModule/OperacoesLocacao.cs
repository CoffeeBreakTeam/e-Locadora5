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
using e_Locadora5.Dominio.TaxasServicosModule;
using e_Locadora5.Email;
using e_Locadora5.Infra.GeradorLogs;
using e_Locadora5.Infra.SQL.CondutorModule;
using e_Locadora5.Infra.SQL.VeiculoModule;
using e_Locadora5.WindowsApp.Features.DevolucaoModule;
using e_Locadora5.WindowsApp.Shared;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Locadora5.WindowsApp.Features.LocacaoModule
{
    public class OperacoesLocacao : ICadastravel
    {
        private FuncionarioAppService funcionarioAppService = null;
        private GrupoVeiculoAppService grupoVeiculoAppService = null;
        private VeiculoAppService veiculoAppService = null;
        private ClienteAppService clienteAppService = null;
        private CondutorAppService condutorAppService = null;
        private TaxasServicosAppService taxasServicosAppService = null;
        private ParceiroAppService parceiroAppService = null;
        private CupomAppService cupomAppService = null;
        private LocacaoAppService locacaoAppService = null;

        private TabelaLocacaoControl tabelaLocacao = null;
        public OperacoesLocacao(FuncionarioAppService funcionarioAppService, GrupoVeiculoAppService grupoVeiculoAppService, VeiculoAppService veiculoAppService, ClienteAppService clienteAppService, CondutorAppService condutorAppService, TaxasServicosAppService taxasServicosAppService, ParceiroAppService parceiroAppService, CupomAppService cupomAppService, LocacaoAppService locacaoAppService)
        {
            this.funcionarioAppService = funcionarioAppService;
            this.grupoVeiculoAppService = grupoVeiculoAppService;
            this.veiculoAppService = veiculoAppService;
            this.clienteAppService = clienteAppService;
            this.condutorAppService = condutorAppService;
            this.taxasServicosAppService = taxasServicosAppService;
            this.parceiroAppService = parceiroAppService;
            this.cupomAppService = cupomAppService;
            this.locacaoAppService = locacaoAppService;
            tabelaLocacao = new TabelaLocacaoControl(locacaoAppService);
        }
        public void InserirNovoRegistro()
        {
            TelaLocacaoForm tela = new TelaLocacaoForm(funcionarioAppService, grupoVeiculoAppService, veiculoAppService, clienteAppService, condutorAppService, taxasServicosAppService, parceiroAppService, cupomAppService, locacaoAppService);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                string resultado = locacaoAppService.InserirNovo(tela.Locacao);

                if (resultado == "ESTA_VALIDO")
                {
                    //TelaPrincipalForm.Instancia.AtualizarRodape("Gerando PDF do Resumo Financeiro...");
                    //Locacao locacao = tela.Locacao;
                    
                    //do
                    //{
                    //    TelaPrincipalForm.Instancia.AtualizarRodape("Tentando se conectar a internet...");
                    //    SMTP email = new SMTP();
                    //    if (email.estaConectadoInternet())
                    //    {
                    //        TelaPrincipalForm.Instancia.AtualizarRodape("Enviando email para " + locacao.Cliente.Email);
                    //        email.enviarEmail(locacao.Cliente.Email, "Resumo Financeiro de Locação", "", localPDF);
                    //        TelaPrincipalForm.Instancia.AtualizarRodape("Email com resumo financeiro enviado para " + locacao.Cliente.Email);
                    //        Log.Logger.Contexto().Information("Funcionalidade Usada");
                    //        locacao.emailEnviado = true;
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        TelaPrincipalForm.Instancia.AtualizarRodape("Não foi possível se conectar a internet para enviar o resumo financeiro");
                    //        if (MessageBox.Show($"Não foi possível conectar-se a internet. Deseja tentar novamente?",
                    //            "Envio de email", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    //        {
                    //            TelaPrincipalForm.Instancia.AtualizarRodape("Cancelado envio de email");
                    //            break;
                    //        }
                    //    }
                    //} while (true);

                    tabelaLocacao.AtualizarRegistros();

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Locação do veículo: [{tela.Locacao.Veiculo.Modelo}] para o Cliente: [{tela.Locacao.Cliente.Nome}] foi efetuada com sucesso");
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(resultado);
                    Log.Logger.Contexto().Information(resultado);
                }
            }
        }
       

        public void EditarRegistro()
        {
            int id = tabelaLocacao.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Locação para poder editar!", "Edição de Locacao",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Locacao locacaoSelecionado = locacaoAppService.SelecionarPorId(id);

            TelaLocacaoForm tela = new TelaLocacaoForm(funcionarioAppService, grupoVeiculoAppService, veiculoAppService, clienteAppService, condutorAppService, taxasServicosAppService, parceiroAppService, cupomAppService, locacaoAppService);

            tela.Locacao = locacaoSelecionado;
            
            if (tela.ShowDialog() == DialogResult.OK)
            {
                string resultado = locacaoAppService.Editar(id, tela.Locacao);

                if (resultado == "ESTA_VALIDO")
                {
                    tabelaLocacao.AtualizarRegistros();
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Locação do veículo: [{tela.Locacao.Veiculo.Modelo}] para o Cliente: [{tela.Locacao.Cliente.Nome}] foi editada com sucesso");
                    Log.Logger.Contexto().Information("Funcionalidade Usada");
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(resultado);
                    Log.Logger.Contexto().Information(resultado);
                }
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaLocacao.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Locação para poder excluir!", "Exclusão de Locacao",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Locacao locacaoSelecionado = locacaoAppService.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir a Locação do veículo: [{locacaoSelecionado.Veiculo.Modelo}] para o Cliente: [{locacaoSelecionado.Cliente.Nome}]?",
                "Exclusão de Locação", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (locacaoAppService.Excluir(id))
                {
                    tabelaLocacao.AtualizarRegistros();

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Locação do veículo: [{locacaoSelecionado.Veiculo.Modelo}] para o Cliente: [{locacaoSelecionado.Cliente.Nome}] foi removida com sucesso");
                    
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Locação do veículo: Não foi possível excluir [{locacaoSelecionado.Veiculo.Modelo}], pois ele está vinculado a outros registros");
                }
            }
        }

        public UserControl ObterTabela()
        {
            tabelaLocacao.AtualizarRegistros();

            return tabelaLocacao;
        }

        public UserControl ObterTabelaEmailsPendentes()
        {
            tabelaLocacao.AtualizarLocacoesEmailsPendentes();

            return tabelaLocacao;
        }

        public void FiltrarRegistros()
        {
            TelaFiltroLocacaoForm tela = new TelaFiltroLocacaoForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                List<Locacao> locacoes = new List<Locacao>();

                string chegadasPendentes = "";

                switch (tela.TipoFiltro)
                {
                    case FlitroLocacoesEnum.TodasLocacoes:
                        locacoes = locacaoAppService.SelecionarTodos();
                        break;

                    case FlitroLocacoesEnum.LocacoesChegadaPendente:
                        {
                            locacoes = locacaoAppService.SelecionarLocacoesPendentes(true, DateTime.Now);
                            chegadasPendentes = "Pendentes";
                            break;
                        }

                    default:
                        break;
                }
                tabelaLocacao.CarregarTabela(locacoes);
                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {locacoes.Count} chegadas {chegadasPendentes}");
                
            }
        }

        public void RegistrarDevolucao()
        {
            int id = tabelaLocacao.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione uma Locação para registrar sua devolução!", "Registro de Devolução",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            TelaDevolucaoForm tela = new TelaDevolucaoForm();
            Locacao locacaoSelecionado = locacaoAppService.SelecionarPorId(id);

            tela.Locacao = locacaoSelecionado;
            if (locacaoSelecionado.emAberto == true)
            {
                tela.ShowDialog();
                //inserir no botão gravar de devolução
                //if (MessageBox.Show($"Tem certeza que deseja registrar a devolução do veículo: [{locacaoSelecionado.veiculo.Modelo}] do Cliente: [{locacaoSelecionado.cliente.Nome}]?",
                //    "Registro de Devolução", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                if (tela.DialogResult == DialogResult.OK)
                {
                    veiculoAppService.Editar(locacaoSelecionado.Veiculo.Id, locacaoSelecionado.Veiculo);
                    locacaoAppService.Editar(id, locacaoSelecionado);

                    tabelaLocacao.AtualizarRegistros();

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Locação do veículo: [{locacaoSelecionado.Veiculo.Modelo}] para o Cliente: [{locacaoSelecionado.Cliente.Nome}] foi devolvida com sucesso");
                    
                }
            }
            else
                MessageBox.Show($"Não é possível fazer a devolução de locações já finalizadas.", "Devolução já realizada", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public void VisualizarEmailsPendentes()
        {
            TelaEmailsPendentesForm tela = new TelaEmailsPendentesForm(funcionarioAppService, grupoVeiculoAppService, veiculoAppService, clienteAppService, condutorAppService, taxasServicosAppService, parceiroAppService, cupomAppService, locacaoAppService);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                List<Locacao> locacoes = new List<Locacao>();
                locacoes = locacaoAppService.SelecionarTodos();
                        
                tabelaLocacao.CarregarTabela(locacoes);
                
            }
        }

        public void AgruparRegistros()
        {
            throw new NotImplementedException();
        }

        public void DesagruparRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
