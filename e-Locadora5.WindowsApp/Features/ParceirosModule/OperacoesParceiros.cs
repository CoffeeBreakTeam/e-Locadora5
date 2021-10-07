using e_Locadora5.Aplicacao.ParceiroModule;
using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Infra.GeradorLogs;
using e_Locadora5.WindowsApp.Shared;
using Serilog;
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
        private ParceiroAppService parceiroAppService = null;
        private TabelaParceiroControl tabela = null;

        public OperacoesParceiros(ParceiroAppService parceiroAppService)
        {
            this.parceiroAppService = parceiroAppService;
            tabela = new TabelaParceiroControl(parceiroAppService);
        }

        public void InserirNovoRegistro()
        {
            TelaParceiroForm tela = new TelaParceiroForm();
            tela.ShowDialog();
            if (tela.DialogResult == DialogResult.OK && parceiroAppService.ValidarParceiros(tela.Parceiro) == "ESTA_VALIDO")
            {
                parceiroAppService.InserirNovo(tela.Parceiro);

                tabela.AtualizarRegistros();

                TelaPrincipalForm.Instancia.AtualizarRodape($"Parceiro: [{tela.Parceiro.Nome}] inserido com sucesso");
                
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
            Parceiro parceiroSelecionado = parceiroAppService.SelecionarPorId(id);

            TelaParceiroForm tela = new TelaParceiroForm();
            tela.Parceiro = parceiroSelecionado;
            tela.ShowDialog();
            if (tela.DialogResult == DialogResult.OK && parceiroAppService.ValidarParceiros(tela.Parceiro, id) == "ESTA_VALIDO")
            {
                parceiroAppService.Editar(id, tela.Parceiro);

                tabela.AtualizarRegistros();

                TelaPrincipalForm.Instancia.AtualizarRodape($"Parceiro: [{tela.Parceiro.Nome}] editado com sucesso");
                
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

            Parceiro parceiroSelecionado = parceiroAppService.SelecionarPorId(id);


            if (MessageBox.Show($"Tem certeza que deseja excluir o Parceiro: [{parceiroSelecionado.Nome}] ?",
                "Exclusão de Cliente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (parceiroAppService.Excluir(id))
                {
                    tabela.AtualizarRegistros();
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Parceiro: [{parceiroSelecionado.Nome}] removido com sucesso");
                    
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Parceiro: Não foi possível excluir [{parceiroSelecionado.Nome}], pois ele está vinculado a um Cupon de Desconto");
                }
            }
        } 

        public UserControl ObterTabela()
        {
            List<Parceiro> parceiros = parceiroAppService.SelecionarTodos();

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
