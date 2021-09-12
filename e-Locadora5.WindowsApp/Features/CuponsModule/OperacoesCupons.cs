using e_Locadora5.Controladores.CupomModule;
using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Locadora5.WindowsApp.Features.CuponsModule
{
    public class OperacoesCupons : ICadastravel
    {
        private ControladorCupons controlador = null;
        private TabelaCupons tabelaCupons = null;

        public OperacoesCupons(ControladorCupons controlador)
        {
            this.controlador = controlador;
            tabelaCupons = new TabelaCupons(controlador);
        }

        public void AgruparRegistros()
        {
            throw new NotImplementedException();
        }

        public void DesagruparRegistros()
        {
            throw new NotImplementedException();
        }

        public void EditarRegistro()
        {
            int id = tabelaCupons.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um cupom para poder editar!", "Edição de Cupom",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Cupons cupomSelecionado = controlador.SelecionarPorId(id);

            TelaCupomForms tela = new TelaCupomForms();

            tela.Cupons = cupomSelecionado;

            tela.ShowDialog();
            if (tela.ValidarCampos() == "CAMPOS_VALIDOS" && tela.DialogResult == DialogResult.OK)
            {
                controlador.Editar(id, tela.Cupons);

                tabelaCupons.AtualizarRegistros();

                TelaPrincipalForm.Instancia.AtualizarRodape($"Cupom: [{tela.Cupons.Nome}] editado com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaCupons.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um cupom para poder excluir!", "Exclusão de Cupom",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Cupons cupons = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Cupom: [{cupons.Nome}] ?",
                "Exclusão de Cupom", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (controlador.Excluir(id))
                {
                    tabelaCupons.AtualizarRegistros();

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Cupom: [{cupons.Nome}] removido com sucesso");
                }
                else
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Cupom: [{cupons.Nome}] não pode ser removido, pois está vinculado a uma locação");
            }
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public void InserirNovoRegistro()
        {
            TelaCupomForms tela = new TelaCupomForms();

            tela.ShowDialog();
            if (tela.ValidarCampos() == "CAMPOS_VALIDOS" && tela.DialogResult == DialogResult.OK)
            {
                controlador.InserirNovo(tela.Cupons);

                tabelaCupons.AtualizarRegistros();

                TelaPrincipalForm.Instancia.AtualizarRodape($"Cupom: [{tela.Cupons.Nome}] inserido com sucesso");
            }
        }
        public UserControl ObterTabela()
        {
            tabelaCupons.AtualizarRegistros();

            return tabelaCupons;
        }

        public void MostrarClassificacao()
        {
            TelaQuantidadeCupomForms tela = new TelaQuantidadeCupomForms();

            tela.ShowDialog();
        }
    }
}
