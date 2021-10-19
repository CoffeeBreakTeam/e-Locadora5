using e_Locadora5.Aplicacao.GrupoVeiculoModule;
using e_Locadora5.Aplicacao.VeiculoModule;
using e_Locadora5.Dominio.VeiculosModule;
using e_Locadora5.Infra.GeradorLogs;
using e_Locadora5.WindowsApp.Features.VeiculoModule;
using e_Locadora5.WindowsApp.Shared;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Locadora5.WindowsApp.VeiculoModule
{
    public class OperacoesVeiculo : ICadastravel
    {
        private VeiculoAppService veiculoAppService = null;
        private GrupoVeiculoAppService grupoVeiculoAppService = null;
        private TabelaVeiculoControl tabelaVeiculoControl = null;

        public OperacoesVeiculo(VeiculoAppService veiculoAppService, GrupoVeiculoAppService grupoVeiculoAppService)
        {
            this.veiculoAppService = veiculoAppService;
            this.grupoVeiculoAppService = grupoVeiculoAppService;
            tabelaVeiculoControl = new TabelaVeiculoControl(veiculoAppService);
        }


        public void AgruparRegistros()
        {
        }

        public void DesagruparRegistros()
        {
        }

        public void EditarRegistro()
        {
            int id = tabelaVeiculoControl.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Veiculo para poder editar!", "Edição de Veiculos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Veiculo VeiculoSelecionada = veiculoAppService.SelecionarPorId(id);

            TelaVeiculoForm tela = new TelaVeiculoForm(veiculoAppService, grupoVeiculoAppService);

            tela.Veiculo = VeiculoSelecionada;

            
            if (tela.ShowDialog() == DialogResult.OK)
            {
                string resultado = veiculoAppService.Editar(id, tela.Veiculo);

                if (resultado == "ESTA_VALIDO")
                {
                    tabelaVeiculoControl.AtualizarRegistros();
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Veiculo: [{tela.Veiculo.Placa}] editado com sucesso");
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
            int id = tabelaVeiculoControl.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um veiculo para poder excluir!", "Exclusão de Veiculo",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Veiculo VeiculoSelecionada = veiculoAppService.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o veiculo: [{VeiculoSelecionada.Placa}] ?",
                "Exclusão de Veiculo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (veiculoAppService.Excluir(id))
                {
                    tabelaVeiculoControl.AtualizarRegistros();

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Veiculo: [{VeiculoSelecionada.Placa}] removido com sucesso");
                    Log.Logger.Contexto().Information("Funcionalidade Usada");
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Veiculo: [{VeiculoSelecionada.Placa}] não pode ser removido, pois está vinculado a uma locação");
                    Log.Logger.Contexto().Information("Funcionalidade Usada");
                }
                    
            }
        }

        public void FiltrarRegistros()
        {
        }

        public void InserirNovoRegistro()
        {
            TelaVeiculoForm tela = new TelaVeiculoForm(veiculoAppService,grupoVeiculoAppService);
            
            if (tela.ShowDialog() == DialogResult.OK)
            {
                string resultado = veiculoAppService.InserirNovo(tela.Veiculo);

                if (resultado == "ESTA_VALIDO")
                {
                    tabelaVeiculoControl.AtualizarRegistros();
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Veiculo: [{tela.Veiculo.Placa}] inserido com sucesso");
                    Log.Logger.Contexto().Information("Funcionalidade Usada");
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(resultado);
                    Log.Logger.Contexto().Information(resultado);
                }
            }
        }

        public UserControl ObterTabela()
        {
            tabelaVeiculoControl.AtualizarRegistros();

            return tabelaVeiculoControl;
        }
    }
}
