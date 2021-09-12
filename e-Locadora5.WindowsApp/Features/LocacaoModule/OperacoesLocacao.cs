using e_Locadora5.Controladores.CondutorModule;
using e_Locadora5.Controladores.LocacaoModule;
using e_Locadora5.Controladores.VeiculoModule;
using e_Locadora5.Dominio.LocacaoModule;
using e_Locadora5.Dominio.TaxasServicosModule;
using e_Locadora5.WindowsApp.Features.DevolucaoModule;
using e_Locadora5.WindowsApp.Shared;
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
        private ControladorLocacao controladorLocacao = null;
        private ControladorVeiculos controladorVeiculo = new ControladorVeiculos();
        private TabelaLocacaoControl tabelaLocacao = null;
        private ControladorCondutor controladorCondutor = new ControladorCondutor();


        public OperacoesLocacao(ControladorLocacao controladorLocacao)
        {
            this.controladorLocacao = controladorLocacao;
            tabelaLocacao = new TabelaLocacaoControl();
        }
        public void InserirNovoRegistro()
        {
            TelaLocacaoForm tela = new TelaLocacaoForm();
            tela.ShowDialog();
            if (tela.DialogResult == DialogResult.OK && controladorLocacao.ValidarLocacao(tela.Locacao) == "ESTA_VALIDO" 
                && controladorLocacao.ValidarCNH(tela.Locacao) == "ESTA_VALIDO")
            {
                controladorLocacao.InserirNovo(tela.Locacao);

                tabelaLocacao.AtualizarRegistros();

                TelaPrincipalForm.Instancia.AtualizarRodape($"Locação do veículo: [{tela.Locacao.veiculo.Modelo}] para o Cliente: [{tela.Locacao.cliente.Nome}] foi efetuada com sucesso");
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

            Locacao locacaoSelecionado = controladorLocacao.SelecionarPorId(id);

            TelaLocacaoForm tela = new TelaLocacaoForm();

            tela.Locacao = locacaoSelecionado;
            tela.ShowDialog();
            if (tela.DialogResult == DialogResult.OK && controladorLocacao.ValidarLocacao(tela.Locacao, id) == "ESTA_VALIDO"
                && controladorLocacao.ValidarCNH(tela.Locacao) == "ESTA_VALIDO")
            {
     
                controladorLocacao.Editar(id, tela.Locacao);

                tabelaLocacao.AtualizarRegistros();

                TelaPrincipalForm.Instancia.AtualizarRodape($"Locação do veículo: [{tela.Locacao.veiculo.Modelo}] para o Cliente: [{tela.Locacao.cliente.Nome}] foi editada com sucesso");
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

            Locacao locacaoSelecionado = controladorLocacao.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir a Locação do veículo: [{locacaoSelecionado.veiculo.Modelo}] para o Cliente: [{locacaoSelecionado.cliente.Nome}]?",
                "Exclusão de Locação", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (controladorLocacao.Excluir(id))
                {
                    tabelaLocacao.AtualizarRegistros();

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Locação do veículo: [{locacaoSelecionado.veiculo.Modelo}] para o Cliente: [{locacaoSelecionado.cliente.Nome}] foi removida com sucesso");
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Locação do veículo: Não foi possível excluir [{locacaoSelecionado.veiculo.Modelo}], pois ele está vinculado a outros registros");
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
                        locacoes = controladorLocacao.SelecionarTodos();
                        break;

                    case FlitroLocacoesEnum.LocacoesChegadaPendente:
                        {
                            locacoes = controladorLocacao.SelecionarLocacoesPendentes(true, DateTime.Now);
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
            Locacao locacaoSelecionado = controladorLocacao.SelecionarPorId(id);

            tela.Locacao = locacaoSelecionado;
            if (locacaoSelecionado.emAberto == true)
            {
                tela.ShowDialog();
                //inserir no botão gravar de devolução
                //if (MessageBox.Show($"Tem certeza que deseja registrar a devolução do veículo: [{locacaoSelecionado.veiculo.Modelo}] do Cliente: [{locacaoSelecionado.cliente.Nome}]?",
                //    "Registro de Devolução", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                if (tela.DialogResult == DialogResult.OK && controladorLocacao.ValidarLocacao(tela.Locacao, id) == "ESTA_VALIDO")
                {
                    controladorVeiculo.Editar(locacaoSelecionado.veiculo.Id, locacaoSelecionado.veiculo);
                    controladorLocacao.Editar(id, locacaoSelecionado);

                    tabelaLocacao.AtualizarRegistros();

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Locação do veículo: [{locacaoSelecionado.veiculo.Modelo}] para o Cliente: [{locacaoSelecionado.cliente.Nome}] foi devolvida com sucesso");
                }
            }
            else
                MessageBox.Show($"Não é possível fazer a devolução de locações já finalizadas.", "Devolução já realizada", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public void VisualizarEmailsPendentes()
        {
            TelaEmailsPendentesForm tela = new TelaEmailsPendentesForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                List<Locacao> locacoes = new List<Locacao>();
                locacoes = controladorLocacao.SelecionarTodos();
                        
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
