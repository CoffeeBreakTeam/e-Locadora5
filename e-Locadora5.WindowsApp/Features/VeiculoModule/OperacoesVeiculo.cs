using e_Locadora5.Aplicacao.VeiculoModule;
using e_Locadora5.Dominio.VeiculosModule;
using e_Locadora5.WindowsApp.Features.VeiculoModule;
using e_Locadora5.WindowsApp.Shared;
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
        private TabelaVeiculoControl tabelaVeiculoControl = null;


        public OperacoesVeiculo(VeiculoAppService veiculoAppService)
        {
            this.veiculoAppService = veiculoAppService;
            tabelaVeiculoControl = new TabelaVeiculoControl();
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

            TelaVeiculoForm tela = new TelaVeiculoForm();

            tela.Veiculo = VeiculoSelecionada;

            tela.ShowDialog();
            if (tela.ValidarCampos() == "VALIDO" && tela.DialogResult == DialogResult.OK)
            {
                veiculoAppService.Editar(id, tela.Veiculo);

                tabelaVeiculoControl.AtualizarRegistros();

                TelaPrincipalForm.Instancia.AtualizarRodape($"Veiculo: [{tela.Veiculo.Placa}] editado com sucesso");
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
                }
                else
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Veiculo: [{VeiculoSelecionada.Placa}] não pode ser removido, pois está vinculado a uma locação");
            }
        }

        public void FiltrarRegistros()
        {
        }

        public void InserirNovoRegistro()
        {
            TelaVeiculoForm tela = new TelaVeiculoForm();
            tela.ShowDialog();
            if (tela.ValidarCampos() == "VALIDO" && tela.DialogResult == DialogResult.OK)
            {
                veiculoAppService.InserirNovo(tela.Veiculo);

                tabelaVeiculoControl.AtualizarRegistros();

                TelaPrincipalForm.Instancia.AtualizarRodape($"Veiculo: [{tela.Veiculo.Placa}] inserido com sucesso");
            }
        }

        public UserControl ObterTabela()
        {
            tabelaVeiculoControl.AtualizarRegistros();

            return tabelaVeiculoControl;
        }
    }
}
