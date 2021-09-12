using e_Locadora5.Controladores.ParceiroModule;
using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Locadora5.WindowsApp.Features.ParceirosModule
{
    public class OperacoesParceiros : ICadastravel
    {
        private ControladorParceiro controladorParceiro = null;
        private TabelaParceiroControl tabela = null;

        public OperacoesParceiros(ControladorParceiro controladorParceiro)
        {
            this.controladorParceiro = controladorParceiro;
            tabela = new TabelaParceiroControl(controladorParceiro);
        }

        public void InserirNovoRegistro()
        {
            TelaParceiroForm tela = new TelaParceiroForm();
            tela.ShowDialog();
            if (tela.DialogResult == DialogResult.OK && controladorParceiro.ValidarParceiros(tela.Parceiro) == "ESTA_VALIDO")
            {
                controladorParceiro.InserirNovo(tela.Parceiro);

                tabela.AtualizarRegistros();

                TelaPrincipalForm.Instancia.AtualizarRodape($"Parceiro: [{tela.Parceiro.nome}] inserido com sucesso");
            }
        }
        public void EditarRegistro()
        {
            int id = tabela.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Parceiro para poder editar!", "Edição de Parceiros",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Parceiro parceiroSelecionado = controladorParceiro.SelecionarPorId(id);

            TelaParceiroForm tela = new TelaParceiroForm();
            tela.Parceiro = parceiroSelecionado;
            tela.ShowDialog();
            if (tela.DialogResult == DialogResult.OK && controladorParceiro.ValidarParceiros(tela.Parceiro, id) == "ESTA_VALIDO")
            {
                controladorParceiro.Editar(id, tela.Parceiro);

                tabela.AtualizarRegistros();

                TelaPrincipalForm.Instancia.AtualizarRodape($"Parceiro: [{tela.Parceiro.nome}] editado com sucesso");
            }

        }

        public void ExcluirRegistro()
        {
            int id = tabela.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Parceiro para poder excluir!", "Exclusão de Parceiros",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Parceiro parceiroSelecionado = controladorParceiro.SelecionarPorId(id);


            if (MessageBox.Show($"Tem certeza que deseja excluir o Parceiro: [{parceiroSelecionado.nome}] ?",
                "Exclusão de Cliente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (controladorParceiro.Excluir(id))
                {
                    tabela.AtualizarRegistros();
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Parceiro: [{parceiroSelecionado.nome}] removido com sucesso");
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Parceiro: Não foi possível excluir [{parceiroSelecionado.nome}], pois ele está vinculado a um Cupon de Desconto");
                }
            }
        } 

        public UserControl ObterTabela()
        {
            List<Parceiro> parceiros = controladorParceiro.SelecionarTodos();

            tabela.CarregarTbela(parceiros);

            return tabela;
        }

        public void AgruparRegistros()
        {
            throw new NotImplementedException();
        }

        public void DesagruparRegistros()
        {
            throw new NotImplementedException();
        }
        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
