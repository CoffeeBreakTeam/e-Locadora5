using e_Locadora5.Aplicacao.GrupoVeiculoModule;
using e_Locadora5.Dominio;
using e_Locadora5.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Locadora5.WindowsApp.GrupoVeiculoModule
{
    public class OperacoesGrupoVeiculo : ICadastravel
    {
        private GrupoVeiculoAppService grupoVeiculoAppService = null;
        private TabelaGrupoVeiculoControl tabelaGrupoVeiculos = null;



        public OperacoesGrupoVeiculo(GrupoVeiculoAppService grupoVeiculoAppService)
        {
            this.grupoVeiculoAppService = grupoVeiculoAppService;
            tabelaGrupoVeiculos = new TabelaGrupoVeiculoControl();
        }

        public void InserirNovoRegistro()
        {
            TelaGrupoVeiculoForm tela = new TelaGrupoVeiculoForm();

            tela.ShowDialog();
            if (tela.ValidarCampos() == "CAMPOS_VALIDOS" && tela.DialogResult == DialogResult.OK)
            {
                grupoVeiculoAppService.InserirNovo(tela.GrupoVeiculo);

                tabelaGrupoVeiculos.AtualizarRegistros();

                TelaPrincipalForm.Instancia.AtualizarRodape($"GrupoVeiculo: [{tela.GrupoVeiculo.categoria}] inserido com sucesso");
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaGrupoVeiculos.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um grupoVeiculo para poder editar!", "Edição de GrupoVeiculos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GrupoVeiculo grupoVeiculoSelecionada = grupoVeiculoAppService.SelecionarPorId(id);

            TelaGrupoVeiculoForm tela = new TelaGrupoVeiculoForm();

            tela.GrupoVeiculo = grupoVeiculoSelecionada;

            tela.ShowDialog();
            if (tela.ValidarCampos() == "CAMPOS_VALIDOS" && tela.DialogResult == DialogResult.OK)
            {
                grupoVeiculoAppService.Editar(id, tela.GrupoVeiculo);

                tabelaGrupoVeiculos.AtualizarRegistros();

                TelaPrincipalForm.Instancia.AtualizarRodape($"GrupoVeiculo: [{tela.GrupoVeiculo.categoria}] editado com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaGrupoVeiculos.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um grupoVeiculo para poder excluir!", "Exclusão de GrupoVeiculos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GrupoVeiculo grupoVeiculoSelecionada = grupoVeiculoAppService.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o grupoVeiculo: [{grupoVeiculoSelecionada.categoria}] ?",
                "Exclusão de GrupoVeiculos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if(grupoVeiculoAppService.Excluir(id))
                {
                    tabelaGrupoVeiculos.AtualizarRegistros();

                    TelaPrincipalForm.Instancia.AtualizarRodape($"GrupoVeiculo: [{grupoVeiculoSelecionada.categoria}] removido com sucesso");
                }else
                    TelaPrincipalForm.Instancia.AtualizarRodape($"GrupoVeiculo: Não foi possível excluir [{grupoVeiculoSelecionada.categoria}], pois ele está vinculado a um veículo");

            }
        }

        public UserControl ObterTabela()
        {
            tabelaGrupoVeiculos.AtualizarRegistros();

            return tabelaGrupoVeiculos;
        }

        public void FiltrarRegistros()
        {
        }

        public void AgruparRegistros()
        {
        }

        public void DesagruparRegistros()
        {
        }


    }
}
